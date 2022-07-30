using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   
   public HitPoints hitPoints;
   public firePoints fp;
   public Text Ppoint;
   [HideInInspector]

   public Player py;
   public Image meter;
   float maxHitPoints=100;
    void Start()
    {
       
    }

    void Update()
    {
      
            
            meter.fillAmount=hitPoints.value/maxHitPoints;
            Ppoint.text="火力："+fp.value+"/5" ;
         
    }
}
