using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    private static int _playerLeftScore;
    private static int _playerRightScore;
    
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
            Debug.Log($"Right player score ({_playerLeftScore} - {_playerRightScore})");
        }
        else
        {
            _playerLeftScore++;
            Debug.Log($"Left player score ({_playerLeftScore} - {_playerRightScore})");
        }
        
        if (_playerLeftScore >= 11 || _playerRightScore >= 11)
        {
            Debug.Log("Game over");
            _playerLeftScore = 0;
            _playerRightScore = 0;
        }
        
        MoveBall.ResetAllPositions();
    }
}
