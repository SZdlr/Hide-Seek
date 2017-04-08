using UnityEngine;
using System.Collections;

public class ButtonUsed : MonoBehaviour
{

		private bool inUse; //is the button moving
		private bool atLowestY; //is button at lowest Y
		public bool reusable; //can the button used multiple times

		public float speed; //moving speed
		public float minY; //Y coordinates when down
		public float maxY; //Y coordinates when up


		//on triggering button
		void OnTriggerEnter ()
		{
				//if not moving
				if (!inUse) {
						//set to moving
						inUse = true;
				} 
		}

		//every frame
		void Update ()
		{
				//if moving and not going down
				if (inUse && !atLowestY) {
						//changes Y coordinates of button by value of speed per second, going down
						transform.Translate (Vector3.up * -Time.deltaTime * speed, Space.World);
						
						//if button at lowest Y
						if (transform.localPosition.y <= minY) {
								//set variable
								atLowestY = true;
						}
						
						//if reusable button
						if (reusable) {
								//sends message to be used by other script, message: button can't be used
								BroadcastMessage ("setCanBeUsed", false);
						}
				} 

				// if moving and at lowest Y and reusable button
				if (inUse && atLowestY && reusable) {
						//changes Y coordinates of button by value of speed per second, going up
						transform.Translate (Vector3.up * +Time.deltaTime * speed, Space.World);

						//if button at highest Y
						if (transform.localPosition.y > maxY) {
								//set variables
								atLowestY = false;
								inUse = false;

								//sends message to be used by other script, message: button can be used
								BroadcastMessage ("setCanBeUsed", true);
						}
				}
			
		}
}