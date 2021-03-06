using UnityEngine;
using System.Collections;

//GamePlayScene核心的代码。嘛，也就是整体控制器

public class Group_GameCenterScript : MonoBehaviour {

    GameObject[] CardCollection;//提示：这个只存储牌库里的牌，而不管理手牌等
	public bool ifclick;
	
	// Use this for initialization
	void Start () {
	    
		
		//初始化第一步：根据已有的数据来编造卡组
        //数据来源：Common_NowCardSet.CardSet&.Length

        //提示：测试时，可以将此行注释掉，改为手动设定
        int length = Common_NowCardSet.Length;
        int[] cardSet = Common_NowCardSet.CardSet;
		CardCollection = new GameObject[length];
        //生成的卡片按顺序铺在场上
        for (int i = 0; i < length; i++)
        {
            CardCollection[i]=CardSet_DataBase.GetCard(cardSet[i]);
			CardCollection[i].transform.SetParent(GameObject.Find("Canvas/Panel_left_scoll/Panel_left").transform);
        }
        
        //然后应该要通过网络获取对方卡组。因为还没有加入联网测试功能所以选择将双方卡组设为相同。

        //初始化第二步：根据英雄信息，将头像和英雄技能按钮置于场上。

        //初始化第三步：初始化各个控件的信息

        //初始化第四步：设置状态为初始状态。
		ifclick = false;
        //初始化第五步：启动Trigger_GameStart，游戏开始。
	}

    // Update is called once per frame
    void Update()
    {
	
	}

}
