using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadidFireHeal : MonoBehaviour {

	//治療量
	public float 治療量 = 2f;
	public float 迷霧充能量 = 10f;
	//燃燒傷害重置時間
	private float HealCD = 1.5f;
	private float nextHealTime = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			if (Time.time > nextHealTime)
			{
				// 等於碰撞的物件 各自的OBJ資訊
				PlayerStatus palyerstatus = other.GetComponent<PlayerStatus>();
				nextHealTime = HealCD + Time.time;
				palyerstatus.HP += 治療量;
				palyerstatus.Mist += 迷霧充能量;
				Debug.Log("PlayerHealFiering");
			}
		}

	}

}
