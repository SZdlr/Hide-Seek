using UnityEngine;
using System.Collections;

public class sc12_Teleport : MonoBehaviour
{
		public GameObject player; //player character

		//on triggering
		void OnTriggerEnter ()
		{
				//teleport player to new location
				player.transform.localPosition = new Vector3 (64.8f, 4.415534f, 1.015328f);
		}
}
