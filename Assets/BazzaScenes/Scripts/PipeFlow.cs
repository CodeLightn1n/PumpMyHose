using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]

public class PipeFlow : Pipe
{
    //Each grid is 0.75, so onced half it 0.375
    public bool up, down, left, right;

    public float distance;
    //public void FindAndStartFlow()
    //{
    //    if(HasPlaced)
    //    {

    //    }
    //}

    private void Awake()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    /// <summary>
    /// Checks in the given direction to determine if there is a valid pipe connected
    /// </summary>
    public bool ValidCheck(Vector2 originDirection)
    {
        Debug.Log(originDirection);

        if (up && originDirection.y == -1f)
        {
            up = false;
            return true;
        }
        else if (down && originDirection.y == 1f)
        {
            down = false;
            return true;
        }
        else if (left && originDirection.x == 1f)
        {
            left = false;
            return true;
        }
        else if (right && originDirection.x == -1f)
        {
            right = false;
            return true;
        }
        return false;
    }


    /// <summary>
    /// This is called on another script to start the flow on this pipe
    /// </summary>
    public void EngageFlow()
    {
        if (up)
        {
            StartFlowOnConnectedPipe(Vector2.up);
        }
        if (down)
        {
            StartFlowOnConnectedPipe(Vector2.down);
        }
        if (left)
        {
            StartFlowOnConnectedPipe(Vector2.left);
        }
        if (right)
        {
            StartFlowOnConnectedPipe(Vector2.right);
        }
    }

    /// <summary>
    /// Fires a raycast in any of the allowed directions and if it hits a pipe, begins the process again from EngageFlow
    /// </summary>
    /// <param name="direction"></param>
    private void StartFlowOnConnectedPipe(Vector2 direction)
    {
        RaycastHit2D hit = new RaycastHit2D();

        //DebugStuff
        Color debugColor = Color.red;

        hit = Physics2D.Raycast(transform.position, direction, distance);

        //does the object we hit have a collider
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Pipe")
            {
                PipeFlow connectedPipe = hit.collider.GetComponent<PipeFlow>();

                // Debug.Log(hit.collider.tag);
                //is the direction associated with an opening in the pipe that we hit
                if (connectedPipe.ValidCheck(direction))
                {
                    connectedPipe.EngageFlow();
                    debugColor = Color.green;
                }
            }

            //also put the check for the exit node here
        }
        else
        {

            //There is no pipe there
        }

        Debug.DrawRay(transform.position, direction * distance, debugColor, 5);
    }
}