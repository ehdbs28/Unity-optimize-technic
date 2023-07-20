using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMDontDestroyOnLoad : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
