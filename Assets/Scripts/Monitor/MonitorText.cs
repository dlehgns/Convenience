using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;


public class MonitorText : MonoBehaviour
{

    public string quotes;

    [System.Serializable]
    class SaveData
    {
        public string quotes;
    }

    public void SaveText()
    {
        SaveData data = new SaveData();
        data.quotes = quotes;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadText()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            quotes = data.quotes;
        }
    }


    Dictionary<int, string[]> talkData;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(0, new string[]
        { "�ȳ��ϼ���",
          "������ �ùķ����Ϳ� �°��� ȯ���մϴ�",
          "������ ����͸� Ŭ�����ּ���"
        });
        talkData.Add(1, new string[]
        { "�Ǹ��մϴ�",
            "���� ���� ������ �����غ��ڽ��ϴ�",
            "�ȳ����� �����ּ���"
        });
        talkData.Add(2, new string[]
        { "�����մϴ�",
            "���������� �Ϸ��߽��ϴ�"
        });
        talkData.Add(3, new string[]
        { "���ǰ�� ��Ʈ�Դϴ�",
            "ù°�� ������ ������ �ſ�ī��� ����ϴ� ����� ������ڽ��ϴ�",
        });
        talkData.Add(4, new string[]
        { "�����մϴ�",
            "ī������ �Ϸ��߽��ϴ�"
        });
        talkData.Add(5, new string[]
        { "���ǰ�� ��Ʈ�Դϴ�",
            "�̹����� �������� ����ϴ� ����� ������ڽ��ϴ�"
        });
        talkData.Add(6, new string[]
        { "�����մϴ�",
            "���ݰ���� �Ϸ��߽��ϴ�"
        });
        talkData.Add(7, new string[]
        { "���Ǻ��� ��Ʈ�Դϴ�",
            "���ڵ�� �̸� ������ â�� ��� ������ �� �ֽ��ϴ�"
        });
        talkData.Add(8, new string[]
        { "�����մϴ�",
            "���Ǻ����� �Ϸ��߽��ϴ�"
        });
        talkData.Add(9, new string[]
        { "1+1 ��Ʈ�Դϴ�",
            "Ű�������� �߱��ϴ� ���� ������ڽ��ϴ�"
        });
        talkData.Add(10, new string[]
        { "�����մϴ�",
            "1+1�� �Ϸ��߽��ϴ�"
        });
        talkData.Add(11, new string[]
        { "�޽�ī�� ��Ʈ�Դϴ�",
            "�޽�ī��� ����ϴ¹��� �˾ƺ��ڽ��ϴ�"
        });
        talkData.Add(12, new string[]
        { "�����մϴ�",
            "�޽�ī�带 �Ϸ��߽��ϴ�"
        });
        talkData.Add(13, new string[]
        { "������� ��� ��Ʈ�Դϴ�",
            "��������� ���� ��ǰ�� ����ϴ� ����� �˾ƺ��ڽ��ϴ�"
        });
        talkData.Add(14, new string[]
        { "�����մϴ�",
            "������� ��⸦ �Ϸ��߽��ϴ�"
        });
        talkData.Add(15, new string[]
        { "������� ��Ʈ�Դϴ�",
            "������ ����ϴ¹��� �˾ƺ��ڽ��ϴ�"
        });
        talkData.Add(16, new string[]
        { "�����մϴ�",
           "��� é�Ͱ� �������ϴ� �����մϴ�"
        });

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    
}
