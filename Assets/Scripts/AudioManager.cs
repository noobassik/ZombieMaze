using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource sfx;
    public AudioSource music;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }


    public void PlaySFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }
}
