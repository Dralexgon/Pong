using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDestroyBall : PowerUp
{
    protected static GameObject PowerUpGameObject;
    
    private GameObject _ballDisabled;
    
    private void Start()
    {
        PowerUpGameObject = gameObject;
        SpawnPowerUp();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ball")) return;
        
        PowerUpGameObject.SetActive(false);
        if (MoveBall.Balls.Count > 1)
        {
            MoveBall.Balls.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
        else
        {
            //execute the function 2 seconds later
            other.gameObject.SetActive(false);
            _ballDisabled = other.gameObject;
            Invoke(nameof(ResetAllPositions), 2f);
        }
        //particles effect
    }
    
    public static void SpawnPowerUp()
    {
        PowerUpGameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        PowerUpGameObject.SetActive(true);
        PowerUpGameObject.transform.position = new Vector3(Random.Range(-4, 4), 0.5f, Random.Range(-6, 6));
    }
    
    private void ResetAllPositions()
    {
        _ballDisabled.SetActive(true);
        MoveBall.ResetAllPositions();
    }
}
