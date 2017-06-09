using UnityEngine;
using System.Collections;

public class robot_destrroy_script : MonoBehaviour {

	public Sprite head;
	public Sprite body;
	public Sprite leg;

	public GameObject destroyedElement;
	public GameObject destroyedParts;

	public int numberOfParts;


	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update() {
	}

	public void Explode () {
		GameObject clone = Game.Spawn(destroyedElement, this.gameObject.transform.position, Quaternion.identity);
		clone.gameObject.GetComponent<SpriteRenderer>().sprite = head;
		clone = Game.Spawn(destroyedElement, this.gameObject.transform.position, Quaternion.identity);
		clone.gameObject.GetComponent<SpriteRenderer>().sprite = body;
		clone = Game.Spawn(destroyedElement, this.gameObject.transform.position, Quaternion.identity);
		clone.gameObject.GetComponent<SpriteRenderer>().sprite = leg;

		for(int i=0;i<numberOfParts;i++) {
			Game.Spawn(destroyedParts, this.gameObject.transform.position, Quaternion.identity);
		}

		Destroy(this.gameObject);
	}
}
