using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [DoNotSerialize] public static AudioManager instance;
    [Header("------------Audio Source --------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("------------Audio Clips -------------")]
    public AudioClip gameTheme;
    public AudioClip gameOverTheme;
    public AudioClip attack;
    public AudioClip jump;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else Destroy(gameObject);
        musicSource.volume = 0.35f;

    }
    void Start()
    {

    }
    public void StartMusic()
    {
        musicSource.volume = 0.35f;
        musicSource.clip = gameTheme;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void StartGameOverTheme()
    {
        if (sfxSource.isPlaying) 
        {
            sfxSource.Stop();
        }
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
        musicSource.clip = gameOverTheme;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip audio)
    {
        sfxSource.PlayOneShot(audio);
    }
}