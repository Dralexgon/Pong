using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    private int _playerLeftScore;
    private int _playerRightScore;
    
    void Start()
    {
        _playerLeftScore = 0;
        _playerRightScore = 0;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ball")) return;
        
        if (other.transform.position.z < 0)
        {
            _playerRightScore++;
            Debug.Log("Right player score: " + _playerRightScore);
        }
        else
        {
            _playerLeftScore++;
            Debug.Log("Left player score: " + _playerLeftScore);
        }
        other.gameObject.GetComponent<MoveBall>().ResetPosition();
    }
}
