using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10.0f;
    
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        //V1
        transform.position += new Vector3(Input.GetAxis("Vertical") * speed * 4 * Time.deltaTime, 0, 0);
        //Vector3 force = Vector3.right * (Input.GetAxis("Vertical") * speed);
        //_rb.AddForce(force, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Paddle hit " + other.gameObject.name);
        
        if (!other.gameObject.CompareTag("Ball")) return;
        
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        Bounds bounds = boxCollider.bounds;
        float maxX = bounds.max.x;
        float minX = bounds.min.x;
        
        float ballX = other.transform.position.x;
        
        float x = (ballX - minX) / (maxX - minX);
        x = (x * 2) - 1;
        
        float zSign = -Mathf.Sign(other.gameObject.GetComponent<Rigidbody>().velocity.z);

        Quaternion rotation = Quaternion.Euler(0, x * 60 * zSign, 0);
        Vector3 bounceDirection = rotation * Vector3.forward * zSign;
        
        Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();
        otherRb.AddForce(bounceDirection * 1000, ForceMode.Force);
        
        
        MoveBall moveBall = other.gameObject.GetComponent<MoveBall>();
        moveBall.IncreaseSpeed();
    }
}
