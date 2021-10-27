using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Youtube Tutorials Link : https://www.youtube.com/playlist?list=PLLH3mUGkfFCU5D0nT9dsN2-RYh1XjnHgH
//Original Script Ownder : N3K EN , https://www.youtube.com/channel/UCtQPCnbIB7SP_gM1Xtv8bDQ

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance {set ; get; }
    public SaveState state;

    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;   
        Load();

        Debug.Log(Helper.Serialize<SaveState>(state));
    }

    //Save the whole state of this script
    public void Save()
    {
        PlayerPrefs.SetString("save" ,Helper.Serialize<SaveState>(state));
    }

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

    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("save");
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
