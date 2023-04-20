using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    [SerializeField] private Tutorial _tutorial;
    private bool _tutorialHasBeenCompleted = false;
    public bool TutorialHasBeenCompleted => _tutorialHasBeenCompleted;
    

    public void Loading(GameData gameData)
    {
        _tutorialHasBeenCompleted = gameData.tutorialHasBeenCompleted;
    }

    public void StartGame()
    {
        if (_tutorialHasBeenCompleted == false)
        {
            _tutorial.StartTutorial();
            _tutorial.TutorialComplete.AddListener(TutorialComplete);
        }
        else
        {
            GlobalEventSystem.SpawnEntity?.Invoke();
            GlobalEventSystem.StartGame?.Invoke();
        }      
    }

    private void TutorialComplete()
    {
        _tutorialHasBeenCompleted = true;
        StartGame();
    }

   
}
