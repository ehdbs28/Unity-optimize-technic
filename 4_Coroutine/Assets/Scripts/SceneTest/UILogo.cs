using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogo : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MGScene.Instance.ChangeScene(eSceneName.Title);
        }
    }
}
