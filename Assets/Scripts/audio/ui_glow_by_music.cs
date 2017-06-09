using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ui_glow_by_music : MonoBehaviour {

	public AudioSource audio;
	
	public FFTWindow win = FFTWindow.BlackmanHarris;
	public int size = 1024;
	
	public float alphaBy = 1f;


	// Use this for initialization
	void Start () {
		if(SoundController.Data != null)
			audio = SoundController.Data.BMGAudioSource;
	}
	
	// Update is called once per frame
	void Update () {
		if(SoundController.Data != null) {
			if(audio != null) {
				float[] spectrum = audio.GetSpectrumData(size, 0, win);
				
				float alpha = 0.1f;
				
				alpha = (spectrum[2] * alphaBy);
				
				Image img = this.gameObject.GetComponent<Image>();
				if(img != null) {
					Color col = img.color;
					col.a = alpha;
					img.color = col;
				}
			}
		}
	}
}
