﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneVibrateBehaviour : NPCComponent {
	public bool stopCoroutines = false;

	private AudioSource audioSource;
	private float timeProbability;
	private float timeProbabilityOnSpot;

	[SerializeField] private float probabilityFactor;
	[SerializeField] private AudioClip vibrateSound;

	private void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = vibrateSound;
	}

	public override IEnumerator NPCAction () {
		timeProbability += probabilityFactor * Time.fixedDeltaTime;
		if (timeProbability > 195f) {
			//XmlUtil.Save (gameObject.name + "/" + "ChairSqueakComponent" + (Time.time - 105f).ToString());
			//EventManager.addEvent(this, Time.time - 105f);
			timeProbability = 0f;
		}
		while (true && !stopCoroutines) {
			if (timeProbability >= 90f && timeProbability <= 195f) {
				if (!audioSource.isPlaying) {
					audioSource.Play ();
					Debug.Log ("Action: " + Time.time);
					EventManager.addEvent (this, Time.time);
				}
			} else {
				audioSource.Stop ();
			}
			yield return null;
		}
	}

	public override IEnumerator NPCRepeatAction () {
		timeProbability += probabilityFactor * Time.fixedDeltaTime;
		if (timeProbability > 195f) {
			//XmlUtil.Save (gameObject.name + "/" + "ChairSqueakComponent" + (Time.time - 105f).ToString());
			//EventManager.addEvent(this, Time.time - 105f);
			timeProbability = 0f;
		}
		while (true && !stopCoroutines) {
			if (timeProbability >= 90f && timeProbability <= 195f) {
				if (!audioSource.isPlaying) {
					audioSource.Play ();
					Debug.Log ("Repeat: " + Time.time);
					//EventManager.addEvent (this, Time.time);
				}
			} else {
				audioSource.Stop ();
			}
			yield return null;
		}
	}

	public override void setTimeProbability(float tp){
		timeProbability = tp;
	}

	public override void stop() {
		stopCoroutines = true;
		audioSource.Stop ();
		StopAllCoroutines ();
	}
}
