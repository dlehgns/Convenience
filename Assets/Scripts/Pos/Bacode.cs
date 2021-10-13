using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacode : MonoBehaviour
{
    [Header("Reference")]
    public AudioSource bacodeSound;
    public Calculation calculation;

    [Header("other")]
    public GameObject mainScreen;
    public GameObject CalculationScreen;
    public Outline bacodeOutline; // 바코드의 아웃라인 저장

    bool scane; //스캔을 단시간에 여러번 찍히지 않게 방지

    private void OnTriggerEnter(Collider other)
    {
        if (!scane)
        {
            bacodeSound.Play();

            //============스테이지 진행=============//
            StageManager.stageManager.Stage100();
            StageManager.stageManager.Stage110();
            StageManager.stageManager.Stage210();
            StageManager.stageManager.Stage310();
            StageManager.stageManager.Stage410();
            StageManager.stageManager.Stage440();
            StageManager.stageManager.Stage510();
            StageManager.stageManager.Stage630();

            //============아웃라인해제=============//
            other.gameObject.GetComponent<Outline>().enabled = false; // 물건 아웃라인 해제
            bacodeOutline.enabled = false; // 바코드 스캐너 아웃라인 해제

            //============UI 화면 여닫기=============//
            mainScreen.SetActive(false); // 메인화면 닫기
            CalculationScreen.SetActive(true); // 계산화면 열기

            //==바코드에 찍힌 물건의 컴포넌트 접근후 정보 가져와서 calculation에 보내기 ==//
            string name = other.gameObject.GetComponent<Product>().productName; 
            int price = other.gameObject.GetComponent<Product>().ProductPrice;
            calculation.calculations(name, price);

            scane = true;
        }

        if (scane == true)
        {
            StartCoroutine(scanecheck());
        }
    }

    IEnumerator scanecheck() // 한번찍고 3초의 텀을 둠
    {
        yield return new WaitForSeconds(3.0f);
        scane = false;
    }

}
