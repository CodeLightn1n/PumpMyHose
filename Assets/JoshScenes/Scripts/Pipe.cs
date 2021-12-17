using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public bool HasPlaced = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //placing the pipe to the grid placement
        if(HasPlaced && collision.gameObject.name == "GridSpace")
        {
            this.gameObject.transform.position = collision.gameObject.transform.position;
            //check for parent object
            this.gameObject.transform.parent = null;
            this.gameObject.transform.parent = collision.gameObject.transform;
            
            //assigning tag
            if (collision.gameObject.CompareTag("StartPipe"))
            {
                this.gameObject.tag = "StartPipe";
            }
            else if (collision.gameObject.CompareTag("EndPipe"))
            {
                this.gameObject.tag = "EndPipe";
            }
            else if(collision.gameObject.CompareTag("Pipe"))
            {
                this.gameObject.tag = "Pipe";
            }
        }
        else if(HasPlaced)
        {
            Destroy(this.gameObject);
        }
        

        
    }
}
