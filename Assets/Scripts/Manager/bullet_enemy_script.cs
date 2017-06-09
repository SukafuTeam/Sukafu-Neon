using UnityEngine;
using System.Collections;

public class bullet_enemy_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Enter() {
		Game.Data.bullet = true;
		Game.Data.tempoRestante = 10;
	}

	public void Exit() {
		Game.Data.bullet = false;
	}
}
