using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    private Vector2 TouchPosition;
    private Vector3 WorldPosition;
    private bool IsDragActive = false;
    private Pipe LastSummoned;
    private void Update()
    {
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended && IsDragActive)
        {
            Drop();
            return;
        }
        if (Input.touchCount > 0 )
        {
            TouchPosition = Input.GetTouch(0).position;

            WorldPosition = Camera.main.ScreenToWorldPoint(TouchPosition);
        }
        if (IsDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(WorldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                Pipe pipe = hit.transform.gameObject.GetComponent<Pipe>();
                if (pipe != null && pipe.HasPlaced == false)
                {
                    LastSummoned = pipe;
                    InitDrag();
                }
            }
        }
    }

    void InitDrag()
    {
        IsDragActive = true;
    }
    void Drag()
    {
        LastSummoned.transform.position = new Vector2(WorldPosition.x, WorldPosition.y);
    }
    void Drop()
    {
        IsDragActive = false;
        LastSummoned.HasPlaced = true;
    }
}
