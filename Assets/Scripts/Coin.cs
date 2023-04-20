using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Coin : MonoBehaviour
{
    public UnityAction<int> CoinTake;
    [SerializeField] private int _value = 1;
    [SerializeField] private GameObject _iconImage;
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private UnityEvent _coinTake;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<CoinGathered>(out CoinGathered coinGathered))
        {
            CoinTake?.Invoke(coinGathered.GatherCoin(_value));
            _coinTake?.Invoke();
            _iconImage.SetActive(false);
            circleCollider.enabled = false;
            StartCoroutine(TurnOffObject(gameObject));
        }
    }

    private IEnumerator TurnOffObject(GameObject gameObject)
    {
        yield return new WaitForSeconds(1);       
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        _iconImage.SetActive(true);
        circleCollider.enabled = true;
    }

}

