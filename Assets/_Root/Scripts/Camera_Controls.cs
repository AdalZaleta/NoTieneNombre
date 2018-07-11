using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controls : MonoBehaviour {

    public float camVel;
    public GameObject player;
    public GameObject camOffset;
    public GameObject cam;
    public LayerMask layerMask;
    bool autoFocus;
	// Use this for initialization
	void Start () {
		
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

    void FixedUpdate () {

        float RStick_H = Input.GetAxis("RStick_H");
        float RStick_V = Input.GetAxis("RStick_V");

        if (transform.forward.y >= 0.9 && RStick_V <= 0)
        {
            RStick_V = 0;
        }
        else if (transform.forward.y <= -0.9 && RStick_V >= 0)
        {
            RStick_V = 0;
        }

        transform.Rotate(Vector3.up * camVel * RStick_H * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right * camVel * RStick_V * Time.deltaTime, Space.Self);
    }
}
