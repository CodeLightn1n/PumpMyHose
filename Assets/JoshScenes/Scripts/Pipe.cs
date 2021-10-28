using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public bool HasPlaced = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (HasPlaced && collision.gameObject.name =="GridSpace(Clone)")
        {
            this.gameObject.transform.position = collision.gameObject.transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
