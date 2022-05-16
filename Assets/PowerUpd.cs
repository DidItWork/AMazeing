using UnityEngine;
using System.Collections;

public class PowerUpd : MonoBehaviour {
	public GameObject PowerUp;
	public GameObject dude;
	UnityStandardAssets.Characters.FirstPerson.FirstPersonController FirstPersonControll;
	public float FloatingForce = 12.0f;
	DroneLaunch Access;
	
	void Start(){
		Access = GameObject.Find ("Check").GetComponent<DroneLaunch> ();
	}
	
	void OnTriggerStay(Collider detect){
		if (detect.gameObject.tag == "DoorPower") {
			detect.attachedRigidbody.AddForce (Vector3.up * FloatingForce, ForceMode.Acceleration);
		} else if (detect.gameObject.tag == "Player") {
			dude.tag = "Powered";
			Destroy (PowerUp);
		} else if (detect.gameObject.tag == "Drone") {
			Access.DoorPower = true;
			Destroy (PowerUp);
		}
	}
}
