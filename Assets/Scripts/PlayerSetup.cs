using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

	[SerializeField] private Behaviour[] componentsToDisable;
	[SerializeField] private GameObject playerCamera;

	void Start () {
		if (!isLocalPlayer) {
			DisableComponents ();
		} else {
			Camera.main.gameObject.SetActive (false);
			playerCamera.SetActive (true);
		}
	}

	private void DisableComponents () {
		for (int i = 0; i < componentsToDisable.Length; i++) {
			componentsToDisable [i].enabled = false;
		}
	}
}
