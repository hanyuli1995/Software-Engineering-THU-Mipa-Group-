﻿using UnityEngine;
using System.Collections;

public class  MainScene_ChangeCardGroup: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		int CardGroupSum =  MainScene_CardGroupManager.CardGroupSum;
		int CanDelete = 0;
		string FileName;
		for (int i = 0; i < 3; i++) {
			if (MainScene_CardGroupManager.IsClick [i] == 1) {
				CanDelete = i + 1;
			}
		}
		if (CanDelete > 0) {
			Debug.Log ("进入修改卡组界面");
			MainScene_CardGroupManager.IsClick [CanDelete - 1] = 0;
			int CardNumber;
			if (CanDelete == 1) {
				FileName = MainScene_CardGroup1.CardGroupName;
			} else if (CanDelete == 2) {
				FileName = MainScene_CardGroup2.CardGroupName;
			} else {
				FileName = MainScene_CardGroup3.CardGroupName;
			}
			Common_NowCardSet.LoadCardFile (FileName);
			Application.LoadLevel ("CardSetScene");
		} else {
			Debug.Log ("没有选中卡组，无法修改卡组！");
		}
	}
}
