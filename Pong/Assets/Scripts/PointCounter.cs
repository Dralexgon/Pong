using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    private TextMeshProUGUI _scoreTextLeft;
    private TextMeshProUGUI _scoreTextRight;
    
    private Vector3 _scoreTextLeftPosition;
    private Vector3 _scoreTextRightPosition;
    
    private static int _playerLeftScore;
    private static int _playerRightScore;
    
    void Start()
    {
        _playerLeftScore = 0;
        _playerRightScore = 0;
        
        _scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        _scoreTextLeft = GameObject.Find("ScoreTextLeft").GetComponent<TextMeshProUGUI>();
        _scoreTextRight = GameObject.Find("ScoreTextRight").GetComponent<TextMeshProUGUI>();
        
        _scoreTextLeftPosition = _scoreTextLeft.transform.position;
        _scoreTextRightPosition = _scoreTextRight.transform.position;
        
        UpdateText();
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
        UpdateText();
    }

    private void UpdateText()
    {
        _scoreTextLeft.text = _playerLeftScore.ToString();
        _scoreTextRight.text = _playerRightScore.ToString();
        
        // ReSharper disable once PossibleLossOfFraction
        _scoreText.fontSize = 20 + ((_playerLeftScore + _playerRightScore) / 2) * 3;
        _scoreTextLeft.fontSize = 20 + _playerLeftScore * 3;
        _scoreTextRight.fontSize = 20 + _playerRightScore * 3;
        
        _scoreText.color = new Color(1, 1 - (_playerLeftScore + _playerRightScore) * 0.05f, 1 - (_playerLeftScore + _playerRightScore) * 0.05f, 1 );
        _scoreTextLeft.color = new Color(1, 1 - _playerLeftScore * 0.1f, 1 - _playerLeftScore * 0.1f, 1 );
        _scoreTextRight.color = new Color(1, 1- _playerRightScore * 0.1f, 1- _playerRightScore * 0.1f, 1 );
        
        _scoreTextLeft.transform.position = _scoreTextLeftPosition + new Vector3(_playerLeftScore * 2f + (_playerLeftScore >= 10 ? 20 : 0), 0, 0);
        _scoreTextRight.transform.position = _scoreTextRightPosition + new Vector3(-_playerRightScore * 2f - (_playerRightScore >= 10 ? 20 : 0), 0, 0);
    }
}
