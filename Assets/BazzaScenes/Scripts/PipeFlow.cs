using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PSIElements;

//Orignal Script Owner : Karl Pytte 

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]

public class PipeFlow : Pipe
{
    //Each grid is 0.75, so onced half it 0.375
    public bool up, down, left, right;

    private bool[] startingState = new bool[4];

    private Vector3 Offset;

    public float distance;

    private GameManager GM;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
    private void Start()
    {
        startingState[0] = up;
        startingState[1] = down;
        startingState[2] = left;
        startingState[3] = right;

        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    /// <summary>
    /// Checks in the given direction to determine if there is a valid pipe connected
    /// </summary>
    public bool ValidCheck(Vector2 originDirection)
    {

        up = startingState[0];
        down = startingState[1];
        left = startingState[2];
        right = startingState[3];

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
            Offset = new Vector3(0f, 0.5f, 0f);
            StartFlowOnConnectedPipe(Vector2.up);
        }
        if (down)
        {
            Offset = new Vector3(0f, -0.5f, 0f);
            StartFlowOnConnectedPipe(Vector2.down);
        }
        if (left)
        {
            Offset = new Vector3(-0.5f, 0f, 0f);
            StartFlowOnConnectedPipe(Vector2.left);
        }
        if (right)
        {
            Offset = new Vector3(0.5f, 0f, 0f);
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
        

        hit = Physics2D.Raycast(transform.position + Offset, direction, distance);

        //does the object we hit have a collider
        if (hit.collider != null)
        {
            Debug.Log("Object Name : " + hit.collider.name + "\nObject Tag : " + hit.collider.tag);
            if (hit.collider.tag == "Pipe")
            {
                PipeFlow connectedPipe = hit.collider.GetComponent<PipeFlow>();

                // Debug.Log(hit.collider.tag);
                //is the direction associated with an opening in the pipe that we hit
                if (connectedPipe.ValidCheck(direction))
                {
                    PSIElements.PSIManager.AddOverallPSi(-5);
                    connectedPipe.EngageFlow();
                    debugColor = Color.green;
                }
            }
            if(hit.collider.tag == "EndPipe")
            {
                Debug.Log("The end has been reached");
                GM.UpdatePSI();
            }
        }
        else
        {

            //There is no pipe there
        }

        Debug.DrawRay(transform.position + Offset, direction * distance, debugColor, 5);
    }
}