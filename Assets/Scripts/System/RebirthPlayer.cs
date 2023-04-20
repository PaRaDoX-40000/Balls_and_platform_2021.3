using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RebirthPlayer : MonoBehaviour
{

    [SerializeField] private StartSpawnSystem _startSpawnSystem;
    [SerializeField] private DefeatController _defeatController;

    public void Rebirth()
    {
        _startSpawnSystem.Ball.EntityHealth.Restart();
        _startSpawnSystem.Ball.BallSticking.Restart();
        _startSpawnSystem.Platform.EntityHealth.Restart();

        _startSpawnSystem.Ball.EntityHealth.SetInvulnerability(true, 5);
        _startSpawnSystem.Platform.EntityHealth.SetInvulnerability(true, 5);
        _defeatController.RestoreState();

    }
}
