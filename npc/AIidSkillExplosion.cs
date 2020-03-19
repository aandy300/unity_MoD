using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIidSkillExplosion : MonoBehaviour

{
	//調用玩家 HP
	[SerializeField]
	private PlayerStatus hp;
	//傷害量
	public float 燃燒傷害量 = 10f;
	//燃燒傷害重置時間
	private float FireCD = 6f;
	private float nextFire = 0f;
	
	//傷害量

	void Start()
	{
		hp = GameObject.Find("Player").GetComponentInParent<PlayerStatus>();
	}

	void Update()
	{

	}


	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			if (Time.time > nextFire)
			{
				nextFire = FireCD + Time.time;
				hp.HP -= 燃燒傷害量;
			}
		}
	}
}


