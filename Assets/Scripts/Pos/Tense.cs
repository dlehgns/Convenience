using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tense : MonoBehaviour // 시제계산 구현
{
    [Header ("Buttons")] // 버튼 인풋기능 구현
    public Button[] tenseButton;

    [Header("Images")] // 초록색으로 강조되는 이미지
    public GameObject[] tenseObject;

    [Header("Texts")] // 갯수가 들어갈 텍스트
    public Text walkerText;
    public Text[] tenseText;

    [Header("PriceTexts")] // 금액이 곱해질 텍스트
    public Text[] tenseTextPrice;

    [Header("SumText")]
    public Text sumText;
    private int sumValue;

    void OnEnable() // 켜질때 포스버튼의 이벤트에 연결
    {
        PosButton.OnButtonNumber += this.NumberInput;
    }

    void OnDisable() // 꺼질때 포스버튼의 이벤트에서 해제
    {
        PosButton.OnButtonNumber -= this.NumberInput;
    }

    void Start()
    {
        for (int i = 0; i < tenseButton.Length-1; i++) //나머지 오브젝트 끄고 해당 오브젝트 켜기
        {
            int num = i; //그냥 값을 넣으면 모든 값이 맨 마지막 값으로 초기화 되기 때문에 이렇게 만든다 버튼에 람다식 넣을때 클로저 문제 에러
            tenseButton[num].onClick.AddListener(() => { OffObject(); tenseObject[num].SetActive(true); });
        }
        //스테이지 진행
        tenseButton[0].onClick.AddListener(() => StageManager.stageManager.Stage5());
        tenseButton[2].onClick.AddListener(() => StageManager.stageManager.Stage7());
        tenseButton[3].onClick.AddListener(() => StageManager.stageManager.Stage9());
        tenseButton[5].onClick.AddListener(() => StageManager.stageManager.Stage11());
    }

    void OffObject() //나머지 오브젝트 한번에 끄기
    {
        for (int i = 0; i < tenseObject.Length; i++)
        {
            tenseObject[i].SetActive(false);
        }
    }

    void NumberInput() // 켜져있는 입력창을 구분
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

    void Change(Text changeText) // 숫자 입력
    {
        if (PosButton.buttonNum == "clear") // 문자열 없는것처럼 보이게
        {
            changeText.text = "";
        }
        else if (PosButton.buttonNum == "back") // 문자열 맨처음에서 -1 만 큼
        {
            changeText.text.Substring(changeText.text.Length - 1);
        }
        else if (PosButton.buttonNum == "10000") // 문자열 10000으로 변경
        {
            changeText.text = "10000";
        }
        else // 문자열에 해당 숫자 추가
        {
            changeText.text += PosButton.buttonNum;
        }
        Changed();
    }

    void Changed() // text의 값이 int로 변환되는지를 확인후 변환 *에러방지용
    {
        int n = 0; // 인트값인지 확인하기 위한 변수
        sumValue = 0; // 총 더한 값

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
