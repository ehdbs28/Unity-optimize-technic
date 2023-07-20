using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public Text _scoreText;
    // 메모리를 더 사용하고 시간을 챙김
    public Text _scoreDisplayText;

    public int _score;
    public int _oldScore;

    private string _scoreStr;

    private void Start() 
    {
        _score = 9999;   
        _scoreText.text = "Score : "; 
    }    

    private void Update() 
    {
        // update 주기를 최소화 시켜야 한다 -> Focusing!!
        if(_score != _oldScore)
        {
            if(_scoreText != null)
            {
                // 문자열을 concat하거나 format할 필요 없음
                _scoreStr = _score.ToString();
                _scoreDisplayText.text = _scoreStr;
                _oldScore = _score;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _score = Random.Range(1, 1000);
        }
    }
}
