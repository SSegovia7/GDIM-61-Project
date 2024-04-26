using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Getting and setting player movement
    [SerializeField] private Rigidbody2D m_rb;
    [SerializeField] private float m_speed;
    private float moveForce;

    [SerializeField] private GameObject m_flashLight;

    private void Start()
    {
        m_flashLight.SetActive(false);
    }

    private void Update()
    {
        //Character moves side to side
        moveForce = Input.GetAxis("Horizontal");
        m_rb.velocity = new Vector2(moveForce * m_speed, m_rb.velocity.y);

        //FlashLight(not sure if to make this a different script)
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_flashLight.SetActive(true);
        }
        
        if (Input.GetKeyUp(KeyCode.Mouse0))
        { 
            m_flashLight.SetActive(false);
        }
    }
}
