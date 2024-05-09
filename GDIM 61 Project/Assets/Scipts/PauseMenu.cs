using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_pauseMenu;
    public static bool m_isPaused;

    private void Start()
    {
        ResumeGame();
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

    private void ReturnToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void ResumeGame()
    {
        m_pauseMenu.SetActive(false);
        m_isPaused = false;
        Time.timeScale = 1f;
    }

    private void PauseGame()
    {
        m_pauseMenu.SetActive(true);
        m_isPaused = true;
        Time.timeScale = 0f;
    }
}
