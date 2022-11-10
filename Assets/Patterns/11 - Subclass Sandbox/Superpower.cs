using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Superpower
{
    private SoundPlayer _soundPlayer;

    public abstract void Activate();

    protected void Move(Vector2 destination)
    {
        Debug.Log($"Moving to {destination.x}, {destination.y}");
    }

    /*protected void PlaySound(string sound)
    {
        Debug.Log($"Playing {sound} sound");
    }*/

    protected SoundPlayer GetSoundPlayer()
    {
        if(_soundPlayer == null)
            _soundPlayer = new SoundPlayer();

        return _soundPlayer;
    }

    protected void SpawnParticles(string particles)
    {
        Debug.Log($"Playing {particles} particles");

        //The book says you could use the Service Locator pattern here, with an ParticleSystem class
        //Still to learn
    }
}
