using UnityEngine;
using System.Collections;

public class sc1_Credits : MonoBehaviour
{
		private float fade = 1; //value of alpha(transparency) of title/credits
		private bool scrolling = true; //true: scrolling up, false: not scrolling
		public bool title; //true: is title, false: is credits
		public float speed = 0f; //scrolling speed
		public float max; // highest Y coordinate for scrolling
	
		private float alphaValue = 0; //value of alpha(transparency) of GUI
		public int fadeTime = 10; //fade duration

	
		//every frame
		void Update ()
		{
				//if scrolls and fading finished
				if (scrolling && alphaValue == 1) {
						//
						transform.Translate (Vector3.up * Time.deltaTime * speed, Space.World);
						//if scrolling finished
						if (transform.localPosition.y > max) {
								//set variable
								scrolling = false;
						}
				}

				//counting fadeTime seconds
				alphaValue = Mathf.Clamp01 (alphaValue + (Time.deltaTime / fadeTime));

				//if is title and fading half finished
				if (title && alphaValue > 0.5) {
						//change alpha value variable of text
						fade = Mathf.Clamp01 (fade - (Time.deltaTime / fadeTime));
						//change color and alpha of text
						this.renderer.material.color = new Color (fade, fade, fade, fade);
				}
		}
}