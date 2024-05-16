using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseDeathMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_pauseMenu;
    public static bool m_isPaused;

    [SerializeField] private GameObject m_deathMenu;

    private void Start()
    {
        m_pauseMenu.SetActive(false);
        m_deathMenu.SetActive(false);
        ResumeGame();
    }

    private void Update()
    {
        if (!PlayerMove.m_playerDeath) 
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
        else
        {
            m_deathMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        m_pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        m_isPaused = false;
    }

    public void ReturnToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void PauseGame()
    {
        m_pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        m_isPaused = true;
    }

    public void Restart()
    {
        m_deathMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        PlayerMove.m_playerDeath = false;
    }
}
