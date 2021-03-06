﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public static LevelController current;
    Vector3 startingPosition;
    private int fruitsQuantity = 0;
    private int coins = 0;

    public static bool[] crystals = new bool[3];

    void Awake()
    {
        current = this;
    }

    public void setStartPosition(Vector3 pos) { 
        this.startingPosition = pos; 
    } 
    
    public void onRabitDeath(HeroRabit rabit) { 
        //При смерті кролика повертаємо на початкову позицію 
        rabit.transform.position = this.startingPosition;
        rabit.removeLifes();
    }

    public int addCoins(int number)
    {
        return ++coins;
    }

    public int addFruit() 
    {
        return fruitsQuantity++;
    }

    public int addCrystal(int number) 
    {
        if (number > 3 || number < 1) 
            return number;
        crystals[number - 1] = true;
        return number;
    }

    public int getFruits()
    {
        return fruitsQuantity;
    }

    public int getCoins()
    {
        return coins;
    }

    public bool hasCrystal(int n)
    {
        return crystals[n];
    }

    public void saveCoins()
    {
        int globalCoins = PlayerPrefs.GetInt("coins");
        globalCoins += coins;

        PlayerPrefs.SetInt("coins", globalCoins);
    }

    public bool[] getCrystalArr()
    {
        return crystals;
    }

}
