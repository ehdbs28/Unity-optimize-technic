using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landscape : MonoBehaviour
{
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject block4;

    public int width = 100;
    public int depth = 100;

    void Start()
    {
        for (int z = 0; z < depth; z++)
        {
            for (int x = 0; x < width; x++)
            {
                float height = Mathf.PerlinNoise(x / 50f, z / 50f) * 50 + Mathf.PerlinNoise((x + 25) / 30f, (z + 25) / 30f) * 50;

                Vector3 pos = new Vector3(x, height, z);
                if (height > 60)
                    Instantiate(block1, pos, Quaternion.identity);
                else if (height > 50)
                    Instantiate(block2, pos, Quaternion.identity);
                else if (height > 30)
                    Instantiate(block3, pos, Quaternion.identity);
                else
                    Instantiate(block4, pos, Quaternion.identity);
            }
        } 
    }
}
