using UnityEngine;
using System.Collections;

//�������;�����ڻ�ȡ��Ƭ��ϸ����

public class Common_DataBase 
{
    static int nowItemId = 0;
    //��ҪΪ��Ƭ�����Զ�һ���࣬���ҽ�����Ϊ��Ƭ�ĳ�Ա��
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
                info.maxhp = 12;
                info.name = "Cute Wing";
                info.description = "ս����ɱ���ж��ѣ���ɱ�Լ���������";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 2:
                info.cost = 1;
                info.atk = 1;
                info.maxhp = 1;
                info.hp = 1;
                info.name = "Angry Bird";
                info.description = "��ŭ��ɱ�����ϵ���������֮��";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 3:
                info.cost = 1;
                info.atk = 1;
                info.maxhp = 1;
                info.hp = 1;
                info.name = "Alexstrasza";
                info.description = "��ŭ��ɱ�����ϵ���������֮��";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 4:
                info.cost = 1;
                info.atk = 1;
                info.maxhp = 1;
                info.hp = 1;
                info.name = "Illidan Stormrage";
                info.description = "��ŭ��ɱ�����ϵ���������֮��";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 5:
                info.cost = 6;
                info.atk = 5;
                info.maxhp = 5;
                info.hp = 5;
                info.name = "Sylvanas";
                info.description = "�����ȡMiPa";
				info.CardType=Common_CardInfo.BaseInfo.normalUnit;
                break;
			case 6:

				info.cost=4;
				info.name="ˮ����";
				info.description="��һ����λ���5���˺�/n �����û�������ģ����ôˮ�����ܲ���ģ�˰ɣ�";
				info.CardType=Common_CardInfo.BaseInfo.aimSpell;//�����ǩָʾ�����ſ���һ��ָ������
				info.thisTrigger=new Trigger.Trigger();
				info.thisTrigger.thisTarget.target=Trigger.TriggerTarget.Anyone;//������ָ������������Թ����κε�λ
				info.thisTrigger.thisResult = new TriggerExecSpace.DealDamage(5);

            break;
			case 7:
				info.cost=3;
				info.name="������";
				info.description="��һ���з���λ���4���˺�";
				info.CardType=Common_CardInfo.BaseInfo.aimSpell;//�����ǩָʾ�����ſ���һ��ָ������
				info.thisTrigger = new Trigger.Trigger();
				info.thisTrigger.thisTarget.target=Trigger.TriggerTarget.Enemy;//��������ָʾ��ֻ�ܹ����з���λ
				info.thisTrigger.thisResult = new TriggerExecSpace.DealDamage(4);
            break;
        }
        info.id = cardId;
        nowItemId++;
        info.itemId = nowItemId;
		info.ifdelete = false;
        newCard.GetComponent<Common_CardInfo>().cardInfo = info;

        newCard.name = newCard.name + nowItemId;

        return newCard;
    }
}