using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;


//Netlink����ֱ�ӵش�����Ϣ��
//��õ��������κ��¼�����ʱ��Զ�˴���һ���ȼ��¼���Ȼ��Զ��ȡ���¼�����Ϊ�ȼ��¼��ó���

public class Netlink
{
	private static TcpListener listener;
    private static TcpClient client;
    private static NetworkStream netStream;
    private static StreamReader reader;
    //private static StreamWriter writer;

    public static int id;
    public static bool shutdown;

    public static int Host(int port)
    {
        listener = new TcpListener(port);
        listener.Start(10);
        client = listener.AcceptTcpClient();
        //Debug.Log("OK Accept");
        netStream = client.GetStream();
        reader = new StreamReader(netStream);
        //writer = new StreamWriter(netStream);
        id = 0;
        //Debug.Log("OK Stream");
        //һ���������ӣ�������ɵĹ�����1��������������ӣ�2������˫������

        //�������������
        Common_Random.init();
        int next = Common_Random.random(0, 32767);
        Common_Random.init(next);
        //writer.WriteLine(next.ToString());
        {
            byte[] data = Encoding.ASCII.GetBytes(next.ToString() + "\r\n");
            netStream.Write(data, 0, data.Length);
        }
        //Debug.Log("OK RandomSeed");
        //����˫������
        //writer.WriteLine(Common_NowCardSet.Length.ToString());
        {
            byte[] data = Encoding.ASCII.GetBytes(Common_NowCardSet.Length.ToString() + "\r\n");
            netStream.Write(data, 0, data.Length);
        }

        for (int i = 0; i < Common_NowCardSet.Length; i++)
        {
            //writer.WriteLine(Common_NowCardSet.CardSet[i].ToString());
            {
                byte[] data = Encoding.ASCII.GetBytes(Common_NowCardSet.CardSet[i].ToString() + "\r\n");
                netStream.Write(data, 0, data.Length);
            }
        }
        //Debug.Log("OK WriteInfo");
        Common_NowCardSet.Length_op = int.Parse(reader.ReadLine());
        Common_NowCardSet.CardSet_op = new int[Common_NowCardSet.Length_op];
        for (int i = 0; i < Common_NowCardSet.Length_op; i++)
        {
            Common_NowCardSet.CardSet_op[i] = int.Parse(reader.ReadLine());
        }
        //Debug.Log("OK ReadInfo");
        //Ȼ��Ӧ�ü���Ƿ�ɹ������ӵ��˶Է�
        return 0;
    }

    public static int Client(string address, int port)
	{
		IPEndPoint remotePoint=new IPEndPoint(IPAddress.Parse(address),port);
		client=new TcpClient();
		client.Connect(remotePoint);
        //Debug.Log("Connect");
        netStream = client.GetStream();
        reader = new StreamReader(netStream);
        //writer = new StreamWriter(netStream);
        //Debug.Log("GetStream");
        id = 1;
        //�������������
        int nextRan = int.Parse(reader.ReadLine());
        Common_Random.init(nextRan);
        //Debug.Log("ReadLine!"+nextRan);
        //����˫������
        //writer.WriteLine(Common_NowCardSet.Length.ToString());

        Common_NowCardSet.Length_op = int.Parse(reader.ReadLine());
        //Debug.Log("length_op=" + Common_NowCardSet.Length_op);
        Common_NowCardSet.CardSet_op = new int[Common_NowCardSet.Length_op];
        for (int i = 0; i < Common_NowCardSet.Length_op; i++)
        {
            Common_NowCardSet.CardSet_op[i] = int.Parse(reader.ReadLine());
            //Debug.Log("CardSet_op[i]=" + Common_NowCardSet.CardSet_op[i]);
        }
        {
            byte[] data = Encoding.ASCII.GetBytes(Common_NowCardSet.Length.ToString() + "\r\n");
            netStream.Write(data, 0, data.Length);
        }
        for (int i = 0; i < Common_NowCardSet.Length; i++)
        {
            //writer.WriteLine(Common_NowCardSet.CardSet[i].ToString());
            {
                byte[] data = Encoding.ASCII.GetBytes(Common_NowCardSet.CardSet[i].ToString() + "\r\n");
                netStream.Write(data, 0, data.Length);
            }
        }

		//Ȼ��Ӧ�ü���Ƿ�ɹ������ӵ��˶Է�
		return 0;
	}

    public static int CloseLink()
	{
        if (reader != null)
            reader.Close();
        reader = null;
        /*if (writer != null)
            writer.Close();
        writer = null;*/
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
        //writer.WriteLine(tempmsg.ToString());
        {
            byte[] data = Encoding.ASCII.GetBytes(tempmsg.ToString() + "\r\n");
            netStream.Write(data, 0, data.Length);
        }
	}

    public static void SendMessage(NetMessage inputMessage)
	{
		if(client==null)return;
        //writer.WriteLine(inputMessage.ToString());
        {
            byte[] data = Encoding.ASCII.GetBytes(inputMessage.ToString() + "\r\n");
            netStream.Write(data, 0, data.Length);
        }
	}

    public static NetMessage RecvMessage()
	{
		if(client==null)return null;
        string next = reader.ReadLine();
        return NetMessage.toMSG(next);
	}
}