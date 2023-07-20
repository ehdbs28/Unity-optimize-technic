using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    Vector3 velocity;
    float sides = 30.0f;
    float speedMax = 0.3f;

    int colorPropertyID;

    void Start()
    {

        velocity = new Vector3(Random.Range(0.0f, speedMax),
                        Random.Range(0.0f, speedMax),
                        Random.Range(0.0f, speedMax));

        colorPropertyID = Shader.PropertyToID("_Color");
    }

    Color GetRandomColor()
    {
        return new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

    void Update()
    {
        transform.Translate(velocity);

        if (transform.position.x > sides)
        {
            velocity.x = -velocity.x;
        }
        if (transform.position.x < -sides)
        {
            velocity.x = -velocity.x;
        }
        if (transform.position.y > sides)
        {
            velocity.y = -velocity.y;
        }
        if (transform.position.y < -sides)
        {
            velocity.y = -velocity.y;
        }
        if (transform.position.z > sides)
        {
            velocity.z = -velocity.z;
        }
        if (transform.position.z < -sides)
        {
            velocity.z = -velocity.z;
        }

        // this.GetComponent<Renderer>().material.SetColor("_Color", new Color(transform.position.x / sides,
        //                                                                      transform.position.y / sides,
        //                                                                    transform.position.z / sides));

        this.GetComponent<Renderer>().material.SetColor(colorPropertyID, new Color(transform.position.x / sides,
                                                                             transform.position.y / sides,
                                                                           transform.position.z / sides));
    }
}
