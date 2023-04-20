using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounterUI:MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText;

    public void UpdateScore(int Score)
    {
        ScoreText.text = Score.ToString();
    }

}