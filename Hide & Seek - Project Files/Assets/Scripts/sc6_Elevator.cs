using UnityEngine;
using System.Collections;

public class sc6_Elevator : MonoBehaviour
{
		private bool isDown; //true: elevator moving up, false: moving down
		private bool playerhit; //true: player on elevator
		public float max; // highest Y coordinate
		public float min; // lowest Y coordinate
		public GameObject player; //player character

		//when object landing on elevator
		void OnCollisionStay (Collision collision)
		{
				//if object is player
				if (collision.gameObject == player) {
						//set variable
						playerhit = true;
				}
		}
		
		//when object moving from elevator
		void OnCollisionExit (Collision collision)
		{
				//if object is player
				if (collision.gameObject == player) {
						//set variable
						playerhit = false;
				}
		}


		//every frame
		void Update ()
		{
				//if elevator is moving up
				if (isDown) {
						//move elevator up
						transform.Translate (Vector3.up * Time.deltaTime, Space.World);
						
						//if at highest Y
						if (transform.localPosition.y > max) {
								//set variable
								isDown = false;
						}
				//if elevator is moving down
				} else {
						//move elevator down
						transform.Translate (Vector3.up * -Time.deltaTime, Space.World);

						//if at lowest Y
						if (transform.localPosition.y < min) {
								//set variable
								isDown = true;
						}
				}
	
				//if player on elevator
				if (playerhit) {
						//if elevator is moving up
						if (isDown) {
								//move player up
								player.transform.Translate (Vector3.up * Time.deltaTime, Space.World);
								
								//if at highest Y
								if (transform.localPosition.y > max) {
										//set variable
										isDown = false;
								}
						//if elevator is moving down
						} else {
								//move player down
								player.transform.Translate (Vector3.up * -Time.deltaTime, Space.World);

								//if at highest Y
								if (transform.localPosition.y < min) {
										//set variable
										isDown = true;
								}
						}
				}
		}
}
