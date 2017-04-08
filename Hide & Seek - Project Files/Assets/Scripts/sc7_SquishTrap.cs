using UnityEngine;
using System.Collections;

public class sc7_SquishTrap : MonoBehaviour
{
		private bool trap; //true: trap activated
		public GameObject deathblock; //block that's the trap
		public float speed; //block moving speed


		//on triggering
		void OnTriggerEnter ()
		{
				//activate kill script
				deathblock.collider.isTrigger = true;
				//set variable
				trap = true;
		}

		//every frame
		void Update ()
		{
				//if trap is active
				if (trap) {
						//move trap to the right at speed per second
						deathblock.transform.Translate (Vector3.left * -Time.deltaTime * speed, Space.World);
				}
		}
}
