using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    public static bool m_winState = false;

    private void Awake()
    {
        m_winState = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Add Win Menu");
            m_winState = true;
        }
    }
}
