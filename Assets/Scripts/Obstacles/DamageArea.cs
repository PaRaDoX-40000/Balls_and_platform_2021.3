using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageArea : MonoBehaviour
{  
    [SerializeField] private int _damage=1;
    [SerializeField] private ObstacleClolr obstacleClolr;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Entity>(out Entity entity))
        {
            entity.GetComponent<EntityHealth>().TakeDamage(_damage, obstacleClolr);
        }
    }
}
public enum ObstacleClolr
{
    Green = 0,
    Red = 1,
    Blue = 2,
    Null = 99

}
