//�ܶ���֮�����ж��Ƿ��ڷ�Χ�ڣ��ĺ�����
//�����Χ����˼����ָ������һ��GameObject,����һ��Trigger.TriggerTarget���ж��Ƿ����ڷ�Χ��

using UnityEngine;
using System.Collections;

//�ƺ�����Ҫһ��ʹ��Ŀ�귶Χ
public bool IsInRange(GameObject user,GameObject target,Trigger.TriggerTarget range)
{
	//��˳���ж��Ƿ���ȷ��
	//�κε�����£�ֱ��Ϊ��
	if(range&Trigger.TriggerTarget.Anytime==1)return true;
	
	//ÿ����һһ�жϣ���һ�鲻�Ե�ʱ���ж�Ϊ�ٲ�������û�������������Ϊ�����С�
	
	//������
	if(!(range&Trigger.TriggerTarget.Enemy==0 && range&Trigger.TriggerTarget.Friend==0))
	{
		int userPos;
		int targetPos;

		if(user.GetComponent<Common_CardInfo>().cardInfo.position<=2) userPos=1;else userPos=2;
		if(target.GetComponent<Common_CardInfo>().cardInfo.position<=2) targetPos=1;else targetPos=2;
		if(userPos==targetPos && !(range&Trigger.TriggerTarget.Friend)) return false;
		if(userPos!=targetPos && !(range&Trigger.TriggerTarget.Enemy)) return false;
	}

	//������
	if(!(range&Trigger.TriggerTarget.Myself==0 && range&Trigger.TriggerTarget.Others==0))
	{
		if(user==target && !(range&Trigger.TriggerTarget.Myself))return false;
		if(user!=target && !(range&Trigger.TriggerTarget.Others))return false;
	}



	return true;
}