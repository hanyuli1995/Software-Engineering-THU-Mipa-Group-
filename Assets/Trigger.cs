using UnityEngine;
using System.Collections;


//�����ֱ������ΪTrigger�ˣ��������������̳���������ȻҪ��"Trigger_"ϵ��ѽ��
//������ʽ����Ϊ����������������ս�𣩺ͱ�������������ʲôʱ������ʱӦ����������������������Ҫȷ��TriggerTarget�����������������Ҫȷ��TriggerCondition
class Trigger
{
	public class TriggerInput//����TriggerʱӦ�еı�������Ҫ�ı���Ӧ����������
	{
		//������������ʽ��CardUser������Ϊ�գ����ڱ�������ʽ��������й���ɶ�ģ���Ӧ����CardUser��Ϊ�����Ŀ�Ƭ��
		GameObject CardUser;
		GameObject CardTarget;
	}


	public class TriggerTarget//������ʾ��Ƭʹ�������ı�������Щʹ������������������ս����ӵ�ʹ��Ŀ�ꡣ����û����ȷĿ��ģ����������1�����ģ�ֱ�ӿ��Ե���Anytime
	{
		//ʹ�÷���������&�������Ӷ���ࡣ
		public int target;

		static public readonly int Anytime=1;//�������Ǿʹ����κε�λ������
		//����������һһ���������������û��Ǿʹ������ɡ�ֻ�����һ���ʹ�����Ҫ��һ��
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
	public TriggerTarget thisTarget;

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
	public TriggerCondition thisCondition;

//ִ�з�ʽ
	public class TriggerResult
	{
		public void exec(Trigger.TriggerInput input)
		{
		}
	}
	public TriggerResult thisResult;

//���캯����Ӧ��ֱ�Ӹ�������Trigger�����Թ�����
	public Trigger(TriggerTarget target,TriggerCondition condition,TriggerResult result)
    {
	thisTarget=target;
	thisCondition=condition;
	thisResult=result;
    }

//ʵ��ִ�е�ִ�з�ʽ
	public void exec(TriggerInput input)
	{
		this.thisResult.exec(input);
	}
}