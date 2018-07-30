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
        public float playerRotSpeed;

        float RStick_H;
        float RStick_V;

        public bool camLocked;

        GameObject findNearest()
        {
            // Method to Find Nearest Gameobject tagged w/'enemy' to the Player
            // Get Gameobjects
            GameObject[] gos; 
            gos = GameObject.FindGameObjectsWithTag("enemy");
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            // Check and Compare Positions
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    // Set Closests Gameobject
                    closest = go;
                    distance = curDistance;
                }
            }
            return closest;
        }

        private void Update()
        {
            // Camera to Map Collisions and Position Fix
            RaycastHit hit;
            if (Physics.Linecast(player.transform.position, camOffset.transform.position, out hit, layerMask)) // Detected a Collision w/map
            {
                // Camera Position Adjustment
                cam.transform.position = hit.point;
                Debug.DrawLine(player.transform.position, camOffset.transform.position, Color.red);
            }
            else
            {
                // No Map Collisions
                // Camera Position is at Max Length
                cam.transform.position = camOffset.transform.position;
                Debug.DrawLine(player.transform.position, camOffset.transform.position, Color.green);
            }
        }

        void AutoFocus()
        {
            // Toggle AutoFocus
            autoFocus = !autoFocus;
            nearest = findNearest();
        }

        void FixedUpdate()
        {
            // Camera Pivot Rotation Horizontal
            RStick_H = Input.GetAxis("RStick_H");
            // Camera Pivot Rotation Vertical
            if (invertedY)
            {
                // Inverted Y Rotation
                RStick_V = -Input.GetAxis("RStick_V");
            }
            else
            {
                // Non-Inverted Y Rotation
                RStick_V = Input.GetAxis("RStick_V");
            }

            // Limit Camera Rotation to 0.9 and -0.9
            if (transform.forward.y >= 0.9 && RStick_V <= 0)
            {
                RStick_V = 0;
            }
            else if (transform.forward.y <= -0.9 && RStick_V >= 0)
            {
                RStick_V = 0;
            }

            // Implicit AutoFocus Input
            // Can Remove | After Input Manager Calls Method
            if (Input.GetButtonDown("Jump"))
            {
                AutoFocus();
            }

            // Camera LookAt if AutoFocus Disabled
            if (!autoFocus)
            {
                // Camera Looks At Player
                // Can Rotate Camera Pivot
                cam.transform.LookAt(player.transform);
                camLocked = false;
            }
            else
            {
                // If Player is Further than 10 units away from enemy | autofocus is disabled
                if (Vector3.Distance(player.transform.position, nearest.transform.position) > 10.0f)
                {
                    autoFocus = false;
                }
                else
                {
                    // Camera Looks At Midpoint Between Player and Enemy
                    // Can't Rotate Camera
                    cam.transform.LookAt((player.transform.position + (nearest.transform.position - player.transform.position) / 2));
                    camLocked = true;
                }
            }

            if (!camLocked)
            {
                // Rotate Camera Pivot With RStick_HV
                transform.Rotate(Vector3.up * camVel * RStick_H * Time.deltaTime, Space.World); // Horizontal Pivot Rotation
                transform.Rotate(Vector3.right * camVel * RStick_V * Time.deltaTime, Space.Self); // Vertical Pivot Rotation

                // Check if Camera Follow to Camera Offset is enabled and Disable it
                if (camOffset.GetComponent<Camera_Follow>().enabled)
                {
                    camOffset.GetComponent<Camera_Follow>().enabled = false;
                }
            }
            else
            {
                // Player 1-Axis LookAt to Enemy Position
                var lookPos = nearest.transform.position - player.transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                // Player LookAt Smooth
                player.transform.rotation = Quaternion.Slerp(player.transform.rotation, rotation, Time.deltaTime * playerRotSpeed);

                // Camera Pivot 1-Axis LookAt to Enemy
                transform.rotation = rotation;

                // Enable Camera Follow to Camera Offset
                if (!camOffset.GetComponent<Camera_Follow>().enabled)
                {
                    camOffset.GetComponent<Camera_Follow>().enabled = true;
                }
            }
        }
    }
}