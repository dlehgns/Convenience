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
        { "안녕하세요",
          "편의점 시뮬레이터에 온것을 환영합니다",
          "포스기 모니터를 클릭해주세요"
        });
        talkData.Add(1, new string[]
        { "훌륭합니다",
            "이제 시제 점검을 시작해보겠습니다",
            "안내문을 따라주세요"
        });
        talkData.Add(2, new string[]
        { "축하합니다",
            "시제점검을 완료했습니다"
        });
        talkData.Add(3, new string[]
        { "물건계산 파트입니다",
            "첫째로 편의점 물건을 신용카드로 계산하는 방법을 배워보겠습니다",
        });
        talkData.Add(4, new string[]
        { "축하합니다",
            "카드계산을 완료했습니다"
        });
        talkData.Add(5, new string[]
        { "물건계산 파트입니다",
            "이번에는 현금으로 계산하는 방법을 배워보겠습니다"
        });
        talkData.Add(6, new string[]
        { "축하합니다",
            "현금계산을 완료했습니다"
        });
        talkData.Add(7, new string[]
        { "물건보류 파트입니다",
            "바코드로 미리 찍어놓은 창을 잠시 보류할 수 있습니다"
        });
        talkData.Add(8, new string[]
        { "축하합니다",
            "물건보류를 완료했습니다"
        });
        talkData.Add(9, new string[]
        { "1+1 파트입니다",
            "키핑쿠폰을 발급하는 법을 배워보겠습니다"
        });
        talkData.Add(10, new string[]
        { "축하합니다",
            "1+1을 완료했습니다"
        });
        talkData.Add(11, new string[]
        { "급식카드 파트입니다",
            "급식카드로 계산하는법을 알아보겠습니다"
        });
        talkData.Add(12, new string[]
        { "축하합니다",
            "급식카드를 완료했습니다"
        });
        talkData.Add(13, new string[]
        { "유통기한 폐기 파트입니다",
            "유통기한이 지난 식품을 폐기하는 방법을 알아보겠습니다"
        });
        talkData.Add(14, new string[]
        { "축하합니다",
            "유통기한 폐기를 완료했습니다"
        });
        talkData.Add(15, new string[]
        { "공병계산 파트입니다",
            "공병을 계산하는법을 알아보겠습니다"
        });
        talkData.Add(16, new string[]
        { "축하합니다",
           "모든 챕터가 끝났습니다 감사합니다"
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
