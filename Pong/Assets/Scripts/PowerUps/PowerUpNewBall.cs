using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpNewBall : PowerUp
{
    protected static GameObject PowerUpGameObject;
    
    public GameObject ball;
    
    private void Start()
    {
        PowerUpGameObject = gameObject;
        SpawnPowerUp();
    }
    
    public static void SpawnPowerUp()
    {
        PowerUpGameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        PowerUpGameObject.SetActive(true);
        PowerUpGameObject.transform.position = new Vector3(Random.Range(-4, 4), 0.5f, Random.Range(-6, 6));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ball")) return;
        
        PowerUpGameObject.SetActive(false);
        GameObject newBall = Instantiate(ball, Vector3.zero, Quaternion.identity);
        newBall.transform.position = PowerUpGameObject.transform.position;
    }
}
