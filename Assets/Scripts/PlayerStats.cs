﻿using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public static int money;
    public int startMoney = 400;

    public static int lives;
    public int startLives = 3;

    public static int rounds;

    void Start()
    {
        money = startMoney;
        lives = startLives;

        rounds = 0;

        
    }
}
