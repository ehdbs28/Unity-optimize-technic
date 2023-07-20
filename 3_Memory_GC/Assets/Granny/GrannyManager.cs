using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrannyManager : MonoBehaviour
{
    public int numberOfGranniesRow;
    public int numberOfGranniesCol;
    public GameObject grannyPrefab;

    void Start()
    {
        for (int z = 0; z < numberOfGranniesRow; z++)
        {
            for (int x = -(int)(numberOfGranniesCol / 2.0f); x < numberOfGranniesCol / 2.0f; x++)
            {
                GameObject go = Instantiate(grannyPrefab);
                go.transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
