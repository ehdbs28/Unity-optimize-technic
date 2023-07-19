using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceTesting : MonoBehaviour
{
    private const int NumberOfTest = 5000;

    private Transform _testTrm;

    private void PerformanceTest1(){
        for(int i = 0; i < NumberOfTest; i++){
            _testTrm = GetComponent<Transform>();
        }
    }

    private void PerformanceTest2(){
        for(int i = 0; i < NumberOfTest; i++){
            _testTrm = (Transform)GetComponent("Transform");
            // _testTrm = GetComponent("Transform").transform;
            // .도 다 연산이라 해줄빠에는 형변환
        }
    }

    private void PerformanceTest3(){
        for(int i = 0; i < NumberOfTest; i++){
            _testTrm = (Transform)GetComponent(typeof(Transform));
        }
    }

    private void Update() {
        PerformanceTest1();

        // 이게 제일 빠름 -> 1번과 3번은 함수 호출을 하나 더 함
        PerformanceTest2();

        PerformanceTest3();    
    }
}
