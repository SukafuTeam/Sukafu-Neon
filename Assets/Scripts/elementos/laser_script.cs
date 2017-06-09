using UnityEngine;
using System.Collections;

public class laser_script : MonoBehaviour {
	
	public GameObject begin;
	public GameObject end;
	public LineRenderer line;

	// Use this for initialization
	void Start () {
		Vector3 begin_pos = begin.transform.position;
		begin_pos.y -= 0.3f;
		Vector3 end_pos = end.transform.position;
		end_pos.y -= 0.3f;
		line.SetPosition(0, begin_pos);
		line.SetPosition(1, end_pos);
		line.SetWidth(0.5f,0.5f);
		line.SetColors(Color.red, Color.red);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 begin_pos = begin.transform.position;
		begin_pos.y -= 0.3f;
		Vector3 end_pos = end.transform.position;
		end_pos.y -= 0.3f;
		line.SetPosition(0, begin_pos);
		line.SetPosition(1, end_pos);
		line.SetWidth(0.5f,0.5f);
		line.SetColors(Color.red, Color.red);
	}
}
