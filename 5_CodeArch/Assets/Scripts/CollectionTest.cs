using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
1. 데이터 추가 (Add)
2. 데이터를 반복(순회)한다. (Iterate)
3. 검색 (Search)
4. 삭제 (Remove)
*/

public class CollectionTest : MonoBehaviour
{
    const int numberOfTests = 10000;

    int[] invenArr = new int[numberOfTests];
    Dictionary<int, int> invenDic = new Dictionary<int, int>();
    List<int> invenList = new List<int>();
    HashSet<int> invenHash = new HashSet<int>();

    private void Start() 
    {
        AddValuesInArray();
        AddValuesInDic();
        AddValuesInList();
        AddValuesInHash();
    }

    private void Update() 
    {
        // 출력
        if(Input.GetKeyDown(KeyCode.C))
        {
            PrintValuesInArray();
            PrintValuesInDic();
            PrintValuesInList();
            PrintValuesInHash();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ContainsValuesInArray();
            ContainsValuesInDict();
            ContainsValuesInList();
            ContainsValuesInHash();
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            RemoveValuesInArray();
            RemoveValuesInDict();
            RemoveValuesInList();
            RemoveValuesInHash();
        }
    }

    private void AddValuesInHash()
    {
        for(int i = 0; i < numberOfTests; i++)
        {
            invenArr[i] = Random.Range(10, 100);
        }
    }

    private void AddValuesInList()
    {
        for(int i = 0; i < numberOfTests; i++)
        {
            invenDic.Add(i, Random.Range(10, 100));
        }
    }

    private void AddValuesInDic()
    {
        for(int i = 0; i < numberOfTests; i++)
        {
            invenList.Add(Random.Range(10, 100));
        }
    }

    private void AddValuesInArray()
    {
        for(int i = 0; i < numberOfTests; i++)
        {
            invenHash.Add(Random.Range(10, 100));
        }
    }

    //=========================================

    private void PrintValuesInHash()
    {
        foreach(int i  in invenHash)
        {
            Debug.Log(i);
        }
    }

    private void PrintValuesInList()
    {
        foreach(int i in invenList)
        {
            Debug.Log(i);
        }
    }

    private void PrintValuesInDic()
    {
        foreach(KeyValuePair<int, int> i in invenDic)
        {
            Debug.Log(i.Value);
        }
    }

    private void PrintValuesInArray()
    {
        foreach(int i in invenArr)
        {
            Debug.Log(i);
        }
    }

    //=========================================

    private void ContainsValuesInArray()
    {
        int searchValue = 5000;
        bool bFound = false;
        for(int i = 0; i < numberOfTests; i++)
        {
            if(invenArr[i] == searchValue)
                bFound = true;
        }

        Debug.Log(bFound);
    }

    private void ContainsValuesInDict()
    {
        int searchValue = 5000;
        bool bFound = invenDic.ContainsKey(searchValue);
    }

    private void ContainsValuesInList()
    {
        int searchValue = 5000;
        bool bFound = invenList.Contains(searchValue);
    }

    private void ContainsValuesInHash()
    {
        int searchValue = 5000;
        bool bFound = invenHash.Contains(searchValue);
    }

    //=========================================

    void RemoveValuesInArray()
    {
        int index = 5000;
        int[] temp = new int[invenArr.Length - 1];
        int tempCount = 0;

        for(int i = 0; i < invenArr.Length; i++)
        {
            if(i == index)
            {
                temp[tempCount++] = invenArr[i];
            }
        }

        invenArr = temp;
    }

    void RemoveValuesInDict()
    {
        int searchValue = 5000;
        bool found = invenDic.Remove(searchValue);
    }

    void RemoveValuesInList()
    {
        int searchValue = 5000;
        bool found = invenList.Remove(searchValue);
    }

    void RemoveValuesInHash()
    {
        int searchValue = 5000;
        bool found = invenHash.Remove(searchValue);
    }
}   