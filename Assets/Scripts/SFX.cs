using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class SFX : MonoBehaviour {

	public static SFX Data;

	public bool config = false;

	public Slider BMGVolume;
	public Slider SFXVolume;

	// Use this for initialization
	void Start () {
		BMGVolume.onValueChanged.AddListener(updateBMGVolume);
		SFXVolume.onValueChanged.AddListener(updateSFXVolume);
	}

	void Awake() {
		if(Data == null) {
			Data = this;

			if(PlayerPrefs.HasKey("BMGVolume"))
				BMGVolume.value = PlayerPrefs.GetFloat("BMGVolume");

			if(PlayerPrefs.HasKey("SFXVolume"))
				SFXVolume.value = (PlayerPrefs.GetFloat("SFXVolume"));
		}
	}

	// Update is called once per frame
	void Update () {
	}

	public void ChangeConfig() {
		config = !config;
	}
	
	public void updateBMGVolume(float value) {
		if(SoundController.Data != null) {
			SoundController.Data.BMGVolume = value;
			PlayerPrefs.SetFloat("BMGVolume",value);
			PlayerPrefs.Save();
		}
		
	}
	
	public void updateSFXVolume(float value) {
		if(SoundController.Data != null) {
			SoundController.Data.SFXVolume = value;
			PlayerPrefs.SetFloat("SFXVolume",value);
			PlayerPrefs.Save();
		}
	}
}
