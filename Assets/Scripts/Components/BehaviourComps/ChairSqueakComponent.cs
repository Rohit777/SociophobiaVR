using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairSqueakComponent : NPCComponent {
	private Transform chairObject;
	private AudioSource audioSource;

	[SerializeField] private float timeProbability;
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
			timeProbability = 0f;
		}
		while (true) {
			if (timeProbability >= 90f && timeProbability <= 195f) {
				if (!audioSource.isPlaying)
					audioSource.Play ();
	
				chairObject.Rotate (new Vector3 (0f, 0.5f * Mathf.Sin (Time.time) * rotationSpeed, 0f));
			} else {
				audioSource.Stop ();
			}
			yield return null;
		}
	}
}
