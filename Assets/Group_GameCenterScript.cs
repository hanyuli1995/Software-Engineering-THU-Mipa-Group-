using UnityEngine;
using System.Collections;

//GamePlayScene���ĵĴ��롣�Ҳ�������������

public class Group_GameCenterScript : MonoBehaviour {

    GameObject[] CardCollection;//��ʾ�����ֻ�洢�ƿ�����ƣ������������Ƶ�
	public bool ifclick;
	
	// Use this for initialization
	void Start () {
	    
		
		//��ʼ����һ�����������е����������쿨��
        //������Դ��Common_NowCardSet.CardSet&.Length

        //��ʾ������ʱ�����Խ�����ע�͵�����Ϊ�ֶ��趨
        int length = Common_NowCardSet.Length;
        int[] cardSet = Common_NowCardSet.CardSet;
		CardCollection = new GameObject[length];
        //���ɵĿ�Ƭ��˳�����ڳ���
        for (int i = 0; i < length; i++)
        {
            CardCollection[i]=Common_DataBase.GetCard(cardSet[i]);
			CardCollection[i].transform.SetParent(GameObject.Find("Canvas/Panel_left_scoll/Panel_left").transform);
        }
        
        //Ȼ��Ӧ��Ҫͨ�������ȡ�Է����顣��Ϊ��û�м����������Թ�������ѡ��˫��������Ϊ��ͬ��

        //��ʼ���ڶ���������Ӣ����Ϣ����ͷ���Ӣ�ۼ��ܰ�ť���ڳ��ϡ�

        //��ʼ������������ʼ�������ؼ�����Ϣ

        //��ʼ�����Ĳ�������״̬Ϊ��ʼ״̬��
		ifclick = false;
        //��ʼ�����岽������Trigger_GameStart����Ϸ��ʼ��
	}

    // Update is called once per frame
    void Update()
    {
	
	}

}
