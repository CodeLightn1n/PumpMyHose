using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PSIElements;
using UnityEngine.Analytics;
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
        if(CurrentScene == 2)
        {
            grid.SetGridSize(5, 5, 1, 2, 20);
        }
        if(CurrentScene == 3)
        {
            grid.SetGridSize(5, 5, 1, 4, 24);
        }
        if(CurrentScene == 4)
        {
            grid.SetGridSize(5,5,1,9,10);
        }
        if(CurrentScene == 5)
        {
            grid.SetGridSize(5, 5 ,1, 4, 20);
        }
        if(CurrentScene == 6)
        {
            grid.SetGridSize(5, 5, 1, 2, 15);
        }
        Debug.Log("GameManager's Position : " + transform.position);
    }

    /// <summary>
    /// Begins the flow for the pipes connection
    /// </summary>
    public void StartFlow()
    {
        string levelName = SceneManager.GetActiveScene().name;
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
                AnalyticsResult analyticsResult = Analytics.CustomEvent("Level Complete", new Dictionary<string,object>
                {
                    {"Level", levelName},
                    {"Time Spent", Time.timeSinceLevelLoad}
                });
                SceneManager.LoadScene("01_MainMenu_01");
                Debug.Log("analyticsResult " + analyticsResult);
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