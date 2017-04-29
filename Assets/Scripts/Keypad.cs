using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Keypad : MonoBehaviour {

	public GameObject keypadText, entryText;
	public GameObject keypad, door1, door2, door3, door4;
	public static bool keypadUsed = false;
	public GameObject player;
	public float minDistance = 3.5f;
	private bool looking = false;
	private float distance;

	// Use this for initialization
	void Start () {
		keypadText.SetActive (false);
		door1.SetActive (true);
		door2.SetActive (true);
		door3.SetActive (false);
		door4.SetActive (false);
		looking = false;
	}

	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (player.transform.position, keypad.transform.position);
		//		Debug.Log (distance);
		if (looking) {
			if (!keypadUsed && Computer.enableKeypad) {
				if (distance <= minDistance) {
					keypadText.SetActive (true);
					if (Input.GetButtonDown ("Fire1")) {
						keypadUsed = true;
						keypadText.SetActive (false);
						entryText.SetActive (true);
						door1.SetActive (false);
						door2.SetActive (false);
						door3.SetActive (true);
						door4.SetActive (true);
					}
				}
			}
		}
	}

	#region IGvrGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter() {
		looking = true;
//		Debug.Log (distance);
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
		keypadText.SetActive (false);
		looking = false;
	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
	public void OnGazeTrigger() {
		if (!keypadUsed && Computer.enableKeypad) {
			if (distance <= minDistance) {
				keypadUsed = true;
				keypadText.SetActive (false);
				entryText.SetActive (true);
				door1.SetActive (false);
				door2.SetActive (false);
				door3.SetActive (true);
				door4.SetActive (true);
			}
		}
	}

	#endregion
}
