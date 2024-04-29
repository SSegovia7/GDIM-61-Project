using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float camSpeed;

    //follows the player when the game is playing
    private void FixedUpdate()
    {
        Vector3 updatedPos = Player.position + offset;
        transform.position = Vector3.Lerp(transform.position, updatedPos, camSpeed * Time.deltaTime);
    }
}
