using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpheresBenchmark : MonoBehaviour
{
    public int _number = 100;

    private void Start()
    {
        for(int i = 0; i < _number; i++){
            GameObject sphereObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Renderer rend = sphereObj.GetComponent<Renderer>();
            rend.material = new Material(Shader.Find($"Specular"));
            rend.material.color = Color.red;
            sphereObj.transform.position = Random.insideUnitSphere * 20f;
        }    
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Transform[] spheres = GameObject.FindObjectsOfType<Transform>();
            foreach(Transform t in spheres){
                t.Translate(0, 0, 1f);
            }
        }
    }
}