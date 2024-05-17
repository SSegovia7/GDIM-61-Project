using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] private GameObject m_player;
    [SerializeField] private float m_speed;
    [SerializeField] private float m_targetDistance;
    private float m_distance;

    [SerializeField] private GameObject m_door;

    private mobState m_currentState = mobState.Wondering;

    //For chase sfx
    [SerializeField] private GameObject audioManager;
    private AudioManager audioScript;

    private enum mobState
    {
        Wondering, 
        Chasing, 
        Retreat
    }

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager");
        audioScript = audioManager.GetComponent<AudioManager>();
    }

    private void Update()
    {
        switch (m_currentState)
        {
            case mobState.Wondering:
                //audioScript.StopLoopSFX("heartbeat");
                wonderingBehavior();
                break;
            case mobState.Chasing:
                chasingBehavior();
                //audioScript.PlayLoopSFX("heartbeat");
                break;
            case mobState.Retreat:
                retreatBehavior();
                //audioScript.StopLoopSFX("heartbeat");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("FlashLight"))
        {
            m_currentState = mobState.Retreat;
        }
        
        if (collider.gameObject.CompareTag("Door") && m_currentState == mobState.Retreat)
        {
            Destroy(this.gameObject);
        }
    }

    private void wonderingBehavior()
    {
        m_distance = Vector2.Distance(transform.position, m_player.transform.position);
        Vector2 direction = m_player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (m_distance < m_targetDistance)
        {
            m_currentState = mobState.Chasing;
        }
    }

    private void chasingBehavior()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, m_player.transform.position, m_speed * Time.deltaTime);
    }

    private void retreatBehavior()
    {
        m_distance = Vector2.Distance(transform.position, m_door.transform.position);
        Vector2 newDirection = m_door.transform.position - transform.position;
        newDirection.Normalize();
        float angle = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, m_door.transform.position, m_speed * Time.deltaTime);
    }
}
