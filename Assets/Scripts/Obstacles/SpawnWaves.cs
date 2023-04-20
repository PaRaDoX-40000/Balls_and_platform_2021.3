using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnWaves : MonoBehaviour
{
    
    public UnityAction WavesIsFinished;

    [SerializeField] private PoolObjects _poolObjects;
    [SerializeField] private SpawnPosition[] _spawnPosition;
    [SerializeField] private float _waitingTime;
    private int _spawnFinished;
    private List<Coroutine> _coroutines = new List<Coroutine>();

    public float WaitingTime => _waitingTime;

    private void SpawnIsFinished()
    {
        _spawnFinished++;
        if(_spawnFinished>= _spawnPosition.Length)
        {
            WavesIsFinished?.Invoke();
        }
    }

    private void OnEnable()
    {
        _spawnFinished = 0;
        foreach (SpawnPosition spawnPosition in _spawnPosition)
        {
            spawnPosition.SpawnIsFinished += SpawnIsFinished;
            _coroutines.Add(StartCoroutine(spawnPosition.StartSpavn(_poolObjects)));
        }       
    }
    private void OnDisable()
    {
        
        foreach (Coroutine coroutine in _coroutines)
        {
            StopCoroutine(coroutine);           
        }
        foreach (SpawnPosition spawnPosition in _spawnPosition)
        {
            spawnPosition.SpawnIsFinished -= SpawnIsFinished;           
        }
        _coroutines.Clear();
    }
}
