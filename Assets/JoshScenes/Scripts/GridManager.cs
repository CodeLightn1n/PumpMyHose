using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    int StartPipe = 0;
    int EndPipe = 0;
    int Length = 0;
    int Height = 0;
    float SpaceX = 0.0f;
    float SpaceY = 0.0f;
    float StartX = 0.0f;
    float StartY = 0.0f;

    public GameObject GridSpace;
    public void SetGridSize(int length, int height, float spacing, int startPipe, int endPipe)
    {
        StartPipe = startPipe;
        EndPipe = endPipe;
        Length = length;
        Height = height;
        SpaceX = spacing;
        SpaceY = spacing;
        StartX = this.gameObject.transform.position.x;
        StartY = this.gameObject.transform.position.y;
        InstantiateGrid();
    }
    //creates grid using gameobjects
    public void InstantiateGrid()
    {
        for(int i = 0; i < Length * Height; i++)
        {
            GameObject space = Instantiate(GridSpace, new Vector3( StartX + ( SpaceX * (i % Length)), StartY + ( SpaceY * (i / Height))), Quaternion.identity);
            space.gameObject.name = "GridSpace";
            if(StartPipe == i)
            {
                space.gameObject.tag = "StartPipe";
            }
            else if(EndPipe == i)
            {
                space.gameObject.tag = "EndPipe";
            }
            else
            {
                space.gameObject.tag = "Pipe";
            }
            space.transform.parent = this.gameObject.transform;
        }
    }
}
