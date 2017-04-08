using UnityEngine;
using System.Collections;

public class sc8_ColorChange : MonoBehaviour
{
		private bool canBeUsed = true; //true: reusable button
		public GameObject block; //block to be changed
		public int nr; //color number, 1 = red, 2 = yellow, 3 = blue


		//on triggering
		void OnTriggerEnter ()
		{
				//if button can be used
				if (canBeUsed) {
						//change color of block
						block.renderer.material.SetColor ("_Color", getColor (nr));
						
						//if color number not 3
						if (nr != 3) {
								//next color
								nr++;
						//if color number 3
						} else {
								//first color
								nr = 1;
						}
				}
		}

		//get color for number
		Color getColor (int nr)
		{
				//number 1
				if (nr == 1) {
						//red
						return Color.red;
				//number 2
				} else if (nr == 2) {
						//yellow
						return Color.yellow;
				//number 3
				} else {
						//blue
						return Color.blue;
				}
		}

		//called to from ButtonUsed
		void setCanBeUsed (bool yea)
		{
				//set variable
				canBeUsed = yea;
		}
}