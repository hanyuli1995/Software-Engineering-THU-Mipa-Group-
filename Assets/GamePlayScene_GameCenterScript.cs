using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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
	public GameObject[] Hint;
	
	public AnimationCurve scaleCurve;
    public float duration = 0.5f;
	
	
	// Use this for initialization
	void Start () {
	    
		
		//��ʼ����һ�����������е����������쿨��
        //������Դ��Common_NowCardSet.CardSet&.Length

        //��ʾ������ʱ�����Խ�����ע�͵�����Ϊ�ֶ��趨
        int length = Common_NowCardSet.Length;
        int[] cardSet = Common_NowCardSet.CardSet;
	
	    //�˴�Ϊ�����õļ򵥿���
        /*Debug.Log("Warning: You are using TestCardSet!");
	    length=9;
	    cardSet=new int[9]{1,2,3,4,5,6,7,1,5};*/

	    CardCollection=new List<GameObject>();
        //���ɵĿ�Ƭ��˳�����ڳ���
        for (int i = 0; i < length; i++)
        {
            CardCollection.Add(Common_DataBase.GetCard(cardSet[i]));
        }

        //Ȼ��Ӧ��Ҫͨ�������ȡ�Է����顣
        //û�м����������Թ���ʱ��ѡ��˫��������Ϊ��ͬ��


	    int length_op=Common_NowCardSet.Length_op;
	    int[] cardSet_op=Common_NowCardSet.CardSet_op;

	    CardCollection_op=new List<GameObject>();
        if (length_op != 0)
        {
            for (int i = 0; i < length_op; i++)
            {
                CardCollection_op.Add(Common_DataBase.GetCard(cardSet_op[i]));
            }
        }
        else//˵�����ֿ���Ϊ�գ��ǲ���״̬��ʹ���ҷ�����������
        {
            for (int i = 0; i < length; i++)
            {
                CardCollection_op.Add(Common_DataBase.GetCard(cardSet[i]));
            }
        }
		
        //��ʼ���ڶ���������Ӣ����Ϣ����ͷ���Ӣ�ۼ��ܰ�ť���ڳ��ϡ�
        GameObject.Find("Hero").GetComponent<Common_CardInfo>().cardInfo.itemId = ++Common_DataBase.nowItemId;
        GameObject.Find("Hero").GetComponent<Common_CardInfo>().cardInfo.position = 2;
        GameObject.Find("Hero").GetComponent<Common_CardInfo>().cardInfo.hp = 30;
        GameObject.Find("Hero").GetComponent<Common_CardInfo>().cardInfo.maxhp = 30;
        GameObject.Find("Hero").GetComponent<Common_CardInfo>().cardInfo.CardType = Common_CardInfo.BaseInfo.Hero;
        GameObject.Find("Hero").GetComponent<Common_CardInfo>().cardInfo.atk = 0;
        GameObject.Find("Hero").GetComponent<Common_CardInfo>().cardInfo.thisTrigger = null;//��ʱ��Ϊ�գ�֮������ΪӢ�ۼ���trigger

        GameObject.Find("Hero_op").GetComponent<Common_CardInfo>().cardInfo.itemId = ++Common_DataBase.nowItemId;
        GameObject.Find("Hero_op").GetComponent<Common_CardInfo>().cardInfo.position = 3;
        GameObject.Find("Hero_op").GetComponent<Common_CardInfo>().cardInfo.hp = 30;
        GameObject.Find("Hero_op").GetComponent<Common_CardInfo>().cardInfo.maxhp = 30;
        GameObject.Find("Hero_op").GetComponent<Common_CardInfo>().cardInfo.CardType = Common_CardInfo.BaseInfo.Hero;
        GameObject.Find("Hero_op").GetComponent<Common_CardInfo>().cardInfo.atk = 0;
        GameObject.Find("Hero_op").GetComponent<Common_CardInfo>().cardInfo.thisTrigger = null;//��ʱ��Ϊ�գ�֮������ΪӢ�ۼ���trigger


        //��ʼ������������ʼ�������ؼ�����Ϣ
	Common_Random.init();//���������������Ӧ�ô������ȡ��ͬ����

        //��ʼ�����Ĳ�������״̬Ϊ��ʼ״̬��
		nowturn=0;
		nowcost=10;
		maxcost=10;
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
			StopCoroutine(TurnRound(0));
			StartCoroutine(TurnRound(0));
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
			StopCoroutine(TurnRound(1));
			StartCoroutine(TurnRound(1));
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
	IEnumerator TurnRound(int id){
		GameObject HintTextEnd;
		GameObject HintTextStart;
		if(id == 1){
			HintTextEnd = Instantiate(Hint[0]);
			HintTextEnd.transform.SetParent(GameObject.Find("Canvas").transform);
		}
		else{
			HintTextEnd = Instantiate(Hint[2]);
			HintTextEnd.transform.SetParent(GameObject.Find("Canvas").transform);
		}
		
		
		//fly1
		float time = 0f;
		Vector3 startPosition = new Vector3(520f,380f,0f);
		HintTextEnd.transform.position  = startPosition;
		 while (time <= 2f)
        {
            float scale = scaleCurve.Evaluate(time/2f);
            time += Time.deltaTime / duration;

            Vector3 localScale = HintTextEnd.transform.localScale;
            localScale.x = scale;
			if(time < 1)
				HintTextEnd.transform.localScale = localScale;
			else
			{
				Color c = HintTextEnd.GetComponent<Text>().color;
				c.a = scale;
				HintTextEnd.GetComponent<Text>().color = c;
			}

            yield return new WaitForFixedUpdate();
        }
		
		Destroy(HintTextEnd);
		
		//�Ƚ��������в����Ļ���������Ӧ�÷ֿ�д��
		yield return new WaitForSeconds(0.5f);
		//fly2
		
		time = 0f;
		if(id == 1){
			HintTextStart = Instantiate(Hint[1]);
			HintTextStart.transform.SetParent(GameObject.Find("Canvas").transform);
		}
		else{
			HintTextStart = Instantiate(Hint[3]);
			HintTextStart.transform.SetParent(GameObject.Find("Canvas").transform);
		}
		HintTextStart.transform.position  = startPosition;
		 while (time <= 2.5f)
        {
            float scale = scaleCurve.Evaluate(time/2.5f);
            time += Time.deltaTime / duration;

            Vector3 localScale = HintTextStart.transform.localScale;
            localScale.x = scale;
			if(time < 1)
				HintTextStart.transform.localScale = localScale;
			else
			{
				Color c = HintTextStart.GetComponent<Text>().color;
				c.a = scale;
				HintTextStart.GetComponent<Text>().color = c;
			}

            yield return new WaitForFixedUpdate();
        }
		
		Destroy(HintTextStart);
	}
	
	public void DrawCard(int user=0)
	{
	if(user==1)
	{
		DrawCard_op();
		return;
	}
		if(CardCollection.Count!=0)
		{
			int num=Common_Random.random(0,CardCollection.Count-1);
			Debug.Log("���ҳ��ƣ�����");
			CardCollection[num].GetComponent<CardMove>().flyAndFlip();
			//CardCollection[num].transform.SetParent(GameObject.Find("Canvas/Hand").transform);
			CardCollection[num].GetComponent<Common_CardInfo>().cardInfo.position=1;
			CardCollection.RemoveAt(num);
		}

	}
	public void DrawCard_op()
	{
		if(CardCollection_op.Count!=0)
		{
			int num=Common_Random.random(0,CardCollection_op.Count-1);
			CardCollection_op[num].GetComponent<CardMove>().flyAndFlip(1);
			//CardCollection_op[num].transform.SetParent(GameObject.Find("Canvas/Hand_op").transform);
			CardCollection_op[num].GetComponent<Common_CardInfo>().cardInfo.position=4;
			CardCollection_op.RemoveAt(num);
		}

	}

	//˵��������itemid��ö�Ӧ�Ŀ�Ƭ����ȫ��
	public GameObject GetCard(int itemid)
	{
		return GameObject.Find("Card"+itemid);
	}

	//�ڶ��ֻغ�ʱ�����޶�ȡ���ֲ���ֱ�����ַ��ͽ������������䣩��ָ��
	//ֻҪ�����������ȷִ�У����������ͽ����һ��
	public void EnemyTurn()
	{
		while(true)
		{
			NetMessage nextMSG=Netlink.RecvMessage();
            if (nextMSG == null) break;//Ϊ�մ�����Ȼ����û�����������ǵ�������
			if(nextMSG.infoType==NetMessage.Attack)
			{
				GameObject user=GetCard(nextMSG.addint1);
				GameObject target=GetCard(nextMSG.addint2);
				user.GetComponent<CardMove>().cardAttack(user,target);
				user.GetComponent<Common_CardInfo>().cardInfo.attack = false;

			}
			if(nextMSG.infoType==NetMessage.DrawCard)
			{//�ݲ���Ҫ��һ����˵���ַ��������Զ�����
			}
			if(nextMSG.infoType==NetMessage.Summon)
			{
				GameObject user=GetCard(nextMSG.addint1);
				int point=nextMSG.addint2;
				//��ȱ
				user.GetComponent<Draggerable>().SummonUnit(point);
			}
			if(nextMSG.infoType==NetMessage.SpellCard)
			{
				GameObject user=GetCard(nextMSG.addint1);
				GameObject target=GetCard(nextMSG.addint2);
				
				Trigger.TriggerInput newInput = new Trigger.TriggerInput(user,target);
				user.GetComponent<Common_CardInfo>().cardInfo.thisTrigger.exec(newInput);
			GameObject.Find("GameCenter").GetComponent<GamePlayScene_GameCenterScript>().nowcost-=user.GetComponent<Common_CardInfo>().cardInfo.cost;

			}
			if(nextMSG.infoType==NetMessage.TriggerExec)
			{//ע��TriggerExec��ָ�������Ч������Ϊ����Ч��ֱ����ΪSpellCard��Ч��
				GameObject user=GetCard(nextMSG.addint1);
				GameObject target=GetCard(nextMSG.addint2);
				Trigger.TriggerInput newInput = new Trigger.TriggerInput(user,target);
				user.GetComponent<Common_CardInfo>().cardInfo.thisTrigger.exec(newInput);

			}
			if(nextMSG.infoType==NetMessage.TurnChange)
			{
				this.TurnChange();
				break;
			}
		}
	}
}
