using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuInGame : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private DefeatController _defeatController;
    [SerializeField] private ExitToMenu _exitToMenu;
    [SerializeField] ChangingActivityAnimation activityAnimation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SaprtPause();
        }
    }

    public void SaprtPause()
    {
        _pausePanel.SetActive(true);
        activityAnimation.SerActivity(true);
        Time.timeScale = 0;
    }
    public void Сontinue()
    {
        activityAnimation.SerActivity(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        activityAnimation.SerActivity(false);
        _defeatController.Restart();
    }
    public void Exit()
    {
        activityAnimation.SerActivity(false);
        _exitToMenu.Exit();
    }
}
