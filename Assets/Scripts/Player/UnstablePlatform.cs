using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstablePlatform : MonoBehaviour
{
    [SerializeField] private Transform _movingParts;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;
    [SerializeField] private float _speed = 2;
    private Vector3 _vectorSpeed = new Vector3(1, 0);

    void Start()
    {
        
    }

   
    void Update()
    {
        if(_movingParts.position.x>= _rightBorder.position.x|| _movingParts.position.x <= _leftBorder.position.x)
        {
            _vectorSpeed *= -1;
        }
        _movingParts.Translate(_vectorSpeed * _speed * Time.deltaTime);
    }
}
