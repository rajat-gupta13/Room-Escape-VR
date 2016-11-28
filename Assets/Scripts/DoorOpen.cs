using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {

	public GameObject door, doorOpenText, door1;
	public static bool canOpenDoor = false;
	// Use this for initialization
	void Start () {
	}
	
	void OnTriggerStay (Collider collider) {
		if (collider.gameObject.tag == "Player" && canOpenDoor) {
			doorOpenText.SetActive (true);
			if (Input.GetButtonDown ("Fire1")) {
				doorOpenText.SetActive (false);
				door.SetActive (false);
				door1.SetActive (true);
				door.GetComponent<BoxCollider> ().enabled = false;
			}
		}
	}
	void OnTriggerExit (Collider collider) {
		if (collider.gameObject.tag == "Player") {
			doorOpenText.SetActive (false);
		}
	}
}
