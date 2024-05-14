using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject audioManager;

    private AudioManager audioScript;

    private void Start()
    {
        audioScript = audioManager.GetComponent<AudioManager>();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeMusic()
    {
        audioScript.ToLevel();
    }
}
