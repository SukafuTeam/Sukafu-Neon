using UnityEngine;
using UnityEngine.UI;

public class button_pause_show : MonoBehaviour {

	Button btn;

	// Use this for initialization
	void Start () {
		btn = this.gameObject.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		if(btn != null) {
			btn.enabled = Game.Data.begin;
		}
	}
}
