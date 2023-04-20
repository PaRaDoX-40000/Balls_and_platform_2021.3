using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private Transform[] _backgrounds;
    [SerializeField] float _speed =1;


    void Start()
    {
        
    }

   
    void Update()
    {
        foreach(Transform background in _backgrounds)
        {
            background.Translate(Vector3.down * _speed * Time.deltaTime);
            if (background.localPosition.y < -12.5)
            {
                background.localPosition = new Vector3(0, 12.5f, 0);
            }

        }

    }
}
