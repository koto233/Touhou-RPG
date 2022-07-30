using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    //---------------------定义变量-------------------//
    public float speed=3.0f;                //速度
    Vector2 position=new Vector2();         //位置
    Vector2 lookdirection=new Vector2(0,-1);//方向 
    Rigidbody2D rb2d;                       //刚体组件
    Animator ani;                           //动画组件
    public GameObject ammoprafb;            //子弹预制体
    float shotTime=0.3f;                    //射击间隔
    float invokeTime;                       //
    public float currentfirePoint=2;        //当前灵力值
    public firePoints firePoint;            //灵力值
    public float currentMaxPoints=20;      //血量上限
    public HealthBar hbprafb;               //血量UI预制体
    HealthBar hb;                           //血量UI
    public HitPoints hitPoints;             //血量
    public GameObject Bag;                  //背包
    public bool isOpen;                     //背包状态
    //---------------------定义变量-------------------//
    
    //---------------------初始设定-------------------//
    void Start()
    {
        invokeTime=shotTime;
        rb2d=GetComponent<Rigidbody2D>();   
        ani=GetComponent<Animator>();       
        hitPoints.value=currentMaxPoints;   //设定初始血量
        hb=Instantiate(hbprafb);            
        firePoint.value=currentfirePoint;   //设定初始灵力值
           
    }
    //---------------------初始设定-------------------//
    
    
    
    void FixedUpdate()
    {
        Move();
                                       
    }

    void Update()
    {
        Shoot();      
        openBP();
    }

   public void Move()
   {                                              //移动
    position.x=Input.GetAxisRaw("Horizontal");  
    position.y=Input.GetAxisRaw("Vertical");
    position.Normalize();
    Vector2 MoveDirection=new Vector2(position.x,position.y);
    if (MoveDirection.x!=0||MoveDirection.y!=0)
    {
        lookdirection=MoveDirection;
    }
    ani.SetFloat("lookx",lookdirection.x);
    ani.SetFloat("looky",lookdirection.y);
    ani.SetFloat("speed",MoveDirection.magnitude);

    rb2d.velocity=position*speed; 
   }

   public void Shoot()        //射击
   {             
       if(Input.GetKey(KeyCode.Z))
       {
           invokeTime+=Time.deltaTime;
           if(invokeTime-shotTime>0){
            GameObject ammo=Instantiate(ammoprafb,transform.position,Quaternion.identity);
            invokeTime=0;
            Ammocs ac=ammo.GetComponent<Ammocs>();
            if(ac!=null){
                ac.Shoot(lookdirection);   
                ac.damage=firepoint(ac.damage);
               
            }
                     
           }
            
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            invokeTime = shotTime;
        }
   }


   public override IEnumerator DamageCharacter(float damage, float interval)   //伤害协程 
    {
        while (true)
        {
            StartCoroutine(FlickerCharacter());                                //角色闪烁

            hitPoints.value = hitPoints.value- damage;

            if (hitPoints.value <= float.Epsilon)
            {
                KillCharacter();
                break;
            }

            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }
    public override void KillCharacter()  
    {
        base.KillCharacter();

    }

    void OnTriggerEnter2D(Collider2D collision)                             //拾取道具
    {
        if (collision.gameObject.CompareTag("pickup"))
        {
            
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;
            switch (hitObject.itemType)
                {
                    case Item.ItemType.Ppoint:
                        firePoint.value+=1;
                        break;
                    case Item.ItemType.HEALTH:
                        addHitPoint();
                        break;
                    case Item.ItemType.MONEY:
                        break;    
                    default:
                        break;
                }
                
               
            collision.gameObject.SetActive(false);
        }
    }

     public float firepoint(float damage){                //灵力值系统
    
    if(firePoint.value<=4){
        
    damage+=(firePoint.value/4)*damage; 
    }
    else if(firePoint.value<float.Epsilon)
    {
        firePoint.value=0;
    }
    
    else  
    {
        firePoint.value=5;
        damage=damage*2;
    }
    
    return damage;
    }
    
    public void addHitPoint()                 //加血
    {
        hitPoints.value+=100;
        if(hitPoints.value>currentMaxPoints)
        {
            hitPoints.value=currentMaxPoints;
        }
    }

    public void openBP(){                    //打开背包
        if(Input.GetKeyDown(KeyCode.E)){
           isOpen=!isOpen;
           Bag.SetActive(isOpen); 
           
        }
    }     

}
