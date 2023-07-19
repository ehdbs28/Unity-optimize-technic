using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyListCreator : MonoBehaviour
{
    public int numberOfLists;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateLists();
        }
    }

    void CreateLists()
    {
        for(int i = 0; i < numberOfLists; i++)
        {
            List<string> nameList = new List<string>(numberOfLists);
        }
    }
}
