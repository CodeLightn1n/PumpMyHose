using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    THIS IS A APA7TH SCRIPT/CODE from https://uark.libguides.com/CSCE/CitingCode
Title: Helper
Aurther: N3K EN
Date: <2017>
Availability https://youtube.com/playlist?list=PLLH3mUGkfFCU5D0nT9dsN2-RYh1XjnHgH
*/

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
        SceneManager.LoadScene(1);
    }
}
