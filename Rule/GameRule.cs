using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameRule : MonoBehaviour {

	public GameObject Player;

	public float 迷霧可見度數值 = 0.05f;
	public float lerpSpeed = 2 ;
	[SerializeField]
	private PlayerStatus playerstatus;
	public float fogDensity;

	public GameObject UI_玩家死亡字幕;

	public GameObject UI_黑場用;

	EvntSavePoint savepoint;
	public float 玩家重生的時間點;
	public float 玩家重生CD時間 = 8f;


	public GameObject Gameclear;
	public string UI_讀取的場景名稱;


	void Start () {
		playerstatus = GameObject.Find("Player").GetComponentInParent<PlayerStatus>();
		savepoint = GameObject.Find("Player").GetComponentInParent<EvntSavePoint>();

	}
	
	// Update is called once per frame
	void Update () {

		if (Gameclear.activeSelf == true)
		{
			this.Invoke("GameclearLoadScrene", 5f);
		}

		if (playerstatus.HP == 0 || playerstatus.HP <= 0)
		{
			this.Invoke("ReLife", 8f);
			UI_玩家死亡字幕.SetActive(true);
		}
		else if (playerstatus.HP >= 0)
		{
			UI_玩家死亡字幕.SetActive(false);
		}

			if (playerstatus.Mist > 80)
		{
			RenderSettings.fogDensity = 迷霧可見度數值;
		}
		if (playerstatus.Mist < 70)
		{
			RenderSettings.fogDensity = Mathf.Lerp(RenderSettings.fogDensity, 0.06f, Time.deltaTime * lerpSpeed);
		}
		if (playerstatus.Mist > 70)
		{
			RenderSettings.fogDensity = Mathf.Lerp(RenderSettings.fogDensity, 0.05f, Time.deltaTime * lerpSpeed);
		}
		if (playerstatus.Mist < 50)
		{
			RenderSettings.fogDensity = Mathf.Lerp(RenderSettings.fogDensity, 0.07f, Time.deltaTime * lerpSpeed);
		}
		if (playerstatus.Mist > 50)
		{
			RenderSettings.fogDensity = Mathf.Lerp(RenderSettings.fogDensity, 0.06f, Time.deltaTime * lerpSpeed);
		}
		if (playerstatus.Mist < 30)
		{
			RenderSettings.fogDensity = Mathf.Lerp(RenderSettings.fogDensity, 0.08f, Time.deltaTime * lerpSpeed);
		}
		if (playerstatus.Mist > 30)
		{
			RenderSettings.fogDensity = Mathf.Lerp(RenderSettings.fogDensity, 0.07f, Time.deltaTime * lerpSpeed);
		}
		if (playerstatus.Mist < 10)
		{
			RenderSettings.fogDensity = Mathf.Lerp(RenderSettings.fogDensity, 0.093f, Time.deltaTime * lerpSpeed);
		}
	}
	private void ReLife()
	{
		//防止重複一直重生覆蓋位置
		if (Time.time > 玩家重生的時間點)
		{
			玩家重生的時間點 = Time.time + 玩家重生CD時間;
		GameObject UI_黑場 = Instantiate<GameObject>(UI_黑場用);
		UI_黑場.transform.position =this.gameObject.transform.position;
		savepoint.Reborn();
		playerstatus.ReLife();
		Debug.Log("log_re");
		}
	}

	public void GameclearLoadScrene()
	{
		SceneManager.LoadScene(UI_讀取的場景名稱);
	}
}
