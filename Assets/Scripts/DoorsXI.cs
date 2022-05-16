using UnityEngine;
using System.Collections;

public class DoorsXI : MonoBehaviour {
	bool doorXOpen;
	public GameObject doora;
	public GameObject playor;
	void start(){
		doorXOpen = false;
	}
	
	void OnTriggerEnter(Collider hat){
		if (hat.gameObject.tag == "Player" && playor.transform.position.z < doora.transform.position.z) {
			doorXOpen = true; 
			IDooractions ("IOpen");
		} else if( hat.gameObject.tag == "Drone" || hat.gameObject.tag == "Powered"){
			doorXOpen = true; 
			IDooractions ("IOpen");
		}
	}
	
	void OnTriggerExit(Collider hat){
		if (doorXOpen == true) {
			doorXOpen = false;
			IDooractions("IClose");
		}
	}
	
	void IDooractions(string mave){
		GetComponent<Animator>().SetTrigger(mave);
	}
}
