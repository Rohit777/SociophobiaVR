using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSystem : MonoBehaviour, AbstractEventSystem {
	// Use this for initialization
	[SerializeField] private GameObject sessionManager;
	private bool inSession = true;

	protected virtual void Start () {

	}
	
	// Update is called once per frame
	protected virtual void Update () {
		if(inSession) {
			foreach (GameObject NPCObject in EntityManager.getObjectsOfType<NPCComponent>()) {
				NPCComponent npcComp = NPCObject.GetComponent<NPCComponent> ();
				StartCoroutine (npcComp.NPCAction ());
			}
		}
		sessionManager.GetComponent<EventManager> ().RepeatEvents ();
		//EventManager.RepeatEvents ();
	}

	public void StopAllNPCAction () {
		inSession = false;
		foreach (GameObject NPCObject in EntityManager.getObjectsOfType<NPCComponent>()) {
			NPCComponent npcComp = NPCObject.GetComponent<NPCComponent> ();
			npcComp.stop ();
		}
		// Regenerate the actions based on NPC_ACTION_LIST.txt file.
	}
}