using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer
{
    public void PlaySound(string sound)
    {
        Debug.Log($"Playing {sound} sound");
    }

    public void StopSound(string sound)
    {
        Debug.Log($"Stopping {sound} sound");
    }

    public void SetVolume(float volume)
    {
        Debug.Log($"Setting volume to {volume}");
    }
}
