using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] private GameObject m_mob;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("FlashLight"))
        {
            //
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("FlashLight"))
        {
            //
        }
    }
}
