using UnityEngine;
using System.Collections;

public class BookOpen : MonoBehaviour {

	public GameObject book, bookOpenText;
	public static bool canOpenBook = true;
	// Use this for initialization
	void Start () {
		book.GetComponent<Animation> ().enabled = false;
	}
	
	void OnTriggerStay (Collider collider) {
		if (collider.gameObject.tag == "Player" && canOpenBook) {
			bookOpenText.SetActive (true);
			if (Input.GetButtonDown ("Fire1")) {
				bookOpenText.SetActive (false);
				book.GetComponent<Animation> ().enabled = true;
//				door.SetActive (false);
				book.GetComponent<SphereCollider> ().enabled = false;
				DoorOpen.canOpenDoor = true;
			}
		}
	}
	void OnTriggerExit (Collider collider) {
		if (collider.gameObject.tag == "Player") {
			bookOpenText.SetActive (false);
		}
	}
}
