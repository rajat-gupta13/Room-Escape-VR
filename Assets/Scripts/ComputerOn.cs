using UnityEngine;
using System.Collections;

public class ComputerOn : MonoBehaviour {

	public GameObject screen1,screen2,screen3,screen4,screen5,keyboard;
	public static bool computerOn = false;
	public GameObject player;
	public float minDistance = 7.5f;

	private float distance;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (player.transform.position, keyboard.transform.position);
	}

	#region IGvrGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter() {
//		Debug.Log (distance);
		if (distance <= minDistance) {
			if (Input.GetButtonDown ("Fire1")) {
				screen1.SetActive (true);
				screen2.SetActive (true);
				screen3.SetActive (true);
				screen4.SetActive (true);
				screen5.SetActive (true);
				computerOn = true;
			}
		}
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
		
	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
	public void OnGazeTrigger() {
		if (distance <= minDistance) {
			screen1.SetActive (true);
			screen2.SetActive (true);
			screen3.SetActive (true);
			screen4.SetActive (true);
			screen5.SetActive (true);
			computerOn = true;
		}
	}
	#endregion
}
