using GameAnalyticsSDK;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppMetricsEventSupport : MonoBehaviour
{
    [SerializeField] private DefeatController _defeatController;
    private DateTime _dateOfRegistration = DateTime.Now;
    private int _daysSinceRegistration = 0;
    private int _numbersessions = 0;
    private float _timeStart = 0;

    public DateTime DateOfRegistration => _dateOfRegistration;
    public int DaysSinceRegistration => _daysSinceRegistration;
    public int Numbersessions => _numbersessions;

    internal void Loading(GameData gameData)
    {
        _dateOfRegistration = new DateTime(gameData._year, gameData._month, gameData._day);
        _numbersessions = gameData.numbersessions;
    }

    private void Awake()
    {
        GameAnalytics.Initialize();
    }

    void Start()
    {        
        _daysSinceRegistration = (DateTime.Now - _dateOfRegistration).Days;
        _numbersessions++;
        AppMetrica.Instance.ReportEvent("game_start", new Dictionary<string, object>() { { "count",_numbersessions},{ "days_since_reg",_daysSinceRegistration }});

        AppMetrica.Instance.ReportEvent("main_menu", new Dictionary<string, object>() { { "days_since_reg", _daysSinceRegistration } });

        GameAnalytics.NewDesignEvent("Staged_events:Game_start:Count", _numbersessions);
        GameAnalytics.NewDesignEvent("Staged_events:Game_start:Days_since_reg", _daysSinceRegistration);
        
        GameAnalytics.NewDesignEvent("Staged_events:Main_menu:Days_since_reg", _daysSinceRegistration);

        GlobalEventSystem.StartGame.AddListener(LevelStartEvent);
        _defeatController.LevelFailEvent.AddListener(LevelFailEvent);
        GlobalEventSystem.RestartGame.AddListener(LevelRestartEvent);
        GlobalEventSystem.ExitToMenu.AddListener(MainMenuEvent);
    }

    void LevelStartEvent()
    {
        AppMetrica.Instance.ReportEvent("level_start", new Dictionary<string, object>() { { "level", 0},{ "days_since_reg",_daysSinceRegistration }});
        AppMetrica.Instance.SendEventsBuffer();
        
        GameAnalytics.NewDesignEvent("Staged_events:Level_start:Days_since_reg", _daysSinceRegistration);
        _timeStart = Time.time;
    }
    void LevelFailEvent()
    {
        AppMetrica.Instance.ReportEvent("level_fail", new Dictionary<string, object>() { { "level", 0 }, { "time_spent", Time.time - _timeStart }, { "days_since_reg", _daysSinceRegistration } });

        GameAnalytics.NewDesignEvent("Staged_events:Level_fail:time_spent", Time.time - _timeStart);
        GameAnalytics.NewDesignEvent("Staged_events:Level_fail:Days_since_reg", _daysSinceRegistration);
        _timeStart = 0;
    }
    void LevelRestartEvent()
    {
        AppMetrica.Instance.ReportEvent("level_restart", new Dictionary<string, object>() { { "level", 0 },  { "days_since_reg", _daysSinceRegistration } });
        _timeStart = Time.time;
        GameAnalytics.NewDesignEvent("Staged_events:Level_restart:Days_since_reg", _daysSinceRegistration);

    }
    void MainMenuEvent()
    {
        AppMetrica.Instance.ReportEvent("main_menu", new Dictionary<string, object>() { { "days_since_reg", _daysSinceRegistration } });      
        _timeStart = 0;
        GameAnalytics.NewDesignEvent("Staged_events:Main_menu:Days_since_reg", _daysSinceRegistration);
    }
   
}
