using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Router : MonoBehaviour {

	public GameObject routerText;
	public GameObject[] routerButtons;
	public GameObject router;
	public static bool routerOn = false;
	public GameObject player;
	public float minDistance = 3.5f;
	private bool looking = false;

	private float distance;

	// Use this for initialization
	void Start () {
		routerText.SetActive (false);
		for (int i = 0; i < routerButtons.Length; i++) {
			routerButtons[i].SetActive (false);
		}
		looking = false;
	}

	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (player.transform.position, router.transform.position);
//		Debug.Log (distance);
		if (looking) {
			if (!routerOn) {
				if (distance <= minDistance) {
					routerText.SetActive (true);
					if (Input.GetButtonDown ("Fire1")) {
						routerOn = true;
						for (int i = 0; i < routerButtons.Length; i++) {
							routerButtons [i].SetActive (true);
						}
						routerText.SetActive (false);
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
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
		routerText.SetActive (false);
		looking = false;
	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
	public void OnGazeTrigger() {
		if (!routerOn) {
			if (distance <= minDistance) {
				routerOn = true;
				for (int i = 0; i < routerButtons.Length; i++) {
					routerButtons [i].SetActive (true);
				}
				routerText.SetActive (false);
			}
		}
	}

	#endregion
}
