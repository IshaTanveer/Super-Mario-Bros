using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioClip background;
    public AudioClip gameOver;
    public AudioClip jump;
    public AudioClip coin;
    public AudioClip thud;
    private void Start()
    {
        playMusic(background);
    }
    public void playSFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    private void playMusic(AudioClip background)
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}
