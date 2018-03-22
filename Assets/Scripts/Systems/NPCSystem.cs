using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSystem : MonoBehaviour, AbstractEventSystem {
	// Use this for initialization
	private bool inSession = true;
	[SerializeField] private List<NPCComponent> behaviorComponents;

	protected virtual void Start () {

	}
	
	// Update is called once per frame
	protected virtual void Update () {
		//Debug.Log ("NPC System");
		if(inSession == true)
		{
			foreach (GameObject NPCObject in EntityManager.getObjectsOfType<NPCComponent>()) {
				NPCComponent npcComp = NPCObject.GetComponent<NPCComponent> ();
				StartCoroutine (npcComp.NPCAction ());
			}
		}
		gameObject.GetComponent<EventManager> ().RepeatEvents ();
		//EventManager.RepeatEvents ();
	}

	public void StopAllNPCAction () {
		inSession = false;
		foreach (NPCComponent component in behaviorComponents) {
			component.stop ();
		}

		// Regenerate the actions based on NPC_ACTION_LIST.txt file.

	}
}