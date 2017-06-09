using UnityEngine;
using System.Collections;

public class scale_by_music : MonoBehaviour {

	public AudioSource audio;

	public FFTWindow win = FFTWindow.BlackmanHarris;
	public int size = 1024;

	public float scaleBy = 0.3f;

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
				for(int i=0;i<size-1;i++) {
					Debug.DrawLine(new Vector3(0.05f * i, 0,0), new Vector3(0.05f * i, spectrum[i] * 5, 0), Color.red);
				}

				float scale = 1;

				scale = 1 + (spectrum[3] * scaleBy);

				this.gameObject.transform.localScale = new Vector3(scale, scale, scale);
			}
		}
	}
}
