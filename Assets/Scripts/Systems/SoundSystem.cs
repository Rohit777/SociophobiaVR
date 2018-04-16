using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour {

	[SerializeField] private int sessionLength;
	[SerializeField] private int recordingFrequency;

	private GvrAudioSource audioSource;

	private void Start () {
		audioSource = GetComponent<GvrAudioSource> (); 
		audioSource.clip = Microphone.Start("", false, sessionLength, recordingFrequency);
	}

	public void Update () {
		Debug.Log (EventManager.inSession);
		if (!EventManager.inSession) {
			Debug.Log ("Okay");
			audioSource.Play ();
		}
	}
}
