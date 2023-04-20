using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    [SerializeField] private StartSpawnSystem _startSpawnSystem;
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        GlobalEventSystem.StartGame.AddListener(Subscribe);
    }

    public void Subscribe()
    {
        EntityHealth ballEntityHealth = _startSpawnSystem.Ball.GetComponent<EntityHealth>();
        EntityHealth platformEntityHealth = _startSpawnSystem.Platform .GetComponent<EntityHealth>();
        ballEntityHealth.TakeDamageEvent.AddListener(Play);
        platformEntityHealth.TakeDamageEvent.AddListener(Play);
    }

    public void Play()
    {
        StartCoroutine(ShakingCamera());
        StartCoroutine(TimeStop());
    }

    private IEnumerator ShakingCamera()
    {
        _animator.SetBool("Bool", true);
        yield return new WaitForSeconds(1);
        _animator.SetBool("Bool", false);
    }
    private IEnumerator TimeStop()
    {
        Time.timeScale = 0.3f;
        yield return new WaitForSeconds(0.03f);
        Time.timeScale = 1f;
    }

}
