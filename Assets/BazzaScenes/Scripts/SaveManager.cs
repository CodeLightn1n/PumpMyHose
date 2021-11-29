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

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance {set ; get; }
    public SaveState state;

    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;   
        Load();
        //Clean(); //Uncomment *Clean* To reset the save data and once reset commit it out again

        Debug.Log(Helper.Serialize<SaveState>(state));
    }

    /// <summary>
    /// Save the whole state of this script
    /// </summary>
    public void Save()
    {
        PlayerPrefs.SetString("save" ,Helper.Serialize<SaveState>(state));
    }

    /// <summary>
    /// Will load the current progress of save script
    /// </summary>
    public void Load()
    {
        if(PlayerPrefs.HasKey("save"))
        {
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save")); 
        }
        else
        {
            state = new SaveState();
            Save();
            Debug.Log("No save file detected, making new one");
        }
    }

    /// <summary>
    /// Will delete the save file and reset to the orginal state
    /// </summary>
    public void Clean()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Save state has been deleted and making new one");
    }

    public void CompletedLevel(int index)
    {
        if(state.completedLevel == index)
        {
            state.completedLevel ++;
            Save();
        }
    }
}
