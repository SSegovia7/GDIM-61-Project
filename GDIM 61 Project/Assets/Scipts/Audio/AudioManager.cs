using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;


public class AudioManager : MonoBehaviour
{
    public sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayMusic("Ambience");
    }

    public void PlayMusic(string name)
    {
        sound s = Array.Find(musicSounds, x => x.name == name);

        if (s != null)
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s != null)
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
}
