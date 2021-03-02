using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionCollision : MonoBehaviour
{
    private Character character;

    void Start()
    {
        character = this.GetComponentInParent(typeof(Character)) as Character;
        
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.y > this.transform.position.y + this.transform.localScale.y && character.jumping)
        {
            character.CancelJump();
            character.jumping = false;
        }
    }
}
