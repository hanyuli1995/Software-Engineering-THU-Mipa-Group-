using UnityEngine;
using System.Collections;

//GamePlayScene���ĵĴ��롣�Ҳ�������������

public class GamePlayScene_GameCenterScript : MonoBehaviour {

	public GameObject[] CardCollection;//��ʾ�����ֻ�洢�ƿ�����ƣ������������Ƶ�
	public GameObject[] CardCollection_op;
	//��Ҫ������ֵ��ƿ⣡������
	//����˫���ķ���ˮ��
	public int nowcost;//�ҷ���ǰ����ˮ��
	public int maxcost;//�ҷ������ˮ��	
	public int nowcost_op;//�з���ǰ����ˮ��
	public int maxcost_op;//�з������ˮ��
	public int nowturn;//��ǰ��˭�Ļغ�
	public bool ifclick;
	
	// Use this for initialization
	void Start () {
	    
		
		//��ʼ����һ�����������е����������쿨��
        //������Դ��Common_NowCardSet.CardSet&.Length

        //��ʾ������ʱ�����Խ�����ע�͵�����Ϊ�ֶ��趨
        int length = Common_NowCardSet.Length;
        int[] cardSet = Common_NowCardSet.CardSet;
		
        //���ɵĿ�Ƭ��˳�����ڳ���
        for (int i = 0; i < length; i++)
        {
            CardCollection[i]=Common_DataBase.GetCard(cardSet[i]);
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
