using UnityEngine;
using System.Collections;

public class sc13_Error : MonoBehaviour
{
		private bool keyUp; //true: key was pressed
		private int count; //counts keypresses

		private float restart = 0; //counts to 1
		private int fadeTime = 5; //fade duration

	
		//every frame
		void Update ()
		{
				//as long as less than 5 keys have been pressed
				if (count != 5) {
						//if any key has been pressed and let go
						if (Input.anyKeyDown && keyUp) {
								//set variables
								keyUp = false;
								count++;
						//if no key is pressed
						} else if (!Input.anyKeyDown) {
								//set variable
								keyUp = true;
						}
				//if 5 keys have been pressed
				} else {
						//display this plane
						renderer.enabled = true;

						//counting fadeTime seconds
						restart = Mathf.Clamp01 (restart + (Time.deltaTime / fadeTime));
						//if fade finished
						if (restart == 1) {
								//load first level
								Application.LoadLevel (0);
						}
				}
		}
}
