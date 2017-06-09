using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class goto_menu_after_time : MonoBehaviour {

	public float timeToStart = 2;

	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
		StartCoroutine(GotoMenu());
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator GotoMenu()
	{
		yield return new WaitForSeconds(timeToStart);
		SceneManager.LoadScene("cena_intro");
	}
}
