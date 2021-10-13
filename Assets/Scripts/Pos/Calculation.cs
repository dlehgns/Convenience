using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculation : MonoBehaviour
{
    [Header ("Calculation Impormation")]
    public GameObject[] imageGroups; //�Ѱ�� �̹��� �׷�
    public GameObject[] bulueImages; // ���� �Ķ� �޹�� �̹���
    public Text[] names; // �̸�
    public Text[] quantitys; // ����
    public Text[] unitPrices; // �ܰ�
    public Text[] prices; // ����

    [Header("Sum Text")]
    public Text sumQuantity; // ���� ����
    public Text sumPrice; // ���� ����
    public Text received;

    [Header("CashInput")]
    public Text cashInputText;

    private void Change(string goodsName,int goodsPrice, Text name, Text quantity, Text unitPrice, Text price)
    {
        int tempQuantity = Int32.Parse(quantity.text); //������ ���� ����
        tempQuantity++; // ���� �����ϰ�� ���� ���� ++ (ó���� 0)
        name.text = goodsName; // �̸��� ���� �̸�
        quantity.text = $"{tempQuantity}"; // ������ �ӽ� ����
        unitPrice.text = $"{goodsPrice}"; //�ܰ��� ���ǰ���
        price.text = $"{tempQuantity * goodsPrice}"; //���ݿ� �ӽ� ������ ���ǰ��� ���Ѱ�
    }

    public void calculations(string goodsName, int goodsPrice)
    {
        
        // �ߺ� Ȯ��
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
            // �ߺ��� ������ ���� �Ʒ�ĭ�� �����
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

    public void Sum() // ���� ���� ���� ���� 
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

    public void Reset() // ����
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
