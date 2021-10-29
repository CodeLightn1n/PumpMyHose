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
    }
}
