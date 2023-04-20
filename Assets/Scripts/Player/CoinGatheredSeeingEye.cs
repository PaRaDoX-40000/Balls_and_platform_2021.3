using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGatheredSeeingEye : CoinGathered
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] spritesEyeState = new Sprite[4];
    [SerializeField] private EntityHealth entityHealth;
    private int _eyeState = 0;
    private int _maxEyeState = 3;
    private Coroutine eyeRollback;


    public override int GatherCoin(int value)
    {
        value += _eyeState;
        if(_eyeState < _maxEyeState)
        {
            _eyeState++;
            _spriteRenderer.sprite = spritesEyeState[_eyeState];
            if (eyeRollback == null)
            {
                eyeRollback = StartCoroutine(EyeRollback());
            }
        }
        else
        {           
            StopCoroutine(eyeRollback);
            eyeRollback = StartCoroutine(EyeRollback());
        }
        if(_eyeState == _maxEyeState)
        {
            entityHealth.SetInvulnerability(true);
        }
        return value;
    }

    private IEnumerator EyeRollback()
    {
        yield return new WaitForSeconds(7);
        if (_eyeState == _maxEyeState)
        {
            entityHealth.SetInvulnerability(false);
        }
        _eyeState--;
        _spriteRenderer.sprite = spritesEyeState[_eyeState];
        if (_eyeState > 0)
        {
            StartCoroutine(EyeRollback());
        }
        else
        {
            StopCoroutine(eyeRollback);
            eyeRollback = null;
        }
    }
}
