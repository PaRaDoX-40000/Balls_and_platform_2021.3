using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameLoadingAndSaving : MonoBehaviour
{
    
    private string _path;
    private GameData _gameData;
    [SerializeField] private SelectPlayer _selectPlayer;
    [SerializeField] private СurrencyСontainer _сurrencyСontainer;
    [SerializeField] private StartGameManager _startGameManager;
    [SerializeField] private AppMetricsEventSupport _appMetricsEventSupport;


    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        _path = Path.Combine(Application.dataPath, "Save.json");
#endif
        if (File.Exists(_path))
        {
            Loading();
        }
    }

    private void Start()
    {

    }


    

    private void Saving()
    {
        _gameData = new GameData(_selectPlayer, _сurrencyСontainer, _startGameManager, _appMetricsEventSupport);
        File.WriteAllText(_path, JsonUtility.ToJson(_gameData));
    }
    private void Loading()
    {
        _gameData = JsonUtility.FromJson<GameData>(File.ReadAllText(_path));
        _selectPlayer.Loading(_gameData);
        _сurrencyСontainer.Loading(_gameData);
        _startGameManager.Loading(_gameData);
        _appMetricsEventSupport.Loading(_gameData);
    }


#if UNITY_ANDROID && !UNITY_EDITOR           
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Saving();
        }     
    }
#endif

    void OnApplicationQuit()
    {
        Saving();
    }
}
