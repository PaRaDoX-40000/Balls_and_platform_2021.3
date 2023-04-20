using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatControllerUI : MonoBehaviour
{
    [SerializeField] GameObject _panelDefeat;
    [SerializeField] ChangingActivityAnimation changingActivityAnimation;

    public void ShoweDefeatPanel()
    {
        _panelDefeat.SetActive(true);
        changingActivityAnimation.SerActivity(true);
        
    }

    public void hideDefeatPanel()
    {
        changingActivityAnimation.SerActivity(false);               
    }



}
