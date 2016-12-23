//�㼸��ʾ������......�����ԣ���ֱ�Ӹ㼸������ˡ�

//����Triggerʵ�֣���д�ڴ�������.....Ҳ��һ��������д�ڲ�ͬ���ļ�����Ƕ�Ҫ�����namespace����
using UnityEngine;

namespace TriggerExecSpace
{
	public class DealRandomDamage : Trigger.TriggerResult
	{
		int DamageTotal;
		public DealRandomDamage(int total)
		{
			DamageTotal=total;
		}
		public void exec(Trigger.TriggerInput input)
		{
			//ʵ��������������Է�Ϊ������������к��ʵĵ�λ��Ȼ���������˺���
			//������Ҫ�ĵ�һ�����жϿɴ����Χ�����ʹ��ר�ŵĺ���Ϊ��

			//�ڶ��������������˺���ÿ��1�㡣ÿ���˺�����һ�δ�����
		}
	}

	public class DealDamage : Trigger.TriggerResult
	{
		int thisDamage;
		public DealDamage(int damage)
		{
			thisDamage=damage;
		}
		public override void doMove(Trigger.TriggerInput input,int extra = 0)
		{
			base.doMove(input,thisDamage);
		}
		public override void exec(Trigger.TriggerInput input)
		{
			
			input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.hp-=thisDamage;
		}
	}

	public class HealUnit : Trigger.TriggerResult
	{
		int thisHeal;
		public HealUnit(int heal)
		{
			thisHeal=heal;
		}
		public void exec(Trigger.TriggerInput input)
		{
			
			if(input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.hp>input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.maxhp)
			input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.hp=input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.maxhp;
		}
	}
	
	public class DrawCard : Trigger.TriggerResult
	{
		int CardNum;//�鿨����һ����1�ţ���Ҳ���ܶ���
		public DrawCard(int number=1)
		{
			CardNum=number;
		}
		public override void exec(Trigger.TriggerInput input)
		{
			//��Ҫ�ڿ�Ƭ�ﱣ��һ������������Լ������ı�
			for(int i=0;i<CardNum;i++)
			if(input.CardUser.GetComponent<Common_CardInfo>().cardInfo.position<=2)
			GameObject.Find("GameCenter").GetComponent<GamePlayScene_GameCenterScript>().DrawCard();
	else
		{
	GameObject.Find("GameCenter").GetComponent<GamePlayScene_GameCenterScript>().DrawCard_op();

		}
		}
	}

//���Ա仯������+1/+1��-1/-1���ࡣ���ֻ���˲����������üӳɡ�
	public class StaticChange : Trigger.TriggerResult
	{
		int atk;
		int hp;
		public StaticChange(int atkch,int hpch)
		{
			atk=atkch;
			hp=hpch;
		}
		public void exec(Trigger.TriggerInput input)
		{
			input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.atk+=atk;
			if(input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.atk<0)input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.atk=0;
			input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.maxhp+=hp;
			if(hp>0)input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.hp+=hp;
			else if(input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.hp>input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.maxhp)
			input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.hp=input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.maxhp;
		}
	}

}