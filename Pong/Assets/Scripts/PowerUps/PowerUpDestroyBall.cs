using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDestroyBall : MonoBehaviour
{
    private static GameObject _powerUpGameObject;
    private AudioManager _audioManager;
    
    private GameObject _ballDisabled;
    
    private void Start()
    {
        _powerUpGameObject = gameObject;
        _audioManager = FindObjectOfType<AudioManager>();
        SpawnPowerUp();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ball")) return;
        
        _powerUpGameObject.SetActive(false);
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
        _audioManager.Play("BOOM");
    }
    
    public static void SpawnPowerUp()
    {
        _powerUpGameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _powerUpGameObject.SetActive(true);
        _powerUpGameObject.transform.position = new Vector3(Random.Range(-4, 4), 0.5f, Random.Range(-6, 6));
    }
    
    private void ResetAllPositions()
    {
        _ballDisabled.SetActive(true);
        MoveBall.ResetAllPositions();
    }
}
