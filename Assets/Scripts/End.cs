using UnityEngine;
using System.Collections;

public class End : MonoBehaviour {

	void OnTriggerEnter(Collider End){
		if (End.gameObject.tag == "Player" || End.gameObject.tag == "Powered") {
			Debug.Log ("You win!");
			UnityEditor.EditorApplication.isPlaying = false;
		}
	}

}
