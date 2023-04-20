using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectPlayerUI : MonoBehaviour
{
    [SerializeField] private List<PriceEntityUI> _priceEntityUIs = new List<PriceEntityUI>();


    public void ShoweEntity(List<PriceEntity> priceEntities,int _selectedEntityNumber)
    {
        
        for (int i =0; i< priceEntities.Count; i++)
        {
            _priceEntityUIs[i].gameObject.SetActive(true);
            _priceEntityUIs[i].Init(priceEntities[i],false);           
        }
        for(int i = priceEntities.Count; i< _priceEntityUIs.Count; i++)
        {
            _priceEntityUIs[i].gameObject.SetActive(false);
        }
        _priceEntityUIs[_selectedEntityNumber].Init(priceEntities[_selectedEntityNumber], true);

    }
}
