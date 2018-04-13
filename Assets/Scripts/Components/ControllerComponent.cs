using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ControllerComponent : MonoBehaviour {

	[SerializeField] private List<Transform> tppCameraPositions;

	private int currentCameraIndex = 0;
	private bool updatedOnce = false;

	void UpdatePositions () {
		if (!updatedOnce) {
			for (int i = 0; i < tppCameraPositions.Count; i++) {
				if (transform.position.Equals (tppCameraPositions [i].position)) {
					currentCameraIndex = i;
					break;
				}
			}
		}
	}

	void Update () {
		if (tppCameraPositions.Count == 0) {
			tppCameraPositions = NetworkManager.singleton.startPositions;
		} else {
			UpdatePositions ();
			if (Input.GetKeyDown (KeyCode.A)) {
				currentCameraIndex--;
				if (currentCameraIndex < 0) {
					currentCameraIndex = tppCameraPositions.Count - 1;
				}
				WarpTo ();
			} else if (Input.GetKeyDown (KeyCode.D)) {
				currentCameraIndex++;
				if (currentCameraIndex > tppCameraPositions.Count - 1) {
					currentCameraIndex = 0;
				}
				WarpTo ();
			}
		}
	}

	void WarpTo () {
		transform.position = tppCameraPositions [currentCameraIndex].position;
		transform.rotation = tppCameraPositions [currentCameraIndex].rotation;
	}
}
