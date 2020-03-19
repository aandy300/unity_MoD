using UnityEngine;
using System.Collections;

public class TimeChick : MonoBehaviour {

	// 計時器

	private int nCount;
	
	void Awake() {
		
	}
	
	void Start () {
		//5秒時調用 RunInvoke 這個函示
		this.Invoke("RunInvoke", 5.0f);
		//00=開始調用的第一時間 每2秒時調用 RunInvoke 這個函示
		this.InvokeRepeating("RunInvokeRepeating", 0.0f, 2.0f);
		// Use Skill
		// BtnSkill.Lock(); 
		// this.Invoke("CD", BtnSkill.CDTime);
	}
	
	//5秒時調用這個函示
	private void RunInvoke() {
		
		float nowTime = Time.time;
		Debug.Log("RunInvoke 目前遊戲時間：" + nowTime);
	}
	//函示調用次數計數器
	private void RunInvokeRepeating() {
		float nowTime = Time.time;
		Debug.Log("RunInvokeRepeating 目前遊戲時間：" + nowTime);
		nCount += 1;
		if(nCount == 5)
			this.CancelInvoke();
	}
	
	private void CD() {
		// BtnSkill.unLock(); 
	}
}

//--------------------------------

//public void Invoke(string methodName, float time);

//-Invoke ( 委派的funtion,幾秒後開始調用 )
	
//	public void InvokeRepeating(string methodName, float time, float repeatRate);

//-InvokeRepeating ( 委派的funtion, 幾秒後開始調用, 開始調用後每幾秒再調用 ) 
	
//	public bool IsInvoking(string methodName);

//-IsInvoking ( 委派的funtion ) 判斷是否正在調用中
	
	// 以下範例 可以看得很清楚 運作模式
	
	// 可以用在 技能CD, 時間倒數後做某些事的應用

//兩個測試用的 funton
	
//	第一個 註冊後五秒後執行
		
//		第二個 註冊後立刻後執行之後每兩秒執行一次  有用count 去計算只要執行幾次

//--------------------------------





