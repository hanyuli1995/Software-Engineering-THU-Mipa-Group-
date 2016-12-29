﻿using UnityEngine;
using System.Collections;

//ԋ ՄӃ;ʇӃӚ۱ȡߨƬϪϸʽޝ

public class CardSet_DataBase
{
    static public int nowItemId = 0;
    //ШҪΪߨƬՄʴД֨һض ìҢǒݫƤ׷ΪߨƬՄӉԱc
    static public GameObject GetCard(int cardId, int copyType = 0, bool amplify = false)
    {
        GameObject newCard;
        if (amplify)
        {
            newCard = GameObject.Find("GamePlayScene_CardFactory")
            .GetComponent<CardSetScene_CardFactory>().CreateNewBigCard(cardId);
        }
        else
        {
            newCard = GameObject.Find("GamePlayScene_CardFactory")
            .GetComponent<CardSetScene_CardFactory>().CreateNewCard(cardId);
        }

        Common_CardInfo.BaseInfo info = new Common_CardInfo.BaseInfo();
        switch (cardId)
        {
            case 1:
                info.cost = 2;
                info.atk = 1;
                info.hp = 1;
                info.name = "颜大师学徒";
                info.description = "战吼：抽一张牌";
                info.CardType = Common_CardInfo.BaseInfo.noaimBattleUnit;
                info.thisTrigger = new Trigger.Trigger();
                info.thisTrigger.thisTarget.target = Trigger.TriggerTarget.Anyone;
                info.thisTrigger.thisResult = new TriggerExecSpace.DrawCard(1);

                break;
            case 2:
                info.cost = 1;
                info.atk = 1;
                info.hp = 1;
                info.name = "奇怪的射手";
                info.description = "战吼：造成1点伤害";
                info.CardType = Common_CardInfo.BaseInfo.aimBattleUnit;
                info.thisTrigger = new Trigger.Trigger();
                info.thisTrigger.thisTarget.target = Trigger.TriggerTarget.Others;//Ԛբ/ָ÷Kբضߨ߉Ҕ٥۷Ȏڎեλ
                info.thisTrigger.thisResult = new TriggerExecSpace.DealDamage(1);
                info.thisTrigger.thisResult.thisMove = CardMove.battleDamage;
                break;
            case 3:
                info.cost = 2;
                info.atk = 2;
                info.hp = 3;
                info.name = "普通的植物";
                info.description = "";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 4:
                info.cost = 1;
                info.atk = 1;
                info.hp = 3;
                info.name = "标准身材的战士";
                info.description = "";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 5:
                info.cost = 6;
                info.atk = 5;
                info.hp = 5;
                info.name = "圣光治疗者";
                info.description = "为所有友方角色恢复3点生命值";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 6:
                info.cost = 4;
                info.name = "光球术";
                info.description = "造成5点伤害——人们都说火球术超模，但是光球术绝不超模！";
                info.CardType = Common_CardInfo.BaseInfo.aimSpell;//բضѪǩָʾKբՅߨʇһضָϲרʵߨ
                info.thisTrigger = new Trigger.Trigger();
                info.thisTrigger.thisTarget.target = Trigger.TriggerTarget.Anyone;//Ԛբ/ָ÷Kբضߨ߉Ҕ٥۷Ȏڎեλ
                info.thisTrigger.thisResult = new TriggerExecSpace.DealDamage(5);
                info.thisTrigger.thisResult.thisMove = CardMove.spellDamage;
                break;
            case 7:
                info.cost = 3;
                info.name = "半个炎枪术";
                info.description = "对一个敌方单位造成4点伤害——当炎枪变成两半时，就可以攻击英雄了";
                info.CardType = Common_CardInfo.BaseInfo.aimSpell;//բضѪǩָʾKբՅߨʇһضָϲרʵߨ
                info.thisTrigger = new Trigger.Trigger();
                info.thisTrigger.thisTarget.target = Trigger.TriggerTarget.Enemy;//Ԛբ/ԲָʾKֻĜ٥۷Ր׽եλ
                info.thisTrigger.thisResult = new TriggerExecSpace.DealDamage(4);
                info.thisTrigger.thisResult.thisMove = CardMove.spellDamage;
                break;
            case 8:
                info.cost = 1;
                info.atk = 2;
                info.hp = 1;
                info.name = "标准咸鱼";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 9:
                info.cost = 2;
                info.atk = 2;
                info.hp = 3;
                info.name = "高等咸鱼";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 10:
                info.cost = 2;
                info.atk = 3;
                info.hp = 2;
                info.name = "次生咸鱼";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 11:
                info.cost = 2;
                info.atk = 4;
                info.hp = 1;
                info.name = "鱼刺";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 12:
                info.cost = 3;
                info.atk = 3;
                info.hp = 4;
                info.name = "正常的猴子";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 13:
                info.cost = 3;
                info.atk = 4;
                info.hp = 3;
                info.name = "倒立的猴子ۺ";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 14:
                info.cost = 3;
                info.atk = 5;
                info.hp = 2;
                info.name = "没生气的猴子";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 15:
                info.cost = 3;
                info.atk = 6;
                info.hp = 1;
                info.name = "真没生气的猴子";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 16:
                info.cost = 4;
                info.atk = 4;
                info.hp = 5;
                info.name = "优秀的打工战士";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 17:
                info.cost = 4;
                info.atk = 5;
                info.hp = 4;
                info.name = "一般的打工战士";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 18:
                info.cost = 4;
                info.atk = 7;
                info.hp = 2;
                info.name = "打工队长";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 19:
                info.cost = 4;
                info.atk = 2;
                info.hp = 7;
                info.name = "这个是工人么？";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 20:
                info.cost = 5;
                info.atk = 5;
                info.hp = 6;
                info.name = "看不见东西的龙";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 21:
                info.cost = 4;
                info.atk = 8;
                info.hp = 1;
                info.name = "高级岩浆暴怒者";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 22:
                info.cost = 5;
                info.atk = 6;
                info.hp = 5;
                info.name = "力量龙";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 23:
                info.cost = 6;
                info.atk = 6;
                info.hp = 7;
                info.name = "石巨人";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 24:
                info.cost = 6;
                info.atk = 7;
                info.hp = 6;
                info.name = "人巨石";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 25:
                info.cost = 7;
                info.atk = 7;
                info.hp = 8;
                info.name = "完爆战争傀儡";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 26:
                info.cost = 7;
                info.atk = 5;
                info.hp = 10;
                info.name = "战争古树——忘拿盾牌的";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 27:
                info.cost = 8;
                info.atk = 6;
                info.hp = 10;
                info.name = "急速战士";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 28:
                info.cost = 8;
                info.atk = 8;
                info.hp = 8;
                info.name = "沉默的炎魔之王";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 29:
                info.cost = 10;
                info.atk = 10;
                info.hp = 10;
                info.name = "大怪兽（白卡）";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;
            case 30:
                info.cost = 8;
                info.atk = 4;
                info.hp = 12;
                info.name = "伊瑟拉（醒着的）";
                info.CardType = Common_CardInfo.BaseInfo.normalUnit;
                break;

        }
        info.id = cardId;
        info.copyType = copyType;
        nowItemId++;
        info.itemId = nowItemId;
        info.attack = false;
        newCard.GetComponent<Common_CardInfo>().cardInfo = info;

        newCard.name = "Card" + nowItemId;

        return newCard;
    }
}