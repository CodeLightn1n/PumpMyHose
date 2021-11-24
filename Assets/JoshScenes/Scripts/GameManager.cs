using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PSIElements;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI PSIDisplay;


    GridManager grid;
    int CurrentScene;
    int CurrentPSI;
    int LevelPSI;

    private void Start()
    {
        grid = FindObjectOfType<GridManager>();
        CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SetGrid();
        SetPSI();
    }

    private void SetGrid()
    {
        //Setting grid sizes based on the level
        if(CurrentScene == 2)
        {
            //gridsize components in order : Length, Height, Spacing, StartPipeGridSpaceNumber, EndPipeGridSpaceNumber
            grid.SetGridSize(5, 5, 1, 2, 20);
        }
        Debug.Log("GameManager's Position : " + transform.position);
    }

    /// <summary>
    /// Begins the flow for the pipes connection
    /// </summary>
    public void StartFlow()
    {
        List<PipeFlow> pipes = new List<PipeFlow>();
        foreach(PipeFlow pipe in GameObject.FindObjectsOfType<PipeFlow>())
        {
            pipes.Add(pipe);
            if(pipe.gameObject.CompareTag("StartPipe"))
            {
                pipe.EngageFlow();
            }
            if(pipe.gameObject.CompareTag("EndPipe"))
            {
                //this.gameObject.GetComponent<GameSceneTest>().CompletedLevel();
                Debug.Log("You have finished the level");
            }
        }
    }
    /// <summary>
    /// Displays the current PSI to the connected Text Box
    /// </summary>
    public void SetPSI()
    {
        switch(CurrentScene)
        {
            case  2:
                LevelPSI = 100;
                PSIManager.SetOverallPSI(100);
                break;
            default:
                LevelPSI = 0;
                break;
        }
        UpdatePSI();
    }
    /// <summary>
    /// Updates the textbox holding the PSI values
    /// </summary>
    public void UpdatePSI()
    {
        CurrentPSI = PSIManager.GetOverallPSI();
        PSIDisplay.text = "Water : " + LevelPSI + "|" + CurrentPSI;
    }
}