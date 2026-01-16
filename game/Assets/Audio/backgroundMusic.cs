using UnityEngine;

public class MusicLooper : MonoBehaviour
{
    public AudioSource musicSource;

    void Start()
    {
        musicSource.loop = true;
        musicSource.Play();
    }
    
    public void SetVolume(float volume)
    {
        musicSource.volume = Mathf.Clamp01(volume);
    }
}