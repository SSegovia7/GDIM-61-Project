using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        if (PauseMenu.m_isPaused || PlayerMove.m_playerDeath || Fridge.m_winState)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }
}
