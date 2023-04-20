using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;
using UnityEngine.UI;

public class RewardedAds : MonoBehaviour// IUnityAdsLoadListener, IUnityAdsShowListener
{
    

    //private string _androidAdUnitId = "Rewarded_Android";
    //private string _iOSAdUnitId = "Rewarded_iOS";

    //[SerializeField] private Button adsButton;

    //[SerializeField] private UnityEvent _adСompleted;

    //private string _adUnitId;

    //void Awake()
    //{       
    //   // _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
    //    //    ? _iOSAdUnitId
    //      //  : _androidAdUnitId;
       
    //}

    //private void Start()
    //{
    //    StartCoroutine(WaitTime(2, LoadAd));
    //}

    //private IEnumerator WaitTime(float time,UnityAction action)
    //{
    //    yield return new WaitForSeconds(time);
    //    action?.Invoke();
    //}

   
    //public void LoadAd()
    //{           
    //  //  Advertisement.Load(_adUnitId, this);
    //}

    //public void ShowAd()
    //{       
    //    Advertisement.Show(_adUnitId, this);
    //    adsButton.interactable = false;
    //}

    ////public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    ////{
    ////    if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
    ////    {
    ////        _adСompleted?.Invoke();
    ////        Debug.Log("Unity Ads Rewarded Ad Completed");                           
    ////    }
    ////    LoadAd();
    ////}

    //public void OnUnityAdsAdLoaded(string adUnitId)
    //{
    //    Debug.Log("Ad Loaded: " + adUnitId);
    //    adsButton.interactable = true;
    //}

    //// Implement Load and Show Listener error callbacks:
    ////public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    ////{
    ////    Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    ////    // Use the error details to determine whether to try to load another ad.
    ////}

    ////public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    ////{
    ////    Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    ////    // Use the error details to determine whether to try to load another ad.
    ////}

    //public void OnUnityAdsShowStart(string adUnitId) { }
    //public void OnUnityAdsShowClick(string adUnitId) { }
}
