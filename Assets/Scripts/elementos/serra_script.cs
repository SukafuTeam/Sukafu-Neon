using UnityEngine;
using System.Collections;

public class serra_script : MonoBehaviour {

	Rigidbody2D rig;
	public float speed;

	// Use this for initialization
	void Start () {
		rig = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(rig != null) {
			rig.angularVelocity = speed;
		}
	}
}
