using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.IO;


//Netlink����ֱ�ӵش�����Ϣ��
//��õ��������κ��¼�����ʱ��Զ�˴���һ���ȼ��¼���Ȼ��Զ��ȡ���¼�����Ϊ�ȼ��¼��ó���

public class Netlink : MonoBehaviour
{
	private static TcpListener listener;
    private static TcpClient client;
    private static NetworkStream netStream;
    private static StreamReader reader;
    private static StreamWriter writer;

    public static int Host(int port)
	{
		listener=new TcpListener(port);
		listener.Start(2);
		client=listener.AcceptTcpClient();
        netStream = client.GetStream();
        reader = new StreamReader(netStream);
        writer = new StreamWriter(netStream);

		//Ȼ��Ӧ�ü���Ƿ�ɹ������ӵ��˶Է�
		return 0;
	}

    public static int Client(string address, int port)
	{
		IPEndPoint remotePoint=new IPEndPoint(IPAddress.Parse(address),port);
		client=new TcpClient();
		client.Connect(remotePoint);
        netStream = client.GetStream();
        reader = new StreamReader(netStream);
        writer = new StreamWriter(netStream);

		//Ȼ��Ӧ�ü���Ƿ�ɹ������ӵ��˶Է�
		return 0;
	}

    public static int CloseLink()
	{
        if (reader != null)
            reader.Close();
        reader = null;
        if (writer != null)
            writer.Close();
        writer = null;
        if (netStream != null)
            netStream.Close();
        netStream = null;

		if(client!=null)
			client.Close();
		client=null;
        if (listener != null)
            listener.Stop();
        listener = null;
        return 0;
	}

    public static void SendMessage(int input, Trigger.TriggerInput inputTrigger)
	{
		if(client==null)return;
        NetMessage tempmsg = NetMessage.toMSG(input, inputTrigger);
        writer.WriteLine(tempmsg.ToString());
	}

    public static void SendMessage(NetMessage inputMessage)
	{
		if(client==null)return;
        writer.WriteLine(inputMessage.ToString());
	}

    public static NetMessage RecvMessage()
	{
		if(client==null)return null;
        string next = reader.ReadLine();
        return NetMessage.toMSG(next);
	}
}