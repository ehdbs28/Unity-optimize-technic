using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAIBenchmark : MonoBehaviour
{
    GameObject[] tanks;
    public int numberOfTanks;
    public GameObject tankPrefab;

    // Start is called before the first frame update
    void Start()
    {
        tanks = new GameObject[numberOfTanks];
        for (int i = 0; i < numberOfTanks; i++)
        {
            tanks[i] = Instantiate(tankPrefab);
            tanks[i].transform.position = new Vector3(Random.Range(-50,50), 0, Random.Range(-50,50));
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject t in tanks)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                t.transform.LookAt(player.transform.position);
                t.transform.Translate(0, 0, 0.05f);
            }
        } 
    }
}
