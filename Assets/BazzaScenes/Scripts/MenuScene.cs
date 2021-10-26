using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour
{
    private CanvasGroup fadegroup;
    private float FadeInSpeed = 0.33f;


    private void Start() 
    {
        fadegroup = FindObjectOfType<CanvasGroup>();

        fadegroup.alpha = 1;    
    }

    private void Update() 
    {
        fadegroup.alpha = 1 - Time.timeSinceLevelLoad * FadeInSpeed;
    }

    //Button Section
    public void OnPlayClick()
    {
        Debug.Log ("PlayButton");
    }

    public void OnStoreClick()
    {
        Debug.Log ("StoreButton");
    }
}
