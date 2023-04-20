using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDropZone : MonoBehaviour
{
    [SerializeField] Transform _spavnBall;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            ball.GetComponent<EntityHealth>().TakeDamage(1,ObstacleClolr.Null);
            ball.transform.position = _spavnBall.position;
        }
    }
}
