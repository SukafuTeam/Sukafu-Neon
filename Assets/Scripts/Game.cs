using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Game : MonoBehaviour {
	
	public static Game Data;
	public bool Paused = false;
	public bool gameover = false;
	public bool bullet = false;
	public MechaData Mecha;
	public float globalSpeed = 1;
	public float HSpeed;
	public float tempoRestante;
	public Animator flash_animator;
	public float shake;
	
	// BMG related things
	public string LevelMusicName;
	public AudioClip LevelMusic;

	// Menu
	public bool begin;

	//GAme over
	public Grayscale gray;

	public void Awake() {
		if (Data == null) {
			Data = this;

			Mecha.health = 3;
			begin = false;

			if(SoundController.Data != null) {
				if(!SoundController.Data.mutedBMG) {
					if(SoundController.Data.actualBMG != LevelMusicName) {

						if(SoundController.Data.BMGAudioSource != null)
							SoundController.Data.BMGAudioSource.Pause();

						if(LevelMusic != null) {
							SoundController.Data.BMGAudioSource.clip = LevelMusic;
							SoundController.Data.BMGAudioSource.loop = true;
							SoundController.Data.BMGAudioSource.Play();
						}
						SoundController.Data.actualBMG = LevelMusicName;
					}
				}
			}

			gray = Camera.main.GetComponent<Grayscale>();
		}
	}

	void Update() {

		if(gray != null) {
			gray.enabled = Game.Data.gameover;
		}

		if(Mecha.health < 1) {
			gameover = true;
			HSpeed = 0;
		}

		BlurOptimized blur = Camera.main.gameObject.GetComponent<BlurOptimized>();
		if(blur != null) {
			blur.enabled = gameover;
		}

		if(SoundController.Data != null) {
			SoundController.Data.BMGAudioSource.pitch = globalSpeed;
		}

		if(Mecha.Root.transform.position.x > 12) {
			HSpeed = 25;
		} else if(Mecha.Root.transform.position.x > 10){
			HSpeed = 20;
		} else {
			HSpeed = 15;
		}

		if(Mecha.recovery) {
			if(Mecha.timeRecovery > 0){
				Mecha.timeRecovery -= Time.deltaTime;
			} else {
				Mecha.recovery = false;
			}
		}

		if(Mecha.timeToResetCombo > 0) {
			Mecha.timeToResetCombo -= Time.deltaTime;
			if(Mecha.timeToResetCombo <= 0) {
				Mecha.combo = 0;
			}
		}

		if(!Game.Data.Paused) {
			if(bullet) {
				Mecha.Animator.speed = 0;
				Mecha.RigidBody.velocity = new Vector2(0,0);
				globalSpeed = 0.5f;
			} else {
				Mecha.Animator.speed = 1;
				if(globalSpeed < 1) {
					globalSpeed += 0.05f;
					if(globalSpeed > 1)
						globalSpeed = 1; 
				}
			}
		}

	

		AudioLowPassFilter low = Camera.main.GetComponent<AudioLowPassFilter>();
		if(low != null) {
			if(Game.Data.Paused) {
				if(low.cutoffFrequency > 1400)
					low.cutoffFrequency -= 500;
			} else {
				if(low.cutoffFrequency < 22000) {
					low.cutoffFrequency += 500;
				}
			}
		}
	}
	
    [System.Serializable]
	public class MechaData {
		public GameObject Root;
		private Rigidbody2D _rigidbody;
		private Animator _animator;
		public bool dead = false;
		public bool aiming = false;
		public bool invencible = false;
		public bool recovery = false;
		public float timeRecovery = 0;
		public int health = 3;
		public bool wasGrounded = false;
		public GameObject target;
		public float timeToResetCombo = 0;
		public int combo;

		public Rigidbody2D RigidBody {
			get {
				if (_rigidbody == null && Root != null)
					_rigidbody = Root.GetComponent<Rigidbody2D>();
				return _rigidbody;
			}
		}

		public Animator Animator {
			get {
				if (_animator == null && Root != null)
					_animator = Root.GetComponent<Animator>();
				return _animator;
			}
		}
	}

	static public void Flash() {
		Game.Data.flash_animator.SetBool("Flash", true);
	}


	static public GameObject Spawn(GameObject gameObject, Vector3 position, Quaternion rotation) {
#if UNITY_EDITOR
		GameObject clone = PrefabUtility.InstantiatePrefab(gameObject) as GameObject;
		clone.transform.position = position;
		clone.transform.rotation = rotation;
		return clone;
#else
		return Object.Instantiate(gameObject, position, rotation) as GameObject;
#endif
	}
}
