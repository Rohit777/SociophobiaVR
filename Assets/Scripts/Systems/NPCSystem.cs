using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSystem : MonoBehaviour, AbstractEventSystem {
	// Use this for initialization
	[SerializeField] private GameObject sessionManager;
	private bool inSession = true;

	protected virtual void Start () {
		EntityManager.Start ();
	}
	
	// FixedUpdate is called once per frame
	protected virtual void FixedUpdate () {
		if (inSession) {
			foreach (GameObject NPCObject in EntityManager.getObjectsOfType<NPCComponent>()) {
				NPCComponent[] npcComps = NPCObject.GetComponents<NPCComponent> ();
				foreach (NPCComponent npcComp in npcComps) {
					StartCoroutine (npcComp.NPCAction ());
				}
			}
		}
		sessionManager.GetComponent<EventManager> ().RepeatEvents ();
	}

	public void StopAllNPCAction () {
		inSession = false;
		sessionManager.GetComponent<EventManager> ().closingSession ();
		foreach (GameObject NPCObject in EntityManager.getObjectsOfType<NPCComponent>()) {
			NPCComponent[] npcComps = NPCObject.GetComponents<NPCComponent> ();
			foreach (NPCComponent npcComp in npcComps) {
				npcComp.stop ();
			}
		}
	}
}