using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairSqueakComponent : NPCComponent {
	public bool stopCoroutines = false;

	private Transform chairObject;
	private AudioSource audioSource;
	private float timeProbability;
	private float sessionEndTime;

	[SerializeField] private float probabilityFactor;
	[SerializeField] private float rotationSpeed;
	[SerializeField] private AudioClip chairSqueakSound;

	private void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = chairSqueakSound;
		chairObject = transform.parent;
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
					//Debug.Log ("Action: " + Time.time);
					EventManager.addEvent (this, Time.time);
				}
				chairObject.Rotate (new Vector3 (0f, 0.4f * Mathf.Sin (Time.time) * rotationSpeed, 0f));
			} else {
				audioSource.Stop ();
			}
			yield return null;
		}
	}

	public override IEnumerator NPCRepeatAction () {
		//Debug.Log ("Repeat: " + Time.time);
		//float timeProbability = 90f;
		while (true) {
			if (timeProbability >= 90f && timeProbability <= 195f) {
				if (!audioSource.isPlaying) {
					audioSource.Play ();
				}
				chairObject.Rotate (new Vector3 (0f, 0.4f * Mathf.Sin (Time.time - sessionEndTime) * rotationSpeed, 0f));
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
		StopCoroutine (NPCAction ());
	}

}
