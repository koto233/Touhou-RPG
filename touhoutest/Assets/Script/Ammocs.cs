using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammocs : MonoBehaviour
{
     Rigidbody2D rb2d;
     public float damage=10;
     private float speed=8.0f;
    void Awake()
    {
        
       rb2d=GetComponent<Rigidbody2D>();
         
    }

    void Update()
    {
        
    }
    
    public void Shoot(Vector2 lookdirection)
    {
        rb2d.velocity=lookdirection*speed;
    }

    void Start(){
        // Destroy(gameObject,1.0f);
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision is BoxCollider2D)
        {
            enemy1 enemy = collision.gameObject.GetComponent<enemy1>();
          
            StartCoroutine(enemy.DamageCharacter(damage, 0.0f));
            gameObject.SetActive(false);
        }
    }
    
  
   
}
