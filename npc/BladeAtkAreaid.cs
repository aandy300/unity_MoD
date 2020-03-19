using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeAtkAreaid : MonoBehaviour {

	// 劍 身上的碰撞器 損敵人血用

	//抓玩家的角色資訊 提取傷害量用
	private Statusid statusid;
	//抓砍到的物件資訊 給予傷害量用
	private OBJStatus ObjStatus;
	//紀錄玩家角色傷害量 儲存用 (多此一舉,直接 - 角色資訊.傷害量就好)
	private float atkpower;

	// ↓繞一圈去抓  PlayerAttack的特效
	private GameObject hitEffect;
	private Attackid AIidattack;
	// 指定產生效果位置 儲存用
	private Transform hiteffectTransform;
	// 隨機數值 增加效果變化 (沒啥用重點沒辦法用旋轉 旋轉效果差比較多)
	public float  r_transform;
	void Start () {
		
	}

	void Update()
	{
		// 抓取場景中的角色物件的角色資訊
		statusid = GameObject.Find("AIid").GetComponentInParent<Statusid>();
		//抓取到角色資訊號儲存傷害量(多此一舉 同上面的)
		atkpower = statusid.AtkPower;
	}

	void OnTriggerEnter(Collider other)
	{
		//碰撞器tag如果是 Enemy
		if (other.tag == "Player")
		{
			//隨機數值
			r_transform = Random.Range(0.1f, 0.3f);
			// ↓下二行 繞一圈去抓  PlayerAttack的特效
			AIidattack = GameObject.Find("AIid").GetComponentInParent<Attackid>();
			hitEffect = AIidattack.hitEffect;
			// 座標 = 碰到的物件的 座標
			hiteffectTransform = other.transform;

			// 物件資訊 = 碰撞器碰撞到的物件的資訊
			PlayerStatus playerstatus = other.GetComponent<PlayerStatus>();
			// 發出 物件資訊的HP - 傷害量的資料
		    playerstatus.HP -= atkpower;
			//GameObject effect = Instantiate(hitEffect,transform.position, Quaternion.identity) as GameObject;
			//GameObject effect = Instantiate<GameObject>(hitEffect);
			//effect.transform.localPosition = hiteffectTransform.transform.position + new Vector3(0.0f,4.2f + r_transform, 0.0f);
			//effect.transform.position. = other.GetComponent<Transform>().transform.position;
			//effect.transform.position = new Vector3( other.GetComponent<Transform>().transform.position.x, other.GetComponent<Transform>().transform.position.y);
			//Destroy(effect, 0.3f);
		}

		
	}

}
