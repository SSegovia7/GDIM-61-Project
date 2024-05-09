using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] private GameObject m_flashLight;
    [SerializeField] private GameObject m_player;
    [SerializeField] private float m_minRot;
    [SerializeField] private float m_maxRot;
    [SerializeField] private Transform m_lightTransform;

    private void Start()
    {
        m_flashLight.SetActive(false);
    }

    private void Update()
    {
        if (!PauseMenu.m_isPaused)
        {
            //FlashLight(not sure if to make this a different script)
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (m_flashLight.activeInHierarchy == false)
                {
                    m_flashLight.SetActive(true);
                }
                else
                {
                    m_flashLight.SetActive(false);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float Z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        m_lightTransform.eulerAngles = new Vector3 (0f, 0f, Z);

        limitRot();
    }

    private void limitRot()
    {
        Vector3 playerEulerAngles = m_lightTransform.rotation.eulerAngles;
        playerEulerAngles.z = (playerEulerAngles.z > 180) ? playerEulerAngles.z - 360 : playerEulerAngles.z;
        playerEulerAngles.z = Mathf.Clamp(playerEulerAngles.z, m_minRot, m_maxRot);

        m_lightTransform.rotation = Quaternion.Euler(playerEulerAngles);
    }
}
