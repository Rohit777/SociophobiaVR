using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneVibrateBehaviour : NPCComponent {
	private AudioSource audioSource;
	private float timeProbability;

	[SerializeField] private float probabilityFactor;
	[SerializeField] private AudioClip vibrateSound;

	private void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = vibrateSound;
	}

	public override IEnumerator NPCAction () {
		timeProbability += probabilityFactor * Time.fixedDeltaTime;
		if (timeProbability > 195f) {
			XmlUtil.Save (gameObject.name + "/" + "ChairSqueakComponent" + (Time.time - 105f).ToString());
			timeProbability = 0f;
		}
		while (true) {
			if (timeProbability >= 90f && timeProbability <= 195f) {
				if (!audioSource.isPlaying)
					audioSource.Play ();
			} else {
				audioSource.Stop ();
			}
			yield return null;
		}
	}
}
