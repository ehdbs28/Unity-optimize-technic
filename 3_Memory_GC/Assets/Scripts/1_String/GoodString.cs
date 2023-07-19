using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodString : MonoBehaviour
{
    string[] testStr = { "a", "b", "c", "d", "e" };

    private StringBuilder _sb = new StringBuilder();

    private void Start() 
    {
        _sb.Clear();    
    }

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
        _sb.Clear();

        for(int i = 0; i < strArr.Length; i++)
        {
            _sb.Append(strArr[i]);
        }

        return _sb.ToString();
    }
}
