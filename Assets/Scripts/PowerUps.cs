using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {
	public GameObject PowerUp;
	public GameObject dude;
	UnityStandardAssets.Characters.FirstPerson.FirstPersonController FirstPersonControll;
	public float FloatingForce = 12.0f;
	DroneLaunch Sprint;
	
	void Start(){
		Sprint = GameObject.Find ("Check").GetComponent<DroneLaunch> ();
	}
	
	void OnTriggerStay(Collider detect){
		if (detect.gameObject.tag == "SprintPower") {
			detect.attachedRigidbody.AddForce (Vector3.up * FloatingForce, ForceMode.Acceleration);
		} else if (detect.gameObject.tag == "Player") {
			FirstPersonControll = dude.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ();
			FirstPersonControll.m_WalkSpeed = 25;
			FirstPersonControll.m_RunSpeed = 25;
			Destroy (PowerUp);
		} else if (detect.gameObject.tag == "Drone") {
			Sprint.SprintPower = true;
			Destroy (PowerUp);
		}
	}
}
