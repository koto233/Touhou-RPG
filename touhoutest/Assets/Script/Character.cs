using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
        //血量
   public float damage;  //伤害
      
   public virtual void KillCharacter(){
      Destroy(gameObject);

   } 
    public abstract IEnumerator DamageCharacter(float damage, float interval);
    public virtual IEnumerator FlickerCharacter()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
