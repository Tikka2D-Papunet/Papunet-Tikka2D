using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; //{ get; private set; }
    AudioSource source;
    public bool isMuted = false;

    private void Awake()
    {
        instance = this;

        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        isMuted = source.mute;

        if(PlayerPrefs.HasKey("IsMuted"))
        {
            isMuted = PlayerPrefs.GetInt("IsMuted") == 1;
        }
    }

    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }

    public void SoundOn()
    {
        isMuted = !isMuted;
        source.mute = isMuted;

        PlayerPrefs.SetInt("IsMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void AgainButtonFunction()
    {
        SceneManager.LoadScene(1);
    }
}
