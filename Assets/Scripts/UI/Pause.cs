using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Paused() {
		if(Game.Data.Paused) {
			Time.timeScale = 1;
			Game.Data.Paused = !Game.Data.Paused;
		} else {
			Time.timeScale = 0;
			Game.Data.Paused = !Game.Data.Paused;
		}

	}
}
