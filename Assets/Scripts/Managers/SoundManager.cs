using UnityEngine;
using UnityEngine.SceneManagement;
public class SoundManager : MonoBehaviour
{
    #region Singleton
    public static SoundManager Instance; //{ get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    #endregion
    AudioSource source;
    public bool isMuted = false;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        isMuted = PlayerPrefs.GetInt("isMuted", 0) == 1;
        source.mute = isMuted;
    }
    public void PlaySound(AudioClip sound)
    {
        if(!isMuted)
            source.PlayOneShot(sound);
    }
    public void ToggleSoundOnOrOff()
    {
        isMuted = !isMuted;
        source.mute = isMuted;
        PlayerPrefs.SetInt("isMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void AgainButtonFunction()
    {
        SceneManager.LoadScene(1);
    }
}