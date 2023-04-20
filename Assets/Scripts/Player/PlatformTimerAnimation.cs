using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTimerAnimation : MonoBehaviour
{
    [SerializeField] private Transform _animationObjektTransform;
    private float _maxState = 0;
    private float _minState = -0.15f;
    float time = 0;



    void Start()
    {
        
    }
    
    public void SetStateAnimation(float i)
    {
        if (i > 1 || i < 0)
        {            
            return;
        }
        _animationObjektTransform.localPosition = new Vector3(0, Mathf.Lerp(_minState, _maxState, 1-i),0);

    }

    void Update()
    {
        
        
        time += Time.deltaTime;       
        if(time < 5)
        {
            SetStateAnimation(time / 5);

        }
    }
}
