using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodScore : MonoBehaviour
{
    public Text _scoreText;

    public int _score;
    public int _oldScore;

    private string _scoreStr;

    private void Start() 
    {
        _score = 9999;    
    }    

    private void Update() 
    {
        // update 주기를 최소화 시켜야 한다 -> Focusing!!
        if(_score != _oldScore)
        {
            if(_scoreText != null)
            {
                _scoreStr = "Score : " + _score.ToString();
                _scoreText.text = _scoreStr;
                _oldScore = _score;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _score = Random.Range(1, 1000);
        }
    }
}
