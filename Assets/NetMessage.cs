using UnityEngine;
using System.Collections;


//NetMessage:�������ݴ����õĽӿڡ��ڴ�����������඼Ӧ���Դ�Ϊ�ӿ�������������

public class NetMessage
{
	public interface MSGPack
	{
        //int unitId;
	    string sendMSG();//����ת��ΪMSG�����Դ���
		void recvMSG(string input);//��MSGת������
	}
	
	static int Attack=1;
	static int DrawCard=2;
	static int Summon=3;
	static int SpellCard=4;
}