using UnityEngine;
using System.Collections;

public class PowerUpr : MonoBehaviour {
	public GameObject PowerUp;
	UnityStandardAssets.Characters.FirstPerson.FirstPersonController FirstPersonControll;
	public float FloatingForce = 12.0f;
	public GameObject Restrictions;
	DroneLaunch Reveal;

	void Start(){
		Reveal = GameObject.Find ("Check").GetComponent<DroneLaunch> ();
	}

	void OnTriggerStay(Collider detect){
		if (detect.gameObject.tag == "RevealPower") {
			detect.attachedRigidbody.AddForce (Vector3.up * FloatingForce, ForceMode.Acceleration);
		} else if (detect.gameObject.tag == "Player") {
			Restrictions.transform.position = new Vector3(0, 100, 0);
			Destroy (PowerUp);
		} else if (detect.gameObject.tag == "Drone") {
			Reveal.RevealPower = true;
			Destroy (PowerUp);

		}
	}
}
