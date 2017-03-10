using UnityEngine;
using System.Collections;

public class Tablet : MonoBehaviour {

	public GameObject tabletText;
	public GameObject tablet;
	private bool tabletPicked = false;
	public GameObject player;
	public float minDistance = 3.5f;

	private float distance;

	// Use this for initialization
	void Start () {
		tabletText.SetActive (false);

	}

	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (player.transform.position, tablet.transform.position);
//		Debug.Log (distance);
	}

	#region IGvrGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter() {
		if (!tabletPicked) {
			if (distance <= minDistance) {
				tabletText.SetActive (true);
				if (Input.GetButtonDown ("Fire1")) {
					tabletPicked = true;
					tabletText.SetActive (false);
					player.GetComponent<VRBluetoothController> ().enabled = false;
				}
			}
		}
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
		tabletText.SetActive (false);
	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
	public void OnGazeTrigger() {
		if (!tabletPicked) {
			if (distance <= minDistance) {
				tabletPicked = true;
				tabletText.SetActive (false);
				player.GetComponent<VRBluetoothController> ().enabled = false;
			}
		}
	}

	#endregion
}
