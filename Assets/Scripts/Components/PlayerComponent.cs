using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityComponent))]
public class PlayerComponent : AbstractComponent {
	
	private void Update () {
		//InvokeRepeating (EventManager.RecordPlayerMovement(transform.rotation), 1f, 3f);
	}

}
