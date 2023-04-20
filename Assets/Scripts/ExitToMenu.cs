using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToMenu : MonoBehaviour
{   
    public void Exit()
    {
        GlobalEventSystem.ExitToMenu?.Invoke();
        Time.timeScale = 1;
        
    }
}
