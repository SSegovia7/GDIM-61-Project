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
    [SerializeField] private GameObject m_winMenu;

    private void Awake()
    {
        m_pauseMenu.SetActive(false);
        m_deathMenu.SetActive(false);
        m_winMenu.SetActive(false);
        ResumeGame();
    }

    private void Update()
    {
        if (!PlayerMove.m_playerDeath && !Fridge.m_winState) 
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
        else if (PlayerMove.m_playerDeath)
        {
            m_deathMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (Fridge.m_winState)
        {
            m_winMenu.SetActive(true);
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
        FalseActiveMenus();
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
        FalseActiveMenus();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    private void FalseActiveMenus()
    {
        m_deathMenu.SetActive(false);
        m_winMenu.SetActive(false);

        PlayerMove.m_playerDeath = false;
        Fridge.m_winState = false;
        Time.timeScale = 1.0f;
    }
}
