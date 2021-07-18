using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AM_SetVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
}