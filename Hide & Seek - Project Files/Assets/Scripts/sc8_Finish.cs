using UnityEngine;
using System.Collections;

public class sc8_Finish : MonoBehaviour
{

		public GameObject block1; //block to check color
		public GameObject block2; //block to check color

		private bool levelend = false; //true: puzzle finished
		public bool setActive = true; //true: puzzle active

		private int fadeTime = 2; //fade duration
		private float alphaFadeValue = 1; //value of alpha(transparency) of GUI
		public Texture blackTexture; //texture for fade out


		//GUI
		void OnGUI ()
		{
				//if puzzle finished
				if (levelend) {
						//change alpha value variable so it reaches 100% in fadeTime time
						alphaFadeValue = Mathf.Clamp01 (alphaFadeValue + (Time.deltaTime / fadeTime));
						//change color and alpha of GUI 
						GUI.color = new Color (alphaFadeValue, alphaFadeValue, alphaFadeValue, alphaFadeValue);
						//draw rectangle as big as screen
						GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), blackTexture);

						//if fade finished
						if (alphaFadeValue == 1) {
								//load next level
								Application.LoadLevel (Application.loadedLevel + 1);
						}
				//if puzzle not finished
				} else {
						//change alpha value variable so it reaches 100% in fadeTime time
						alphaFadeValue = Mathf.Clamp01 (alphaFadeValue - (Time.deltaTime / fadeTime));
						//change color and alpha of GUI 
						GUI.color = new Color (alphaFadeValue, alphaFadeValue, alphaFadeValue, alphaFadeValue);
						//draw rectangle as big as screen
						GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), blackTexture);
				}
		}
	
	

		//every frame
		void Update ()
		{
				//if blocks are blue
				if (block1.renderer.material.color == block2.renderer.material.color && block1.renderer.material.color == Color.blue) {
						//set variable
						levelend = true;		
				}
		}
}
