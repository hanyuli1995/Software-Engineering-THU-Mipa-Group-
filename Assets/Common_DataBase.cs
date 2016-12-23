using UnityEngine;
using System.Collections;

//ԋ ՄӃ;ʇӃӚ۱ȡߨƬϪϸʽޝ

public class Common_DataBase 
{
    static int nowItemId = 0;
    //ШҪΪߨƬՄʴД֨һض ìҢǒݫƤ׷ΪߨƬՄӉԱc
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
                info.cost = 2;
                info.atk = 1;
                info.hp = 1;
                info.name = "颜大师学徒";
                info.description = "战吼：抽一张牌";
				info.CardType=Common_CardInfo.BaseInfo.noaimBattleUnit;
                //info.thisTrigger.thisResult = new TriggerExecSpace.DrawCard(1);
                break;
            case 2:
                info.cost = 1;
                info.atk = 1;
                info.hp = 1;
                info.name = "ޫi٭ܽʖ";
                info.description = "սڰúԬӉһգɋڦ";
				info.CardType=Common_CardInfo.BaseInfo.aimBattleUnit;
				info.thisTrigger=new Trigger.Trigger();
			    info.thisTrigger.thisTarget.target=Trigger.TriggerTarget.Others;//Ԛբ/ָ÷Kբضߨ߉Ҕ٥۷Ȏڎեλ
                info.thisTrigger.thisResult = new TriggerExecSpace.DealDamage(1);
				info.thisTrigger.thisResult.thisMove = CardMove.battleDamage;
                break;
			case 3:
                info.cost = 1;
                info.atk = 1;
                info.hp = 1;
                info.name = "Ѽ&ɽԳ";
                info.description = "ܤŭúɱˀӡɏՄ˹ӐˀͶ֮ҭ";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 4:
                info.cost = 1;
                info.atk = 1;
                info.hp = 1;
                info.name = "ҁ;դdŭק";
                info.description = "ܤŭúɱˀӡɏՄ˹ӐˀͶ֮ҭ";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 5:
                info.cost = 6;
                info.atk = 5;
                info.hp = 5;
                info.name = "ϣֻ͟Ĉ˹";
                info.description = "Ͷӯú۱ȡMiPa";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 6:
				info.cost=4;
				info.name="ˮǲʵ";
				info.description="֔һضեλԬӉ5գɋڦ/n ּ޵Ճ۰ǲʵӬģìćôˮǲʵלһӬģKЉá";
				info.CardType=Common_CardInfo.BaseInfo.aimSpell;//բضѪǩָʾKբՅߨʇһضָϲרʵߨ
				info.thisTrigger=new Trigger.Trigger();
				info.thisTrigger.thisTarget.target=Trigger.TriggerTarget.Anyone;//Ԛբ/ָ÷Kբضߨ߉Ҕ٥۷Ȏڎեλ
				info.thisTrigger.thisResult = new TriggerExecSpace.DealDamage(5);
				info.thisTrigger.thisResult.thisMove = CardMove.spellDamage;
            break;
			case 7:
				info.cost=3;
				info.name="٢÷ܽ";
				info.description="֔һضՐ׽եλԬӉ4գɋڦ";
				info.CardType=Common_CardInfo.BaseInfo.aimSpell;//բضѪǩָʾKբՅߨʇһضָϲרʵߨ
				info.thisTrigger = new Trigger.Trigger();
				info.thisTrigger.thisTarget.target=Trigger.TriggerTarget.Enemy;//Ԛբ/ԲָʾKֻĜ٥۷Ր׽եλ
				info.thisTrigger.thisResult = new TriggerExecSpace.DealDamage(4);
				info.thisTrigger.thisResult.thisMove = CardMove.spellDamage;
            break;
			case 8:
                info.cost = 1;
                info.atk = 2;
                info.hp = 1;
                info.name = "СѸ1";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 9:
                info.cost = 2;
                info.atk = 2;
                info.hp = 3;
                info.name = "СѸ2";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 10:
                info.cost = 2;
                info.atk = 3;
                info.hp = 2;
                info.name = "ѸÍz";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 11:
                info.cost = 2;
                info.atk = 4;
                info.hp = 1;
                info.name = "߬٥ۯЩ";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 12:
                info.cost = 3;
                info.atk = 3;
                info.hp = 4;
                info.name = "ύ՟";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 13:
                info.cost = 3;
                info.atk = 4;
                info.hp = 3;
                info.name = "Ξȋʕخۺ";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 14:
                info.cost = 3;
                info.atk = 5;
                info.hp = 2;
                info.name = "ѩŭ՟";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 15:
                info.cost = 3;
                info.atk = 6;
                info.hp = 1;
                info.name = "߬٥Ưʿ";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 16:
                info.cost = 4;
                info.atk = 4;
                info.hp = 5;
                info.name = "ѩչ";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 17:
                info.cost = 4;
                info.atk = 5;
                info.hp = 4;
                info.name = "٥۷Ѝѩȋ";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 18:
                info.cost = 4;
                info.atk = 7;
                info.hp = 2;
                info.name = "٥۷Ѝ٪";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 19:
                info.cost = 4;
                info.atk = 2;
                info.hp = 7;
                info.name = "׀ʘЍ٪";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 20:
                info.cost = 5;
                info.atk = 5;
                info.hp = 6;
                info.name = "zȋ׷˦՟";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 21:
                info.cost = 4;
                info.atk = 8;
                info.hp = 1;
                info.name = "Ӭܶѩŭ՟";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 22:
                info.cost = 5;
                info.atk = 6;
                info.hp = 5;
                info.name = "޺ܼӡٜ-՟";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 23:
                info.cost = 6;
                info.atk = 6;
                info.hp = 7;
                info.name = "ԳŖד";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 24:
                info.cost = 6;
                info.atk = 7;
                info.hp = 6;
                info.name = "ǿۯЦַԗ";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 25:
                info.cost = 7;
                info.atk = 7;
                info.hp = 8;
                info.name = "Գا1";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 26:
                info.cost = 7;
                info.atk = 5;
                info.hp = 10;
                info.name = "Գʷ";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 27:
                info.cost = 8;
                info.atk = 6;
                info.hp = 10;
                info.name = "ޞʞ";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 28:
                info.cost = 8;
                info.atk = 8;
                info.hp = 8;
                info.name = "Д͵z";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 29:
                info.cost = 10;
                info.atk = 10;
                info.hp = 10;
                info.name = "ƽñՄˀͶ֮ҭ";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 30:
                info.cost = 8;
                info.atk = 4;
                info.hp = 12;
                info.name = "ѻӁĬՄޞz";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
        }
        info.id = cardId;
        nowItemId++;
        info.itemId = nowItemId;
		info.attack = false;
        newCard.GetComponent<Common_CardInfo>().cardInfo = info;

        newCard.name = "Card" + nowItemId;
		
        return newCard;
    }
}