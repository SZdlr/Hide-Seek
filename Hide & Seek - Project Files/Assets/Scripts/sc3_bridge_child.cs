using UnityEngine;
using System.Collections;

public class sc3_bridge_child : MonoBehaviour
{
		private float time = 1; //counts from 1 to 0 and from 0 to 1
		private int fadeTime = 2; //time until bridge pieces disappear

		public int nr; //bridge piece number
		private bool active; //true: bridge pieces appear and disappear, false: no bridge
		private bool visible = false; //true: piece visible, false: invisible

		//initialization
		void Start ()
		{
				//can't be jumped on
				collider.enabled = false;
				//can't be seen
				renderer.enabled = false;
		}

		//message called from sc3_Bridge
		void appear (int nr2)
		{
				//if piece number is number called upon
				if (nr == nr2) {
						//set variables
						active = true;
						collider.enabled = true;
						renderer.enabled = true;
				}
		}

		//every frame
		void Update ()
		{
				//if activated
				if (active) {
						//if counting not finished than 1 and piece not visible
						if (time < 1 && !visible) {
								//count fadeTime seconds to 1
								time = Mathf.Clamp01 (time + (Time.deltaTime / fadeTime));

								//if counting finished
								if (time == 1) {
										//set variables
										visible = true;
										collider.enabled = false;
										this.renderer.enabled = false;
								}
						//if visible and time not 0
						} else if (time > 0) {
								//count fadeTime seconds to 0
								time = Mathf.Clamp01 (time - (Time.deltaTime / fadeTime));

								//if counting finished
								if (time == 0) {
										//set variables
										visible = false;
										collider.enabled = true;
										this.renderer.enabled = true;
								}
						}
				}
		}
}