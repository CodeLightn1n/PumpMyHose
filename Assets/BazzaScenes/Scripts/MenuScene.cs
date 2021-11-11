using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Youtube Tutorials Link : https://www.youtube.com/playlist?list=PLLH3mUGkfFCU5D0nT9dsN2-RYh1XjnHgH
//Original Script Ownder : N3K EN , https://www.youtube.com/channel/UCtQPCnbIB7SP_gM1Xtv8bDQ

public class MenuScene : MonoBehaviour
{
    private CanvasGroup fadegroup;
    private float FadeInSpeed = 0.33f;

    public RectTransform menuContainer;
    public Transform levelPanel;
    public Transform ShopPanel;

    private Vector3 desiredMenuPosition;


    private void Start() 
    {
        SetCameraTo(Manager.Instance.menuFocus);

        fadegroup = FindObjectOfType<CanvasGroup>();

        fadegroup.alpha = 1;

        InitShop(); 

        InitLevel();  
    }

    private void Update() 
    {
        fadegroup.alpha = 1 - Time.timeSinceLevelLoad * FadeInSpeed;

        menuContainer.anchoredPosition3D = Vector3.Lerp(menuContainer.anchoredPosition3D,desiredMenuPosition,0.1f);
    }

    private void InitShop()
    {
        if(ShopPanel == null)
            Debug.Log("It working I think");
        
        int i = 0;
        foreach (Transform t in ShopPanel)
        {
            int currentIndex = i;

            Button b = t.GetComponent<Button>();
            b.onClick.AddListener(() => OnWrenchSelect(currentIndex));
            i++;
        }   
    }

    private void InitLevel()
    {
        if(levelPanel == null)
            Debug.Log("It working I think");
        
        int i = 0;
        foreach (Transform t in levelPanel)
        {
            int currentIndex = i;

            Button b = t.GetComponent<Button>();
            b.onClick.AddListener(() => OnLevelSelect(currentIndex));

            Image img = t.GetComponent<Image>();

            if(i <= SaveManager.Instance.state.completedLevel)
            {
                if(i == SaveManager.Instance.state.completedLevel)
                {
                    img.color = Color.white;
                }
                else
                {
                    img.color = Color.green; 
                }
            }
            else
            {
                b.interactable = false;

                img.color = Color.grey;
            }

            i++;
        }
    }

    private void SetCameraTo(int menuIndex)
    {
        NavigateTo(menuIndex);
        menuContainer.anchoredPosition3D = desiredMenuPosition;
    }

    private void NavigateTo (int menuIndex)
    {
        switch (menuIndex)
        {
            default:
            case 0: //MainMenu
                desiredMenuPosition = Vector3.zero;
                break;
            case 1://PlayMenu
                desiredMenuPosition = Vector3.right * 673;
                break;
            case 2:// Shopmenu
                desiredMenuPosition = Vector3.left * 673;
                break;
            
        }
    }

    private void OnLevelSelect(int currentIndex) 
    {
        Manager.Instance.currentlLevel = currentIndex;
        SceneManager.LoadScene("Level1");
        Debug.Log("Selected level : " + currentIndex);
    }

    private void OnWrenchSelect(int currentIndex)
    {
        Debug.Log("Slected item " + currentIndex);
    }

    //Button Section
    public void OnPlayClick()
    {
        NavigateTo(1);
        Debug.Log ("PlayButton");
    }

    public void OnStoreClick()
    {
        NavigateTo(2);
        Debug.Log ("StoreButton");
    }

    public void OnBackClick()
    {
        NavigateTo(0);
    }
}
