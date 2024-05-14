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
        currentScene = SceneManager.GetActiveScene().name;
        if(currentScene == "MainMenu" && titleMusicPlaying == false)
        {
            PlayMusic("TitleMusic");
            titleMusicPlaying = true;
            ambiencePlaying = false;
        }
        if (currentScene != "MainMenu" && ambiencePlaying == false)
        {
            PlayMusic("Ambience");
            ambiencePlaying = true;
            titleMusicPlaying = false;
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
}
