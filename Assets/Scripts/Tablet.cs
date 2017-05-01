using UnityEngine;
using System.Collections;

public class Tablet : MonoBehaviour {

	public GameObject tabletText, pipelineText;
	public GameObject tablet;
	private bool tabletPicked = false;
	private bool looking = false;
	public GameObject player, currentScreen, nextScreen;
	public float minDistance = 3.5f;
	private float distance;
	public Vector3 rotationAngle = new Vector3 (0f, -90f, -20f);
	public Vector3 transformDistance = new Vector3 (0f, 2f, 0.5f);
	public GameObject door, door1;
	private float delayTime = 3.0f;

	// Use this for initialization
	void Start () {
		tabletText.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (looking) {
			if (Television.codeScanned && !tabletPicked && Television.tabletConnected) {
				if (distance <= minDistance) {
					tabletText.SetActive (true);
					if (Input.GetButtonDown ("Fire1")) {
						tabletPicked = true;
						tabletText.SetActive (false);
						player.GetComponent<VRBluetoothController> ().enabled = false;
						player.GetComponent<Transform> ().position = new Vector3 (-10f,0.08f, -34.21f);
						tablet.transform.Rotate (rotationAngle);
						tablet.transform.Translate (transformDistance);
						currentScreen.SetActive (false);
						nextScreen.SetActive (true);
						pipelineText.SetActive (true);
					}
				}
			}
		}
		if (tabletPicked && looking && delayTime <= 0.0f) {
			if (Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Fire3")) {
				pipelineText.SetActive (false); 
				tablet.transform.eulerAngles = new Vector3 (180,180,180);
				tablet.transform.position = new Vector3 (-9.859f, 3.18f, -36.62f);
				player.GetComponent<VRBluetoothController> ().enabled = true;
				door.SetActive (false);
				door1.SetActive (true);
			}
		} else if (tabletPicked && looking && delayTime > 0.0f) {
			delayTime -= Time.deltaTime;
		} else {
			distance = Vector3.Distance (player.transform.position, tablet.transform.position);
//			Debug.Log (distance); 
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
		looking = false;
		tabletText.SetActive (false);
	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
	public void OnGazeTrigger() {
		if (Television.tabletConnected && !tabletPicked) {
			if (distance <= minDistance) {
				tabletPicked = true;
				tabletText.SetActive (false);
				player.GetComponent<VRBluetoothController> ().enabled = false;
				player.GetComponent<Transform> ().position = new Vector3 (-10f,0.08f, -34.21f);
				tablet.transform.Rotate (rotationAngle);
				tablet.transform.Translate (transformDistance);
				currentScreen.SetActive (false);
				nextScreen.SetActive (true);
				pipelineText.SetActive (true);

			}
		}
	}

	#endregion
}
