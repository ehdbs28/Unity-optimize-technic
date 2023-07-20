using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class SpeedTest : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StringDemoFunc();
        }
    }

    void StringDemoFunc()
    {
        // 스트링 vs 스트링빌더 속도 테스트
        // string -> 약 19000ms stringBuilder -> 1000ms 미만
        // 약 20배 정도 차이남

        string s = "";
        StringBuilder sb = new StringBuilder();

        Debug.Log($"StartTime : {DateTime.Now.ToLongTimeString()}");

        for(int i = 0; i < 100000; i++)
        {
            //s += "Hi ";
            sb.Append("Hi ");
        }

        Debug.Log($"EndTime : {DateTime.Now.ToLongTimeString()}");

        Debug.Log(sb.ToString());
    }
}
