using UnityEngine;
using System.Collections;

public class sc4_TriggerTrap : MonoBehaviour
{
	
		public GameObject target; //falling sphere
		public GameObject targetCube1; //cube blocking left
		public GameObject targetCube2; //cube blocking right
	
		//on triggering
		void OnTriggerEnter (Collider other)
		{
				//if object triggering has tag called "Player"
				if (other.gameObject.tag == "Player") {
						//set blocking cubes active
						targetCube2.SetActive (true);
						targetCube1.SetActive (true);
						//let sphere fall on players head
						target.rigidbody.useGravity = true;
				}
		}
}