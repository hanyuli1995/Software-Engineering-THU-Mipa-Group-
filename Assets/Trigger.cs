using UnityEngine;
using System.Collections;


//基类就直接命名为Trigger了！（捂脸）不过继承类命名仍然要是"Trigger_"系列呀！
//工作方式：分为主动触发（法术或战吼）和被动触发。无论什么时候，输入时应有输入变量；主动触发类的要确认TriggerTarget，而被动触发类的则要确认TriggerCondition
class Trigger
{
	public class TriggerInput//输入Trigger时应有的变量。需要的变量应当尽可能少
	{
		//对于主动触发式，CardUser可以置为空；对于被动触发式，诸如进行攻击啥的，则应当把CardUser设为发动的卡片。
		GameObject CardUser;
		GameObject CardTarget;
	}


	public class TriggerTarget//用于提示卡片使用条件的变量。这些使用条件代表法术或者战吼随从的使用目标。对于没有明确目标的，例如随机打1这样的，直接可以当作Anytime
	{
		//使用方法是利用&符号连接多个类。
		public int target;

		static public readonly int Anyone=1;//这个被标记就代表任何单位都可以
		//以下两个将一一排他。如果两个都没标记就代表均可。只标记了一个就代表不要另一个
		public static readonly int Enemy=2;//敌军
		public static readonly int Friend=4;//友军。这个是包括自己的。

		public static readonly int Myself=8;//使用单位自己。这个和下面那个估计没有用，是我蠢了，捂脸
		public static readonly int Others=16;//除了使用者以外。

		public static readonly int Hero=32;//英雄
		public static readonly int Unit=64;//随从

		//下面为各种种族。只要标记了一个，就意味着其他没标记的都当作不能被指向。当然你可以标记多个
		public static readonly int Animal=128;//野兽
		public static readonly int Tecnical=256;//机械
		public static readonly int Evavl=512;//恶魔，好吧我英语不好，之后改
		public static readonly int Dragon=1024;//龙
		public static readonly int Fish=2048;//鱼人。如果你吐槽说鱼不等于鱼人，你就输了。
	}
	public TriggerTarget thisTarget;

	public class TriggerCondition//触发条件。这里的触发条件是被动触发的trigger的被动触发条件。所有的触发条件只能允许一个。
	{
		public int conditionType;//触发类型
		public int conditionTarget;//触发目标
		public int conditionTime;//触发时机

//conditionType组
		public static readonly int OnAnyTime=0;
		public static readonly int OnAttack=1;
		public static readonly int OnAttacked=2;
		public static readonly int OnDead=3;
		public static readonly int OnSummon=4;//召唤时。这个时间不包括“召唤自己”
		public static readonly int OnPlayCard=5;

//conditionTarget组
		public static readonly int OnAnyUnit=0;
		public static readonly int OnEnemy=1;
		public static readonly int OnFriend=2;
		public static readonly int OnHero=4;
		public static readonly int OnUnit=8;

//conditimeTime组
		public static readonly int TimeAnyTime=0;//无时机
		public static readonly int TimeBefore=1;//事件发生前
		public static readonly int TimeAfter=2;//事件发生后
	}
	public TriggerCondition thisCondition;

//执行方式
	public class TriggerResult
	{
		public void exec(Trigger.TriggerInput input)
		{
		}
	}
	public TriggerResult thisResult;

//构造函数就应该直接给定两个Trigger条件以供后用
	public Trigger(TriggerTarget target=new TriggerTarget,TriggerCondition condition=new TriggerCondition,TriggerResult result=new TriggerResult)
    {
	thisTarget=target;
	thisCondition=condition;
	thisResult=result;
    }

//实际执行的执行方式
	public void exec(TriggerInput input)
	{
		this.thisResult.exec(input);
	}
}