using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObstacleParameters
{
    [Range(0, 3)] [SerializeField] float _maxRandomTime;
    [SerializeField] private float _time;
    [SerializeField] private Vector3 _rotation = Vector3.zero;
    [SerializeField] private int _speed = 1;
    [SerializeField] private ObstacleEnum _spavnObstacle;
  
    public ObstacleEnum SpavnObect => _spavnObstacle;
    public Vector3 Rotation => _rotation;
    public int Speed => _speed;

    public float GetTime()
    {
        float random = Random.Range(0, _maxRandomTime);
        return _time + random;       
    }
          
   
}

