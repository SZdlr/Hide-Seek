using UnityEngine;
using System.Collections;

public class LoadNextMap : MonoBehaviour
{
	
		private bool levelend = false; //true: level finished, false: not finished yet

		private float alphaFadeValue = 1; //value of alpha(transparency) of GUI
		private int fadeTime = 2; //fade duration
		public Texture blackTexture; //texture for fade out


		//GUI
		void OnGUI ()
		{
				//if level finished
				if (levelend) {
						//change alpha value variable so it reaches 100% in fadeTime time
						alphaFadeValue = Mathf.Clamp01 (alphaFadeValue + (Time.deltaTime / fadeTime));
						//change color and alpha of GUI 
						GUI.color = new Color (0, 0, 0, alphaFadeValue);
						//draw rectangle as big as screen
						GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), blackTexture);

						//if fade finished
						if (alphaFadeValue == 1) {
								Application.LoadLevel (Application.loadedLevel + 1);
						}
				} else {
						//change alpha value variable so it reaches 0% in fadeTime time
						alphaFadeValue = Mathf.Clamp01 (alphaFadeValue - (Time.deltaTime / fadeTime));
						//change color and alpha of GUI 
						GUI.color = new Color (alphaFadeValue, alphaFadeValue, alphaFadeValue, alphaFadeValue);
						//draw rectangle as big as screen
						GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), blackTexture);
				}
		}


		//on triggering
		void OnTriggerEnter (Collider other)
		{
				//if object triggering has tag called "Player"
				if (other.gameObject.tag == "Player") {
						//set variable
						levelend = true;
				}

		}

}
