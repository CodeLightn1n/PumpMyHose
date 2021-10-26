using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GridManager grid;
    Scene CurrentScene, Level1, Level2, Level3;
    private void Start()
    {
        grid = GameObject.Find("GridManager").GetComponent<GridManager>();
        CurrentScene = SceneManager.GetActiveScene();
        Level1 = SceneManager.GetSceneByBuildIndex(1);
        SetGrid();
    }

    private void SetGrid()
    {
        //Setting grid sizes based on the level
        if(CurrentScene == Level1)
        {
            grid.SetGridSize(5, 5, 1);
        }
    }
}
