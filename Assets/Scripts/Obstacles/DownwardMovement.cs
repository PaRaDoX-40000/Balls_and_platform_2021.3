using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownwardMovement : MonoBehaviour
{
    [SerializeField] private int speed = 1;
    

    public void SetSpeed(int value)
    {
        speed = value;
    }
    
    void Update()
    {
        transform.Translate(transform.InverseTransformDirection(Vector3.down) * speed * Time.deltaTime);
    }
}
