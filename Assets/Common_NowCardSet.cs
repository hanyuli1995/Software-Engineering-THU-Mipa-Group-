using UnityEngine;
using System.Collections;

using System.IO;

//NowCardSet:�����ͼ佻���������ݵĹ����ࡣֱ�Ӳ��þ�̬�ࡣ

public class Common_NowCardSet {
    static string FileName;
    static public void LoadCardFile(string inputFile)
    {
        FileName = inputFile;
        StreamReader sr = new StreamReader(FileName, System.Text.Encoding.Default);
        string line;
        Length = 0;
        line = sr.ReadLine();
        Length=int.Parse(line);
        for(int i=0;i<Length;i++)
        {
            CardSet[Length] = int.Parse(line);
            
        }

    }
    static public void SaveCardFile()//����Ҫ���֣��Զ����ü��ɶ�ȡ���ļ������ɡ�
    {
        FileStream fs = new FileStream(FileName, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        //��ʼд��
        sw.WriteLine(Length.ToString());
        for (int i = 0; i < Length; i++)
        {
            sw.WriteLine(CardSet[i].ToString());
        }
        //��ջ�����
        sw.Flush();
        //�ر���
        sw.Close();
        fs.Close();
    }
    public static int[] CardSet;//����
    public static int Length;//���鳤��
	public static int[] CardSet_op;
	public static int Length_op;

}

