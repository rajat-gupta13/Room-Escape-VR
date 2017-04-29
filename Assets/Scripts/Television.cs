 using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Television : MonoBehaviour {

	public GameObject remoteNotPickedText,phoneUpText, scanText, connectedTabletText; 
	public GameObject televisionText, onScreen, connectedScreen, QR, imageScreen, notConnectedText;
	public static bool televisionOn = false;
    private bool televisionConnected = false;
	public static bool codeScanned = false;
	private float timeTillText = 3.0f;
	public static bool tabletConnected = false;
	private bool looking = false;

	// Use this for initialization
	void Start () {
		remoteNotPickedText.SetActive (false);
		televisionText.SetActive (false);
		looking = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (looking) {
			if (!RemotePicker.remotePicked) {
				remoteNotPickedText.SetActive (true);
			} else if (RemotePicker.remotePicked && !Router.routerOn && !televisionOn) {
				remoteNotPickedText.SetActive (false);
				televisionText.SetActive (true);
				if (Input.GetButtonDown ("Fire1")) {
					televisionOn = true;
					onScreen.SetActive (true);
					notConnectedText.SetActive (true);
					televisionText.SetActive (false);
				}
			} else if (RemotePicker.remotePicked && Router.routerOn && !televisionOn) { 
				remoteNotPickedText.SetActive (false);
				televisionText.SetActive (true);
				if (Input.GetButtonDown ("Fire1")) {
					televisionOn = true;
					connectedScreen.SetActive (true);
					notConnectedText.SetActive (false);
					televisionText.SetActive (false);
					televisionConnected = true;
				}
			} else if (televisionOn && Router.routerOn) {
				notConnectedText.SetActive (false);
				connectedScreen.SetActive (true);
				televisionConnected = true;
			}
			if (televisionConnected && Phone.phoneOpen && !codeScanned) {
				scanText.SetActive (true);
			} else {
				scanText.SetActive (false);
			}
		}
		if (RemotePicker.remotePicked) {
			remoteNotPickedText.SetActive (false);
		}
		if (televisionOn && !Router.routerOn) {
			notConnectedText.SetActive (true);	
		} else {
			notConnectedText.SetActive (false);
		}
		if (televisionConnected && !codeScanned) {
			phoneUpText.SetActive (true);
			QR.SetActive (true);
			if (Phone.phoneOpen) {
				phoneUpText.SetActive (false);
			}
		} 

		if (televisionConnected && !codeScanned && !Phone.phoneOpen) {
			phoneUpText.SetActive (true);
			scanText.SetActive (false);
			QR.SetActive (true);
			if (Phone.phoneOpen) {
				phoneUpText.SetActive (false);
			}
		} 
//		if (!Phone.phoneOpen){
//			scanText.SetActive (false);
//		}
        if (scanText.activeInHierarchy) {
            if (Input.GetButtonDown("Fire1")) {
                scanText.SetActive(false);
                codeScanned = true;
                imageScreen.SetActive(true);
            }
        }

		if (codeScanned) {
			QR.SetActive(false);
			if (timeTillText >= 0) {
				timeTillText -= Time.deltaTime;
			} else {
				connectedTabletText.SetActive (true);
				imageScreen.SetActive (false);
				tabletConnected = true;
			}
		}
	}


	#region IGvrGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter() {
		looking = true;
    }

 

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
		remoteNotPickedText.SetActive (false);
		televisionText.SetActive (false);
        scanText.SetActive(false);
		looking = false;
    }

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
	public void OnGazeTrigger() {
		if (RemotePicker.remotePicked) {
			televisionOn = true;
			onScreen.SetActive (true);
			televisionText.SetActive (false);
		}
	}

	#endregion
}
