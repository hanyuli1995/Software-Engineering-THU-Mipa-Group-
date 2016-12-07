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


	public class TriggerTarget//������ʾ��Ƭʹ�������ı�������Щʹ����������������ս����ӵ�ʹ��Ŀ�ꡣ����û����ȷĿ��ģ����������1�����ģ�ֱ�ӿ��Ե���Anytime
	{
		//ʹ�÷���������&�������Ӷ���ࡣ
		public int target;

		public static const int Anytime=1;//�������Ǿʹ����κε�λ������
		//����������һһ���������������û��Ǿʹ�����ɡ�ֻ�����һ���ʹ���Ҫ��һ��
		public static const int Enemy=2;//�о�
		public static const int Friend=4;//�Ѿ�������ǰ����Լ��ġ�

		public static const int Myself=8;//ʹ�õ�λ�Լ�������������Ǹ�����û���ã����Ҵ��ˣ�����
		public static const int Others=16;//����ʹ�������⡣

		public static const int Hero=32;//Ӣ��
		public static const int Unit=64;//���

		//����Ϊ�������塣ֻҪ�����һ��������ζ������û��ǵĶ��������ܱ�ָ�򡣵�Ȼ����Ա�Ƕ��
		public static const int Animal=128;//Ұ��
		public static const int Tecnical=256;//��е
		public static const int Evavl=512;//��ħ���ð���Ӣ�ﲻ�ã�֮���
		public static const int Dragon=1024;//��
		public static const int Fish=2048;//���ˡ�������²�˵�㲻�������ˣ�������ˡ�
	}
	public TriggerTarget thisTarget;

	public class TriggerCondition//��������������Ĵ��������Ǳ���������trigger�ı����������������еĴ�������ֻ������һ����
	{
		public int conditionType;//��������
		public int conditionTarget;//����Ŀ��
		public int conditionTime;//����ʱ��

//conditionType��
		public static const int OnAnyTime=0;
		public static const int OnAttack=1;
		public static const int OnAttacked=2;
		public static const int OnDead=3;
		public static const int OnSummon=4;//�ٻ�ʱ�����ʱ�䲻�������ٻ��Լ���
		public static const int OnPlayCard=5;

//conditionTarget��
		public static const int OnAnyUnit=0;
		public static const int OnEnemy=1;
		public static const int OnFriend=2;
		public static const int OnHero=4;
		public static const int OnUnit=8;

//conditimeTime��
		public static const int TimeAnyTime=0;//��ʱ��
		public static const int TimeBefore=1;//�¼�����ǰ
		public static const int TimeAfter=2;//�¼�������
	}
	public TriggerCondition thisCondition;

//ִ�з�ʽ
	public class TriggerResult
	{
		public void exec(Trigger.TriggerInput input)
		{
		}
	}
	public class thisResult;

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