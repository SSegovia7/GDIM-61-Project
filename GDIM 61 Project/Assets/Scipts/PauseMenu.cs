using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_pauseMenu;
    private bool m_isPaused;

    private void Start()
    {
        pauseMenuDefault();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            m_pauseMenu.SetActive(true);
            m_isPaused = true;
        }
    }

    private void pauseMenuDefault()
    {
        m_pauseMenu.SetActive(false);
        m_isPaused = false;
    }

    private void returnToMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void resumeGame()
    {
        pauseMenuDefault();
    }
}
