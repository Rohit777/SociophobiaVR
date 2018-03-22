using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
	public static UIManager instance;

	[SerializeField] private NPCSystem npcSystem;

	void Start () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}
	
	public void StopSessionAction () {
		Debug.Log ("Session stopped");
		npcSystem.StopAllNPCAction ();
		EventManager.closeSession ();
	}
}
