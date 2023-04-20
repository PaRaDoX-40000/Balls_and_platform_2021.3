using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CoinSpavner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private int _coinNumber;
    [SerializeField] private Transform _conector;
    [SerializeField] private ChargeMoney _chargeMoney; 
    [SerializeField] private Transform _firstSpawnPoint;
    [SerializeField] private Transform _secondSpawnPoint;
    [SerializeField] private int _minTimeSpawn=5;
    [SerializeField] private int _maxTimeSpawn=15;



    private List<GameObject> _coins = new List<GameObject>();
    private Coroutine _spawnCoins;



    void Start()
    {
        GlobalEventSystem.SpawnEntity.AddListener(SpavnObject);
        GlobalEventSystem.StartGame.AddListener(StartGame);
        GlobalEventSystem.RestartGame.AddListener(Restart);
        GlobalEventSystem.ExitToMenu.AddListener(StopGame);
    }

    private void SpavnObject()
    {
        for(int i =0; i< _coinNumber-_coins.Count; i++)
        {
            GameObject coin = Instantiate(_coinPrefab, _conector);
            coin.GetComponent<Coin>().CoinTake += _chargeMoney.AddGold;
            coin.SetActive(false);
            _coins.Add(coin);
        }
    }

    private bool TryGetCoin(out GameObject coin)
    {
        try
        {
            coin = _coins.First(q => q.activeSelf == false);
            return true;
        }
        catch
        {
            Debug.LogError("Нехватает монет для спавна");
            coin = null;
            return false;
        }
    }

    private void Restart()
    {
        foreach(GameObject coin in _coins)
        {
            coin.SetActive(false);
        }
    }

    private void StopGame()
    {
        Restart();
        StopCoroutine(_spawnCoins);
    }


    private void StartGame()
    {
        _spawnCoins = StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            int time = Random.Range(_minTimeSpawn, _maxTimeSpawn);
            yield return new WaitForSeconds(time);
            if (TryGetCoin(out GameObject coin))
            {
                float position = Random.Range(0f, 1f);              
                coin.transform.position = Vector3.Lerp(_firstSpawnPoint.position, _secondSpawnPoint.position, position);
                coin.SetActive(true);
            }
        }          
    }

   
    void Update()
    {
        
    }
}
