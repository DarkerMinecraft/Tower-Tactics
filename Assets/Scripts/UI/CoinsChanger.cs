﻿using System.Collections;
using TMPro;
using UnityEngine;

public class CoinsChanger : MonoBehaviour
{

    private static int coins = 650;

    private TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = coins.ToString("N0");
    }

    public static void ChangeCoins(int amount) 
    {
        coins += amount;
    }
    public static bool CanChangeCoins(int amount) 
    {
        return coins >= amount;
    }
}
