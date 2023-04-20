using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatingObstacle : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Activate()
    {
        _animator.SetBool("active", true);       
    }

    private void OnDisable()
    {
        _animator.SetBool("active", false);
    }
    void Disable()
    {
        gameObject.SetActive(false);
    }

}
