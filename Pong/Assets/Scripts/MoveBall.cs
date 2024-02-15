using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class MoveBall : MonoBehaviour
{
    [Header("Settings")]
    public float increaseSpeed = 1.1f;
    public float startSpeed = 10f;
    
    [Header("Paddle")]
    public GameObject paddleLeft;
    public GameObject paddleRight;
    
    private Rigidbody _rb;
    private float _speed;
    
    private Vector3 _paddleLeftPosition;
    private Vector3 _paddleRightPosition;
    
    public static List<GameObject> Balls = new List<GameObject>();

    private void Start()
    {
        Balls.Add(gameObject);
        _rb = GetComponent<Rigidbody>();
        _paddleLeftPosition = paddleLeft.transform.position;
        _paddleRightPosition = paddleRight.transform.position;
        ResetPosition();
    }

    private void Update()
    {
        Vector3 velocity = _rb.velocity;
        velocity.Normalize();
        _rb.velocity = velocity * _speed;
    }
    
    public void IncreaseSpeed()
    {
        _speed *= increaseSpeed;
        //Debug.Log("Speed increased to " + _speed);
    }
    
    public static void ResetAllPositions()
    {
        Balls[0].GetComponent<MoveBall>().ResetPosition();
        if (Balls.Count == 1) return;
        Destroy(Balls[1]);
        PowerUpNewBall.SpawnPowerUp();
        PowerUpDestroyBall.SpawnPowerUp();
        Balls.RemoveAt(1);
    }
    
    private void ResetPosition()
    {
        transform.position = Vector3.zero;
        _speed = startSpeed;
        _rb.AddForce(new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), ForceMode.Force);
        
        paddleLeft.transform.position = _paddleLeftPosition;
        paddleRight.transform.position = _paddleRightPosition;
        
        paddleLeft.GetComponent<Rigidbody>().velocity = Vector3.zero;
        paddleRight.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
