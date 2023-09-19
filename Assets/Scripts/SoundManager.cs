using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    AudioSource source;
    public bool isMuted = false;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        isMuted = AudioListener.pause;
    }

    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }

    public void SoundOn()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
    }
}
