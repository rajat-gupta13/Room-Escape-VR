using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Television : MonoBehaviour {

	public GameObject remoteNotPickedText; 
	public GameObject televisionText, onScreen;
	public static bool televisionOn = false;

	// Use this for initialization
	void Start () {
		remoteNotPickedText.SetActive (false);
		televisionText.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (RemotePicker.remotePicked) {
			remoteNotPickedText.SetActive (false);
		}
	}


	#region IGvrGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter() {
		if (!RemotePicker.remotePicked) {
			remoteNotPickedText.SetActive (true);
		} else if (RemotePicker.remotePicked) {
			remoteNotPickedText.SetActive (false);
			televisionText.SetActive (true);
			if (Input.GetButtonDown ("Fire1")) {
				televisionOn = true;
				onScreen.SetActive (true);
				televisionText.SetActive (false);
			}
		}
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
		remoteNotPickedText.SetActive (false);
		televisionText.SetActive (false);
	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
	public void OnGazeTrigger() {
		televisionOn = true;
		onScreen.SetActive (true);
		televisionText.SetActive (false);
	}

	#endregion
}
