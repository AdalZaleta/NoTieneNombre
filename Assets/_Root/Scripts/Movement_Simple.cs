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

            /*
            if (Input.GetKey(KeyCode.W))
            {
                transform.eulerAngles = new Vector3(0, camPivot.transform.eulerAngles.y, 0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.eulerAngles = new Vector3(0, camPivot.transform.eulerAngles.y + 180, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.eulerAngles = new Vector3(0, camPivot.transform.eulerAngles.y + 90, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.eulerAngles = new Vector3(0, camPivot.transform.eulerAngles.y - 90, 0);
            } */

            transform.Translate(Vector3.forward * speed * vertical * Time.deltaTime);
            transform.Translate(Vector3.right * speed * horizontal * Time.deltaTime);
        }
    }
}