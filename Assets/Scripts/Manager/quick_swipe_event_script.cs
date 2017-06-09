using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class quick_swipe_event_script : MonoBehaviour {


	public Image texto1;
	public Image texto2;
	public Image texto3;

	public Sprite dirCimaAzul;
	public Sprite dirDireitaAzul;
	public Sprite dirBaixoAzul;
	public Sprite diresquerdaAzul;

	public Sprite dirCimaVerde;
	public Sprite dirDireitaVerde;
	public Sprite dirBaixoVerde;
	public Sprite diresquerdaVerde;

	bool last_value;

	public enum Direcoes {
		Cima,
		Direita, 
		Baixo,
		Esquerda
	}

	public Direcoes dir1;
	public Direcoes dir2;
	public Direcoes dir3;

	public int direcao_atual;


	private float fingerStartTime  = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;
	
	private bool isSwipe = false;
	private float minSwipeDist  = 50.0f;
	private float maxSwipeTime = 0.5f;


	bool swipeUp = false;
	bool swipeRight = false;
	bool swipeDown = false;
	bool swipeLeft = false;

	// Use this for initialization
	void Start () {
		texto1.enabled = false;
		texto2.enabled = false;
		texto3.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if(Game.Data.bullet) {
			if(Game.Data.tempoRestante > 0) {
				Game.Data.tempoRestante -= Time.deltaTime;

				// Acabou de entrar no bullet
				if(!last_value) {

					texto1.enabled = true;
					texto2.enabled = true;
					texto3.enabled = true;

					swipeUp = false;
					swipeRight = false;
					swipeDown = false;
					swipeLeft = false;


					int ran = Random.Range(0,4);
					switch(ran) {
					case 0: 
						dir1 = Direcoes.Cima;
						texto1.sprite = dirCimaAzul;
						texto1.SetNativeSize();
						break;
					case 1:
						dir1 = Direcoes.Direita;
						texto1.sprite = dirDireitaAzul;
						texto1.SetNativeSize();
						break;
					case 2:
						dir1 = Direcoes.Baixo;
						texto1.sprite = dirBaixoAzul;
						texto1.SetNativeSize();
						break;
					case 3:
						dir1 = Direcoes.Esquerda;
						texto1.sprite = diresquerdaAzul;
						texto1.SetNativeSize();
						break;
					}
					ran = Random.Range(0,4);
					switch(ran) {
					case 0: 
						dir2 = Direcoes.Cima;
						texto2.sprite = dirCimaAzul;
						texto2.SetNativeSize();
						break;
					case 1:
						dir2 = Direcoes.Direita;
						texto2.sprite = dirDireitaAzul;
						texto2.SetNativeSize();
						break;
					case 2:
						dir2 = Direcoes.Baixo;
						texto2.sprite = dirBaixoAzul;
						texto2.SetNativeSize();
						break;
					case 3:
						dir2 = Direcoes.Esquerda;
						texto2.sprite = diresquerdaAzul;
						texto2.SetNativeSize();
						break;
					}
					ran = Random.Range(0,4);
					switch(ran) {
					case 0: 
						dir3 = Direcoes.Cima;
						texto3.sprite = dirCimaAzul;
						texto3.SetNativeSize();
						break;
					case 1:
						dir3 = Direcoes.Direita;
						texto3.sprite = dirDireitaAzul;
						texto3.SetNativeSize();
						break;
					case 2:
						dir3 = Direcoes.Baixo;
						texto3.sprite = dirBaixoAzul;
						texto3.SetNativeSize();
						break;
					case 3:
						dir3 = Direcoes.Esquerda;
						texto3.sprite = diresquerdaAzul;
						texto3.SetNativeSize();
						break;
					}
					direcao_atual = 0;

				} else {

					swipeUp = false;
					swipeRight = false;
					swipeDown = false;
					swipeLeft = false;


					if (Input.touchCount > 0){
						
						foreach (Touch touch in Input.touches)
						{
							switch (touch.phase)
							{
							case TouchPhase.Began :
								/* this is a new touch */
								isSwipe = true;
								fingerStartTime = Time.time;
								fingerStartPos = touch.position;
								break;
								
							case TouchPhase.Canceled :
								/* The touch is being canceled */
								isSwipe = false;
								break;
								
							case TouchPhase.Ended :
								
								float gestureTime = Time.time - fingerStartTime;
								float gestureDist = (touch.position - fingerStartPos).magnitude;
								
								if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist){
									Vector2 direction = touch.position - fingerStartPos;
									Vector2 swipeType = Vector2.zero;
									
									if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
										// the swipe is horizontal:
										swipeType = Vector2.right * Mathf.Sign(direction.x);
									}else{
										// the swipe is vertical:
										swipeType = Vector2.up * Mathf.Sign(direction.y);
									}
									
									if(swipeType.x != 0.0f){
										if(swipeType.x > 0.0f){
											// MOVE RIGHT
											swipeRight = true;
										}else{
											// MOVE LEFT
											swipeLeft = true;
										}
									}
									
									if(swipeType.y != 0.0f ){
										if(swipeType.y > 0.0f){
											// MOVE UP
											swipeUp = true;
										}else{
											// MOVE DOWN
											swipeDown = true;
										}
									}
									
								}
								
								break;
							}
						}
					}

					switch(direcao_atual) {
					case 0:
						
						switch(dir1) {
						case Direcoes.Cima:
							if(Input.GetKeyDown(KeyCode.UpArrow)) {
								direcao_atual++;
								texto1.sprite = dirCimaVerde;
								texto1.SetNativeSize();
							}

							if(swipeUp == true) {
								direcao_atual++;
								texto1.sprite = dirCimaVerde;
								texto1.SetNativeSize();
							} else if (swipeLeft || swipeRight || swipeDown) {
								Game.Data.tempoRestante = -0.1f;
							}

							break;
						case Direcoes.Direita:
							if(Input.GetKeyDown(KeyCode.RightArrow)) {
								direcao_atual++;
								texto1.sprite = dirDireitaVerde;
								texto1.SetNativeSize();
							}

							if(swipeRight == true) {
								direcao_atual++;
								texto1.sprite = dirDireitaVerde;
								texto1.SetNativeSize();
							} else if (swipeLeft || swipeUp || swipeDown) {
								Game.Data.tempoRestante = -0.1f;
							}

							break;
						case Direcoes.Baixo:
							if(Input.GetKeyDown(KeyCode.DownArrow)) {
								direcao_atual++;
								texto1.sprite = dirBaixoVerde;
								texto1.SetNativeSize();
							}

							if(swipeDown == true) {
								direcao_atual++;
								texto1.sprite = dirBaixoVerde;
								texto1.SetNativeSize();
							} else if (swipeLeft || swipeRight || swipeUp) {
								Game.Data.tempoRestante = -0.1f;
							}

							break;
						case Direcoes.Esquerda:
							if(Input.GetKeyDown(KeyCode.LeftArrow)) {
								direcao_atual++;
								texto1.sprite = diresquerdaVerde;
								texto1.SetNativeSize();
							}

							if(swipeLeft == true) {
								direcao_atual++;
								texto1.sprite = diresquerdaVerde;
								texto1.SetNativeSize();
							} else if (swipeUp || swipeRight || swipeDown) {
								Game.Data.tempoRestante = -0.1f;
							}

							break;
						}

						break;
					case 1:

						switch(dir2) {
						case Direcoes.Cima:
							if(Input.GetKeyDown(KeyCode.UpArrow)) {
								direcao_atual++;
								texto2.sprite = dirCimaVerde;
								texto2.SetNativeSize();
							}

							if(swipeUp == true) {
								direcao_atual++;
								texto2.sprite = dirCimaVerde;
								texto2.SetNativeSize();
							} else if (swipeLeft || swipeRight || swipeDown) {
								Game.Data.tempoRestante = -0.1f;
							}

							break;
						case Direcoes.Direita:
							if(Input.GetKeyDown(KeyCode.RightArrow)) {
								direcao_atual++;
								texto2.sprite = dirDireitaVerde;
								texto2.SetNativeSize();
							}

							if(swipeRight == true) {
								direcao_atual++;
								texto2.sprite = dirDireitaVerde;
								texto2.SetNativeSize();
							} else if (swipeLeft || swipeUp || swipeDown) {
								Game.Data.tempoRestante = -0.1f;
							}

							break;
						case Direcoes.Baixo:
							if(Input.GetKeyDown(KeyCode.DownArrow)) {
								direcao_atual++;
								texto2.sprite = dirBaixoVerde;
								texto2.SetNativeSize();
							}

							if(swipeDown == true) {
								direcao_atual++;
								texto2.sprite = dirBaixoVerde;
								texto2.SetNativeSize();
							} else if (swipeLeft || swipeRight || swipeUp) {
								Game.Data.tempoRestante = -0.1f;
							}

							break;
						case Direcoes.Esquerda:
							if(Input.GetKeyDown(KeyCode.LeftArrow)) {
								direcao_atual++;
								texto2.sprite = diresquerdaVerde;
								texto2.SetNativeSize();
							}

							if(swipeLeft == true) {
								direcao_atual++;
								texto2.sprite = diresquerdaVerde;
								texto2.SetNativeSize();
							} else if (swipeUp || swipeRight || swipeDown) {
								Game.Data.tempoRestante = -0.1f;
							}

							break;
						}

						break;
					case 2:

						switch(dir3) {
						case Direcoes.Cima:
							if(Input.GetKeyDown(KeyCode.UpArrow)) {
								direcao_atual++;
								texto3.sprite = dirCimaVerde;
								texto3.SetNativeSize();
							}

							if(swipeUp == true) {
								direcao_atual++;
								texto3.sprite = dirCimaVerde;
								texto3.SetNativeSize();
							} else if (swipeLeft || swipeRight || swipeDown) {
								Game.Data.tempoRestante = -0.1f;
							}

							break;
						case Direcoes.Direita:
							if(Input.GetKeyDown(KeyCode.RightArrow)) {
								direcao_atual++;
								texto3.sprite = dirDireitaVerde;
								texto3.SetNativeSize();
							}

							if(swipeRight == true) {
								direcao_atual++;
								texto3.sprite = dirDireitaVerde;
								texto3.SetNativeSize();
							} else if (swipeLeft || swipeUp || swipeDown) {
								Game.Data.tempoRestante = -0.1f;
							}

							break;
						case Direcoes.Baixo:
							if(Input.GetKeyDown(KeyCode.DownArrow)) {
								direcao_atual++;
								texto3.sprite = dirBaixoVerde;
								texto3.SetNativeSize();
							}

							if(swipeDown == true) {
								direcao_atual++;
								texto3.sprite = dirBaixoVerde;
								texto3.SetNativeSize();
							} else if (swipeLeft || swipeRight || swipeUp) {
								Game.Data.tempoRestante = -0.1f;
							}

							break;
						case Direcoes.Esquerda:
							if(Input.GetKeyDown(KeyCode.LeftArrow)) {
								direcao_atual++;
								texto3.sprite = diresquerdaVerde;
								texto3.SetNativeSize();
							}

							if(swipeLeft == true) {
								direcao_atual++;
								texto3.sprite = diresquerdaVerde;
								texto3.SetNativeSize();
							} else if (swipeUp || swipeRight || swipeDown) {
								Game.Data.tempoRestante = -0.1f;
							}

							break;
						}

						break;
					case 3:

						if(SoundController.Data != null) {
							int ran = Random.Range(0,3);
							switch(ran) {
							case 0:
								SoundController.Data.AudioSources["espada_som_1"].Play();
								break;
							case 1:
								SoundController.Data.AudioSources["espada_som_2"].Play();
								break;
							case 2:
								SoundController.Data.AudioSources["espada_som_3"].Play();
								break;
							}
							
						}

						robot_destrroy_script destroy = Game.Data.Mecha.target.GetComponent<robot_destrroy_script>();
						if(destroy != null) {
							destroy.Explode();
							Game.Data.bullet = false;
							texto1.enabled = false;
							texto2.enabled = false;
							texto3.enabled = false;
						} else {
							Destroy(Game.Data.Mecha.target.gameObject);
							Game.Data.Mecha.target = null;
							Game.Data.bullet = false;
							texto1.enabled = false;
							texto2.enabled = false;
							texto3.enabled = false;
						}
						break;
					}
				}


			} else {

				Game.Flash();
				Game.Data.Mecha.health -= 1;
				Game.Data.Mecha.recovery = true;
				Game.Data.Mecha.timeRecovery = 2;
				Game.Data.Mecha.combo = 0;
				Game.Data.shake = 0.8f;

				Game.Data.bullet = false;
				texto1.enabled = false;
				texto2.enabled = false;
				texto3.enabled = false;
			}

		}

		last_value = Game.Data.bullet;
	}
}
