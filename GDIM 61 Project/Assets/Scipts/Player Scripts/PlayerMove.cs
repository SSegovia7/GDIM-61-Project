using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Getting and setting player movement
    [SerializeField] private Rigidbody2D m_rb;
    [SerializeField] private float m_speed;
    private float inputHorizontal;
    public static bool facingRight = true;

    private void FixedUpdate()
    {
        //Character moves side to side
        inputHorizontal = Input.GetAxis("Horizontal");
        m_rb.velocity = new Vector2(inputHorizontal * m_speed, m_rb.velocity.y);
        
        //Flipping Character
        if (inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }

        if (inputHorizontal < 0 && facingRight)
        {
            Flip();
        }

    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
