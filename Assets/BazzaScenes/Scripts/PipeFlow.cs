using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeFlow : Pipe
{
    //Each grid is 0.75, so onced half it 0.375
   private  int number = 5;
   private void Start()
   {
       Debug.Log(number);
   }

   private void Update() 
   {
       FireRaycast();
   }

   private void FireRaycast()
   {
       if(this.gameObject.CompareTag("StartPipe"))
       {
           RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 0.375f);
            Debug.DrawLine(transform.position, transform.TransformDirection(Vector2.up), Color.green, 2f);
           if(hit.collider != null)
           {
               Debug.Log("Hit something : " + hit.collider.gameObject.name);
           }
       }
       
   }
}