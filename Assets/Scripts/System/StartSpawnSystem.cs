using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpawnSystem : MonoBehaviour
{
    [SerializeField] private Platform _platformPrefab;
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private Transform _spawnPlatform;
    [SerializeField] private Transform _spawnBoll;
    private Platform _platform;
    private Ball _ball;

    public Platform Platform => _platform;
    public Ball Ball => _ball;

    void Awake()
    {
        GlobalEventSystem.SpawnEntity.AddListener(StartGameSpawn);
        GlobalEventSystem.ExitToMenu.AddListener(StopGame);
    }

    private void StartGameSpawn()
    {
        if (_platformPrefab == null)
        {
            Debug.LogError("Платформа в старт спавн систем не назначера");
            return;
        }
        if (_ballPrefab == null)
        {
            Debug.LogError("Шар в старт спавн систем не назначен");
            return;
        }
        _platform = Instantiate(_platformPrefab, _spawnPlatform.position, Quaternion.identity);
        _ball = Instantiate(_ballPrefab, _spawnBoll.position, Quaternion.identity);
       
    }

    private void StopGame()
    {
        if (_platform != null)
        {           
            Destroy(_platform.gameObject);
        }
        if (_ball != null)
        {
            Destroy(_ball.gameObject);
        }
    }

    public void ChangePlatform(Entity entitu)
    {
       
        _platformPrefab = (Platform)entitu;
    }
    public void ChangeBoll(Entity boll)
    {
        _ballPrefab = (Ball)boll;
    }


}
