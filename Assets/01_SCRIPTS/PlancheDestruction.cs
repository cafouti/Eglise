using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlancheDestruction : MonoBehaviour
{
    public GameObject planche;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        if (other.gameObject.name == "Monstre(Clone)")
        {
            Debug.Log("Le monstre a tout cassé");
            Destroy(planche);
        }
    }
}
