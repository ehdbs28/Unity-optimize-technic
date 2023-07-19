using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    private Transform[] _tanks;

    public int _tankCount;

    public GameObject _tankPrefab;

    public GameObject _player;

    private void Start()
    {
        _tanks = new Transform[_tankCount];

        GameObject tank;
        for (int i = 0; i < _tankCount; i++)
        {   
            tank = Instantiate(_tankPrefab);
            tank.transform.position = new Vector3(Random.Range(-50,50), 0, Random.Range(-50,50));

            _tanks[i] = tank.transform;
        }
    }

    private void Update() 
    {
        foreach(Transform t in _tanks)
        {
            t.LookAt(_player.transform.position);
            t.Translate(0, 0, 0.05f);
        }    
    }
}
