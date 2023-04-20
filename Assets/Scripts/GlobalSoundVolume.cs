using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GlobalSoundVolume : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup AudioMixerGroup;

    public void SetMasterValueSounds(float valueme)
    {
        AudioMixerGroup.audioMixer.SetFloat("Master", Mathf.Lerp(-80,0, valueme));
    }
}
