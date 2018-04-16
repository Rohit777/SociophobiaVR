using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NPCSystem : NetworkBehaviour, AbstractEventSystem {
	private bool inSession = true;

	protected virtual void Start () {
		EntityManager.Start ();
	}
	
	// FixedUpdate is called once per frame
	protected virtual void FixedUpdate () {
		EntityManager.Start ();

		if (inSession) {
			foreach (GameObject NPCObject in EntityManager.getObjectsOfType<NPCComponent>()) {
				NPCComponent[] npcComps = NPCObject.GetComponents<NPCComponent> ();
				foreach (NPCComponent npcComp in npcComps) {
					StartCoroutine (npcComp.NPCAction ());
				}
			}
		} else {
			GetComponent<EventManager> ().RepeatEvents ();
		}
	}

	public void StopAllNPCAction () {
		inSession = false;
		GetComponent<EventManager> ().closeSession ();
		foreach (GameObject NPCObject in EntityManager.getObjectsOfType<NPCComponent>()) {
			NPCComponent[] npcComps = NPCObject.GetComponents<NPCComponent> ();
			foreach (NPCComponent npcComp in npcComps) {
				npcComp.stop ();
			}
		}
	}
}