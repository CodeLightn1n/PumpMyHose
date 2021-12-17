using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarUI : MonoBehaviour
{
    public TextMeshProUGUI starsText;

    private void Update()
    {
        UpdateStarsUI();
    }

    public void UpdateStarsUI()
    {
        int sum = 0;
        for(int i = 1; i < 14; i++)
        {
            sum += PlayerPrefs.GetInt("Lv" + i.ToString());//Add the level 1 stars number, level 2 stars number.....
        }
        starsText.text = sum + "/" + 15;
    }
}