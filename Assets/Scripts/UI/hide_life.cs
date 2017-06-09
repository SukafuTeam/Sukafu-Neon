using UnityEngine;
using UnityEngine.UI;

public class hide_life : MonoBehaviour {

	Image image;
	public int value;

	// Use this for initialization
	void Start () {
		image = this.gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if(image != null) {
			image.enabled = Game.Data.Mecha.health >= value;

		}
	}
}
