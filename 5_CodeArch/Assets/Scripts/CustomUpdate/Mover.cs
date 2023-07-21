using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomUpdateManager
{
    public class Mover : MonoBehaviour
    {
        float speed;

        private void Awake() 
        {
            speed = Random.Range(1.0f, 1.1f);
        }

        private void Update() 
        {
            MoveUpAndDown();
        }

        void MoveUpAndDown()
        {
            var curPos = transform.position;
            transform.position = new Vector3(curPos.x, Mathf.PingPong(Time.time * speed, 10), curPos.z);
        }
    }
}
