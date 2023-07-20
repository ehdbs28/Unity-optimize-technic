using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodArray : MonoBehaviour
{
    private float[] _randResultVal = null;

    private void Start() 
    {
        _randResultVal = new float[10000];    
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RandomList(_randResultVal);
        }
    }

    private void RandomList(float[] result)
    {
        for(int i = 0; i < result.Length; i++){
            result[i] = Random.value;
        }
    }
}
