using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemAmount : MonoBehaviour
{
    public int blueprintCount, wrenchCount;
    public TextMeshProUGUI wrenchindicator, blueprintindicator;
    

    public void addblueprint(int value)
    {
        blueprintCount += value;
        blueprintindicator.text = blueprintCount.ToString();
    }

    public void addwrench(int value)
    {
        wrenchCount += value;
        wrenchindicator.text = wrenchCount.ToString();

    }

    private void Start()
    {
        blueprintCount = 0;
        wrenchCount = 0;
    }
}
