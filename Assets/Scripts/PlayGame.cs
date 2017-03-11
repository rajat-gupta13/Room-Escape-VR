using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {

	public bool testing = true;
	// Use this for initialization
	void Start () {
//		PlayerPrefs.DeleteAll ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Play () {
		if (testing || !PlayerPrefs.HasKey ("isFirstTime") || PlayerPrefs.GetInt ("isFirstTime") != 1) {
			SceneManager.LoadScene (1);
			// Show your prologue here.
			// Now set the value of isFirstTime to be false in the PlayerPrefs.
			PlayerPrefs.SetInt ("isFirstTime", 1);
			PlayerPrefs.Save ();
		} else {
			SceneManager.LoadScene (2);
		}
	}

	public void Quit () {
		Application.Quit ();
	}
}
