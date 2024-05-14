using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    public sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public static AudioManager instance;

    private string currentScene;

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
        currentScene = SceneManager.GetActiveScene().name;
        if(currentScene == "MainMenu")
        {
            PlayMusic("TitleMusic");
        }
        else
        {
            PlayMusic("Ambience");
        }
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

    public void ToLevel()
    {
        musicSource.Stop();
        PlayMusic("Ambience");
    }

    public void ToMenu()
    {
        musicSource.Stop();
        PlayMusic("TitleMusic");
    }
}
