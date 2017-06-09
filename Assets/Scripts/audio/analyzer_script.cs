using UnityEngine;
using System.Collections;

public class analyzer_script : MonoBehaviour {

	AudioSource audio;

	public FFTWindow win = FFTWindow.BlackmanHarris;
	public int size = 1024;

	public SpriteRenderer background1;
	public SpriteRenderer background2;
	public SpriteRenderer background3;
	public GameObject nebula;
	public Vector3 nebula_destiny;

	// Use this for initialization
	void Start () {
		if(SoundController.Data != null)
			audio = SoundController.Data.BMGAudioSource;
	}
	
	// Update is called once per frame
	void Update () {

		if(SoundController.Data != null) {
			float[] spectrum = audio.GetSpectrumData(size, 0, win);
			for(int i=0;i<size-1;i++) {
				if(i== 1 || i==8 || i==35)
					Debug.DrawLine(new Vector3(0.05f * i, 0,0), new Vector3(0.05f * i, spectrum[i] * 10, 0), Color.green);
				else
					Debug.DrawLine(new Vector3(0.05f * i, 0,0), new Vector3(0.05f * i, spectrum[i] * 10, 0), Color.red);
			}

			background1.color = new Color(background1.color.r, background1.color.g, background1.color.b, spectrum[1]  * 10);
			background2.color = new Color(background1.color.r, background1.color.g, background1.color.b, spectrum[8] * 10);
			background3.color = new Color(background1.color.r, background1.color.g, background1.color.b, spectrum[35] * 10);
		}

		nebula.transform.position = Vector3.Lerp(nebula.transform.position, nebula_destiny, 0.0001f);
	}
}
