//搞几个示例代码......？不对，是直接搞几个类好了。

//所有Trigger实现，将写在此类里面.....也不一定。可以写在不同的文件里，但是都要在这个namespace里面
using UnityEngine;

namespace TriggerExecSpace
{
	public class DealRandomDamage : Trigger.TriggerResult
	{
		public void exec(Trigger.TriggerInput input)
		{
			//实现事情的做法可以分为两步：获得所有合适的单位；然后随机造成伤害。
			//所以需要的第一步是判断可打击范围。这个使用专门的函数为佳

			//第二步则是随机造成伤害。每次1点。每点伤害呼叫一次触发器
		}
	}

	public class DealDamage : Trigger.TriggerResult
	{
		int thisDamage;
		public DealDamage(int damage)
		{
			thisDamage=damage;
		}
		public override void exec(Trigger.TriggerInput input)
		{
			Debug.Log("Let's Damage");
			input.CardTarget.GetComponent<Common_CardInfo>().cardInfo.hp-=thisDamage;
		}
	}

}