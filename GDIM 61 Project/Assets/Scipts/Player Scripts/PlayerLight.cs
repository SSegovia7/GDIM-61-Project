using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] private GameObject m_flashLight;

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
}
