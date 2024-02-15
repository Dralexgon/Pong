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
    
    private GameObject _paddleLeft;
    private GameObject _paddleRight;
    
    private Rigidbody _rb;
    private float _speed;
    
    private Vector3 _paddleLeftPosition;
    private Vector3 _paddleRightPosition;
    
    public static List<GameObject> Balls = new List<GameObject>();

    private void Start()
    {
        _paddleLeft = GameObject.Find("PaddleLeft");
        _paddleRight = GameObject.Find("PaddleRight");
        
        Balls.Add(gameObject);
        _rb = GetComponent<Rigidbody>();
        _paddleLeftPosition = _paddleLeft.transform.position;
        _paddleRightPosition = _paddleRight.transform.position;
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
        PowerUpNewBall.SpawnPowerUp();
        PowerUpDestroyBall.SpawnPowerUp();
        if (Balls.Count == 1) return;
        Destroy(Balls[1]);
        Balls.RemoveAt(1);
    }
    
    private void ResetPosition()
    {
        transform.position = Vector3.zero;
        _speed = startSpeed;
        _rb.AddForce(new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), ForceMode.Force);
        
        _paddleLeft.transform.position = _paddleLeftPosition;
        _paddleRight.transform.position = _paddleRightPosition;
        
        _paddleLeft.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _paddleRight.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
