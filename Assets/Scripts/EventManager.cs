using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {
	private static List<NPCComponent> componentList = new List<NPCComponent> ();
	private static List<float> timeList = new List<float>();
	private static bool inSession = true;
	private static float sessionCloseTime;

	// Use this for initialization
	void Start () {
		
	}

	public static void closeSession(){
		if (inSession == true) {
			inSession = false;
			sessionCloseTime = Time.time;
			Debug.Log ("Session end time: " + sessionCloseTime);
		}
	}

	public static void addEvent(NPCComponent component, float time){
		if (inSession == true) {
			componentList.Add (component);
			timeList.Add (time);
		}
	}


	public void RepeatEvents () {
		if (inSession == false) {
			int s = componentList.Count;
			float diff = Time.time - sessionCloseTime;
			for (int i = 0; i < s; i++) {
				//Debug.Log ("Here");
				//Debug.Log (timeList [i] + " " + diff + " " +Time.time);
				if (timeList [i] <= diff) {
					Debug.Log (timeList [i] + " " + diff + " " +Time.time);
					//componentList [i].NPCAction ();
					//componentList[i].setTimeProbability(90f);
					StartCoroutine (componentList[i].NPCRepeatAction());
					componentList.RemoveAt (i);
					timeList.RemoveAt (i);
					i--;
					s--;
				}
			}
		}
	}

	// Update is called once per frame
	void update(){
		RepeatEvents ();
	}
}
