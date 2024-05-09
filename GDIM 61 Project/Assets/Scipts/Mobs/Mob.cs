using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    private mobState m_currentState = mobState.Wondering;

    private enum mobState
    {
        Wondering, 
        Chasing, 
        Retreat
    }

    private void Update()
    {
        switch (m_currentState)
        {
            case mobState.Wondering:
                wonderingBehavior();
                break;
            case mobState.Chasing:
                chasingBehavior();
                break;
            case mobState.Retreat:
                retreatBehavior();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("FlashLight"))
        {
            Debug.Log("AH!");
        }
    }

    private void wonderingBehavior()
    {

    }

    private void chasingBehavior()
    {

    }

    private void retreatBehavior()
    {

    }
}
