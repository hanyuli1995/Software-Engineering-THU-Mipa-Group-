using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class Common_CardInfo : MonoBehaviour {
    
    //��Ƭ�����ݴ����������Script�����ڿ�Ƭ������Ϊ��Ƭ���ݣ��Է�������Լ���ʾ��

    
    public class BaseInfo
    {
        //��������
        public string name;
        public string description;
        public int cost;
        public int atk;
        public int hp;
		public int maxhp;

        //��������
        public int id;
        public int itemId;
        public int position;

		public bool ifdelete;

		public bool attack;//��ʾ�Ƿ���Թ�������ϵ��û�з�ŭ������Ҳ���г�棩����ֻ��Ҫ��ʶ�Ƿ��Ѿ�����������


        public Trigger.Trigger thisTrigger;//�����������������Ѿ�����������ʹ�÷���
		public int CardType;//��Ƭ���͡�������Ϊ����ʾʹ�ÿ�Ƭʱ�Ƿ���Ҫָ��Ŀ�ꣻ��ѡѡ���������ͨ��������ָ����������ͨ��ӡ�����ͨս����ӡ���ָ��ս����ӡ�������ָ������Ҫָ��target������ָ��ս���������Ҫ���ٻ�����ָ��һ����ѡ��λ����ս��
		public static readonly int normalUnit=1;//��ͨ��ӣ���Ȼ�����⻷��Ӽ����������
		public static readonly int aimBattleUnit=2;//ָ��ս�����
		public static readonly int noaimBattleUnit=3;//��ָ��ս�����
		public static readonly int aimSpell=4;//ָ����
		public static readonly int noaimSpell=5;//��ָ����


    }

    public BaseInfo cardInfo;

    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        this.transform.FindChild("Card Name").GetComponent<Text>().text = cardInfo.name;
        this.transform.Find("Description").GetComponent<Text>().text = cardInfo.description;
        this.transform.Find("Cost").GetComponent<Text>().text = cardInfo.cost.ToString();
        if (this.cardInfo.CardType < BaseInfo.aimSpell)
        {
            this.transform.Find("Attack").GetComponent<Text>().text = cardInfo.atk.ToString();
            this.transform.Find("Life").GetComponent<Text>().text = cardInfo.hp.ToString();
        }
        else
        {
            this.transform.Find("Attack").GetComponent<Text>().text = "";
            this.transform.Find("Life").GetComponent<Text>().text = "";
        }



        if (this.cardInfo.position == 2 || this.cardInfo.position == 3)
            if (this.cardInfo.attack)
            {
                this.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            else
            {
                this.GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, 1.0f);
            }



        if (this.cardInfo.position == 1)
            if (GameObject.Find("GameCenter").GetComponent<GamePlayScene_GameCenterScript>().nowcost >= this.cardInfo.cost)
            {
                this.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            else
            {
                this.GetComponent<Image>().color = new Color(0.9f, 0.9f, 0.9f, 1.0f);
            }

    }
}
