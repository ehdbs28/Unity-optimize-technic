using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrannyControls : MonoBehaviour
{
    Animator anim;
    float speed = 0.1f;

    private readonly int _runningAnimHash = Animator.StringToHash("running");

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool(_runningAnimHash, true);
            this.transform.position += this.transform.forward * speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool(_runningAnimHash, true);
            this.transform.position -= this.transform.forward * speed;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool(_runningAnimHash, false);
        }
    }
}
