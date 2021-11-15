using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

//Youtube Tutorials Link : https://www.youtube.com/playlist?list=PLLH3mUGkfFCU5D0nT9dsN2-RYh1XjnHgH
//Original Script Ownder : N3K EN , https://www.youtube.com/channel/UCtQPCnbIB7SP_gM1Xtv8bDQ

public class MenuScene : MonoBehaviour
{
    private CanvasGroup fadegroup;
    private float FadeInSpeed = 0.33f;

    public RectTransform menuContainer;
    public Transform levelPanel;
    public Transform ShopPanel;
    public Transform SettingPanel;

    private Vector3 desiredMenuPosition;

    public AudioMixer audioMixer;

    private void Start() 
    {
        SetCameraTo(Manager.Instance.menuFocus);

        fadegroup = FindObjectOfType<CanvasGroup>();

        fadegroup.alpha = 1;

        InitShop(); 

        InitLevel();

        InitShop();
    }

    private void Update() 
    {
        fadegroup.alpha = 1 - Time.timeSinceLevelLoad * FadeInSpeed;

        menuContainer.anchoredPosition3D = Vector3.Lerp(menuContainer.anchoredPosition3D,desiredMenuPosition,0.1f);
    }

    public void SetVolume (float volumne)
    {
         audioMixer.SetFloat("volume",volumne);
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
                //TODO: Make it go up a scene when a level has been completed

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

    private void InitSetting()
    {
        
    }

    private void SetCameraTo(int menuIndex)
    {
        NavigateTo(menuIndex);
        menuContainer.anchoredPosition3D = desiredMenuPosition;
    }

    /// <summary>
    /// Will get the Transform of the Ract Transform on the cavus and switch to those specific destinations
    /// </summary>
    private void NavigateTo (int menuIndex)
    {
        switch (menuIndex)
        {
            default:
            case 0: //Main Menu
                desiredMenuPosition = Vector3.zero;
                break;
            case 1://Level Menu
                desiredMenuPosition = Vector3.down * -1441;
                break;
            case 2:// Shop Menu
                desiredMenuPosition = Vector3.right * -693;
                break;
            case 3://Setting Menu
                desiredMenuPosition = Vector3.left * -693;
                break;
        }
    }

    private void OnLevelSelect(int currentIndex) 
    {
        Manager.Instance.currentlLevel = currentIndex;
        SceneManager.LoadScene(2);
        Debug.Log("Selected level : " + currentIndex);
    }

    private void OnWrenchSelect(int currentIndex)
    {
        Debug.Log("Slected item " + currentIndex);
    }

    //Button Section to switch canvese 
    public void OnPlayClick()
    {
        NavigateTo(1);
    }

    public void OnStoreClick()
    {
        NavigateTo(2);
    }

    public void OnSettingClick()
    {
        NavigateTo(3);
    }

    public void OnBackClick()
    {
        NavigateTo(0);
    }
}
