//�㼸��ʾ������......�����ԣ���ֱ�Ӹ㼸������ˡ�

//����Triggerʵ�֣���д�ڴ�������.....Ҳ��һ��������д�ڲ�ͬ���ļ�����Ƕ�Ҫ�����namespace����

namespace TriggerExecSpace
{
	public class DealRandomDamage : Trigger.TriggerResult
	{
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
		public void exec(Trigger.TriggerInput input)
		{
			input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.hp-=thisDamage;
		}
	}
    
	/*public class DealDamageToAll : Trigger.TriggerResult//AOE��ʱ��α���룬��֪��Ŀ��ѡ��
	{
		int thisDamage;
		public DealDamageToAll(int damage)
		{
			thisDamage=damage;
		}
		public void exec(Trigger.TriggerInput input)
		{
			foreach(GameObject obj1 in Trigger.Trigger.MarkTarget��input.user,input.user.GetComponent<Common_CardInfo>().cardInfo.thisTrigger.TriggerTarget)
			{
			obj1.GetComponent<Common_CardInfo>().cardInfo.hp-=thisDamage;
			}
		}
	}*/
}