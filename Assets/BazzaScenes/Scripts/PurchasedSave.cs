using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class PurchasedSave : MonoBehaviour
{
    public TextMeshProUGUI wrenchesown, bluePrintOwned;
    
    private void Start() 
    {
        items.wrench = PlayerPrefs.GetInt("wrench");
        items.bluePrint = PlayerPrefs.GetInt("BluePrint");
        displayWrenchAmount();
        displayBluePrintAmmount();
    }

    void displayWrenchAmount()
    {
        wrenchesown.text = items.wrench.ToString();
        PlayerPrefs.SetInt("wrench",items.wrench);
        PlayerPrefs.Save();
    }

    void displayBluePrintAmmount() 
    {
        bluePrintOwned.text = items.bluePrint.ToString();
        PlayerPrefs.SetInt("BluePrint",items.bluePrint);
        PlayerPrefs.Save();
    }

    public void PurchaseWrench(int amount)
    {
        items.wrench +=amount;
        displayWrenchAmount();
    }

    public void PurchaseBluePrint(int amount)
    {
        items.bluePrint +=amount;
        displayBluePrintAmmount();
    }



   /*
        int: for wrenches and blueprints for UI
        Savestate: to save the values
        Arry[]: Which is a blueprint or Wrench
        int: How much will they give
   */
    
    /*
        Method for giving these items once a specific button is pushed
    */

    /*
        Method for saving all the wrench and bluepritns the player has
    */

    /*
        
    */
}
