using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangingActivityAnimation : MonoBehaviour
{
    [SerializeField] private UnityEvent ShutdownEvent;
    [SerializeField] private UnityEvent EnablingEvent;

    [SerializeField] private Animator _animator;
    private bool _changedState=false;




    private void Start()
    {
        
    }

    public void SerActivity(bool enabled)
    {
        _changedState = true;
        _animator.SetBool("enabled", enabled);
        _animator.SetBool("changedState", _changedState);       
    }




    public void Shutdown()
    {
        ShutdownEvent?.Invoke();
    }
    public void Enabling()
    {
        EnablingEvent?.Invoke();
    }
}
