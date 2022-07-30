using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : Character
{
   public float damageStrength;
   public GameObject Pprafb;  
   public GameObject ammoprafb;
   public GameObject lifeprafb;  
   Rigidbody2D rb2d;
   Rigidbody2D ammorb;
   public float protect;
   public  float hitPoints;
    Coroutine damageCoroutine;
    Vector2 direction=new Vector2(0,-1);
    Vector2 direction2=new Vector2(0,1);
    Vector2 direction3=new Vector2(-1,0);
    Vector2 direction4=new Vector2(1,0);
    float shotTime=0.3f;                    //射击间隔
    float invokeTime;                       //
    public float  ifdrop;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        ammorb=ammoprafb.GetComponent<Rigidbody2D>();
        invokeTime = shotTime;
    }

    void Update()
    {
        Shoot();
        invokeTime = shotTime;
    }

     public override IEnumerator DamageCharacter(float damage, float interval)
    {
        while (true)
        {
            StartCoroutine(FlickerCharacter());
            protect=Random.Range(0,5);
            damage-=protect;
            //  print("伤害："+damage);
            hitPoints = hitPoints - damage;
            
            
            if (hitPoints <= float.Epsilon)
            {
                ifdrop=Random.Range(1,5);
                print("随机数为："+ifdrop);
                KillCharacter();
                 if(ifdrop==1){
                GameObject P=Instantiate(Pprafb,rb2d.position,Quaternion.identity);}
                else if(ifdrop==2){
                  GameObject life=Instantiate(lifeprafb,rb2d.position,Quaternion.identity);}  
                
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            
            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(player.DamageCharacter(damageStrength, 1.0f));
                player.firePoint.value-=1;
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }

    private void Shoot(){
         invokeTime+=Time.deltaTime;
         if(invokeTime-shotTime>0){
        GameObject ammo2=Instantiate(ammoprafb,transform.position,Quaternion.identity);
        invokeTime=0;
        ammo2cs ac2=ammo2.GetComponent<ammo2cs>();
        if(ac2==null)
        {
           ac2.Shoot(direction);
           print("fashe");
        //    ac2.Shoot(direction2);
        //    ac2.Shoot(direction3);
        //    ac2.Shoot(direction4);
        }
        
        
     
        
        }
    } 
}
