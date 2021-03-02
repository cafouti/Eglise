using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTete : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("nom objet = " + other.gameObject.name);
    }    
}
