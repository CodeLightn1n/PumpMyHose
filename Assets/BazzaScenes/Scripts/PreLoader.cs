using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Youtube Tutorial Link https://youtu.be/LyoHCAgbDcw
//Original Script Ownder : N3K EN , https://www.youtube.com/channel/UCtQPCnbIB7SP_gM1Xtv8bDQ

public class PreLoader : MonoBehaviour
{
    private CanvasGroup fadegroup;
    private float loadtime;
    private float minimumLogoTime = 3.0f; // Minimum time of that scene

    private void Start() 
    {
        fadegroup = FindObjectOfType<CanvasGroup>();

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
               SceneManager.LoadScene("Menu");
            }
        }
    }


}
