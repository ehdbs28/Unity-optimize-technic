using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct NPCStruct
{
    public GameObject avatar;
    public string name;
    public int health;

    public NPCStruct(string _name, GameObject go)
    {
        name = _name;
        health = 100;
        avatar = go;
    }
}

public class NPCClass
{
    public GameObject avatar;
    public string name;
    public int health;

    public NPCClass(string _name, GameObject go)
    {
        name = _name;
        health = 100;
        avatar = go;
    }
}

public class NPCTypes : MonoBehaviour
{
    const int numberOfTests = 100000;

    NPCStruct[] npcs = new NPCStruct[numberOfTests];
    NPCClass[] npcc = new NPCClass[numberOfTests];

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateStructs();
            CreateClasses();
        }

        // 함수 전달 패스 테스트
        if (Input.GetKeyDown(KeyCode.P))
        {
            PassStructs();
            PassClasses();
        }
    }

    void CreateStructs()
    {
        // var npcs = new NPCStruct[numberOfTests];
        for(int i = 0; i < numberOfTests; i++)
        {
            npcs[i] = new NPCStruct("도윤", null);
        }
    }

    void CreateClasses()
    {
        // var npcc = new NPCClass[numberOfTests];
        for(int i = 0; i < numberOfTests; i++)
        {
            npcc[i] = new NPCClass("도윤", null);
        }
    }

    void UseStruct(NPCStruct npc)
    {
    }

    void PassStructs()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            UseStruct(npcs[i]);
        }
    }

    void UseClass(NPCClass npc)
    {
    }

    void PassClasses()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            UseClass(npcc[i]);
        }
    }
}
