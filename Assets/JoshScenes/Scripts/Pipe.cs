using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public bool HasPlaced = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (HasPlaced && collision.gameObject.name == "GridSpace")
        {
            this.gameObject.transform.position = collision.gameObject.transform.position;
        }
        if(collision.gameObject.CompareTag("StartPipe"))
        {
            this.gameObject.tag = "StartPipe";
        }
        else if(collision.gameObject.CompareTag("EndPipe"))
        {
            this.gameObject.tag = "EndPipe";
        }
        else
        {
            this.gameObject.tag = "Pipe";
        }
    }
}
