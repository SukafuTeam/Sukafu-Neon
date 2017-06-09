using UnityEngine;
using System.Collections.Generic;

public class SoundController : MonoBehaviour {

	public static SoundController Data;

	public Dictionary<string, AudioSource> AudioSources;
	public float SFXVolume;
	public bool mutedSFX;

	public AudioSource BMGAudioSource;

	public string actualBMG;
	public float BMGVolume;
	public bool mutedBMG;

	public void Awake() {
		if(Data == null) {
		
			DontDestroyOnLoad(this.gameObject);
			Data = this;

			BMGAudioSource = this.gameObject.GetComponent<AudioSource>();

			AudioSources = new Dictionary<string, AudioSource>();

			if(PlayerPrefs.HasKey("SFXVolume"))
				SFXVolume = (PlayerPrefs.GetFloat("SFXVolume"));
			else
				SFXVolume = 1;

			if(PlayerPrefs.HasKey("BMGVolume"))
				BMGVolume = PlayerPrefs.GetFloat("BMGVolume");
			else
				BMGVolume = 1;


			if(!mutedBMG) {
				BMGAudioSource.Play();
				BMGAudioSource.volume = BMGVolume;
			}

			AudioSource[] sources = this.gameObject.GetComponentsInChildren<AudioSource>();
			for(int i=0;i< sources.Length;i++) {
				sources[i].volume = SFXVolume;
				AudioSources[sources[i].gameObject.name] = sources[i];
				DontDestroyOnLoad(sources[i]);
			}

		} else {
			Data = SoundController.Data;
		}
	}

	// Use this for initialization
	void Start () {
		// PUT THIS WHAT WIL BE RESETED EVERYTIME THE GAME OPENS
	}

	// Update is called once per frame
	void Update () {
		if(Data != null) {
			if(BMGAudioSource != null)
				BMGAudioSource.volume = BMGVolume;

			foreach(string key in AudioSources.Keys) {
				if(AudioSources[key] != BMGAudioSource)
					AudioSources[key].volume = SFXVolume * 0.4f;
			}
		}
	}
}
