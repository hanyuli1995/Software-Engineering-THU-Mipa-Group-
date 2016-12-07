using UnityEngine;
using System.Collections;

//�������;�����ڻ�ȡ��Ƭ��ϸ����

public class Common_DataBase 
{
    static int nowItemId = 0;
    //��ҪΪ��Ƭ�����Զ�һ���࣬���ҽ�����Ϊ��Ƭ�ĳ�Ա��
    static public GameObject GetCard(int cardId)
    {
        GameObject newCard = GameObject.Find("GamePlayScene_CardFactory")
            .GetComponent<GamePlayScene_CardFactory>().CreateNewCard(cardId);
        Common_CardInfo.BaseInfo info=new Common_CardInfo.BaseInfo();
        switch (cardId)
        {
            case 1:
                info.cost = 10;
                info.atk = 12;
                info.hp = 12;
                info.name = "����֮��";
                info.description = "ս����ɱ���ж��ѣ���ɱ�Լ���������";
                break;
            case 2:
                info.cost = 1;
                info.atk = 1;
                info.hp = 1;
                info.name = "��ŭ��С��";
                info.description = "��ŭ��ɱ�����ϵ���������֮��";
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