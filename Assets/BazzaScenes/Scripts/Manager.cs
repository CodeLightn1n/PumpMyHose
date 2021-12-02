using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    THIS IS A APA7TH SCRIPT/CODE from https://uark.libguides.com/CSCE/CitingCode
Title: Helper
Aurther: N3K EN
Date: <2017>
Availability https://youtube.com/playlist?list=PLLH3mUGkfFCU5D0nT9dsN2-RYh1XjnHgH
*/
public class Manager : MonoBehaviour
{
    public static Manager Instance { set; get; }

    private void Awake()
    {

        DontDestroyOnLoad(gameObject);
        Instance = this;
        Application.targetFrameRate = 60;
    }
    public int currentlLevel = 0; //Used when changing from menu to game scene
    public int menuFocus = 0;     //Used when entering the game menu scene, to know which menu to focus
}
