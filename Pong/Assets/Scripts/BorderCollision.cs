using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ball")) return;
        
        MoveBall moveBall = other.gameObject.GetComponent<MoveBall>();
        moveBall.ResetPosition();
    }
}
