using UnityEngine;
using System.Collections;

public class combo_counter : MonoBehaviour {

	TextMesh txt;

	// Use this for initialization
	void Start () {
		txt = this.gameObject.GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		if(txt != null) {
			if(Game.Data.Mecha.combo > 0) {
				txt.text = Game.Data.Mecha.combo.ToString();
			} else {
				txt.text = "";
			}
		}
	}
}
