using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    private Vector2 TouchPosition;
    private Vector3 WorldPosition;
    private bool IsDragActive = false;
    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            TouchPosition = Input.GetTouch(0).position;

            WorldPosition = Camera.main.ScreenToWorldPoint(TouchPosition);

            RaycastHit2D hit = Physics2D.Raycast(WorldPosition, Vector2.zero);

            if(hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}
