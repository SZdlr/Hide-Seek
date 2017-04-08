using UnityEngine;
using System.Collections;

public class sc9_StartStop : MonoBehaviour
{
		private bool used; //true: 
		private bool trapused; //true: 
		private bool start; //true: 
		public bool starter; //true: trap active 

		public GameObject hint; //fake button
		public GameObject trapblock; //falling cube
		public GameObject traptrigger; //trigger to stop falling cube


		//on triggering
		void OnTriggerEnter ()
		{
				//if trap active
				if (starter) {
						if (!used) {
								start = true;
								used = true;
						}
				}
				//if trap not active
				if (!starter) {
						//send message getUsed
						traptrigger.BroadcastMessage ("getUsed");
						if (trapused) {
								//send message usedd
								traptrigger.BroadcastMessage ("usedd");
						}
				}
		}

		//to be called by sc9_StartStop
		void getUsed ()
		{
				if (used) {
						//send message usedd
						traptrigger.BroadcastMessage ("usedd");
				}
		}

		//to be called by sc9_StartStop
		void usedd ()
		{
				//set variable
				trapused = true;
		}

		// Update is called once per frame
		void Update ()
		{
				//if block falling
				if (start) {
						if (!trapused) {
								trapblock.transform.Translate (Vector3.up * -Time.deltaTime * 1.8f, Space.World);
								hint.renderer.enabled = true;
								hint.collider.enabled = true;
						}
				}
		}
}