using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo2cs : MonoBehaviour
{
     Rigidbody2D rb2d;
     public float damage=10;
     private float speed=8.0f;
     Vector2 direction=new Vector2(0,-1);
    Vector2 direction2=new Vector2(0,1);
    Vector2 direction3=new Vector2(-1,0);
    Vector2 direction4=new Vector2(1,0);
    void Awake()
    {
        
       rb2d=GetComponent<Rigidbody2D>();
         
    }

    void Update()
    {
        // transform.Translate (* speed * Time.deltaTime);
        Shoot(direction);
    }
    
    public void Shoot(Vector2 lookdirection)
    {
        rb2d.velocity=lookdirection*speed;
    }

    void Start(){
        Destroy(gameObject,1.0f);
    }

    

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    
    //     if (collision is BoxCollider2D)
    //     {
    //         Player player = collision.gameObject.GetComponent<Player>();
          
    //         StartCoroutine(player.DamageCharacter(damage, 0.0f));
    //         gameObject.SetActive(false);
    //     }
    // }

    
   
}
