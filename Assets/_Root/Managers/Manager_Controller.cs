using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TAAI
{
	//Player controller (Si fuera una IA, seria un script similar a este, pero que en lugar de usar el input manager, usa su propia logica de IA para mover un character)
	public class Manager_Controller : MonoBehaviour 
	{
		public GameObject Principal_PJ;

		void Awake()
		{
			Manager_Static.controllerManager = this;
			Principal_PJ = GameObject.FindGameObjectWithTag ("Player");
		}

		public void MoveCharacter(float _x, float _y)
		{
            if (Principal_PJ)
            {
                Debug.Log("Principal_PJ active");
            }
            if (Principal_PJ.GetComponent<CharacterController>())
            {
                Debug.Log("CharacterController Script active");
            }
            Principal_PJ.GetComponent<CharacterController>().MoveCharacter(_x, _y);
		}
	}
}
