using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class RemotePicker : MonoBehaviour {

	public GameObject remoteText;
	public GameObject remote;
	public static bool remotePicked = false;
	public GameObject player;
	public float minDistance = 7.5f;

	private float distance;

	// Use this for initialization
	void Start () {
		remoteText.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (player.transform.position, remote.transform.position);
	}

	#region IGvrGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter() {
		if (distance <= minDistance) {
			remoteText.SetActive (true);
			if (Input.GetButtonDown ("Fire1")) {
				remotePicked = true;
				remote.SetActive (false);
				remoteText.SetActive (false);
			}
		}
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
		remoteText.SetActive (false);
	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
	public void OnGazeTrigger() {
		if (distance <= minDistance) {
			remotePicked = true;
			remote.SetActive (false);
			remoteText.SetActive (false);
		}
	}

	#endregion
}
