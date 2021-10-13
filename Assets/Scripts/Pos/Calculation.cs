using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculation : MonoBehaviour
{
    [Header ("Calculation Impormation")]
    public GameObject[] imageGroups; //켜고끌 이미지 그룹
    public GameObject[] bulueImages; // 옅은 파랑 뒷배경 이미지
    public Text[] names; // 이름
    public Text[] quantitys; // 수량
    public Text[] unitPrices; // 단가
    public Text[] prices; // 가격

    [Header("Sum Text")]
    public Text sumQuantity; // 수량 총합
    public Text sumPrice; // 가격 총합
    public Text received;

    [Header("CashInput")]
    public Text cashInputText;

    private void Change(string goodsName,int goodsPrice, Text name, Text quantity, Text unitPrice, Text price)
    {
        int tempQuantity = Int32.Parse(quantity.text); //기존의 수량 구함
        tempQuantity++; // 같은 물건일경우 기존 수량 ++ (처음엔 0)
        name.text = goodsName; // 이름에 물건 이름
        quantity.text = $"{tempQuantity}"; // 수량에 임시 수량
        unitPrice.text = $"{goodsPrice}"; //단가에 물건가격
        price.text = $"{tempQuantity * goodsPrice}"; //가격에 임시 수량과 물건가격 곱한값
    }

    public void calculations(string goodsName, int goodsPrice)
    {
        
        // 중복 확인
        if (goodsName == names[0].text)
        { Change(goodsName, goodsPrice, names[0], quantitys[0], unitPrices[0], prices[0]); }
        else if (goodsName == names[1].text)
        { Change(goodsName, goodsPrice, names[1], quantitys[1], unitPrices[1], prices[1]); }
        else if (goodsName == names[2].text)
        { Change(goodsName, goodsPrice, names[2], quantitys[2], unitPrices[2], prices[2]); }
        else if (goodsName == names[3].text)
        { Change(goodsName, goodsPrice, names[3], quantitys[3], unitPrices[3], prices[3]); }
        else if (goodsName == names[4].text)
        { Change(goodsName, goodsPrice, names[4], quantitys[4], unitPrices[4], prices[4]); }
        else
        {
            // 중복이 없으면 새로 아래칸에 만들기
            if (names[0].text == "")
            {
                bulueImages[0].SetActive(true);
                Change(goodsName, goodsPrice, names[0], quantitys[0], unitPrices[0], prices[0]);
            }
            else if (names[1].text == "")
            {
                imageGroups[1].SetActive(true);
                bulueImages[0].SetActive(false);
                bulueImages[1].SetActive(true);
                Change(goodsName, goodsPrice, names[1], quantitys[1], unitPrices[1], prices[1]);
            }
            else if (names[2].text == "")
            {
                imageGroups[2].SetActive(true);
                bulueImages[1].SetActive(false);
                bulueImages[2].SetActive(true);
                Change(goodsName, goodsPrice, names[2], quantitys[2], unitPrices[2], prices[2]);
            }
            else if (names[3].text == "")
            {
                imageGroups[3].SetActive(true);
                bulueImages[2].SetActive(false);
                bulueImages[3].SetActive(true);
                Change(goodsName, goodsPrice, names[3], quantitys[3], unitPrices[3], prices[3]);
            }
            else if (names[4].text == "")
            {
                imageGroups[4].SetActive(true);
                bulueImages[3].SetActive(false);
                bulueImages[4].SetActive(true);
                Change(goodsName, goodsPrice, names[4], quantitys[4], unitPrices[4], prices[4]);
            }
        }
        Sum();
    }

    public void Sum() // 물건 수량 가격 총합 
    {
        sumQuantity.text = "";
        sumPrice.text = "";

        int tempQuantity = 0;
        int tempPrice = 0;

        if (imageGroups[0].activeSelf)
        {
            tempQuantity += Int32.Parse(quantitys[0].text);
            tempPrice += Int32.Parse(prices[0].text);
        }
        if (imageGroups[1].activeSelf)
        {
            tempQuantity += Int32.Parse(quantitys[1].text);
            tempPrice += Int32.Parse(prices[1].text);
        }
        if (imageGroups[2].activeSelf)
        {
            tempQuantity += Int32.Parse(quantitys[2].text);
            tempPrice += Int32.Parse(prices[2].text);
        }
        if (imageGroups[3].activeSelf)
        {
            tempQuantity += Int32.Parse(quantitys[3].text);
            tempPrice += Int32.Parse(prices[3].text);
        }
        if (imageGroups[4].activeSelf)
        {
            tempQuantity += Int32.Parse(quantitys[4].text);
            tempPrice += Int32.Parse(prices[4].text);
        }

        sumQuantity.text = $"{tempQuantity}";
        sumPrice.text = $"{tempPrice}";
        received.text = sumPrice.text;
    }

    public void Reset() // 리셋
    {
        for (int i = 0; i < 5; i++)
        {
            names[i].text = "";
            quantitys[i].text = "0";
            unitPrices[i].text = "0";
            prices[i].text = "0";
            bulueImages[i].SetActive(false);
        }

    }

}
