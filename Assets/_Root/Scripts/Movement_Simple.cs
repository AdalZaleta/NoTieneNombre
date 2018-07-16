using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TAAI
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement_Simple : MonoBehaviour
    {
        public Rigidbody rig;
        public float speed;
        int xDir;
        int zDir;
        public GameObject camPivot;

        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            transform.Translate(Vector3.forward * speed * vertical * Time.deltaTime);
            transform.Translate(Vector3.right * speed * horizontal * Time.deltaTime);
        }
    }
}