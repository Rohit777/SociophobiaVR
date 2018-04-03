﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneVibrateBehaviour : NPCComponent {
	public bool stopCoroutines = false;

	private AudioSource audioSource;
	private float timeProbability;
	private float timeProbabilityOnSpot;
	private float sessionEndTime;

	[SerializeField] private float probabilityFactor;
	[SerializeField] private AudioClip vibrateSound;

	private void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = vibrateSound;
	}

	public override IEnumerator NPCAction () {
		timeProbability += probabilityFactor * Time.fixedDeltaTime;
		if (timeProbability > 195f) {
			//XmlUtil.Save (gameObject.name + "/" + "ChairSqueakComponent" + (Time.timeSinceLevelLoad - 105f).ToString());
			//EventManager.addEvent(this, Time.timeSinceLevelLoad - 105f);
			timeProbability = 0f;
		}
		while (true && !stopCoroutines) {
			if (timeProbability >= 90f && timeProbability <= 195f) {
				if (!audioSource.isPlaying) {
					audioSource.Play ();
					//Debug.Log ("Action: " + Time.timeSinceLevelLoad);
					EventManager.addEvent (this, Time.timeSinceLevelLoad);
				}
			} else {
				audioSource.Stop ();
			}
			yield return null;
		}
	}

	public override IEnumerator NPCRepeatAction () {
		//Debug.Log ("Repeat: " + Time.timeSinceLevelLoad);
		float timeProbability = 90f; 
		while (true) {
			if (timeProbability >= 90f && timeProbability <= 195f) {
				if (!audioSource.isPlaying) {
					audioSource.Play ();
				}
			} else {
				audioSource.Stop ();
			}
			timeProbability += probabilityFactor * Time.fixedDeltaTime;
			yield return null;
		}
	}

	public override void setTimeProbability(float tp){
		timeProbability = tp;
	}

	public override void setSessionEndTime(float t){
		sessionEndTime = t;
	}

	public override void stop() {
		stopCoroutines = true;
		audioSource.Stop ();
		StopAllCoroutines ();
	}
}
