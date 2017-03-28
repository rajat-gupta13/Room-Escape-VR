using UnityEngine;
using System.Collections;

public class Computer : MonoBehaviour {

	public GameObject computer, player, qrCode, connectDiskText, phoneUpText, scanText, imageScreen, dataOnScreens;
	public static bool qrScanned = false;
	public float minDistance = 5f;
	private float distance;
	private bool diskConnected = false;
	private float timeTillText = 3.0f;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (player.transform.position, computer.transform.position);
		if (diskConnected && !qrScanned) {
			phoneUpText.SetActive (true);
			qrCode.SetActive (true);
			if (Phone.phoneOpen) {
				phoneUpText.SetActive(false);
			}
		}
		if (scanText.activeInHierarchy) {
			if (Input.GetButtonDown("Fire1")) {
				scanText.SetActive(false);
				qrScanned = true;
				imageScreen.SetActive(true);
			}
		}

		if (qrScanned) {
			qrCode.SetActive(false);
			if (timeTillText >= 0) {
				timeTillText -= Time.deltaTime;
			} else {
				dataOnScreens.SetActive (true);
				imageScreen.SetActive (false);
			}
		}
	}

	#region IGvrGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter() {
//		Debug.Log (distance);
		if (distance <= minDistance && Microwave.pickedHardDisk && ComputerOn.computerOn && !diskConnected) {
			connectDiskText.SetActive (true);
			if (Input.GetButtonDown ("Fire1")) {
				diskConnected = true;
			}
		}
		if (diskConnected && Phone.phoneOpen && !qrScanned) {
			scanText.SetActive(true);
		}
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
		connectDiskText.SetActive (false);
	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
	public void OnGazeTrigger() {
		if (distance <= minDistance && Microwave.pickedHardDisk && ComputerOn.computerOn) {
			diskConnected = true;
		}
	}

	#endregion
}
