using UnityEngine;
using System.Collections;

public class DoorsX : MonoBehaviour {
	bool doorOpen;
	public GameObject doorc;
	public GameObject player;
	void start(){
		doorOpen = false;
	}
	
	void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag == "Player" && player.transform.position.z > doorc.transform.position.z) {
			doorOpen = true; 
			Dooractions ("Open");
		} else if( hit.gameObject.tag == "Drone" || hit.gameObject.tag == "Powered"){
			doorOpen = true; 
			Dooractions ("Open");
		}
	}

	void OnTriggerExit(Collider hit){
		if (doorOpen == true) {
			doorOpen = false;
			Dooractions("Close");
		}
	}
	
	void Dooractions(string move){
		GetComponent<Animator>().SetTrigger(move);
	}
}
