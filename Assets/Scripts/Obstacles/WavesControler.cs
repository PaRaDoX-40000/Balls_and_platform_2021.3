using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesControler : MonoBehaviour
{
    [SerializeField] private SpawnWaves[] _spawnWaves;   
    private SpawnWaves _currentWave=null;
    private Coroutine _waitingCoroutine;



    private void Start()
    {        
        GlobalEventSystem.StartGame.AddListener(StartRandomWaves);
        GlobalEventSystem.RestartGame.AddListener(Restart);
        GlobalEventSystem.ExitToMenu.AddListener(StopWaves);
    }
    private void Restart()
    {
        StopWaves();
        StartRandomWaves();
    }

    private void StartRandomWaves()
    {
        int randomInt = Random.Range(0, _spawnWaves.Length);       
        _currentWave = _spawnWaves[randomInt];
        _currentWave.WavesIsFinished += ChangeWaves;
        _currentWave.enabled = true;
        
    }

    private void ChangeWaves()
    {
        _waitingCoroutine = StartCoroutine(WaitingBeforeNewWave(_currentWave.WaitingTime));
        ClearWaves();
    }

    private void StopWaves()
    {
        ClearWaves();
        if (_waitingCoroutine != null)
        {
            StopCoroutine(_waitingCoroutine);
        }
    }

    private void ClearWaves()
    {
        if (_currentWave != null)
        {
            _currentWave.WavesIsFinished -= ChangeWaves;
            _currentWave.enabled = false;
            _currentWave = null;
        }        
    }


    private IEnumerator WaitingBeforeNewWave(float waitingTime)
    {
        yield return new WaitForSeconds(waitingTime);
        StartRandomWaves();
    }



}
