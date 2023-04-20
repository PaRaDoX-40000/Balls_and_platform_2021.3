using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallSticking : MonoBehaviour
{
    [SerializeField] private float _cooldown = 0.5f;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] public UnityEvent Sticking;
    private bool _canSticking = true;

    private void Start()
    {
        GlobalEventSystem.RestartGame.AddListener(Restart);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if(collision.gameObject.TryGetComponent<PlatformTrampoline>(out PlatformTrampoline platformTrampoline))
        {
            if (_canSticking == true)
            {
                _rigidbody.bodyType = RigidbodyType2D.Kinematic;
                _rigidbody.velocity = Vector3.zero;
                platformTrampoline.StickToPlatform(transform);
                Sticking?.Invoke();
                platformTrampoline.BallLanded(_rigidbody);
            }        
        }
    }

    public void Restart()
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody.velocity = Vector3.zero;
        transform.parent = null;
    }
    private void OnDestroy()
    {
        //GlobalEventSystem.RestartGame -= Restart;
    }


    public void RechargeSticking()
    {
        StartCoroutine(Recharge());
    }

    private IEnumerator Recharge()
    {
        _canSticking = false;
        yield return new WaitForSeconds(_cooldown);
        _canSticking = true;
    }
   
}
