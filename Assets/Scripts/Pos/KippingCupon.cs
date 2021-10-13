using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KippingCupon : MonoBehaviour
{
    //키핑쿠폰에서 + - 버튼 누르면 수량 변경

    public Text keepNumText; // 키핑쿠폰 제품 수량 텍스트

    public Button plus;
    public Button minuse;

    int keepNum = 1; // 키핑쿠폰 제품 수량

    private void Start()
    {
        plus.onClick.AddListener(delegate { //플러스 버튼 누르면 값++ 하고 문자에 반영
            keepNum++;
            keepNumText.text = $"{keepNum}";
        });

        plus.onClick.AddListener(delegate { //마이너스 버튼 누르면 값-- 하고 문자에 반영 0보다작으면 0으로 변경
            keepNum--;
            if (keepNum < 0)
            { keepNum = 0; }
            keepNumText.text = $"{keepNum}";
        });
    }

}
