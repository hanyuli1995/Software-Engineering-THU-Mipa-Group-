using UnityEngine;
using System.Collections;

//此类的用途是用于获取卡片详细数据

public class Common_DataBase 
{
    static int nowItemId = 0;
    //需要为卡片的属性定一个类，并且将其作为卡片的成员。
    static public GameObject GetCard(int cardId, bool amplify = false)
    {
		GameObject newCard;
		if(amplify){
			newCard = GameObject.Find("GamePlayScene_CardFactory")
            .GetComponent<GamePlayScene_CardFactory>().CreateNewBigCard(cardId);
		}
		else{
			newCard = GameObject.Find("GamePlayScene_CardFactory")
            .GetComponent<GamePlayScene_CardFactory>().CreateNewCard(cardId);
		}
        
        Common_CardInfo.BaseInfo info=new Common_CardInfo.BaseInfo();
        switch (cardId)
        {
            case 1:
                info.cost = 10;
                info.atk = 12;
                info.hp = 12;
                info.name = "死亡之翼";
                info.description = "战吼：杀死场上所有的随从";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 2:
                info.cost = 1;
                info.atk = 1;
                info.hp = 1;
                info.name = "精灵弓箭手";
                info.description = "战吼：造成一点伤害";
				info.CardType=Common_CardInfo.BaseInfo.aimBattleUnit;
				info.thisTrigger=new Trigger.Trigger();
			    info.thisTrigger.thisTarget.target=Trigger.TriggerTarget.Anyone;//在这里指明了这个卡可以攻击任何单位
                info.thisTrigger.thisResult = new TriggerExecSpace.DealDamage(1);
                break;
			case 3:
                info.cost = 1;
                info.atk = 1;
                info.hp = 1;
                info.name = "鸭梨山大";
                info.description = "激怒：杀死场上的所有死亡之翼";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 4:
                info.cost = 1;
                info.atk = 1;
                info.hp = 1;
                info.name = "伊利丹·怒风";
                info.description = "激怒：杀死场上的所有死亡之翼";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 5:
                info.cost = 6;
                info.atk = 5;
                info.hp = 5;
                info.name = "希尔瓦娜斯";
                info.description = "亡语：获取MiPa";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 6:
			info.cost=4;
			info.name="水球术";
			info.description="对一个单位造成5点伤害/n 都觉得火球术超模，那么水球术总不超模了吧！";
			info.CardType=Common_CardInfo.BaseInfo.aimSpell;//这个标签指示了这张卡是一个指向法术卡
			info.thisTrigger=new Trigger.Trigger();
			info.thisTrigger.thisTarget.target=Trigger.TriggerTarget.Anyone;//在这里指明了这个卡可以攻击任何单位
            info.thisTrigger.thisResult = new TriggerExecSpace.DealDamage(5);
            break;
			case 7:
			info.cost=3;
			info.name="光明箭";
			info.description="对一个敌方单位造成4点伤害";
			info.CardType=Common_CardInfo.BaseInfo.aimSpell;//这个标签指示了这张卡是一个指向法术卡
            info.thisTrigger = new Trigger.Trigger();
			info.thisTrigger.thisTarget.target=Trigger.TriggerTarget.Enemy;//在这里则指示了只能攻击敌方单位
            info.thisTrigger.thisResult = new TriggerExecSpace.DealDamage(4);
            break;
			case 8:
                info.cost = 1;
                info.atk = 2;
                info.hp = 1;
                info.name = "小兵1";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 9:
                info.cost = 2;
                info.atk = 2;
                info.hp = 3;
                info.name = "小兵2";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 10:
                info.cost = 2;
                info.atk = 3;
                info.hp = 2;
                info.name = "迅猛龙";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 11:
                info.cost = 2;
                info.atk = 4;
                info.hp = 1;
                info.name = "快攻伙伴";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 12:
                info.cost = 3;
                info.atk = 3;
                info.hp = 4;
                info.name = "贤者";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 13:
                info.cost = 3;
                info.atk = 4;
                info.hp = 3;
                info.name = "无人收割机";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 14:
                info.cost = 3;
                info.atk = 5;
                info.hp = 2;
                info.name = "暴怒者";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 15:
                info.cost = 3;
                info.atk = 6;
                info.hp = 1;
                info.name = "快攻骑士";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 16:
                info.cost = 4;
                info.atk = 4;
                info.hp = 5;
                info.name = "雪爹";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 17:
                info.cost = 4;
                info.atk = 5;
                info.hp = 4;
                info.name = "攻击型雪人";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 18:
                info.cost = 4;
                info.atk = 7;
                info.hp = 2;
                info.name = "攻击型龟";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 19:
                info.cost = 4;
                info.atk = 2;
                info.hp = 7;
                info.name = "防守型龟";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 20:
                info.cost = 5;
                info.atk = 5;
                info.hp = 6;
                info.name = "龙人追随者";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 21:
                info.cost = 4;
                info.atk = 8;
                info.hp = 1;
                info.name = "超级暴怒者";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 22:
                info.cost = 5;
                info.atk = 6;
                info.hp = 5;
                info.name = "竞技场管理者";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 23:
                info.cost = 6;
                info.atk = 6;
                info.hp = 7;
                info.name = "大胖子";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 24:
                info.cost = 6;
                info.atk = 7;
                info.hp = 6;
                info.name = "强化版主宰";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 25:
                info.cost = 7;
                info.atk = 7;
                info.hp = 8;
                info.name = "大哥1";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 26:
                info.cost = 7;
                info.atk = 5;
                info.hp = 10;
                info.name = "大树";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 27:
                info.cost = 8;
                info.atk = 6;
                info.hp = 10;
                info.name = "巨兽";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 28:
                info.cost = 8;
                info.atk = 8;
                info.hp = 8;
                info.name = "霸王龙";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 29:
                info.cost = 10;
                info.atk = 10;
                info.hp = 10;
                info.name = "平民的死亡之翼";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 30:
                info.cost = 8;
                info.atk = 4;
                info.hp = 12;
                info.name = "被沉默的巨龙";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
        }
        info.id = cardId;
        nowItemId++;
        info.itemId = nowItemId;
        newCard.GetComponent<Common_CardInfo>().cardInfo = info;

        newCard.name = newCard.name + nowItemId;

        return newCard;
    }
}