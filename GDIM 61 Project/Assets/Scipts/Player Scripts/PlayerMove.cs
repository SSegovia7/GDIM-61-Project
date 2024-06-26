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
    public static bool m_playerDeath = false;

    //Player Sounds
    private GameObject audioManager;
    private AudioManager audioScript;
    private Animator animatorPar;
    //private bool notMoving = true;


    private void Start()
    {
        animatorPar = GetComponent<Animator>();
        audioManager = GameObject.Find("AudioManager");
        audioScript = audioManager.GetComponent<AudioManager>();
        facingRight = true;
    }

    private void FixedUpdate()
    {
        if (!m_playerDeath)
        {
            //Character moves side to side
            inputHorizontal = Input.GetAxis("Horizontal");
            m_rb.velocity = new Vector2(inputHorizontal * m_speed, m_rb.velocity.y);

            //Flipping Character
            if (inputHorizontal > 0 && !facingRight)
            {
                Flip();

                //Set footsteps active
                //notMoving = false;
            }

            if (inputHorizontal < 0 && facingRight)
            {
                Flip();

                //Set footsteps active
                //notMoving = false;
            }

            //Set animator parameters
            animatorPar.SetBool("WalkForward", inputHorizontal != 0);
        }

        /*if (notMoving == false)
        {
            audioScript.PlayLoopSFX("playerFootsteps");
            notMoving = true;
        }
        else
        {
            audioScript.StopLoopSFX("playerFootsteps");
            notMoving = true;
        }*/
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            m_playerDeath = true;
            audioScript.StopLoopSFX("heartbeat");
        }
    }
}
