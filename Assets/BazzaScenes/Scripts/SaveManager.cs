using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
