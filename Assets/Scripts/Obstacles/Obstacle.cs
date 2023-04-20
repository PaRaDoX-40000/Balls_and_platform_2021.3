using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{    
    [SerializeField] private DownwardMovement _downwardMovement ;
    [SerializeField] private ObstacleEnum obstacleEnum;


    public ObstacleEnum ObstacleEnum => obstacleEnum;

    public void SetSpeed(int value)
    {
        if (_downwardMovement != null)
        {
            _downwardMovement.SetSpeed(value);
        }
    }

}
public enum ObstacleEnum
{
    ElectroRayPlatform = 0,
    ElectroRayBoll = 1,
    ElectroRay = 2,
    PulsatingBall = 3,
    Laser=4

}
