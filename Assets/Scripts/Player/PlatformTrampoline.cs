using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformTrampoline : MonoBehaviour
{
    [SerializeField] private float _powerMultiplier=5;
    [SerializeField] private Transform _placeSticking;
    public UnityEvent BallLandedAction;
    public UnityEvent BallDetached;



    private bool ballOnPlatform = false;
    private Vector3 _previousPosition;  
    private Vector3 _maxDisplacementVector;
    private Rigidbody2D _bollRigidbody; 
    private bool _platformMovesToTop = false;
    private BallSticking _ballSticking;



    private void Start()
    {
        _previousPosition = transform.position;
    }
 

    private void FixedUpdate()
    {
        if (ballOnPlatform == true)
        {
            if ( transform.position.y - _previousPosition.y > 0.3f)
            {              
                _platformMovesToTop = true;
                if (transform.position.y - _previousPosition.y > _maxDisplacementVector.y)
                {
                    _maxDisplacementVector = transform.position - _previousPosition;
                }
            }
            if(_platformMovesToTop == true && transform.position.y - _previousPosition.y < 0.3f)
            {
                BallDetached?.Invoke();
                _bollRigidbody.bodyType = RigidbodyType2D.Dynamic;
                _bollRigidbody.transform.parent = null;
                _bollRigidbody.AddForce(_maxDisplacementVector * _powerMultiplier, ForceMode2D.Impulse);                
                _ballSticking.RechargeSticking();
                _platformMovesToTop = false;
                ballOnPlatform = false;
                _maxDisplacementVector = Vector3.zero;
            }
            
        }
        _previousPosition = transform.position;

    }

    public void StickToPlatform(Transform ballTransform)
    {
        ballTransform.parent = _placeSticking;
    }


    public void BallLanded(Rigidbody2D ballrigidbod)
    {
        if (_bollRigidbody == null)
        {
            _bollRigidbody = ballrigidbod;
            _ballSticking = _bollRigidbody.gameObject.GetComponent<BallSticking>();
        }
        BallLandedAction?.Invoke();
        ballOnPlatform = true;
    }
}
