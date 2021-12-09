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

    Vector2 Offset;

    GameObject EndPipeObj;
    GameObject StartPipeObj;

    public GameObject GridSpace;
    public GameObject InOutPipe;
    /// <summary>
    /// sets the size and spacing of the grid and where the starting and ending pipes are going to be located at
    /// </summary>
    /// <param name="length">the length of the grid</param>
    /// <param name="height">the height of the grid</param>
    /// <param name="spacing">the spacing between each grid space</param>
    /// <param name="startPipe">where the starting pipe is going to be (needs to be within the number between hieght x length)</param>
    /// <param name="endPipe">where the ending pipe is going to be (needs to be within the number between hieght x length)</param>
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
    /// <summary>
    /// Creates a grid with grid space objects
    /// </summary>
    public void InstantiateGrid()
    {
        for(int i = 0; i < Length * Height; i++)
        {
            GameObject space = Instantiate(GridSpace, new Vector3( StartX + ( SpaceX * (i % Length)), StartY + ( SpaceY * (i / Height))), Quaternion.identity);
            space.gameObject.name = "GridSpace";
            space.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            SpriteRenderer spriteColour = space.gameObject.GetComponent<SpriteRenderer>();
            if(StartPipe == i)
            {
                space.gameObject.tag = "StartPipe";
                spriteColour.color = Color.green;
                StartPipeObj = space.gameObject;
            }
            else if(EndPipe == i)
            {
                space.gameObject.tag = "EndPipe";
                spriteColour.color = Color.red;
                EndPipeObj = space.gameObject;
            }
            else
            {
                space.gameObject.tag = "Pipe";
            }
            space.transform.parent = this.gameObject.transform;
        }
        
        List<Vector2> emptySpaces = DetectInOutPipe(StartPipeObj.transform.position);
        SummonInOutPipe(StartPipeObj, emptySpaces);
        emptySpaces = DetectInOutPipe(EndPipeObj.transform.position);
        SummonInOutPipe(EndPipeObj, emptySpaces);
        
    }
/// <summary>
/// Shoot 4 raycasts on the a specified object on 4 different sides
/// </summary>
/// <param name="startingPos"> the starting position of the object that is shooting raycasts</param>
    private List<Vector2> DetectInOutPipe(Vector2 startingPos)
    {
        RaycastHit2D hit = new RaycastHit2D();
        Vector2 direction;

        List<Vector2> emptyDirections = new List<Vector2>();
        for (int i = 0; i <4; i++)
        {
            switch(i)
            {
                case 0:
                    Offset = new Vector2(0,0.5f);
                    direction = Vector2.up;
                    hit = Physics2D.Raycast(startingPos + Offset, direction, 0.5f);
                    break;
                case 1:
                    Offset = new Vector2(-0.5f, 0);
                    direction = Vector2.left;
                    hit = Physics2D.Raycast(startingPos + Offset, direction, 0.5f);
                    break;
                case 2:
                    Offset = new Vector2(0, -0.5f);
                    direction = Vector2.down;
                    hit = Physics2D.Raycast(startingPos + Offset, direction, 0.5f);
                    break;
                case 3:
                    Offset = new Vector2(0.5f, 0);
                    direction = Vector2.right;
                    hit = Physics2D.Raycast(startingPos + Offset, direction, 0.5f);
                    break;
                default:
                    Debug.LogError("Something went wrong with either the starting or ending square direction");
                    continue;
            }
            Vector2 tempVector = EdgeDetection(hit, startingPos, direction, Offset);
            if(tempVector != Vector2.zero)
            {
                emptyDirections.Add(tempVector);
            }
        }
        return emptyDirections;
    }
    /// <summary>
    /// To detect if there is an empty space next to either the starting pipe or end pipe to know where to put the insert and exit pipe to connect the pipes correctly
    /// </summary>
    /// <param name="hit"></param>
    /// <param name="startingPos"></param>
    /// <param name="direction"></param>
    /// <param name="Offset"></param>
    private Vector2 EdgeDetection(RaycastHit2D hit, Vector2 startingPos, Vector2 direction, Vector2 Offset)
    {
        Debug.DrawRay(startingPos + Offset, direction * 0.5f, Color.blue, 5);
        print(hit.collider?.name == "GridSpace" ? "There is a grid space here" : "There is nothing here");
        if (hit.collider?.name == "GridSpace")
        {
            return Vector2.zero;
        }
        else
        {
            return direction;
        }
        
    }
    /// <summary>
    /// Spawn the In/Out pipe accordingly to which edge it is instantiated on
    /// </summary>
    /// <param name="pipe">the grid spot spawn the pipe</param>
    /// <param name="directions">a lsit of directions that can be detected use EdgeDetection() function to fill a Vector2 List</param>
    private void SummonInOutPipe(GameObject pipe, List<Vector2> directions)
    {
        int randy = Random.Range(0, directions.Count);
        /*Debug.Log("Direction chosen : " + directions[randy] + "\n"
            + "Random Integer : " + randy + "\n"
            + "Object Name : " + pipe.name);*/
        if(directions[randy]== Vector2.up)
        {
            pipe = Instantiate(InOutPipe.gameObject, pipe.transform.position + (Vector3)directions[randy]/4, Quaternion.Euler(0,0,270));
            pipe.GetComponent<PipeFlow>().down = true;
            //Debug.Log("Pipe Check 1 : " + pipe);
        }
        else if (directions[randy] == Vector2.down)
        {
            pipe = Instantiate(InOutPipe.gameObject, pipe.transform.position + (Vector3)directions[randy]/4, Quaternion.Euler(0,0,90));
            pipe.GetComponent<PipeFlow>().up = true;
            //Debug.Log("Pipe Check 2 : " + pipe);
        }
        else if (directions[randy] == Vector2.left)
        {
            pipe = Instantiate(InOutPipe.gameObject, pipe.transform.position + (Vector3)directions[randy]/4, Quaternion.identity);
            pipe.GetComponent<PipeFlow>().right = true;
            //Debug.Log("Pipe Check 3 : " + pipe);
        }
        else if (directions[randy] == Vector2.right)
        {
            pipe = Instantiate(InOutPipe.gameObject, pipe.transform.position + (Vector3)directions[randy]/4, Quaternion.Euler(0,0,180));
            pipe.GetComponent<PipeFlow>().left = true;
            //Debug.Log("Pipe Check 4 : " + pipe);
        }

        pipe.GetComponent<Pipe>().HasPlaced = true;
        //Debug.Log("Pipe Check Fin : " + pipe);
    }
}


