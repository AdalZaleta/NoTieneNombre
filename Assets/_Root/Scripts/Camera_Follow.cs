using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TAAI
{
    public class Camera_Follow : MonoBehaviour
    {
        public GameObject player;
        Transform target;
        bool autoFocus;
        public float followSpeed;

        private void Start()
        {
            target = player.transform;
        }

        void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                autoFocus = !autoFocus;
            }

            if (autoFocus)
            {

            }
            else
            {

            }

            Vector3 finalPos = new Vector3(target.position.x, target.position.y, target.position.z);
            Vector3 smoothedPos = Vector3.Lerp(transform.position, finalPos, followSpeed * Time.deltaTime);
            transform.position = new Vector3(smoothedPos.x, smoothedPos.y, smoothedPos.z);
        }
    }
}