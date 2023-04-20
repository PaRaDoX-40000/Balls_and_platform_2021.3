using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DefeatController : MonoBehaviour
{

    public UnityEvent LevelFailEvent;
    [SerializeField] private StartSpawnSystem _startSpawnSystem;
    [SerializeField] private DefeatControllerUI _defeatControllerUI;
    private List <EntityHealth> _entityHealth = new List<EntityHealth>();
    private bool _defeat = false;

    private void Start()
    {
        GlobalEventSystem.StartGame.AddListener(StartGame);
        GlobalEventSystem.ExitToMenu.AddListener(StopGame);
    }



    private void StartGame()
    {      
        _entityHealth.Add(_startSpawnSystem.Ball.GetComponent<EntityHealth>());// не нравится
        _entityHealth.Add(_startSpawnSystem.Platform.GetComponent<EntityHealth>());
        _defeat = false;

        foreach (EntityHealth entityHealth in _entityHealth)
        {
            entityHealth.DiedAction += Defeat;            
        }
    }  

    private void StopGame()
    {
        _entityHealth.Clear();
    }

    private void Defeat()
    {
        if (_defeat == false)
        {
            StartCoroutine(DefetTime());
            LevelFailEvent?.Invoke();
            _defeat = true;
        }
       


    }
    private IEnumerator DefetTime()
    {
        while (Time.timeScale >= 0.1)
        {
            Time.timeScale = Time.timeScale - 0.05f;
            yield return new WaitForSeconds(0.1f* Time.timeScale);
        }
        _defeatControllerUI.ShoweDefeatPanel();
        Time.timeScale = 0;
    }



    public void RestoreState()
    {
        Time.timeScale = 1;
        _defeatControllerUI.hideDefeatPanel();
        _defeat = false;
    }

    public void Restart()
    {
        RestoreState();
        GlobalEventSystem.RestartGame?.Invoke();              
    }
        
}
