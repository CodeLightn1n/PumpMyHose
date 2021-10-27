using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance { set; get; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;    
    }
    public int currentlLevel = 0; //Used when changing from menu to game scene
    public int menuFocus = 0;     //Used when entering the game menu scene, to know which menu
}
