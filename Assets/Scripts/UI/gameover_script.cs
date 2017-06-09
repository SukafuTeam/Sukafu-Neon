using UnityEngine;
using UnityEngine.UI;

public class gameover_script : MonoBehaviour {

	public Sprite[] images;
	public Sprite selected_image;

	public Image text;
	public Image touchAgain;
	public Button begin;
	public Image beginImage;

	// Use this for initialization
	void Start () {
		selected_image = images[Random.Range(0, images.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		bool show = Game.Data.gameover;
		text.enabled = show;
		touchAgain.enabled = show;
		begin.enabled = show;
		beginImage.enabled = show;
	}

	public void Restart() {
		PlayerPrefs.SetInt("menu", 1);
		PlayerPrefs.Save();
		Application.LoadLevel(Application.loadedLevel);
	}
}
