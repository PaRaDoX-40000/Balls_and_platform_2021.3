using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private int _speed=10;
    [SerializeField] Rigidbody2D _platformRigidbody; 
   
    private void FixedUpdate()
    {
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        //    transform.Translate((touchPosition - transform.position).normalized * _speed * Time.deltaTime);
        //}
        if (Input.GetMouseButton(0))
        {
            Vector3 touch = Input.mousePosition+ new Vector3 (0,75f,0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch);
            Vector3 pathVector = (touchPosition - transform.position);
            pathVector.z = 0;
            Vector3 vectorSpeed = pathVector.normalized * (float)_speed * Time.deltaTime;
            if (vectorSpeed.magnitude > pathVector.magnitude)
            {
                vectorSpeed = pathVector;             
            }
            if (pathVector.magnitude > 0.01f)
                _platformRigidbody.MovePosition(transform.position + vectorSpeed);
                
        }
    }
}
