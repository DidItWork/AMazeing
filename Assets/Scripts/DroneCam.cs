using UnityEngine;
using System.Collections;

public class DroneCam : MonoBehaviour {
	public GameObject DroneP;
	public GameObject PlayerCamera;
	
	void Update () {
		if (DroneP.tag == "Drone") {
			PlayerCamera.GetComponent<Camera>().fieldOfView = 50;
		}
	}
}
