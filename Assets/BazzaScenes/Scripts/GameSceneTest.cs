using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneTest : MonoBehaviour
{
    public void CompletedLevel()
    {
        SaveManager.Instance.CompletedLevel(Manager.Instance.currentlLevel);
        Manager.Instance.menuFocus = 1;
        ExitScene();
    }

    public void ExitScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
