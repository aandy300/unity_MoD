using UnityEngine;
using UnityEngine.UI ;
using System.Collections;

public class UISetTimeActive : MonoBehaviour 
{

	public string loadLevel;


	// 按建 出現
	// 待機 秒數後 播放影片
	// 記時 時間之後 按任建 激活、刪除

	private int nCount;

	public GameObject Button1;
	public GameObject Button2;
	public GameObject DestroyOBJ;

	void Start () 
	{
		this.InvokeRepeating("RunInvokeRepeating", 0.0f, 0.2f);
	}

	void Update () 
	{
		if (nCount > 200) 
		{
			Application.LoadLevel(loadLevel);
		}
	}
	
	private void RunInvokeRepeating() 
	{
		float nowTime = Time.time;
		//Debug.Log("RunInvokeRepeating 目前遊戲時間：" + nowTime);
		nCount += 1;
		
		if (Input.anyKey) 
		{
			if (nCount > 0) 
			{
				Debug.Log ("滿足時間條件:" + nowTime);
				Button1.SetActive (true);
				Button2.SetActive (true);
				Destroy (DestroyOBJ);
		    }
		
	 }
	}
}
