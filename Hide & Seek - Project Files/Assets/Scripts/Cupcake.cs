using UnityEngine;
using System.Collections;

public class Cupcake : MonoBehaviour
{
		//cupcakes are now pumpkins!

		public GameObject sparks; //particles when not collected
		public GameObject firework; //particles when collecting
		private bool exist = true; //true: not collected, false: collected


		//on triggering
		void OnTriggerEnter ()
		{
				//if not collected yet
				if (exist) {
						//play firework
						firework.SetActive (true);
						//stop rendering pumpkin
						this.renderer.enabled = false;
						//stop emitting sparks particles
						sparks.SetActive (false);
						//set variable
						exist = false;
				}
		}
}
