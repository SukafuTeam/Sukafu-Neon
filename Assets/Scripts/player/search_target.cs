using UnityEngine;
using System.Collections;

public class search_target : MonoBehaviour {

	public LayerMask enemyLayer;
	public GameObject miraObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!Game.Data.Mecha.aiming) {
			Collider2D[] res = Physics2D.OverlapCircleAll(this.transform.position, 14, enemyLayer);
			GameObject close = null;
			foreach(Collider2D each in res){
				if(each.transform.position.x > Game.Data.Mecha.Root.transform.position.x + 1) {
					if(close == null) {
						close = each.gameObject;
					} else {
						Vector3 close_pos = close.gameObject.transform.position;
						Vector3 each_pos = each.gameObject.transform.position;
						Vector3 pos = this.gameObject.transform.position;
						if(Vector3.Distance(pos, each_pos) < Vector3.Distance(pos, close_pos))
							close = each.gameObject;
					}
				}
			}

			if(close != null) {
				GameObject clone = Game.Spawn(miraObj, close.transform.position, Quaternion.identity);
				mira_script mir = clone.gameObject.GetComponent<mira_script>();
				if(mir != null) {
					mir.target = close.gameObject;
				}
				Game.Data.Mecha.aiming = true;
			}
		}
	}
}
