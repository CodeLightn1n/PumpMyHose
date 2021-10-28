using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    
    int Length = 0;
    int Height = 0;
    float SpaceX = 0.0f;
    float SpaceY = 0.0f;
    float StartX = 0.0f;
    float StartY = 0.0f;

    public GameObject GridSpace;
    private void Start()
    {
        
        
    }
    public void SetGridSize(int length, int height, float spacing)
    {
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
            space.transform.parent = this.gameObject.transform;
        }
    }
}
