using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private ScoreCounterUI scoreCounterUI;
    private float _score=0;
    private bool _counts = false;


    private void Awake()
    {
        GlobalEventSystem.StartGame.AddListener(StartCounting);
        GlobalEventSystem.RestartGame.AddListener(Restsrt);
        GlobalEventSystem.ExitToMenu.AddListener(Stop); 
    }

    private void StartCounting()
    {
        _counts = true;
        scoreCounterUI.gameObject.SetActive(true);
    }
    private void Restsrt()
    {
        _score = 0;
        StartCounting();
    }
    private void Stop()
    {
        _counts = false;
        scoreCounterUI.gameObject.SetActive(false);
    }
    void Update()
    {
        if (_counts == true)
        {
            _score += Time.deltaTime/3;
            scoreCounterUI.UpdateScore((int)_score);
        }
    }
}
