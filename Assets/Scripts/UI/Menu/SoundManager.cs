using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Music;

    public void SetMusicEnabel(bool isEnabel)
    {
        if (isEnabel)
            Music.Play();
        else
            Music.Pause();
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}
