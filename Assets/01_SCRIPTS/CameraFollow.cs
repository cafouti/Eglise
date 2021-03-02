using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform joueur;
    public Vector3 offset;
    public Vector3 offsetGeneral;
    public Vector3 offsetTunnel;
    
    public float vitesse;
    public bool droite = true;
    public bool inTunnel = false;

    void Start()
    {
        offsetGeneral = new Vector3(2, 1.4f, -12f);
        offset = offsetGeneral;
        offsetTunnel = new Vector3(2,1.4f,-7f);
    }

    // Update is called once per frame
    void Update()
    {
        Tunnel(inTunnel);
        Rotation(droite);        
        Vector3 positionFutur = joueur.position + offset ;
        Vector3 positionTransit = Vector3.Lerp(transform.position, positionFutur, vitesse*Time.deltaTime) ;
        transform.position = positionTransit;
    }

    void Rotation(bool droite)
    {
        if((droite && offset.x < 0) || (!droite && offset.x > 0))
        {
            offset.x *= -1;
        }
    }

    void Tunnel(bool inTunnel)
    {
        if(inTunnel)
        {
            offset = offsetTunnel;
        }
        else
        {
            offset = offsetGeneral;
        }
    }
}
