using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventsSubscriber : MonoBehaviour
{
    [SerializeField] UnityEvent RestartGame;
    [SerializeField] UnityEvent StartGame;  
    [SerializeField] UnityEvent ExitToMenu;
    
   
    

    void Start()
    {
        GlobalEventSystem.RestartGame.AddListener(RestartGame.Invoke);
        GlobalEventSystem.StartGame.AddListener(StartGame.Invoke);        
        GlobalEventSystem.ExitToMenu.AddListener(ExitToMenu.Invoke);               
    }     
}
