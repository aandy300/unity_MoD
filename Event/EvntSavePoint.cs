using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EvntSavePoint : MonoBehaviour 

{
	 
	public List<Vector3> listReborn = new List<Vector3>();
	//public gameObject player;

	public float listreborn = 0.3f;
	public bool load = false; 


	void OnTriggerEnter(Collider col)
	{
		// 碰到存檔點的話
		if (col.tag == "savepoint")
		{
			// 把存檔點存入列表
			listReborn.Add(col.gameObject.transform.position);
			ChangeloadState();
			// 把碰過的存檔點刪除掉, 以免重複碰撞, 
			// 當然, 如果要重複利用存檔點, 就把List改存存檔點的gameObject
			Destroy(col.gameObject);
		}
	}

	public void Reborn()
	{
		{
			// 重生
			// 如果要起始點就
			gameObject.transform.position = listReborn[0];
			// 要最後碰到的點就
			gameObject.transform.position = listReborn[listReborn.Count - 1];
		}
	}


	public void ChangeloadState()   
	{
		load = true;
	}


	void Update ()
	{
		if(load) //open == true
	  {
			if (Input.GetKeyDown(KeyCode.Alpha0))
			Reborn();
	  }
	}
}

