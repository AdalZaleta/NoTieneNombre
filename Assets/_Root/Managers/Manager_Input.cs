using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace TAAI
{
	public class Manager_Input : MonoBehaviour {

		void Awake()
		{
			Manager_Static.inputManager = this;
		}

		void Update()
		{
			//CODIGO DE LOS INPUTS DEPENDIENDO DEL ESTADO DEL JUEGO
			if (Manager_Static.appManager.currentState == AppState.pause_menu) {
				if (Input.GetKeyUp (KeyCode.JoystickButton7)) {
					Manager_Static.appManager.setPlay ();
					Manager_Static.uiManager.isInPause (false);
				}
			}
			else if (Manager_Static.appManager.currentState == AppState.main_menu) {
			}
			else if (Manager_Static.appManager.currentState == AppState.gameplay) {
				if (Input.GetAxisRaw ("Horizontal") != 0.0f || Input.GetAxisRaw ("Vertical") != 0.0f) {
                    Manager_Static.controllerManager.MoveCharacter(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
				}
                if (Input.GetButtonDown("Fire2")) {
                    Debug.Log("Dandole Fire2");
                }
				if (Input.GetKeyUp (KeyCode.JoystickButton7)) {
					Manager_Static.appManager.SetPause ();
					Manager_Static.uiManager.isInPause (true);
				}
			}
			else if (Manager_Static.appManager.currentState == AppState.end_game) {
			}
		}

		public delegate void InputTemplate (int _id);


        public InputTemplate ShootHandler;
        public InputTemplate ShootDownHandler;
        public InputTemplate ShootUpHandler;
        public InputTemplate ThrowHandler;
        public InputTemplate SwitchWeaponHandler;
    }
}
