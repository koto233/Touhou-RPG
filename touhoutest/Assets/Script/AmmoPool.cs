using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPool : MonoBehaviour
{
    
   public GameObject ammoprafb;
   static List<GameObject> ammoPool;
   public int poolSize;
   void Awake() {
   if (ammoPool==null)
   {
      ammoPool=new List<GameObject>();
   }    

   for(int i=0;i<poolSize;i++)
   {
       GameObject ammo=Instantiate(ammoprafb);
       ammo.SetActive(false);
       ammoPool.Add(ammo);
   }
   }
     public GameObject SpawnAmmo(Vector3 location)
    {
        foreach (GameObject ammo  in ammoPool)
        {
            if(ammo.activeSelf==false)
            {
                ammo.SetActive(true);
                ammo.transform.position=location;
                return ammo;
            }
        }
        return null;
    }
    
}
