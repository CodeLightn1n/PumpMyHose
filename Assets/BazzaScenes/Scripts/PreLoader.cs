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
public class PreLoader : MonoBehaviour
{
    private CanvasGroup fadegroup;
    private float loadtime;
    private float minimumLogoTime = 3.0f; // Minimum time of that scene

    private void Start() 
    {
        //Grab the only CanvusGroup in the scene
        fadegroup = FindObjectOfType<CanvasGroup>();
        //Start with a gray screen
        fadegroup.alpha = 1;

        if(Time.time < minimumLogoTime)
        {
            loadtime = minimumLogoTime;
        }
        else
        {
            loadtime = Time.time;    
        }
    }
    private void Update() 
    {
        if(Time.time < minimumLogoTime)
        {
            fadegroup.alpha = 1 - Time.time;
        }

        if(Time.time > minimumLogoTime && loadtime !=0)
        {
            fadegroup.alpha = Time.time - minimumLogoTime;
            if(fadegroup.alpha >= 1)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
