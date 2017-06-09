using UnityEngine;
using System.Collections;

public class ControlFPS_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 1;
		Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
