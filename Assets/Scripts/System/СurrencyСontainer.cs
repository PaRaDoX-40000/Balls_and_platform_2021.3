using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Сurrency Сontainer", menuName = "Сurrency Сontainer", order = 100)]
public class СurrencyСontainer : ScriptableObject
{
    [SerializeField] private int _gold;
    [HideInInspector] public UnityEvent GoldChanged;

    public int Gold => _gold;

    private int _Gold
    {
        get { return _gold; }
        set
        {
            _gold = value;
            GoldChanged?.Invoke();
        }
    }

   


    public bool TryRemoveGold(int quantity)
    {
        if(_Gold- quantity < 0)
        {
            return false;
        }
        else
        {
            _Gold -= quantity;
            return true;
        }
    }
    public void AddGold(int quantity)
    {
        _Gold += quantity;       
    }

    public void Loading(GameData gameData)
    {
        _Gold = gameData.gold;
    }
}
