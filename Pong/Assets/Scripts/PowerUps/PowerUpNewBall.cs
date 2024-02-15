using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpNewBall : MonoBehaviour
{
    private static GameObject _powerUpGameObject;
    
    public GameObject ball;
    
    private void Start()
    {
        _powerUpGameObject = gameObject;
        SpawnPowerUp();
    }
    
    public static void SpawnPowerUp()
    {
        _powerUpGameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _powerUpGameObject.SetActive(true);
        _powerUpGameObject.transform.position = new Vector3(Random.Range(-4, 4), 0.5f, Random.Range(-6, 6));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ball")) return;
        
        _powerUpGameObject.SetActive(false);
        GameObject newBall = Instantiate(ball, Vector3.zero, Quaternion.identity);
        newBall.transform.position = _powerUpGameObject.transform.position;
    }
}
