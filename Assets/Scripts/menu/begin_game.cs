using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class begin_game : MonoBehaviour {

	public Image sukafu;
	public Image neon;
	public Image neon_glow;
	public Image touch_start;
	public Image ggj;

	public bool doit;

	// Use this for initialization
	void Start () {
		doit = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Game.Data.begin && doit) {
			Color col = sukafu.color;
			col.a -= 0.01f;

			sukafu.color = col;
			neon.color = col;
			ggj.color = col;
			touch_start.color = col;


			if(col.a < 0) {
				Destroy(sukafu.gameObject);
				Destroy(neon.gameObject);
				Destroy(touch_start.gameObject);
				Destroy(ggj.gameObject);
				Destroy(this.gameObject);
				doit = false;
			}

			if(neon_glow != null)
				Destroy(neon_glow.gameObject);
		}
	}

	public void Begin() {
		Game.Data.begin = true;
	}
}
