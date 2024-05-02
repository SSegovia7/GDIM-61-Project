using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] private GameObject m_flashLight;
    private Transform m_lightTransform;
    public GameObject m_player;

    private void Awake()
    {

        m_lightTransform = transform.Find("Arm");
    }

    private void Start()
    {
        m_flashLight.SetActive(false);
    }

    private void Update()
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

    private void FixedUpdate()
    {
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float Z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        m_lightTransform.eulerAngles = new Vector3 (0f, 0f, Z);
    }
}
