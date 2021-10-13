using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Empties : MonoBehaviour
{
    //공병파트 계산기 관련

    [Header("GameObject")]
    public GameObject empties_calculator;
    
    [Header ("Text")]
    public Text emptiesQuantity;
    public Text emptiesPrice;
    public Text emptiesPrice2;
    public Text emptiesCalculation;

    [Header("Button")]
    public Button num0;
    public Button num1;
    public Button num2;
    public Button num3;
    public Button num4;
    public Button num5;
    public Button num6;
    public Button num7;
    public Button num8;
    public Button num9;
    public Button ok;
    public Button clear;
    public Button backSpace;

    private void Start()
    {
        //버튼을 누르면 계산된 값 변경
        num0.onClick.AddListener(() => emptiesCalculation.text += "0");
        num1.onClick.AddListener(() => emptiesCalculation.text += "1");
        num2.onClick.AddListener(() => emptiesCalculation.text += "2");
        num3.onClick.AddListener(() => emptiesCalculation.text += "3");
        num4.onClick.AddListener(() => emptiesCalculation.text += "4");
        num5.onClick.AddListener(() => emptiesCalculation.text += "5");
        num6.onClick.AddListener(() => emptiesCalculation.text += "6");
        num7.onClick.AddListener(() => emptiesCalculation.text += "7");
        num8.onClick.AddListener(() => emptiesCalculation.text += "8");
        num9.onClick.AddListener(() => emptiesCalculation.text += "9");
        clear.onClick.AddListener(() => emptiesCalculation.text = "");
        backSpace.onClick.AddListener(() => emptiesCalculation.text = emptiesCalculation.text.Substring(emptiesCalculation.text.Length - 1));

        ok.onClick.AddListener(delegate { //ok 버튼 누르면 다른 값들도 변경
            int num = int.Parse(emptiesCalculation.text);
            emptiesQuantity.text = $"-{num}";
            emptiesPrice.text = $"{100 * num}";
            emptiesPrice2.text = $"{100 * num}";
            StageManager.stageManager.Stage740();
            empties_calculator.SetActive(false);
        });
    }

}
