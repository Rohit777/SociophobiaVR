using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairSqueakComponent : AbstractComponent {
	private float probabilityFactor;
	private Transform chairObject;
	private AudioSource audioSource;

	[SerializeField] private float timeProbability;
	[SerializeField] private float rotationSpeed;
	[SerializeField] private AudioClip chairSqueakSound;

	private void Start () {
		audioSource = GetComponent<AudioSource> ();
		chairObject = transform.parent;
		probabilityFactor = Mathf.Exp (-3.0f);
		timeProbability = Mathf.Clamp (Mathf.Exp (probabilityFactor * Time.time), 0f, 100f);
	}

	IEnumerator SqueakAnimation () {
		while (true) {
			chairObject.Rotate (new Vector3 (0f, Mathf.Sin (Time.time) * rotationSpeed, 0f));
			yield return null;
		}
	}
}
