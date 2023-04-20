using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public bool[] platformsPurchaseds;
    public bool[] ballsPurchaseds;
    public int gold;
    public bool tutorialHasBeenCompleted;
    public int _year;
    public int _month;
    public int _day;
    public int numbersessions;


    public GameData(SelectPlayer selectPlayer, СurrencyСontainer сurrencyСontainer, StartGameManager startGameManager, AppMetricsEventSupport appmetricsEventSupport)
    {
        platformsPurchaseds = new bool[selectPlayer.ListPlatformsPrice.Count];
        for(int i=0; i< platformsPurchaseds.Length; i++)
        {
            platformsPurchaseds[i] = selectPlayer.ListPlatformsPrice[i].Purchased;
        }

        ballsPurchaseds = new bool[selectPlayer.ListballPrice.Count];
        for (int i = 0; i < ballsPurchaseds.Length; i++)
        {
            ballsPurchaseds[i] = selectPlayer.ListballPrice[i].Purchased;
        }
        gold = сurrencyСontainer.Gold;
        tutorialHasBeenCompleted = startGameManager.TutorialHasBeenCompleted;

        _year = appmetricsEventSupport.DateOfRegistration.Year;
        _month = appmetricsEventSupport.DateOfRegistration.Month;
        _day = appmetricsEventSupport.DateOfRegistration.Day;
        numbersessions = appmetricsEventSupport.Numbersessions;



    }
}
