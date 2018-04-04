using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour {
	public static UIManager instance;

	[SerializeField] private NPCSystem npcSystem;
	[SerializeField] private Transform compListParent;

	private GameObject npcComponentListPrefab;
	private GameObject componentListItemPrefab;
	private GameObject npcGameObjectName;
	private GameObject compListItemParent;

	void Start () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
		npcComponentListPrefab = (GameObject) Resources.Load ("ComponentList");
		componentListItemPrefab = (GameObject) Resources.Load ("ComponentButton");
		npcGameObjectName = (GameObject)Resources.Load ("GameObjectName");
		ControllerUISetup ();
	}
	
	public void StopSessionAction () {
		//Debug.Log ("Session stopped");
		npcSystem.StopAllNPCAction ();
		EventManager.closeSession ();
	}

	void ControllerUISetup () {
		foreach (GameObject NPCObject in EntityManager.getObjectsOfType<NPCComponent>()) {
			GameObject _newList = Instantiate (npcComponentListPrefab);
			_newList.transform.position = Vector3.zero;
			_newList.transform.rotation = Quaternion.identity;
			_newList.transform.SetParent (compListParent);

			NPCComponent[] npcComps = NPCObject.GetComponents<NPCComponent> ();
			compListItemParent = _newList.transform.GetChild (0).GetChild (0).gameObject;
			GameObject _nameObj = Instantiate (npcGameObjectName);
			_nameObj.GetComponent<Text> ().text = NPCObject.name;
			_nameObj.transform.SetParent (compListItemParent.transform);
			foreach (NPCComponent npcComp in npcComps) {
				GameObject _newListItem = Instantiate (componentListItemPrefab);
				_newListItem.transform.SetParent (compListItemParent.transform);
				_newListItem.GetComponent<ComponentListItem> ().Setup (npcComp);
			}
		}
	}
}
