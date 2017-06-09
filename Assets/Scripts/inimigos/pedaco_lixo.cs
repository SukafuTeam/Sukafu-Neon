using UnityEngine;
using System.Collections;

public class pedaco_lixo : MonoBehaviour {

	public Sprite lixo1;
	public Sprite lixo2;
	public Sprite lixo3;

	// Use this for initialization
	void Start () {
		int ran = Random.Range(0,3);
		switch(ran) {
		case 0:
			this.gameObject.GetComponent<SpriteRenderer>().sprite = lixo1;
			break;
		case 1:
			this.gameObject.GetComponent<SpriteRenderer>().sprite = lixo2;
			break;
		case 2:
			this.gameObject.GetComponent<SpriteRenderer>().sprite = lixo3;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
