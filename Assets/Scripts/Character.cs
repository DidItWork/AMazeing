using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public GameObject self;
	UnityStandardAssets.Characters.FirstPerson.FirstPersonController FirePC;
	public float duration = 15.0f;
	public float duration2 = 15.0f;
	public float duration3 = 15.0f;
	GameObject Restrictiona;
	DroneLaunch KillIt;

	void Start(){
		FirePC = self.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
		KillIt = GameObject.Find ("Check").GetComponent<DroneLaunch> ();
		Restrictiona = GameObject.Find ("Restriction");
	}

	void Update(){
		if (FirePC.m_WalkSpeed == 25) {
			Invoke ("DestroyPower",duration);
		}
		if (Restrictiona.transform.position.y > 1) {
			Invoke ("DestroyPower2",duration2);
		}
		if (self.tag == "Powered") {
			Invoke ("DestroyPower3",duration3);
		}

	}

	void DestroyPower(){
		FirePC.m_WalkSpeed = 15;
		FirePC.m_RunSpeed = 15;
		KillIt.SprintPower = false;
	}

	void DestroyPower2(){
		Restrictiona.transform.position = new Vector3 (0, 1, 0);
		KillIt.RevealPower = false;
	}
	void DestroyPower3(){
		self.tag = "Player";
		KillIt.DoorPower = false;
	}
}
