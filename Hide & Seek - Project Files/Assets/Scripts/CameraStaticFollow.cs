using UnityEngine;
using System.Collections;

public class CameraStaticFollow : MonoBehaviour {

	//Zielobjekt (Position und Drehung)
	public Transform target;
	//Abstand zum Ziel
	public float distance = 60.0f;
	public float height = 40.0f;
	//Verzögerung/Dämpfung
	public float positionDamping = 2.0f;
		
		
	//fure Bild oder Kamera
	void LateUpdate () {

		//wenn kein Ziel zugewiesen, Abbruch
		if (!target)
			return;

		//Berechnung der Zielposition
		Vector3 wantedPosition = target.position + new Vector3(0,1,-8);

		//die Lerp-Funktion animiert Positionen weich von der aktuellen Position zur Zielposition
		transform.position = Vector3.Lerp (transform.position, wantedPosition,positionDamping);
		

	}
}
