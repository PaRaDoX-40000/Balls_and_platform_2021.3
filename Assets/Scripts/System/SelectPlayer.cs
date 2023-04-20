using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    [SerializeField] private List<PriceEntity> _listPlatformsPrice;
    private int _selectedPlatform=0;
    [SerializeField] private List<PriceEntity> _listBallPrice;
    private int _selectedBoll=0;
    [SerializeField] private StartSpawnSystem _startSpawnSystem;
    [SerializeField] private SelectPlayerUI _selectPlayerUI;
    private int _displayStatus=0;

    public List<PriceEntity> ListPlatformsPrice => _listPlatformsPrice;
    public List<PriceEntity> ListballPrice => _listBallPrice;

    private void Start()
    {
        foreach(PriceEntity priceEntity in _listPlatformsPrice)
        {
            priceEntity.EntityBought += UpdatePanel;
            priceEntity.EntitySelected += ChooseEntity;
        }
        foreach (PriceEntity priceEntity in _listBallPrice)
        {
            priceEntity.EntityBought += UpdatePanel;
            priceEntity.EntitySelected += ChooseEntity;
        }
    }

    private void ChooseEntity(PriceEntity entity)
    {
        if (_displayStatus == 0)
        {
            ChoosePlatform(entity.Entity);
            _selectedPlatform = _listPlatformsPrice.IndexOf(entity);
            UpdatePanel();
            
        }
        else
        {
            ChooseBoll(entity.Entity);
            _selectedBoll = _listBallPrice.IndexOf(entity);
            UpdatePanel();          
        }
    }


    public void ChoosePlatform(Entity entity)
    {
        _startSpawnSystem.ChangePlatform(entity);
    }
    public void ChooseBoll(Entity entity)
    {
        _startSpawnSystem.ChangeBoll(entity);
    }


    private void UpdatePanel()
    {
       
        if (_displayStatus == 0)
        {
            ShowePlatform();
        }
        else
        {
            ShoweBoll();
        }
    }

    public void ShowePlatform()
    {
        _selectPlayerUI.ShoweEntity(_listPlatformsPrice, _selectedPlatform);
        _displayStatus = 0;
        
    }
    public void ShoweBoll()
    {
        _selectPlayerUI.ShoweEntity(_listBallPrice, _selectedBoll);
        _displayStatus = 1;
    }

    public void Loading(GameData gameData)
    {
        for(int i = 0; i < _listPlatformsPrice.Count; i++)
        {
            _listPlatformsPrice[i].Loading(gameData.platformsPurchaseds[i]);
        }
        for (int i = 0; i < _listBallPrice.Count; i++)
        {
            _listBallPrice[i].Loading(gameData.ballsPurchaseds[i]);
        }
    }


}
