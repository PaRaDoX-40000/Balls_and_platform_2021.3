using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Price Entity", order = 100)]
public class PriceEntity : ScriptableObject
{
    [SerializeField] private Entity _entity;
    [SerializeField] private int _price=0;
    [SerializeField] private bool _purchased = false;
    [SerializeField] private СurrencyСontainer _сurrencyСontainer;

    public UnityAction EntityBought;
    public UnityAction<PriceEntity> EntitySelected;

    public Entity Entity => _entity;
    public bool Purchased => _purchased;
    public int Price => _price;

    public void Loading(bool purchased)
    {
        _purchased = purchased;
    }


    public void TryBuyEntityVoid()//Переименуй
    {
        if (_purchased == true)
        {
            EntitySelected?.Invoke(this);
        }
        else
        {
            TryBuyEntity();
        }
       
    }

    public bool TryBuyEntity()
    {       
        if (_сurrencyСontainer.TryRemoveGold(_price)==false)
        {
            return false;
        }
        else
        {
            _purchased = true;
            EntityBought?.Invoke();
            return true;
        }           
    }
}
