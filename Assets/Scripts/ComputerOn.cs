using UnityEngine;
using System.Collections;

public class ComputerOn : MonoBehaviour {

	public GameObject screen1,screen2,screen3,screen4,screen5,keyboard;
	public static bool canSwitchOn = true;
	// Use this for initialization
	void Start () {
	}
	
	void OnTriggerStay (Collider collider) {
		if (collider.gameObject.tag == "Player" && canSwitchOn) {
//			doorOpenText.SetActive (true);
			if (Input.GetButtonDown ("Fire1")) {
//				doorOpenText.SetActive (false);
				screen1.SetActive (true);
				screen2.SetActive (true);
				screen3.SetActive (true);
				screen4.SetActive (true);
				screen5.SetActive (true);
				keyboard.GetComponent<SphereCollider> ().enabled = false;
			}
		}
	}
//	void OnTriggerExit (Collider collider) {
//		if (collider.gameObject.tag == "Player") {
//			doorOpenText.SetActive (false);
//		}
//	}
}
