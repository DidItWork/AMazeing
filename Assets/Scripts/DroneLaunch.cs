using UnityEngine;
using System.Collections;

public class DroneLaunch : MonoBehaviour {
	public GameObject self;
	public GameObject chara;
	public RectTransform Battery;
	bool PathClear;
	Vector3 Oposition;
	Vector3 APosition;
	bool call;
	UnityStandardAssets.Characters.FirstPerson.FirstPersonController FPC;
	BatteryLevel BL;
	bool AlreadyThere = true;
	public Camera CharaCamera;
	CharacterController GroundCheck;
	public GameObject Restrictionb;
	public bool RevealPower;
	public bool SprintPower;
	public bool DoorPower;
	public int DroneCount = 0;
	
	void Start(){
		PathClear = true;
		FPC = self.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>(); 
		BL = Battery.GetComponent<BatteryLevel> ();
		GroundCheck = self.GetComponent<CharacterController> ();
		Invoke ("Quit", 150f);
	}
	
	void FixedUpdate(){
		call = Input.GetButtonDown ("Call");
	}
	
	void OnTriggerEnter (Collider character) {
		PathClear = false;
		if (call){
			Debug.Log ("Path is not clear!");
		}
	} 
	
	void OnTriggerStay(Collider character){
		if (call){
			Debug.Log ("Path is not clear!");
		}
	}
	
	void OnTriggerExit(Collider character){
		PathClear = true;
	}
	
	void Update(){
		if (PathClear == true) {
			ReleaseDrone ();
		}
		if (Battery.localScale.x <= 0 && BL.DroneActive == true) {
			CutDrone();
		}
		if (AlreadyThere == false) {
			self.transform.position = Oposition;
		}
	}
	
	void ReleaseDrone(){
		if (call == true && GroundCheck.isGrounded && self.tag == "Player"&&DroneCount < 5) {
			Restrictionb.transform.position = new Vector3 (0, 1, 0);
			FPC.m_WalkSpeed = 15;
			FPC.m_RunSpeed = 15;
			SprintPower = false;
			RevealPower = false;
			DoorPower = false;
			Oposition = self.transform.position;
			APosition = Oposition + (new Vector3(transform.forward.x, 0, transform.forward.z) * 2.5f);
			self.transform.position = APosition;
			CharaCamera.transform.position = Oposition + new Vector3(0.0f,3.5f,0.0f);
			Vector3 LookDir = new Vector3(self.transform.position.x, CharaCamera.transform.position.y, self.transform.position.z);
			CharaCamera.transform.LookAt(LookDir);
			FPC.m_JumpSpeed = 0;
			FPC.m_UseHeadBob = false;
			FPC.m_FootstepSounds[0] = Resources.Load ("machine_1", typeof(AudioClip)) as AudioClip;
			FPC.m_FootstepSounds[1] = Resources.Load ("machine_1", typeof(AudioClip)) as AudioClip;
			FPC.m_JumpSound = null;
			FPC.m_LandSound = null;
			self.tag = "Drone";
			DroneCount ++;
		}
	}
	void CutDrone(){
		self.tag = "Player";
			CharaCamera.transform.position = new Vector3 (0f, -3.5f, 150f);
		AlreadyThere = false;
		Invoke ("OutIdle", 2f);

	}
	void OutIdle(){
		AlreadyThere = true;
		FPC.m_JumpSpeed = 10;
		FPC.m_UseHeadBob = true;
		FPC.m_FootstepSounds[0] = Resources.Load ("Footstep03", typeof(AudioClip)) as AudioClip;
		FPC.m_FootstepSounds[1] = Resources.Load ("Footstep04", typeof(AudioClip)) as AudioClip;
		FPC.m_JumpSound = Resources.Load ("Jump", typeof(AudioClip)) as AudioClip;
		FPC.m_LandSound = Resources.Load ("Land", typeof(AudioClip)) as AudioClip;
		if (SprintPower == true) {
			FPC.m_WalkSpeed = 25;
			FPC.m_RunSpeed = 25;
		}
		if (RevealPower == true) {
			Restrictionb.transform.position = new Vector3(0, 100, 0);
		}
		if (DoorPower == true) {
			self.tag="Powered";
		}
	}
	void Quit(){
		Debug.Log ("Game End");
		UnityEditor.EditorApplication.isPlaying = false;
	}
	
}
