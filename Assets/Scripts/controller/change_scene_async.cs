using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class change_scene_async : MonoBehaviour {

	public Image loadImage;
	public Text loadIcon;

	// Use this for initialization
	void Start () {
		loadImage.enabled = false;
		loadIcon.enabled = false;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void loadLevelAsync(string level) {
		loadImage.enabled = true;
		loadIcon.enabled = true;
		Application.LoadLevelAsync(level);
	}
}
