using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadArray : MonoBehaviour
{
    private float[] _randResultVal;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _randResultVal = RandomList(10000);
        }
    }

    private float[] RandomList(int cnt)
    {
        float[] result = new float[cnt];
        
        for(int i = 0; i < cnt; i++){
            result[i] = Random.value;
        }

        return result;
    }
}
