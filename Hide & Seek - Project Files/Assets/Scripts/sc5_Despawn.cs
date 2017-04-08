using UnityEngine;
using System.Collections;

public class sc5_Despawn : MonoBehaviour
{
		public GameObject fake; //exit that kills you
		public GameObject block; //cube blocking real level exit


		//on triggering
		void OnTriggerEnter ()
		{
				//disable fake door
				fake.SetActive (false);
				//disable blocking cube
				block.SetActive (false);
		}
}
