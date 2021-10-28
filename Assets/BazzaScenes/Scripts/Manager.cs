using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Youtube Tutorials Link : https://www.youtube.com/playlist?list=PLLH3mUGkfFCU5D0nT9dsN2-RYh1XjnHgH
//Original Script Ownder : N3K EN , https://www.youtube.com/channel/UCtQPCnbIB7SP_gM1Xtv8bDQ

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
