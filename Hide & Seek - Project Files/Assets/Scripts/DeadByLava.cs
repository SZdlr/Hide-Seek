using UnityEngine;
using System.Collections;

public class DeadByLava : MonoBehaviour
{
	
		private bool dead = false; //true: player dead, false: player alive
		public Transform player; //player character
	
		private float alphaFadeValue = 0; //value of alpha(transparency) of GUI
		public int fadeTime = 2; //fade duration
		public Texture blackTexture; //texture for fade out


		//GUI
		void OnGUI ()
		{
				//if player died
				if (dead) {
						//change alpha value variable so it reaches 100% in fadeTime time
						alphaFadeValue = Mathf.Clamp01 (alphaFadeValue + (Time.deltaTime / fadeTime));
						//change color and alpha of GUI 
						GUI.color = new Color (0, 0, 0, alphaFadeValue);
						//draw rectangle as big as screen
						GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), blackTexture);

						//if fade has finished
						if (alphaFadeValue == 1) {
							//load same level again
							Application.LoadLevel (Application.loadedLevel);
						}
				}
		}

		//on triggering
		void OnTriggerEnter (Collider idiot)
		{
				//if object triggering has tag called "Player"
				if (idiot.gameObject.tag == "Player") {
						//set variable
						dead = true;
				}
		}		
}
