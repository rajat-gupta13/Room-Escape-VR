using UnityEngine;
using System.Collections;

public class Microwave : MonoBehaviour {

	public static bool microwaveOpened = false;
	public GameObject player, microwave, hardDiskText, hardDisk;
	public AudioClip[] clips;
	private AudioSource audioSource;
	public float minDistance = 5.0f;
	private float distance;
	private Animation openMicro;
	private bool playedClip1 = false;
	public static bool pickedHardDisk = false;
	private bool looking = false;
	private float delayTime = 2.0f;
	// Use this for initialization
	void Start () {
		audioSource = microwave.GetComponent<AudioSource> ();
		openMicro = microwave.GetComponent<Animation> ();
		looking = false;
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (player.transform.position, microwave.transform.position);
		if (looking) {
			if (distance <= minDistance) {
				if (Input.GetButtonDown ("Fire1")) {
					microwaveOpened = true;
					openMicro.enabled = true;
					if (microwaveOpened && !pickedHardDisk) {
						hardDiskText.SetActive (true);
					}
				}
			}
		}
		if (!microwaveOpened && ComputerOn.computerOn && !playedClip1) {
			audioSource.clip = clips [0];
			audioSource.Play ();
			playedClip1 = true;
		}
		if (!audioSource.isPlaying && !microwaveOpened && ComputerOn.computerOn && playedClip1) {
			audioSource.clip = clips [1];
			audioSource.loop = true;
			audioSource.Play ();
		} else if (microwaveOpened) {
			audioSource.Stop ();
		}
		if (microwaveOpened && hardDiskText.activeInHierarchy && delayTime <= 0.0f) {
			if (Input.GetButtonDown ("Fire1")) {
				hardDisk.SetActive (false);
				hardDiskText.SetActive (false);
				pickedHardDisk = true;
			}
		} else if (microwaveOpened && hardDiskText.activeInHierarchy && delayTime > 0.0f){
			delayTime -= Time.deltaTime;
		}
	}

	#region IGvrGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter() {
//		Debug.Log (distance);
		looking = true;
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
		hardDiskText.SetActive (false);
		looking = false;
	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
	public void OnGazeTrigger() {
		if (distance <= minDistance) {
			microwaveOpened = true;
			openMicro.enabled = true;
			if (microwaveOpened && !pickedHardDisk) {
				hardDiskText.SetActive (true);
			}
		}
	}

	#endregion
}
