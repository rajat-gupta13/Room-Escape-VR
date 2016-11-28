using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class VRBluetoothController : MonoBehaviour {

    // VR Main Camera
    private Transform vrCamera;
    // Speed to move the player
    public float speed = 3f;
	public GameObject player;
    // CharacterController script
    CharacterController myCC;
	[SerializeField] private float m_StepInterval;
	[SerializeField] private AudioClip[] m_FootstepSounds;    // an array of footstep sounds that will be randomly selected from.
	private AudioSource m_AudioSource;
	private float m_StepCycle;
	private float m_NextStep;

    // Use this for initialization
    void Start () {
        // Find the CharacterController
        myCC = gameObject.GetComponent<CharacterController>();
        // Find the Main Camera
        vrCamera = Camera.main.transform;
		m_AudioSource = GetComponent<AudioSource> ();
		m_NextStep = m_StepCycle / 2f;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        // Move with SimpleMove based on Horizontal adn Vertical input
        myCC.SimpleMove(speed * vrCamera.TransformDirection(Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal")));
		if (Input.GetAxis ("Vertical") == 0 && Input.GetAxis ("Horizontal") == 0) {
			player.GetComponent<Animator> ().enabled = false;
		} else {
			player.GetComponent<Animator> ().enabled = true;
		}
		ProgressStepCycle (speed);
    }

	private void ProgressStepCycle(float speed)
	{
		if (myCC.velocity.sqrMagnitude > 0 && (Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0))
		{
			m_StepCycle += (myCC.velocity.magnitude + (speed))* Time.fixedDeltaTime;
		}

		if (!(m_StepCycle > m_NextStep))
		{
			return;
		}

		m_NextStep = m_StepCycle + m_StepInterval;

		PlayFootStepAudio();
	}

	private void PlayFootStepAudio()
	{
		// pick & play a random footstep sound from the array,
		// excluding sound at index 0
		int n = Random.Range (1, m_FootstepSounds.Length);
		m_AudioSource.clip = m_FootstepSounds [n];
		m_AudioSource.PlayOneShot (m_AudioSource.clip);
		// move picked sound to index 0 so it's not picked next time
		m_FootstepSounds [n] = m_FootstepSounds [0];
		m_FootstepSounds [0] = m_AudioSource.clip;
	}
}
