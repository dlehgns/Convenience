using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tense : MonoBehaviour // ������� ����
{
    [Header ("Buttons")] // ��ư ��ǲ��� ����
    public Button[] tenseButton;

    [Header("Images")] // �ʷϻ����� �����Ǵ� �̹���
    public GameObject[] tenseObject;

    [Header("Texts")] // ������ �� �ؽ�Ʈ
    public Text walkerText;
    public Text[] tenseText;

    [Header("PriceTexts")] // �ݾ��� ������ �ؽ�Ʈ
    public Text[] tenseTextPrice;

    [Header("SumText")]
    public Text sumText;
    private int sumValue;

    void OnEnable() // ������ ������ư�� �̺�Ʈ�� ����
    {
        PosButton.OnButtonNumber += this.NumberInput;
    }

    void OnDisable() // ������ ������ư�� �̺�Ʈ���� ����
    {
        PosButton.OnButtonNumber -= this.NumberInput;
    }

    void Start()
    {
        for (int i = 0; i < tenseButton.Length-1; i++) //������ ������Ʈ ���� �ش� ������Ʈ �ѱ�
        {
            int num = i; //�׳� ���� ������ ��� ���� �� ������ ������ �ʱ�ȭ �Ǳ� ������ �̷��� ����� ��ư�� ���ٽ� ������ Ŭ���� ���� ����
            tenseButton[num].onClick.AddListener(() => { OffObject(); tenseObject[num].SetActive(true); });
        }
        //�������� ����
        tenseButton[0].onClick.AddListener(() => StageManager.stageManager.Stage5());
        tenseButton[2].onClick.AddListener(() => StageManager.stageManager.Stage7());
        tenseButton[3].onClick.AddListener(() => StageManager.stageManager.Stage9());
        tenseButton[5].onClick.AddListener(() => StageManager.stageManager.Stage11());
    }

    void OffObject() //������ ������Ʈ �ѹ��� ����
    {
        for (int i = 0; i < tenseObject.Length; i++)
        {
            tenseObject[i].SetActive(false);
        }
    }

    void NumberInput() // �����ִ� �Է�â�� ����
    {
        if (tenseObject[0].activeSelf)
        { Change(walkerText); }
        else if (tenseObject[1].activeSelf)
        { Change(tenseText[0]); }
        else if (tenseObject[2].activeSelf)
        { Change(tenseText[1]); }
        else if (tenseObject[3].activeSelf)
        { Change(tenseText[2]); }
        else if (tenseObject[4].activeSelf)
        { Change(tenseText[3]); }
        else if (tenseObject[5].activeSelf)
        { Change(tenseText[4]); }
        else if (tenseObject[6].activeSelf)
        { Change(tenseText[5]); }
        else if (tenseObject[7].activeSelf)
        { Change(tenseText[6]); }
        else if (tenseObject[8].activeSelf)
        { Change(tenseText[7]); }
    }

    void Change(Text changeText) // ���� �Է�
    {
        if (PosButton.buttonNum == "clear") // ���ڿ� ���°�ó�� ���̰�
        {
            changeText.text = "";
        }
        else if (PosButton.buttonNum == "back") // ���ڿ� ��ó������ -1 �� ŭ
        {
            changeText.text.Substring(changeText.text.Length - 1);
        }
        else if (PosButton.buttonNum == "10000") // ���ڿ� 10000���� ����
        {
            changeText.text = "10000";
        }
        else // ���ڿ��� �ش� ���� �߰�
        {
            changeText.text += PosButton.buttonNum;
        }
        Changed();
    }

    void Changed() // text�� ���� int�� ��ȯ�Ǵ����� Ȯ���� ��ȯ *����������
    {
        int n = 0; // ��Ʈ������ Ȯ���ϱ� ���� ����
        sumValue = 0; // �� ���� ��

        int[] num = { 50000, 10000, 5000, 1000, 500, 100, 50, 10 };

        for (int i = 0; i < tenseText.Length; i++)
        {
            if (Int32.TryParse(tenseText[i].text, out n))
            {
                tenseTextPrice[i].text = $"{int.Parse(tenseText[i].text) * num[i]}";
                sumValue += int.Parse(tenseText[i].text) * num[i];
            }
        }

        sumText.text = $"{sumValue}";
    }
}
