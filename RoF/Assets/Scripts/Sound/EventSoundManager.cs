using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSoundManager : MonoBehaviour
{
    AudioSource audio;
    public float volumeBooster = 0.005f;
    public float volumeReducer = 0.1f;
    public float maxVolume = 0.2f;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = 0f;
    }
    public void PlaySound()
    {
        audio.volume += Time.deltaTime * volumeBooster;
        if(audio.volume > maxVolume)
            audio.volume = maxVolume;
    }

    public void StopSound()
    {
        audio.volume = 0;
    }
}
