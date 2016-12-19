using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//GamePlayScene���ĵĴ��롣�Ҳ�������������

public class GamePlayScene_GameCenterScript : MonoBehaviour {

	public List<GameObject> CardCollection;//��ʾ�����ֻ�洢�ƿ�����ƣ������������Ƶ�
	public List<GameObject> CardCollection_op;
	//��Ҫ������ֵ��ƿ⣡������
	//����˫���ķ���ˮ��
	public int nowcost;//�ҷ���ǰ����ˮ��
	public int maxcost;//�ҷ������ˮ��	
	public int nowcost_op;//�з���ǰ����ˮ��
	public int maxcost_op;//�з������ˮ��
	public int nowturn;//��ǰ��˭�Ļغ�
	public int thisplayer;//�������������ʾ�Լ�����ұ��
	public GameObject suspend;
	public bool ifsuspend;
	public bool ifclick;
	
	
	// Use this for initialization
	void Start () {
	    
		
		//��ʼ����һ�����������е����������쿨��
        //������Դ��Common_NowCardSet.CardSet&.Length

        //��ʾ������ʱ�����Խ�����ע�͵�����Ϊ�ֶ��趨
        int length = Common_NowCardSet.Length;
        int[] cardSet = Common_NowCardSet.CardSet;
	
	//�˴�Ϊ�����õļ򵥿���
	int length=9;
	int cardSet={1,2,3,1,2,3,1,2,3};

	CardCollection=new List<GameObject>();
        //���ɵĿ�Ƭ��˳�����ڳ���
        for (int i = 0; i < length; i++)
        {
            CardCollection.Add(Common_DataBase.GetCard(cardSet[i]));
        }
        
        //Ȼ��Ӧ��Ҫͨ�������ȡ�Է����顣��Ϊ��û�м����������Թ�������ѡ��˫��������Ϊ��ͬ��

        //��ʼ���ڶ���������Ӣ����Ϣ����ͷ���Ӣ�ۼ��ܰ�ť���ڳ��ϡ�

        //��ʼ������������ʼ�������ؼ�����Ϣ
	Common_Random.init();//���������������Ӧ�ô������ȡ��ͬ����

        //��ʼ�����Ĳ�������״̬Ϊ��ʼ״̬��
		nowturn=0;
		nowcost=0;
		maxcost=0;
		nowcost_op=0;
		maxcost_op=0;
		thisplayer=0;
		ifclick = false;
		ifsuspend = false;
		suspend = null;
        //��ʼ�����岽������Trigger_GameStart����Ϸ��ʼ��
	}

	//Ҳ���ǻغϽ���->�غϿ�ʼ
	public void TurnChange()
	{
		nowturn=1-nowturn;
		if(nowturn==0)
		{
			//�غϸ���3������
			//�鿨
			DrawCard();
			//��ԭ����ˮ��
			if(maxcost<10)maxcost++;
			nowcost=maxcost;
			//��ԭ��������Ƿ񹥻�
GameObject myPanal = GameObject.Find("Canvas/Field");
		for(int i=0; i<myPanal.transform.childCount; i++)
		myPanal.transform.GetChild(i).GetComponent<Common_CardInfo>().cardInfo.attack=true;

		}
		else
		{
			//�غϸ���3������
			//�鿨
			DrawCard_op();
			//��ԭ����ˮ��
			if(maxcost_op<10)maxcost_op++;
			nowcost_op=maxcost_op;
			//��ԭ��������Ƿ񹥻�
GameObject myPanal = GameObject.Find("Canvas/Field_op");
		for(int i=0; i<myPanal.transform.childCount; i++)
		myPanal.transform.GetChild(i).GetComponent<Common_CardInfo>().cardInfo.attack=true;

		}
	}
	void DrawCard(int user=0)
	{
	if(user==1)
	{
		DrawCard_op();
		return;
	}
		if(CardCollection.Count!=0)
		{
			int num=Common_Random.random(0,CardCollection.Count-1);
			CardCollection[num].transform.SetParent(GameObject.Find("Canvas/Hand").transform);
			CardCollection.RemoveAt(num);
		}

	}
	void DrawCard_op()
	{
		if(CardCollection.Count!=0)
		{
			int num=Common_Random.random(0,CardCollection.Count-1);
			CardCollection[num].transform.SetParent(GameObject.Find("Canvas/Hand").transform);
			CardCollection.RemoveAt(num);
		}

	}
}
