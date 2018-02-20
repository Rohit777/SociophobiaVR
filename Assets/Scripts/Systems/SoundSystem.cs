using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour {

	[SerializeField] private int sessionLength;
	[SerializeField] private int recordingFrequency;
	[SerializeField] private GameObject player;

	private GvrAudioSource audioSource;

	private void Start () {
		audioSource = player.GetComponent<GvrAudioSource> (); 
		audioSource.clip = Microphone.Start("", false, sessionLength, recordingFrequency);
	}

	public void PlayRecordedAudio () {
		audioSource.Play ();
	}
}
