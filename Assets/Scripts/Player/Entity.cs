using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Entity: MonoBehaviour
{  
    [SerializeField] private string _entityName;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private EntityHealth _entityHealth;


    [SerializeField] private EntityType _entityType;

    public EntityType _EntityType => _entityType;

    public string EntityName => _entityName;
    public string Description  => _description;
    public Sprite Icon => _icon;

    public EntityHealth EntityHealth => _entityHealth;

    
}
public enum EntityType
{
    Boll = 0,
    Platform = 1
}
