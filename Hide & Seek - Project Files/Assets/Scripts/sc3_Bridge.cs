using UnityEngine;
using System.Collections;

public class sc3_Bridge : MonoBehaviour
{
		private bool start; //true: bridge pieces appear and disappear, false: no bridge
		private int nr = 0; //bridge piece number
		public GameObject bridge; // bridge object group
	
		private float time = 1; //counts from 1 to 0 and from 0 to 1
		private int fadeTime = 2; //time until bridge pieces disappear


		//on triggering
		void OnTriggerEnter ()
		{
				//set variable
				start = true;
		}

		//every frame
		void Update ()
		{
				//if started through button press
				if (start) {
						// 
						if (time == 1 && nr != 5) {
								//send message to bridge piece number nr
								bridge.BroadcastMessage ("appear", nr);

								//set variables
								nr++;
								time = 0;
						}
				//counting fadeTime seconds
				time = Mathf.Clamp01 (time + (Time.deltaTime / fadeTime));
				}
		}
}