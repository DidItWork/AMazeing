using UnityEngine;
using System.Collections;

public class DoorsYI : MonoBehaviour {
	bool doorsYOpen;
	public GameObject doorb;
	public GameObject character;
	void start(){
		doorsYOpen = false;
	}
	
	void OnTriggerEnter(Collider bonk){
		if (bonk.gameObject.tag == "Player" && character.transform.position.x < doorb.transform.position.x) {
			doorsYOpen = true; 
			Dooranimation ("IOpen");
		} else if( bonk.gameObject.tag == "Drone" || bonk.gameObject.tag == "Powered"){
			doorsYOpen = true; 
			Dooranimation ("IOpen");
		}
	}
	
	void OnTriggerExit(Collider bonk){
		if (doorsYOpen == true) {
			doorsYOpen = false;
			Dooranimation("IClose");
		}
	}
	
	void Dooranimation(string mafe){
		GetComponent<Animator>().SetTrigger(mafe);
	}
}
