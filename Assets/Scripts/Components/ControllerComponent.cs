using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ControllerComponent : MonoBehaviour {

	[SerializeField] private Transform[] tppCameraPositions;

	private int currentCameraIndex = 0;

	void Start () {
		for (int i = 0; i < tppCameraPositions.Length; i++) {
			if (transform.position.Equals (tppCameraPositions[i].position)) {
				currentCameraIndex = i;
				break;
			}
		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			currentCameraIndex--;
			if (currentCameraIndex < 0) {
				currentCameraIndex = tppCameraPositions.Length - 1;
			}
			WarpTo ();
		} else if (Input.GetKeyDown (KeyCode.D)) {
			currentCameraIndex++;
			if (currentCameraIndex > tppCameraPositions.Length - 1) {
				currentCameraIndex = 0;
			}
			WarpTo ();
		}
	}

	void WarpTo () {
		transform.position = tppCameraPositions [currentCameraIndex].position;
		transform.rotation = tppCameraPositions [currentCameraIndex].rotation;
	}
}
