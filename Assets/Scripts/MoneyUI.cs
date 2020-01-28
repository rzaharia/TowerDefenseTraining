using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;

    private void Update()//TODO -> change from update -> not needed to actualize so fast 
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
