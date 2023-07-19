using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpheresBenchmark : MonoBehaviour
{
    public int _number = 100;

    private Material _mat;
    private Color _color;

    Transform[] _spheres;

    private void Start()
    {
        _mat = new Material(Shader.Find($"Specular"));
        _color = Color.red;

        _spheres = new Transform[_number];

        for(int i = 0; i < _number; i++){
            Transform sphereObj = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
            Renderer rend = sphereObj.GetComponent<Renderer>();
            rend.material = _mat;
            rend.material.color = _color;
            sphereObj.position = Random.insideUnitSphere * 20f;

            _spheres[i] = sphereObj;
        }    
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach(Transform t in _spheres){
                t.Translate(0, 0, 1f);
            }
        }
    }
}
