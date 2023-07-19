using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadString : MonoBehaviour
{
    string[] testStr = { "a", "b", "c", "d", "e" };

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < 1000; i++)
            {
                ConcatExample(testStr);
            }
        }    
    }

    string ConcatExample(string[] strArr)
    {
        string result = "";

        for(int i = 0; i < strArr.Length; i++)
        {
            result += strArr[i];
        }

        return result;
    }
}
