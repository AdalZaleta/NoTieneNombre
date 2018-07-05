using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.L)) // Horizontal +
        {
            turnX(1);
        }
        else if (Input.GetKey(KeyCode.J)) // Horizontal -
        {
            turnX(-1);
        }
        if (Input.GetKey(KeyCode.I)) // Vertical +
        {
            turnY(-1);
        }
        else if (Input.GetKey(KeyCode.K)) // Vertical -
        {
            turnY(1);
        }
    }

    public void turnX(float vel)
    {
        transform.Rotate(Vector3.up * vel, Space.World);
    }

    public void turnY(float vel)
    {
        transform.Rotate(Vector3.right * vel, Space.Self);
    }
}
