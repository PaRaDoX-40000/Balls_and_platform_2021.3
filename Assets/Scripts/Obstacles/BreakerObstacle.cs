using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerObstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
       if(collision.gameObject.TryGetComponent<Obstacle>(out Obstacle obstacle))
       {
            obstacle.gameObject.SetActive(false);
       }
    }
}
