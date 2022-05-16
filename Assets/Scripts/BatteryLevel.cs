using UnityEngine;
using System.Collections;

public class BatteryLevel : MonoBehaviour {
	public GameObject Droner;
	public RectTransform bar; 
	public float BatteryLife = 5f;
	public bool DroneActive = false;
	private float newScale = 2f;

	void Update () {
		if(Droner.tag == "Player"){
			DroneActive = false;
			bar.localScale = new Vector3(0, bar.localScale.y, bar.localScale.z);
		} else if(Droner.tag == "Drone"){
			bar.localScale = new Vector3(newScale, bar.localScale.y, bar.localScale.z);
			newScale -= 0.002f * BatteryLife;
			bar.localScale =new Vector3(newScale, bar.localScale.y, bar.localScale.z);
			if(newScale <= 0){
				newScale = 2f;
			}
			DroneActive = true;
		}

		
			
	}
}
