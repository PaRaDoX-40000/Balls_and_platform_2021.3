using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObstaclesCountPool
{
    [SerializeField] private Obstacle _obstaclesPrefab;
    [SerializeField] private int _numberSpawn;
   
    public Obstacle ObstaclesPrefab => _obstaclesPrefab;
    public int NumberSpawn => _numberSpawn;

   
}


