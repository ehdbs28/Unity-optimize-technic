using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyObjectCreator : MonoBehaviour
{
    public int numberOfObjects;

    GameObject dummyObj;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateObjects();
        }   

        if(Input.GetKeyUp(KeyCode.Space)) 
        {
            DestroyObjects();
        }
    }

    void CreateObjects()
    {
        for(int i = 0; i < numberOfObjects; i++)
        {
            dummyObj = new GameObject("A_Dummy");
            dummyObj.tag = "Player";
        }
    }

    void DestroyObjects()
    {
        GameObject[] dummyObjs = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < numberOfObjects; i++)
        {
            Destroy(dummyObjs[i]);
            // DestroyImmediate(dummyObjs[i]);
        }
    }
}
