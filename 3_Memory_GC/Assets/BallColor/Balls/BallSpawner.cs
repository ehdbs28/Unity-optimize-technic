using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public int numBalls = 1000;
    Color color;

    void Start()
    {
        for (int i = 0; i < numBalls; i++)
        {
            color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            GameObject ball = Instantiate(ballPrefab);
            ball.transform.parent = this.transform;
            ball.transform.position = new Vector3(Random.Range(-30.0f, 30.0f), Random.Range(-30.0f, 30.0f), Random.Range(-30.0f, 30.0f));
            ball.GetComponent<Renderer>().material.color = color;
        }
    }
}
