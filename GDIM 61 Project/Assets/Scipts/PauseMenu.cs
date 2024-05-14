using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_pauseMenu;
    public static bool m_isPaused;

    [SerializeField]
    private GameObject audioManager;

    private AudioManager audioScript;

    private void Start()
    {
        m_pauseMenu.SetActive(false);
        ResumeGame();

        audioScript = audioManager.GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (m_isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ReturnToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ResumeGame()
    {
        m_pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        m_isPaused = false;
    }

    public void PauseGame()
    {
        m_pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        m_isPaused = true;
    }

    public void ChangeMusic()
    {
        audioScript.ToMenu();
    }
}
