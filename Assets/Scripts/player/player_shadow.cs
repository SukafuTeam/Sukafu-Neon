using UnityEngine;
using System.Collections;

public class player_shadow : MonoBehaviour {

	SpriteRenderer ren;

	// Use this for initialization
	void Start () {
		ren = this.gameObject.GetComponent<SpriteRenderer>();
		if(ren != null) {
			SpriteRenderer player_ren = Game.Data.Mecha.Root.GetComponent<SpriteRenderer>();
			if(player_ren != null) {
				ren.sprite = player_ren.sprite;
				Color col = ren.color;
				col.a = 0.8f;
				ren.color = col;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(ren != null) {
			Color col = ren.color;
			col.a -= 0.04f;
			if(col.a < 0) {
				Destroy(this.gameObject);
			}
			ren.color = col;
		}
	}
}
