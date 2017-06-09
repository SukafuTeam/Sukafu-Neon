using UnityEngine;
using System.Collections;

public class mira_script : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.x - Game.Data.Mecha.Root.transform.position.x < 1) {
			Game.Data.Mecha.aiming = false;
			Destroy(this.gameObject);
		}
	}

	void LateUpdate() {
		if(target != null) {
			this.transform.position = target.transform.position;
		} else {
			Game.Data.Mecha.aiming = false;
			Destroy(this.gameObject);
		}
	}
}
