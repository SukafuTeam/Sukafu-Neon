using UnityEngine;
using UnityEngine.UI;

public class show_elements_pause : MonoBehaviour {

	Image img;
	Button btn;
	Text txt;

	// Use this for initialization
	void Start () {
		img = this.gameObject.GetComponent<Image>();
		btn = this.gameObject.GetComponent<Button>();
		txt = this.gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		bool show = Game.Data.Paused;
		if(img != null)
			img.enabled = show;
		if(btn != null)
			btn.enabled = show;
		if(txt != null)
			txt.enabled = show;
	}
}
