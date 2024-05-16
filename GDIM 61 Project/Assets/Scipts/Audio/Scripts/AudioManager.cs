using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private float mainVolume;
    private float currentVolume;

    public sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource, sfxLoop;

    public static AudioManager instance;

    private string currentScene;

    public bool titleMusicPlaying = false;
    public bool ambiencePlaying = false;

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

    private void FixedUpdate()
    {
        musicSource.volume = currentVolume;

        currentScene = SceneManager.GetActiveScene().name;
        if(currentScene == "MainMenu")
        {
            currentVolume = mainVolume;

            if (titleMusicPlaying == false)
            {
                musicSource = musicSource.GetComponent<AudioSource>();
                PlayMusic("TitleMusic");
                titleMusicPlaying = true;
                ambiencePlaying = false;
            }
        }
        if (currentScene != "MainMenu")
        {
            currentVolume = mainVolume / 4;

            if(ambiencePlaying == false)
            {
                musicSource = musicSource.GetComponent<AudioSource>();
                PlayMusic("Ambience");
                ambiencePlaying = true;
                titleMusicPlaying = false;
            }
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

    public void PlayLoopSFX(string name)
    {
        sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s != null)
        {
            sfxLoop.clip = s.clip;
            sfxLoop.Play();
        }
    }

    public void StopLoopSFX(string name)
    {
        sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s != null)
        {
            sfxLoop.clip = s.clip;
            sfxLoop.Stop();
        }
    }
}
