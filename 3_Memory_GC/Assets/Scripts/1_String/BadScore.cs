using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadScore : MonoBehaviour
{
    public Text _scoreText;
    public int _score;

    private string _scoreStr;

    private void Start() 
    {
        _score = 9999;    
    }    

    private void Update() 
    {
        if(_scoreText != null)
        {
            _scoreStr = "Score : " + _score.ToString();
            _scoreText.text = _scoreStr;
        }
    }
}
