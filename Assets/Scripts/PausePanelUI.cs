using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanelUI : MonoBehaviour
{
    [SerializeField] ChangingActivityAnimation activityAnimation;

    private void OnEnable()
    {
        activityAnimation.SerActivity(true);
    }       
}
