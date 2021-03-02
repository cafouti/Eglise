using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteDestruction : MonoBehaviour
{
    public GameObject planche;
    private float characterV;
    public float minV;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Monstre(Clone)")
        {
            characterV = other.gameObject.GetComponentInParent<Character>().mouvement.x;

            if(characterV>minV)
            {
                Destroy(planche);
            }            
        }
    }
}
