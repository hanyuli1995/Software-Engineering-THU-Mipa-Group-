//�㼸��ʾ������......�����ԣ���ֱ�Ӹ㼸������ˡ�

using System.Collections.Generic;
//����Triggerʵ�֣���д�ڴ�������.....Ҳ��һ��������д�ڲ�ͬ���ļ�����Ƕ�Ҫ�����namespace����
using UnityEngine;

namespace TriggerExecSpace
{
/*
	public class DealRandomDamage : Trigger.TriggerResult
	{
		int DamageTotal;
		public DealRandomDamage(int total)
		{
			DamageTotal=total;
		}
		public override void exec(Trigger.TriggerInput input)
		{
			//ʵ��������������Է�Ϊ������������к��ʵĵ�λ��Ȼ���������˺���
			//������Ҫ�ĵ�һ�����жϿɴ����Χ�����ʹ��ר�ŵĺ���Ϊ��

			//�ڶ��������������˺���ÿ��1�㡣ÿ���˺�����һ�δ�����
		}
	}*/

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
		public override void exec(Trigger.TriggerInput input)
		{
            input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.hp += thisHeal;
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

//���Ա仯������+1/+1��-1/-1���ࡣ���ֻ���˲����������üӳɡ��Ͼ���Ĭ������
//˳��һ�ᣬ�����������������������ֵ������Ľ��������
	public class StaticChange : Trigger.TriggerResult
	{
		int atk;
		int hp;
		public StaticChange(int atkch,int hpch)
		{
			atk=atkch;
			hp=hpch;
		}
		public override void exec(Trigger.TriggerInput input)
		{
			input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.atk+=atk;
			if(input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.atk<0)input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.atk=0;
			input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.maxhp+=hp;
			if(hp>0)input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.hp+=hp;
			else if(input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.hp>input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.maxhp)
			input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.hp=input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.maxhp;
		}
	}

    //�������ԣ������С�ǹ�
    //Ҳ�������ں�����ŵ�����ǲ��������������ֵ
    public class StaticSet : Trigger.TriggerResult
    {
        int atk;
        int hp;

        //ע������Ϊ���������Ӵ����Ȼ����������Ϊ0�����ֿ��µ�����
        public StaticSet(int atkst, int hpst)
        {
            atk = atkst;
            hp = hpst;
        }

        public override void exec(Trigger.TriggerInput input)
        {
            if (atk != 0)
                input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.atk = atk;
            if (hp != 0)
            {
                //����Ӣ��ʱ�Ż��趨�������ֵӴ����
                if (input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.CardType != Common_CardInfo.BaseInfo.Hero)
                    input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.maxhp = hp;

                input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.hp = hp;
            }
        }
    }

	//��Һ�����AOE
	public class AllDamage: Trigger.TriggerResult
	{
		int damage;
        public AllDamage(int tdamage)
        {
            damage = tdamage;
        }
        public override void exec(Trigger.TriggerInput input)
        {
            List<GameObject> target = Trigger.Trigger.MarkTarget(input.CardUser, input.CardUser.GetComponent<Common_CardInfo>().cardInfo.thisTrigger.thisTarget);
            Trigger.TriggerResult tempTrigger = new DealDamage(damage);
            foreach (GameObject obj in target)
            {
                tempTrigger.exec(new Trigger.TriggerInput(input.CardUser,obj));
            }
        }
	}

	//����Ⱥ�˾���Ⱥ�֣������˼�������
	public class AllHeal: Trigger.TriggerResult
	{
        int heal;
        public AllHeal(int theal)
        {
            heal = theal;
        }
        public override void exec(Trigger.TriggerInput input)
        {
            List<GameObject> target = Trigger.Trigger.MarkTarget(input.CardUser, input.CardUser.GetComponent<Common_CardInfo>().cardInfo.thisTrigger.thisTarget);
            Trigger.TriggerResult tempTrigger = new HealUnit(heal);
            foreach (GameObject obj in target)
            {
                tempTrigger.exec(new Trigger.TriggerInput(input.CardUser, obj));
            }
        }
	}

	//��Һ���������Ⱥ�����Ա仯��������������������ֵ������Ա仯ӴӴӴ

    //������������԰ɡ����������ø���
/*	public class AllStaticChangeInHand:Trigger.TriggerResult
	{
        int hp;
        int atk;
        public AllStaticChangeInHand(int hpc, int atkc)
        {
            hp = hpc;
            atk = atkc;

        }

        public override void exec(Trigger.TriggerInput input)
        {
            if (input.CardUser.GetComponent<Common_CardInfo>().cardInfo.position <= 2)
            {
                
            }
            else
            {

            }
        }
	}
*/
	//Ⱥ�����ã���ǹܻ�����ƽ
	public class AllStaticSet:Trigger.TriggerResult
	{
        int hp;
        int atk;

        public AllStaticSet(int hpset, int atkset)
        {
            hp = hpset;
            atk = atkset;
        }

        public override void exec(Trigger.TriggerInput input)
        {
            List<GameObject> target = Trigger.Trigger.MarkTarget(input.CardUser, input.CardUser.GetComponent<Common_CardInfo>().cardInfo.thisTrigger.thisTarget);
            Trigger.TriggerResult tempTrigger = new StaticSet(hp,atk);
            foreach (GameObject obj in target)
            {
                tempTrigger.exec(new Trigger.TriggerInput(input.CardUser, obj));
            }
        }
	}

	//public class FACAI���ȿȣ��ܶ���֮ģ��һ������������
	//������ŵ��Ч��Ӵ
    public class ConditionHeal_Collection_No_Same : Trigger.TriggerResult
	{
        public ConditionHeal_Collection_No_Same()
        {
        }

        public override void exec(Trigger.TriggerInput input)
        {
            int[] idlist = new int[300];
            bool abled=true;
            if (input.CardUser.GetComponent<Common_CardInfo>().cardInfo.position <= 2)
            {
                List<GameObject> mylist=GameObject.Find("GameCenter").GetComponent<GamePlayScene_GameCenterScript>().CardCollection;
                foreach (GameObject obj in mylist)
                {
                    int nowid = obj.GetComponent<Common_CardInfo>().cardInfo.id;
                    if (idlist[nowid] == 1) abled = false;
                }
                if (abled)
                {
                    Trigger.TriggerResult newRes = new StaticSet(0, 30);
                    newRes.exec(new Trigger.TriggerInput(GameObject.Find("Hero"),null));
                }
            }
            else
            {
                List<GameObject> mylist = GameObject.Find("GameCenter").GetComponent<GamePlayScene_GameCenterScript>().CardCollection_op;
                foreach (GameObject obj in mylist)
                {
                    int nowid = obj.GetComponent<Common_CardInfo>().cardInfo.id;
                    if (idlist[nowid] == 1) abled = false;
                }
                if (abled)
                {
                    Trigger.TriggerResult newRes = new StaticSet(0, 30);
                    newRes.exec(new Trigger.TriggerInput(GameObject.Find("Hero_op"), null));
                }
            }
            
        }
	}



	//���ǳ�棬���Ч������ʵ��
    //����൱��ս�𣺱��غϿ��Թ���������
    public class CanStrike : Trigger.TriggerResult
	{
        public CanStrike()
        {
        }

        public override void exec(Trigger.TriggerInput input)
        {
            input.CardUser.GetComponent<Common_CardInfo>().cardInfo.attack = true;

        }
	}
}