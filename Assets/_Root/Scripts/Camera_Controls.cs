using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TAAI
{
    public class Camera_Controls : MonoBehaviour
    {

        public float camVel;
        public GameObject player;
        public GameObject camOffset;
        public GameObject cam;
        public LayerMask layerMask;
        public bool invertedY;
        bool autoFocus;
        GameObject nearest;

        float RStick_H;
        float RStick_V;

        public bool camLocked;

        GameObject findNearest()
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("enemy");
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
            return closest;
        }

        private void Update()
        {
            RaycastHit hit;
            if (Physics.Linecast(player.transform.position, camOffset.transform.position, out hit, layerMask))
            {
                cam.transform.position = hit.point;
                Debug.DrawLine(player.transform.position, camOffset.transform.position, Color.red);
            }
            else
            {
                cam.transform.position = camOffset.transform.position;
                Debug.DrawLine(player.transform.position, camOffset.transform.position, Color.green);
            }
        }

        void FixedUpdate()
        {
            RStick_H = Input.GetAxis("RStick_H");
            if (invertedY)
            {
                RStick_V = -Input.GetAxis("RStick_V");
            }
            else
            {
                RStick_V = Input.GetAxis("RStick_V");
            }

            if (transform.forward.y >= 0.9 && RStick_V <= 0)
            {
                RStick_V = 0;
            }
            else if (transform.forward.y <= -0.9 && RStick_V >= 0)
            {
                RStick_V = 0;
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                autoFocus = !autoFocus;
                nearest = findNearest();
            }

            if (!autoFocus)
            {
                cam.transform.LookAt(player.transform);
                camLocked = false;
            }
            else
            {
                Debug.Log("Distance: " + Vector3.Distance(player.transform.position, nearest.transform.position));
                if (Vector3.Distance(player.transform.position, nearest.transform.position) > 10.0f)
                {
                    autoFocus = false;
                }
                else
                {
                    cam.transform.LookAt((player.transform.position + (nearest.transform.position - player.transform.position) / 2));
                    //Lock Camera Rotation if AutoLocked [ W.I.P.! ] 
                    camLocked = true;
                }
            }

            if (!camLocked)
            {
                transform.Rotate(Vector3.up * camVel * RStick_H * Time.deltaTime, Space.World);
                transform.Rotate(Vector3.right * camVel * RStick_V * Time.deltaTime, Space.Self);
                if (camOffset.GetComponent<Camera_Follow>().enabled)
                {
                    camOffset.GetComponent<Camera_Follow>().enabled = false;
                }
            }
            else
            {
                player.transform.LookAt(nearest.transform);
                if (!camOffset.GetComponent<Camera_Follow>().enabled)
                {
                    camOffset.GetComponent<Camera_Follow>().enabled = true;
                }
            }
        }
    }
}