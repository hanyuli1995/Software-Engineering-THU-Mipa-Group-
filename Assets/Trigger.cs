using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//�����ֱ������ΪTrigger�ˣ��������������̳���������ȻҪ��"Trigger_"ϵ��ѽ��
//������ʽ����Ϊ����������������ս�𣩺ͱ�������������ʲôʱ������ʱӦ����������������������Ҫȷ��TriggerTarget�����������������Ҫȷ��TriggerCondition
namespace Trigger
{
	public class TriggerInput//����TriggerʱӦ�еı�������Ҫ�ı���Ӧ����������
	{
		//������������ʽ��CardUser������Ϊ�գ����ڱ�������ʽ��������й���ɶ�ģ���Ӧ����CardUser��Ϊ�����Ŀ�Ƭ��
		public GameObject CardUser;
		public GameObject CardTarget;
		
		public TriggerInput(GameObject user, GameObject Target)
		{
			CardUser = user;
			CardTarget = Target;
		}
	}


	public class TriggerTarget//������ʾ��Ƭʹ�������ı�������Щʹ����������������ս����ӵ�ʹ��Ŀ�ꡣ����û����ȷĿ��ģ����������1�����ģ�ֱ�ӿ��Ե���Anytime
	{
		//ʹ�÷���������&�������Ӷ���ࡣ
		public int target;

		static public readonly int Anyone=1;//�������Ǿʹ����κε�λ������
		//����������һһ���������������û��Ǿʹ�����ɡ�ֻ�����һ���ʹ���Ҫ��һ��
		public static readonly int Enemy=2;//�о�
		public static readonly int Friend=4;//�Ѿ�������ǰ����Լ��ġ�

		public static readonly int Myself=8;//ʹ�õ�λ�Լ�������������Ǹ�����û���ã����Ҵ��ˣ�����
		public static readonly int Others=16;//����ʹ�������⡣

		public static readonly int Hero=32;//Ӣ��
		public static readonly int Unit=64;//���

		//����Ϊ�������塣ֻҪ�����һ��������ζ������û��ǵĶ��������ܱ�ָ�򡣵�Ȼ����Ա�Ƕ��
		public static readonly int Animal=128;//Ұ��
		public static readonly int Tecnical=256;//��е
		public static readonly int Evavl=512;//��ħ���ð���Ӣ�ﲻ�ã�֮���
		public static readonly int Dragon=1024;//��
		public static readonly int Fish=2048;//���ˡ�������²�˵�㲻�������ˣ�������ˡ�
	}
	

	public class TriggerCondition//��������������Ĵ��������Ǳ���������trigger�ı����������������еĴ�������ֻ������һ����
	{
		public int conditionType;//��������
		public int conditionTarget;//����Ŀ��
		public int conditionTime;//����ʱ��

//conditionType��
		public static readonly int OnAnyTime=0;
		public static readonly int OnAttack=1;
		public static readonly int OnAttacked=2;
		public static readonly int OnDead=3;
		public static readonly int OnSummon=4;//�ٻ�ʱ�����ʱ�䲻�������ٻ��Լ���
		public static readonly int OnPlayCard=5;

//conditionTarget��
		public static readonly int OnAnyUnit=0;
		public static readonly int OnEnemy=1;
		public static readonly int OnFriend=2;
		public static readonly int OnHero=4;
		public static readonly int OnUnit=8;

//conditimeTime��
		public static readonly int TimeAnyTime=0;//��ʱ��
		public static readonly int TimeBefore=1;//�¼�����ǰ
		public static readonly int TimeAfter=2;//�¼�������
	}

//ִ�з�ʽ
	public class TriggerResult
	{
		public int thisMove=0;
		public virtual void doMove(TriggerInput input,int extra = 0)
		{
			input.CardUser.GetComponent<CardMove>().Move(input,thisMove,extra);
		}
		public virtual void exec(TriggerInput input)
		{
		}
	}


//���캯����Ӧ��ֱ�Ӹ�������Trigger�����Թ�����
    public class Trigger
    {
            public TriggerCondition thisCondition;
            public TriggerTarget thisTarget;
            public TriggerResult thisResult;
		    
		
            public Trigger()
            {
                thisCondition=new TriggerCondition();
                thisTarget=new TriggerTarget();
                thisResult=new TriggerResult();
			}

	    public Trigger(TriggerTarget target,TriggerCondition condition,TriggerResult result)
        {
	        thisTarget=target;
	        thisCondition=condition;
	        thisResult=result;
        }

//ʵ��ִ�е�ִ�з�ʽ
	    public void exec(TriggerInput input)
	    {
            //Debug.Log("beforeExec");
		   	this.thisResult.doMove(input);
	    }

        public static bool IsInRange(GameObject user, GameObject target, TriggerTarget range)
        {
		//��������µ�����������Ҫ�ų��ų�
		if((target.GetComponent<Common_CardInfo>().cardInfo.position==1)||(target.GetComponent<Common_CardInfo>().cardInfo.position==4)) return false;
            //��˳���ж��Ƿ���ȷ��
            //�κε�����£�ֱ��Ϊ��
			//Debug.Log("IsInRange:"+(range.target & TriggerTarget.Anyone));
            if ((range.target & TriggerTarget.Anyone) == 1) return true;

            //ÿ����һһ�жϣ���һ�鲻�Ե�ʱ���ж�Ϊ�ٲ�������û�������������Ϊ�����С�

            //������
            if (!((range.target & TriggerTarget.Enemy) == 0 && (range.target & TriggerTarget.Friend) == 0))
            {
                int userPos;
                int targetPos;

                if (user.GetComponent<Common_CardInfo>().cardInfo.position <= 2) userPos = 1; else userPos = 2;
                if (target.GetComponent<Common_CardInfo>().cardInfo.position <= 2) targetPos = 1; else targetPos = 2;
                if (userPos == targetPos && (range.target & TriggerTarget.Friend) == 0) return false;
                if (userPos != targetPos && (range.target & TriggerTarget.Enemy) == 0) return false;
            }

            //������
            if (!((range.target & TriggerTarget.Myself) == 0 && (range.target & TriggerTarget.Others) == 0))
            {
                if (user == target && (range.target & TriggerTarget.Myself) == 0) return false;
                if (user != target && (range.target & TriggerTarget.Others) == 0) return false;
            }



            return true;
        }
    public static bool IfHaveTarget(GameObject user,TriggerTarget range)
{
	return MarkTarget(user,range).Count!=0;
}

public static List<GameObject> MarkTarget(GameObject user,TriggerTarget range)
{
	List<GameObject> output=new List<GameObject>();
	//��һ����������е�λ
	GameObject Panal1=GameObject.Find("Canvas/Field");
	GameObject Panal2=GameObject.Find("Canvas/Field_op");
	//�ڶ���������ÿ����λ��Ȼ���ж������λ�Ƿ��������Ŀ��
	for(int i=0;i<Panal1.transform.childCount;i++)
	{
		if(Panal1.transform.GetChild(i).GetComponent<Common_CardInfo>()== null)
				continue;
		if(IsInRange(user,Panal1.transform.GetChild(i).gameObject,range))
			output.Add(Panal1.transform.GetChild(i).gameObject);
	}
	for(int i=0;i<Panal2.transform.childCount;i++)
	{
		if(Panal2.transform.GetChild(i).GetComponent<Common_CardInfo>()== null)
				continue;
		if(IsInRange(user,Panal2.transform.GetChild(i).gameObject,range))
			output.Add(Panal2.transform.GetChild(i).gameObject);
	}
	return output;
}

    }
}