using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {
	private static List<NPCComponent> componentList = new List<NPCComponent> ();
	private static List<Quaternion> playerRotationList;
	private static List<float> timeList = new List<float>();
	private static bool inSession = true;
	private static float sessionCloseTime;

	// Use this for initialization
	void Start () {

	}

	public void closeSession () {
		if (inSession) {
			inSession = false;
			sessionCloseTime = Time.timeSinceLevelLoad;
			Debug.Log ("Session end time: " + sessionCloseTime);
		}
	}

	public static void addEvent(NPCComponent component, float time) {
		if (inSession) {
			componentList.Add (component);
			timeList.Add (time);
		}
	}
		
	public void RepeatEvents () {
		if (!inSession) {
			int s = componentList.Count;
			float diff = Time.timeSinceLevelLoad - sessionCloseTime;
			for (int i = 0; i < s; i++) {
				if (timeList [i] <= diff) {
					Debug.Log (timeList [i] + " " + diff + " " +Time.timeSinceLevelLoad);
					componentList [i].setTimeProbability(90f);
					//componentList [i].setSessionEndTime (sessionCloseTime);
					StartCoroutine (componentList [i].NPCRepeatAction ());
					componentList.RemoveAt (i);
					timeList.RemoveAt (i);
					i--;
					s--;
				}
			}
		}
	}

	public static void RecordPlayerMovement (Quaternion _rotation) {
		playerRotationList.Add (_rotation);
	}
}
