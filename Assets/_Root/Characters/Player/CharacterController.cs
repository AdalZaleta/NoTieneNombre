using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TAAI
{
    public class CharacterController : MonoBehaviour
    {

        public float SpeedMove;
        public GameObject Pivot;
        public Vector3 defaultDoge;
        public Vector3 dogeLateral;

        public void MoveCharacter(float _x, float _z)
        {
            ChangenRotationCharacterAt(Pivot);
            transform.GetComponent<Rigidbody>().velocity = new Vector3(_x * SpeedMove, gameObject.GetComponent<Rigidbody>().velocity.y, _z * SpeedMove);
        }

        private void ChangenRotationCharacterAt(GameObject _pivot)
        {
            transform.LookAt(_pivot.transform.forward,Vector3.up);
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