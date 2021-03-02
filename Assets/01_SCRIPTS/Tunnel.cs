using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour
{
    public CameraFollow cam;
    public Character character;
    private float initSpeed = 0;
    public float crouchSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Fille(Clone)")
        {
            if(initSpeed == 0)
            {
                initSpeed = character.speed;
            }
            cam.inTunnel = true;
            initSpeed = character.speed;
            character.speed = crouchSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Fille(Clone)")
        {
            cam.inTunnel = false;
            character.speed = initSpeed;
        }
    }
}
