using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSystem : MonoBehaviour, AbstractEventSystem {
	// Use this for initialization
	[SerializeField] private List<NPCComponent> behaviorComponents;

	protected virtual void Start () {

	}
	
	// Update is called once per frame
	protected virtual void Update () {
		foreach (GameObject NPCObject in EntityManager.getObjectsOfType<NPCComponent>()) {
			NPCComponent npcComp = NPCObject.GetComponent<NPCComponent> ();
			StartCoroutine (npcComp.NPCAction ());

		}
		EventManager.RepeatEvents ();
	}

	public void StopAllNPCAction () {
		StopAllCoroutines ();

		// Regenerate the actions based on NPC_ACTION_LIST.txt file.

	}
}