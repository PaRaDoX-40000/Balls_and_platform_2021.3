using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateObstacleAfterTime : MonoBehaviour
{
    [SerializeField] private ActivatingObstacle _activatingObstacle;
    [SerializeField] private float _time;
    [SerializeField] private GameObject _dangerIcon;
    private void OnEnable()
    {
        StartCoroutine(Timer());
        if (_dangerIcon != null)
        {
            _dangerIcon.SetActive(true);
        }
    }
    private void OnDisable()
    {
        
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(_time);
        if (_dangerIcon != null)
        {
            _dangerIcon.SetActive(false);
        }
        _activatingObstacle.Activate();

    }
}
