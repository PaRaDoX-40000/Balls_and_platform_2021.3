using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntityHealth : MonoBehaviour//
{

    public UnityAction DiedAction;
    public UnityEvent TakeDamageEvent;

    [SerializeField] private int _maxHealthPoints = 1;
    [SerializeField] private float _invulnerabilityTime = 1.5f;
    [SerializeField] List<ObstacleClolr> _saveColors = new List<ObstacleClolr>();
    private int _healthPoints;
    private Vector3 _spawnPoint;
    private Animator _animator;
    private bool _invulnerability=false;
    private Coroutine coroutineInvulnerabilityTimer;

    public int MaxHealthPoints => _maxHealthPoints;

    void Start()
    {
        _spawnPoint = transform.position;
        _healthPoints = _maxHealthPoints;
        GlobalEventSystem.RestartGame.AddListener(Restart);
        _animator = GetComponent<Animator>();
    }

    public void SetInvulnerability(bool T, float time=0)
    {
        _invulnerability = T;
        if (coroutineInvulnerabilityTimer != null)
        {
            StopCoroutine(coroutineInvulnerabilityTimer);
            _animator.SetBool("Invulnerability", false);
        }
        if (time > 0)
        {
            coroutineInvulnerabilityTimer = StartCoroutine(invulnerabilityTimer(time));
        }
    }

    public virtual void TakeDamage(int damage, ObstacleClolr obstacleClolr)
    {
        if (_saveColors.Contains(obstacleClolr)==false)
        {
            if (_invulnerability == false)
            {
                _healthPoints -= damage;
                TakeDamageEvent?.Invoke();
                coroutineInvulnerabilityTimer = StartCoroutine(invulnerabilityTimer(_invulnerabilityTime));
                if (_healthPoints <= 0)
                {
                    Died();
                }
            }
        }        
    }
    private void Died()
    {
        DiedAction?.Invoke();    
    }

    private IEnumerator invulnerabilityTimer(float invulnerabilityTime)
    {
        _invulnerability = true;
        _animator.SetBool("Invulnerability", true);
        yield return new WaitForSeconds(invulnerabilityTime);
        _animator.SetBool("Invulnerability", false);
        _invulnerability = false;
    }


    public void Restart()
    {
        transform.position = _spawnPoint;
        _healthPoints = _maxHealthPoints;
    }

    private void OnDestroy()
    {
        //GlobalEventSystem.RestartGame -= Restart;
    }

}
