using UnityEngine;
using System.Collections;

public class DoorsY : MonoBehaviour {
	bool doorsOpen;
	public GameObject doord;
	public GameObject guy;
	void start(){
		doorsOpen = false;
	}
	
	void OnTriggerEnter(Collider bang){
		if (bang.gameObject.tag == "Player" && guy.transform.position.x > doord.transform.position.x) {
			doorsOpen = true; 
			Dooranim ("Open");
		} else if( bang.gameObject.tag == "Drone" || bang.gameObject.tag == "Powered"){
			doorsOpen = true; 
			Dooranim ("Open");
		}
	}
	
	void OnTriggerExit(Collider bang){
		if (doorsOpen == true) {
			doorsOpen = false;
			Dooranim("Close");
		}
	}
	
	void Dooranim(string mofe){
		GetComponent<Animator>().SetTrigger(mofe);
	}
}
