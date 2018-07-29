using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TAAI
{
    public class CharacterController : MonoBehaviour
    {
        public Vector3 localVelocity;
        public float SpeedMove;
        public GameObject Pivot;
        public Vector3 defaultDoge;
        public Vector3 dogeLateral;

        public void MoveCharacter(float _x, float _z)
        {
            localVelocity = transform.InverseTransformDirection(transform.GetComponent<Rigidbody>().velocity);
            ChangenRotationCharacterAt(Pivot);
            localVelocity = new Vector3(_x * SpeedMove, 0, _z * SpeedMove);
            transform.GetComponent<Rigidbody>().velocity = transform.TransformDirection(localVelocity);
        }

        private void ChangenRotationCharacterAt(GameObject _pivot)
        {
            transform.LookAt(new Vector3(_pivot.transform.position.x, transform.position.y, _pivot.transform.position.z));
        }

        public void DogeAction(bool _moving)
        {
            if (_moving)
            {
                transform.GetComponent<Rigidbody>().AddForce(dogeLateral, ForceMode.Impulse);
            }
            else
            {
                transform.GetComponent<Rigidbody>().AddForce(defaultDoge, ForceMode.Impulse);
            }
        }
    }
}