using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLight : MonoBehaviour
{
    //Flash Light Movement
    [SerializeField] private GameObject m_flashLight;
    [SerializeField] private GameObject m_player;
    [SerializeField] private float m_minRot;
    [SerializeField] private float m_maxRot;
    [SerializeField] private float m_minLeftRot;
    [SerializeField] private float m_maxLeftRot;
    [SerializeField] private Transform m_lightTransform;

    //Flash Light Timer/Battery
    [SerializeField] private Slider m_batterySlider;
    [SerializeField] private int m_maxTime;
    [SerializeField] private float m_currentTime;
    //private bool m_activeTimer;

    //Flash Light Audio
    [SerializeField] private GameObject audioManager;
    private AudioManager audioScript;

    private void Start()
    {
        audioScript = audioManager.GetComponent<AudioManager>();

        m_flashLight.SetActive(false);

        m_currentTime = m_maxTime;
        if (m_currentTime == m_maxTime)
        {
            m_batterySlider.value = m_currentTime;
        }
    }

    private void Update()
    {
        if (!PauseDeathMenu.m_isPaused && !PlayerMove.m_playerDeath)
        {
            //FlashLight
            m_batterySlider.value = m_currentTime;

            if (Input.GetKeyDown(KeyCode.Mouse0) && m_currentTime > 0)
            {
                //m_activeTimer == true;
                if (m_flashLight.activeInHierarchy == false)
                {
                    m_flashLight.SetActive(true);
                }
                else
                {
                    m_flashLight.SetActive(false);
                }
            }
            
            if(m_flashLight.activeInHierarchy == true && m_currentTime > 0)
            {
                m_currentTime -= Time.deltaTime;
            }

            if (m_currentTime < 0)
            {
                m_currentTime = 0;
                m_flashLight.SetActive(false);
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float Z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        m_lightTransform.eulerAngles = new Vector3 (0f, 0f, Z);

        if (!PlayerMove.facingRight)
        {
            limitLeftRot();
        }
        else
        {
            limitRot();
        }
    }

    private void limitRot()
    {
        Vector3 playerEulerAngles = m_lightTransform.rotation.eulerAngles;
        playerEulerAngles.z = (playerEulerAngles.z > 180) ? playerEulerAngles.z - 360 : playerEulerAngles.z;
        playerEulerAngles.z = Mathf.Clamp(playerEulerAngles.z, m_minRot, m_maxRot);

        m_lightTransform.rotation = Quaternion.Euler(playerEulerAngles);
    }

    private void limitLeftRot()
    {
        Vector3 playerEulerAngles = m_lightTransform.rotation.eulerAngles;
        playerEulerAngles.z = (playerEulerAngles.z > 180) ? playerEulerAngles.z - 360 : playerEulerAngles.z;
        playerEulerAngles.z = Mathf.Clamp(playerEulerAngles.z, m_minLeftRot, m_maxLeftRot);

        m_lightTransform.rotation = Quaternion.Euler(playerEulerAngles);
    }
}
