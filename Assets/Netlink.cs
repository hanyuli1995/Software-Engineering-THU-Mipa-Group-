using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Net;
using System.Net.Sockets;

//Netlink����ֱ�ӵش�����Ϣ��
//��õ��������κ��¼�����ʱ��Զ�˴���һ���ȼ��¼���Ȼ��Զ��ȡ���¼�����Ϊ�ȼ��¼��ó���

public class Netlink
{
	private TcpListener listener;
	private TcpClient client;
	
	
	public int Host(int port)
	{
		listener=new TcpListener(port);
		listener.Start(10);
		StartCoroutine(WaitForClient());

		return 0;
	}
	
	private IEnumerator WaitForClient()
	{
		client=listener.AcceptTcpClient();
		//Ȼ������ʲô�㲥�������������һ������
	}

	public int Client(string address,int port)
	{
		IPEndPoint remotePoint=new IPEndPoint(IPAdress.Parse(address),port);
		client=new TcpClient();
		client.Connect(remotePoint);

		//Ȼ��Ӧ�ü���Ƿ�ɹ������ӵ��˶Է�
		return 0;
	}

	public int CloseLink()
	{
		if(client!=null)
			client.close();
		client=null;
	}



	public void SendMessage()
	{
		if(client==null)return;
	}

	public void RecvMessage()
	{
		if(client==null)return;
	}
}