using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] private GameObject m_player;
    [SerializeField] private float m_speed;
    [SerializeField] private float m_targetDistance;
    private float m_distance;

    private mobState m_currentState = mobState.Chasing;

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
        m_distance = Vector2.Distance(transform.position, m_player.transform.position);
        Vector2 direction = m_player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(m_distance < m_targetDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, m_player.transform.position, m_speed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        /*else
        {
            m_currentState = mobState.Wondering;
        }*/
    }

    private void retreatBehavior()
    {

    }
}
