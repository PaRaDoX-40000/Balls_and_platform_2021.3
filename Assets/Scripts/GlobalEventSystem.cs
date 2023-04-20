using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public static class GlobalEventSystem
{
    public static UnityEvent RestartGame = new UnityEvent();
    public static UnityEvent StartGame = new UnityEvent();
    public static UnityEvent SpawnEntity = new UnityEvent();
    public static UnityEvent ExitToMenu = new UnityEvent();

}
