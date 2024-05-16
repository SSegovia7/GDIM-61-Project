using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = true;
    }

    private void Update()
    {
        if (PauseMenu.m_isPaused || PlayerMove.m_playerDeath)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }
}
