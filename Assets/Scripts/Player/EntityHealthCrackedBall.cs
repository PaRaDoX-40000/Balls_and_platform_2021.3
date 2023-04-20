using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealthCrackedBall : EntityHealth
{
    private int _ignoreDamageColor;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color[] colors = new Color[3];

    private void Start()
    {
        _ignoreDamageColor = Random.Range(0, 2);
        ChangeColor(_ignoreDamageColor);
    }

    public override void TakeDamage(int damage, ObstacleClolr obstacleClolr)
    {
        if((int)obstacleClolr != _ignoreDamageColor)
        {
            base.TakeDamage(damage, obstacleClolr);
        }
        else
        {
            int i = _ignoreDamageColor;
            while(i == _ignoreDamageColor)
            {
                _ignoreDamageColor = Random.Range(0, 3);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }
            ChangeColor(_ignoreDamageColor);
        }
       
    }

    private void ChangeColor(int number)
    {
        _spriteRenderer.color = colors[number];
    }
}
