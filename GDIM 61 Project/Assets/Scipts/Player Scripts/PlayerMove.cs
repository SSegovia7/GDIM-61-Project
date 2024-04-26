using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Getting and setting player movement
    [SerializeField] private Rigidbody2D m_rb;
    [SerializeField] private float m_speed;
    private float moveForce;


    void Update()
    {
        //Character moves side to side
        moveForce = Input.GetAxis("Horizontal");
        m_rb.velocity = new Vector2(moveForce * m_speed, m_rb.velocity.y);

        //FlashLight(not sure if to make this a different script)
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("HEY, LISTEN");
        }
    }
}
