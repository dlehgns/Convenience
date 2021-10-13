using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageManager : MonoBehaviour
{
    public static StageManager stageManager { get; private set; }

    private void Awake()
    { stageManager = this; }

    [HideInInspector]public int stageCount;

    [Header("ScriptReference")]
    public PosButton posButton;
    public Calculation calculation;
    public Monitor monitor;
    public Fade fade;
    public CustomerAI customer1;
    public CustomerAI customer2;
    public ChildAI child;
    public CashBox cashBox;
    public SpawnManager spawnManager;
    public UiManager uiManager;
    public CardLeader cardLeader;

    [Header("Text")]
    public Text indicationText;
    public Text customerText;
    public Text markText;

    [Header("PosUI")]
    public GameObject onScreen;
    public GameObject offScreen;
    public GameObject uiCanvas;
    public GameObject mainScreen;
    public GameObject integratedInquiryScreen;
    public GameObject serviceScreen;
    public GameObject checkScreen;
    public GameObject tenseScreen;
    public GameObject calculationScreen;
    public GameObject calculation2Screen;
    public GameObject calculation3Screen;
    public GameObject discardScreen;
    public GameObject creditcardrefundScreen;
    public GameObject cashrefundScreen;
    public GameObject cashCalculationScreen;
    public GameObject selectionScreen;
    public GameObject kippingScanScreen;
    public GameObject kippingCuponScreen;
    public GameObject kidsCard1Screen;
    public GameObject kidsCard2Screen;
    public GameObject emptiesScreen;

    [Header("PosUIDetails")] //kidcard2 �ȿ�����
    public GameObject cardNameText;
    public GameObject cardNumText;

    [Header("PosParticle")]
    public GameObject calculationParticle;
    public GameObject calculation2Particle;
    public GameObject cashCalculationParticle;
    public GameObject checkParticle;
    public GameObject emptiesParticle1;
    public GameObject emptiesParticle2;
    public GameObject emptiesParticle3;
    public GameObject emptiesParticle4;
    public GameObject kidsCard1Particle;
    public GameObject kidsCard2Particle;
    public GameObject kippingCuponParticle;
    public GameObject selectionParticleCard;
    public GameObject selectionParticleKipping;
    public GameObject tenseParticle;
    public GameObject tenseParticle1;
    public GameObject tenseParticle2;
    public GameObject tenseParticle3;
    public GameObject tenseParticle4;

    [Header("Game Object")]
    public GameObject fadeCanvas;
    public GameObject arrow;
    public GameObject bacode;
    public GameObject smartPhone;
    public GameObject cardReturn;
    public GameObject cardleaderPoint;
    public GameObject firecracker;
    public GameObject soju;
    public GameObject customerObject;
    public GameObject customer2Object;
    public GameObject childObject;
    public GameObject customerUi;

    [Header("Position")]
    public Transform bacodeposition;

    [Header("Outline")]
    public Outline[] money5000;
    public Outline money10000;

    [HideInInspector]
    public GameObject tmpproduct;
    [HideInInspector]
    public GameObject tmpcard;

    void UiReset()
    {
    uiCanvas.SetActive(true);
    mainScreen.SetActive(false);
    integratedInquiryScreen.SetActive(false);
    serviceScreen.SetActive(false);
    checkScreen.SetActive(false);
    tenseScreen.SetActive(false);
    calculationScreen.SetActive(false);
    calculation2Screen.SetActive(false);
    calculation3Screen.SetActive(false);
    discardScreen.SetActive(false);
    creditcardrefundScreen.SetActive(false);
    cashrefundScreen.SetActive(false);
    cashCalculationScreen.SetActive(false);
    selectionScreen.SetActive(false);
    kippingScanScreen.SetActive(false);
    kippingCuponScreen.SetActive(false);
    kidsCard1Screen.SetActive(false);
    kidsCard2Screen.SetActive(false);
    emptiesScreen.SetActive(false);
    }


    private void ChapterStart()
    {
        onScreen.SetActive(true);
        offScreen.SetActive(false);
        UiReset();
        indicationText.text = "";
    }


    void Start()
    {
        fade.FadeOut();
        stageCount = MainManager.mainManager.stageNum;
        ChapterStarted();
        SelectLevel();
        monitor.MonitorDown();
    }

    public void ChapterStarted()
    {
        Stage100();
        Stage200();
        Stage300();
        Stage400();
        Stage500();
        Stage600();
        Stage700();
    }

    void NextWait()
    {
        fade.FadeInOut();
    }

    public void SelectLevel()
    {
        switch (stageCount)
        {
            case 0:
                stage0();
                break;
            case 100:
                Stage101();
                break;
            case 200:
                Stage201();
                break;
            case 300:
                Stage301();
                break;
            case 400:
                Stage401();
                break;
            case 500:
                Stage501();
                break;
            case 600:
                Stage601();
                break;
            case 700:
                Stage701();
                break;
        }
    }

    private void Delay(int Num)
    {
        StartCoroutine(Delay1(Num));
    }
    IEnumerator Delay1(int Num)
    {
        if (Num == 7)
        {
            customer2.Pickup();
            yield return new WaitForSeconds(0.5f * Time.deltaTime);
            smartPhone.SetActive(true);
        }
        if (Num == 10)
        {
            child.PickUp();
            yield return new WaitForSeconds(0.5f * Time.deltaTime);
            spawnManager.productsSpawn();
            tmpproduct = GameObject.FindWithTag("TempProduct");
            tmpproduct.GetComponent<Outline>().enabled = true;
            bacode.GetComponent<Outline>().enabled = true;
        }
        if (Num == 11)
        {
            child.PickUp();
            yield return new WaitForSeconds(0.5f * Time.deltaTime);
            spawnManager.ResetTrafficCard();
        }
        if (Num == 12)
        {
            child.PickUp();
            yield return new WaitForSeconds(0.5f * Time.deltaTime);
            tmpproduct = GameObject.FindWithTag("TempProduct");
            Destroy(tmpproduct);
            tmpcard = GameObject.FindWithTag("RECIVECREDITCARD");
            Destroy(tmpcard);
        }
    }


    public void stage0()
    {
        if (stageCount == 0)
        {
            uiCanvas.SetActive(false);
            fadeCanvas.SetActive(true);
            fade.FadeOut();
            monitor.Talk(0);
            markText.text = "Ʃ�丮��";
            stageCount = 1;
        }
    }

    public void Stage1()
    {
        if (stageCount == 1)
        {
            fadeCanvas.SetActive(false);
            arrow.SetActive(true);
            stageCount = 2;
        }
    }

    public void Stage2() // ������ ȭ�� Ŭ��
    {
        if (stageCount == 2)
        {
            monitor.Talk(1);
            arrow.SetActive(false);
            firecracker.SetActive(true);
            stageCount = 3;
        }
    }

    public void Stage3()
    {
        if (stageCount == 3)
        {
            
            indicationText.text = "�μ��ΰ� ��ư�� Ŭ�����ּ���";
            firecracker.SetActive(false);
            arrow.transform.position = new Vector3(-14.249f, 12.48f, -39.029f);
            posButton.takingOverParticle.SetActive(true);
            markText.text = "�μ��ΰ�";
            stageCount = 4;
        }
    }

    public void Stage4()
    {
        if (stageCount == 4)
        {
            
            indicationText.text = "�űԱٹ���ĭ�� Ŭ�����ּ���";
            firecracker.SetActive(false);
            arrow.SetActive(false);
            posButton.takingOverParticle.SetActive(false);
            cashBox.CashBoxOpen();

            tenseParticle1.SetActive(true);
            stageCount = 5;
        }
    }
    public void Stage5()
    {
        if (stageCount == 5)
        {
            
            indicationText.text = "�ٹ��� ��ȣ�� �Է����ּ���";
            tenseParticle1.SetActive(false);
            posButton.num1Particle.SetActive(true);

            stageCount = 6;
        }
    }

    public void Stage6()
    {
        if (stageCount == 6)
        {
            indicationText.text = "10000��ĭ�� Ŭ�����ּ���";
            posButton.num1Particle.SetActive(false);
            tenseParticle2.SetActive(true);
            stageCount = 7;
        }
    }

    public void Stage7()
    {
        if (stageCount == 7)
        {
            indicationText.text = "�����⿡ �ִ� ������ �Է����ּ���";
            money10000.enabled = true;
            tenseParticle2.SetActive(false);
            posButton.num1Particle.SetActive(true);
            stageCount = 8;
        }
    }

    public void Stage8()
    {
        if (stageCount == 8)
        {
            indicationText.text = "5000��ĭ�� Ŭ�����ּ���";
            money10000.enabled = false;
            posButton.num1Particle.SetActive(false);
            tenseParticle3.SetActive(true);
            stageCount = 9;
        }
    }

    public void Stage9()
    {
        if (stageCount == 9)
        {
            
            indicationText.text = "�����⿡ �ִ� ������ �Է����ּ���";
            for (int i = 0; i < money5000.Length; i++)
            { money5000[i].enabled = true; }
            
            tenseParticle3.SetActive(false);
            posButton.num4Particle.SetActive(true);
            stageCount = 10;
        }
    }

    public void Stage10()
    {
        if (stageCount == 10)
        {
            
            indicationText.text = "500��ĭ�� Ŭ�����ּ���";
            for (int i = 0; i < money5000.Length; i++)
            { money5000[i].enabled = false; }
            posButton.num4Particle.SetActive(false);
            tenseParticle4.SetActive(true);
            stageCount = 11;
        }
    }
    public void Stage11()
    {
        if (stageCount == 11)
        {
            
            indicationText.text = "�����⿡ �ִ� ������ �Է����ּ���";
            tenseParticle4.SetActive(false);
            posButton.num7Particle.SetActive(true);
            stageCount = 12;
        }
    }

    public void Stage12()
    {
        if (stageCount == 12)
        {
            
            indicationText.text = "����� Ŭ�����ּ���";
            posButton.num7Particle.SetActive(false);
            tenseParticle.SetActive(true);
            stageCount = 98;
        }
    }

    public void Stage98()
    {
        if (stageCount == 98)
        {
            
            indicationText.text = "";
            monitor.MonitorDown();
            monitor.Talk(2);
            firecracker.SetActive(true);

            cashBox.CashBoxClose();
            tenseParticle.SetActive(false);

            stageCount = 99;
        }
    }

    public void Stage99()
    {
        if (stageCount == 99)
        {
            
            fadeCanvas.SetActive(true);
            NextWait();

            stageCount = 100;
        }
    }

    public void Stage100()// ���ǰ�� ����
    {
        if (stageCount == 100)
        {
            ChapterStart();
            
            monitor.Talk(3);
            customerObject.SetActive(true);
            firecracker.SetActive(false);
            markText.text = "ī����";
            indicationText.text = "��� �մ��� ��ٷ� �ּ���";

            stageCount = 101;
        }
    }

    public void Stage101() 
    {
        if (stageCount == 101)
        {
            fadeCanvas.SetActive(false);
            
            
            stageCount = 103;
        }
    }

    public void stage103()
    {
        if(stageCount == 103)
        stageCount = 105;
        Invoke("Stage105", 2.0f);
    }
    

    public void Stage105()
    {
        if (stageCount == 105)
        {
            
            indicationText.text = "���ڵ带 ��� ���ǿ� ���ڵ带 ��� �ּ���";

            customerUi.SetActive(true);
            customer1.BananaDrop();

            stageCount = 110;
        }
    }



    public void Stage110()
    {
        if (stageCount == 110)
        {
            
            indicationText.text = "ī�带 ī�帮���⿡ �Ⱦ� �ּ���";
            customerUi.SetActive(false);

            customer1.CardDrop();

            arrow.transform.position = new Vector3(-1.739f, 1.1235f, -3.8678f);
            arrow.SetActive(true);

            stageCount = 120;
        }
    }
    public void Stage120()
    {
        if (stageCount == 120)
        {
            
            indicationText.text = "�ſ��Ͻú� ��ư�� ���� �ּ���";
            cardLeader.CardIn();
            arrow.SetActive(false);
            posButton.creditParticle.SetActive(true);
            stageCount = 130;
        }
    }
    public void Stage130()
    {
        if (stageCount == 130)
        {
            
            indicationText.text = "Ȯ���� ���� �ּ���";
            arrow.SetActive(false);
            posButton.creditParticle.SetActive(false);
            calculation2Particle.SetActive(true);
            stageCount = 140;
        }
    }
    public void Stage140() // Ȯ�� ��ư Ŭ��
    {
        if (stageCount == 140)
        {
            
            indicationText.text = "ī�带 �մԿ��� �ݳ����ּ���";
            cardleaderPoint.SetActive(false);

            cardLeader.CardOut();

            cardReturn.SetActive(true);

            calculation2Particle.SetActive(false);
            stageCount = 150;
        }
    }
    public void Stage150()
    {
        if (stageCount == 150)
        {
            
            indicationText.text = "����Ű ��ư�� �����ּ���";
            customer1.Exit();
            cardReturn.SetActive(false);
            posButton.youngManParticle.SetActive(true);
            stageCount = 198;
        }
    }

    public void Stage198()
    {
        if (stageCount == 198)
        {
            
            indicationText.text = "";
            monitor.MonitorDown();
            monitor.Talk(4);
            firecracker.SetActive(true);

            posButton.youngManParticle.SetActive(false);
            calculation3Screen.SetActive(false);
            mainScreen.SetActive(false);

            stageCount = 199;
        }


    }

    public void Stage199()// ���� ī�� ��� �Ϸ�
    {
        if (stageCount == 199)
        {
            
            fadeCanvas.SetActive(true);

            calculation3Screen.SetActive(false);
            tmpproduct = GameObject.FindWithTag("TempProduct");
            Destroy(tmpproduct);

            calculation.Reset();

            NextWait();
            stageCount = 200;
        }
    }

    public void Stage200()// ���� ���� ���
    {
        if (stageCount == 200)
        {
            ChapterStart();

            monitor.Talk(5);
            customerObject.SetActive(false);
            customer2Object.SetActive(true);
            firecracker.SetActive(false);
            markText.text = "���ݰ��";

            bacode.transform.position = bacodeposition.position;
            stageCount = 201;
        }
    }
    public void Stage201()
    {
        if (stageCount == 201)
        {
            fadeCanvas.SetActive(false);
            
            indicationText.text = "";


            stageCount = 205;
            Invoke("Stage205", 2.0f);
        }
    }

    public void Stage205()
    {
        if (stageCount == 205)
        {
            fadeCanvas.SetActive(false);
            
            indicationText.text = "���ڵ�� ������ ����ּ���";

            customerUi.SetActive(true);
            customer2.BananaDrop();

            stageCount = 210;
        }
    }

    public void Stage210()
    {
        if (stageCount == 210)
        {
            
            indicationText.text = "�մ����� ������ �޾��ּ���";
            customerUi.SetActive(false);
            customer2.CashDrop();
            cashBox.CashBoxOpen();

            stageCount = 211;
        }
    }

    public void Stage211()
    {
        if (stageCount == 211)
        {
            
            indicationText.text = "�ݾ� 1�� �Է����ּ���";
            cashBox.CashBoxClose();
            posButton.num1Particle.SetActive(true);

            stageCount = 212;
        }
    }

    public void Stage212()
    {
        if (stageCount == 212)
        {
            indicationText.text = "00�� �Է����ּ���";
            posButton.num1Particle.SetActive(false);
            posButton.num00Particle.SetActive(true);
            calculation.cashInputText.text = "1";
            stageCount = 213;
        }
    }

    public void Stage213()
    {
        if (stageCount == 213)
        {
            
            indicationText.text = "�ѹ� �� �Է����ּ���";

            posButton.num00Particle.SetActive(true);
            calculation.cashInputText.text = "100";

            stageCount = 214;
        }
    }

    public void Stage214()
    {
        if (stageCount == 214)
        {
            
            indicationText.text = "����Ű�� �Է����ּ���";
            calculation.cashInputText.text = "10000";
            posButton.num00Particle.SetActive(false);
            posButton.youngManParticle.SetActive(true);
            stageCount = 220;
        }
    }

    public void Stage220()
    {
        if (stageCount == 220)
        {
            
            indicationText.text = "�ƴϿ並 �����ּ���";
            cashCalculationScreen.SetActive(true);
            calculationScreen.SetActive(false);
            posButton.youngManParticle.SetActive(false);
            cashCalculationParticle.SetActive(true);
            stageCount = 230;
        }
    }
    public void Stage230()
    {
        if (stageCount == 230)
        {
            
            indicationText.text = "�Ž������� ���� �մԿ��� �ּ���";
            cashCalculationScreen.SetActive(false);
            mainScreen.SetActive(true);
            cashBox.CashBoxOpen();
            money5000[2].enabled = true;
            cardReturn.SetActive(true);
            cashCalculationParticle.SetActive(false);
            stageCount = 298;
        }
    }
    public void Stage298()
    {
        if (stageCount == 298)
        {

            cashBox.CashBoxClose();
            indicationText.text = "";
            monitor.MonitorDown();
            monitor.Talk(6);
            firecracker.SetActive(true);

            customer2.ReceiveMoney();

            cardReturn.SetActive(false);

            stageCount = 299;
        }
    }

    public void Stage299()
    {
        if (stageCount == 299)
        {
            
            fadeCanvas.SetActive(true);

            calculation.Reset();
            

            stageCount = 300;
            NextWait();
        }
    }


    public void Stage300()//�����ϱ�
    {
        if (stageCount == 300)
        {
            ChapterStart();

            monitor.Talk(7);
            customer2Object.SetActive(true);
            firecracker.SetActive(false);
            markText.text = "�����ϱ�";
            bacode.transform.position = bacodeposition.position;

            stageCount = 301;
        }
    }
    public void Stage301()
    {
        if (stageCount == 301)
        {
            fadeCanvas.SetActive(false);
            
            indicationText.text = "";

            stageCount = 305;
            Invoke("Stage305", 2.0f);
        }
    }

    public void Stage305()
    {
        if (stageCount == 305)
        {
            fadeCanvas.SetActive(false);
            
            indicationText.text = "���ڵ带 ����ּ���";

            customer2.BananaDrop();

            customerUi.SetActive(true);
            bacode.GetComponent<Outline>().enabled = true;

            stageCount = 310;
        }
    }

    public void Stage310()
    {
        if (stageCount == 310)
        {
            
            indicationText.text = "�ٷΰ���2�� �����ּ���";
            customerText.text = "����Ŀ� ����Ҳ���";
            customer2.Talk();
            bacode.GetComponent<Outline>().enabled = false;
            posButton.shortcuts2Particle.SetActive(true);

            stageCount = 398;
        }
    }

    public void Stage398()
    {
        if (stageCount == 398)
        {
            
            indicationText.text = "";
            customerUi.SetActive(false);
            posButton.shortcuts2Particle.SetActive(false);
            calculationScreen.SetActive(false);
            mainScreen.SetActive(true);

            monitor.MonitorDown();
            monitor.Talk(8);
            firecracker.SetActive(true);

            stageCount = 399;
        }
    }

    public void Stage399()
    {
        if (stageCount == 399)
        {
            
            fadeCanvas.SetActive(true);

            calculation.Reset();
            tmpproduct = GameObject.FindWithTag("TempProduct");
            Destroy(tmpproduct);

            stageCount = 400;
            NextWait();
        }
    }

    public void Stage400()//1+1 �̺� ȯ���ϱ�
    {
        if (stageCount == 400)
        {
            ChapterStart();

            monitor.Talk(9);
            markText.text = "Ű������ �߱�";
            customer2Object.SetActive(true);
            firecracker.SetActive(false);
            bacode.transform.position = bacodeposition.position;

            stageCount = 401;
        }
    }

    public void Stage401()
    {
        if (stageCount == 401)
        {
            fadeCanvas.SetActive(false);
            
            indicationText.text = "";

            

            stageCount = 405;
            Invoke("Stage405", 2.0f);
        }
    }

    public void Stage405()
    {
        if (stageCount == 405)
        {
            
            indicationText.text = "���ڵ带 ����ּ���";
            calculationParticle.SetActive(true);

            customer2.BananaDrop();
            bacode.GetComponent<Outline>().enabled = true;
            customerUi.SetActive(true);
            customerText.text = "������ּ���";

            stageCount = 410;
        }
    }

    public void Stage410()
    {
        if (stageCount == 410)
        {
            
            indicationText.text = "�������ù�ư�� �����ּ���";
            calculationParticle.SetActive(true);
            customerUi.SetActive(false);


            stageCount = 420;
        }
    }

    public void Stage420()
    {
        if (stageCount == 420)
        {
            
            indicationText.text = "Ű������ �߱� ��ư�� Ŭ�����ּ���";
            calculationParticle.SetActive(false);
            selectionParticleKipping.SetActive(true);

            stageCount = 430;
        }
    }

    public void Stage430()
    {
        if (stageCount == 430)
        {
            
            indicationText.text = "�޴��� ȭ�鿡 ���ڵ带 ����ּ���";

            Delay(7);

            arrow.SetActive(true);
            arrow.transform.position = new Vector3(-2.62f, 1.182f, -3.762f);

            bacode.transform.position = bacodeposition.position;
            bacode.GetComponent<Outline>().enabled = true;
            selectionParticleKipping.SetActive(false);

            

            stageCount = 440;
        }
    }
    public void Stage440()
    {
        if (stageCount == 440)
        {
            
            indicationText.text = "�߱޹�ư�� Ŭ���� �ּ���";
            selectionScreen.SetActive(false);
            kippingScanScreen.SetActive(false);
            smartPhone.SetActive(false);
            kippingCuponScreen.SetActive(true);
            arrow.SetActive(false);

            kippingCuponParticle.SetActive(true); // ��ƼŬ

            stageCount = 450;
        }
    }

    public void Stage450()
    {
        if (stageCount == 450)
        {
            
            indicationText.text = "ī�带 ī�� �����⿡ �Ⱦ��ּ���";

            arrow.transform.position = new Vector3(-1.739f, 1.1235f, -3.8678f);
            arrow.SetActive(true);


            kippingCuponParticle.SetActive(false); // ��ƼŬ

            kippingCuponScreen.SetActive(false);
            selectionScreen.SetActive(true);
            
            cardleaderPoint.SetActive(true);

            customer2.CardDrop();

            stageCount = 460;
        }
    }

    public void Stage460()
    {
        if (stageCount == 460)
        {
            
            indicationText.text = "�ſ��Ͻú� ��ư�� ���� �ּ���";
            arrow.SetActive(false);
            cardLeader.CardIn();

            posButton.creditParticle.SetActive(true);
            cardleaderPoint.SetActive(false);

            stageCount = 470;
        }
    }

    public void Stage470()
    {
        if (stageCount == 470)
        {
            
            indicationText.text = "Ȯ���� ���� �ּ���";
            posButton.creditParticle.SetActive(false);
            selectionScreen.SetActive(false);
            calculation2Screen.SetActive(true);
            calculation2Particle.SetActive(true);
            arrow.SetActive(false);
            stageCount = 480;
        }
    }
    public void Stage480()
    {
        if (stageCount == 480)
        {
            
            indicationText.text = "ī�带 �մԿ��� �ݳ����ּ���";
            cardleaderPoint.SetActive(false);
            cardLeader.CardOut();
            cardReturn.SetActive(true);
            calculation2Particle.SetActive(false);



            stageCount = 490;
        }
    }
    public void Stage490()
    {
        if (stageCount == 490)
        {
            
            indicationText.text = "����Ű ��ư�� �����ּ���";
            cardReturn.SetActive(false);
            posButton.youngManParticle.SetActive(true);
            customer2.ReceiveCard();
            stageCount = 498;
        }
    }

    public void Stage498()
    {
        if (stageCount == 498)
        {
            
            indicationText.text = "";
            cardReturn.SetActive(false);
            posButton.youngManParticle.SetActive(false);
            calculation3Screen.SetActive(false);
            mainScreen.SetActive(true);
            monitor.MonitorDown();
            monitor.Talk(10);
            firecracker.SetActive(true);

            stageCount = 499;
        }
    }


    public void Stage499()
    {
        if (stageCount == 499)
        {
            
            fadeCanvas.SetActive(true);

            calculation.Reset();
            Destroy(tmpproduct);

            NextWait();

            stageCount = 500;
        }
    }



    public void Stage500() //�޽ľƵ�ī�� ����
    {
        if (stageCount == 500)
        {
            ChapterStart();

            monitor.Talk(11);
            indicationText.text = "";
            customer2Object.SetActive(false);
            childObject.SetActive(true);
            firecracker.SetActive(false);
            markText.text = "�޽ľƵ�ī��";

            stageCount = 501;
        }
    }

    public void Stage501()
    {
        if (stageCount == 501)
        {
            fadeCanvas.SetActive(false);
           

            stageCount = 505;
            Invoke("Stage505", 2.0f);
        }
    }

    public void Stage505()
    {
        if (stageCount == 505)
        {
            indicationText.text = "���ڵ带 ����ּ���";

            Delay(10);
            customerUi.SetActive(true);
            customerUi.transform.position = new Vector3(-2.804f, 1.851f, -3.265f);
            customerText.text = "������ּ���";

            bacode.GetComponent<Outline>().enabled = true;
            bacode.transform.position = bacodeposition.position;

            stageCount = 510;
        }
    }



    public void Stage510()
    {
        if (stageCount == 510)
        {
            
            indicationText.text = "�������ù�ư�� �����ּ���";
            calculationParticle.SetActive(true);
            customerUi.SetActive(false);

            stageCount = 520;
        }
    }

    public void Stage520()
    {
        if (stageCount == 520)
        {
            
            indicationText.text = "�޽�ī�� ��ư�� �����ּ���";
            calculationParticle.SetActive(false);
            selectionParticleCard.SetActive(true);

            stageCount = 530;
        }
    }

    public void Stage530()
    {
        if (stageCount == 530)
        {
            
            indicationText.text = "�ش��ϴ� ��ư�� �����ּ���";
            selectionParticleCard.SetActive(false);
            kidsCard1Particle.SetActive(true);
            stageCount = 540;
        }
    }

    public void Stage540()
    {
        if (stageCount == 540)
        {
            
            indicationText.text = "ī�带 ī�� �����⿡ �Ⱦ��ּ���";
            arrow.transform.position = new Vector3(-1.739f, 1.1235f, -3.8678f);
            arrow.SetActive(true);
            kippingCuponScreen.SetActive(false);
            selectionScreen.SetActive(true);

            Delay(11);

            cardleaderPoint.SetActive(true);
            kidsCard1Particle.SetActive(false);

            stageCount = 550;
        }
    }

    public void Stage550()
    {
        if (stageCount == 550)
        {
            
            indicationText.text = "Ȯ���� �����ּ���";
            spawnManager.TrafficCard();
            arrow.SetActive(false);
            cardNameText.SetActive(true);
            cardNumText.SetActive(true);
            kidsCard2Particle.SetActive(true);
            calculation3Screen.SetActive(true);

            stageCount = 560;
        }
    }

    public void Stage560()
    {
        if (stageCount == 560)
        {
            
            indicationText.text = "ī�带 �մԿ��� �ݳ����ּ���";
            cardNameText.SetActive(false);
            cardNumText.SetActive(false);
            kidsCard2Screen.SetActive(false);

            kidsCard2Particle.SetActive(false);

            cardleaderPoint.SetActive(false);
            tmpcard = GameObject.FindWithTag("RECIVECREDITCARD");
            tmpcard.GetComponent<Outline>().enabled = true;
            cardReturn.SetActive(true);

            stageCount = 570;
        }
    }
    public void Stage570()
    {
        if (stageCount == 570)
        {
            
            indicationText.text = "����Ű ��ư�� �����ּ���";
            

            Delay(12);
            cardReturn.SetActive(false);
            posButton.ChildWomanParticle.SetActive(true);

            stageCount = 598;
        }
    }

    public void Stage598()
    {
        if (stageCount == 598)
        {
            
            indicationText.text = "";
            cardReturn.SetActive(false);
            posButton.ChildWomanParticle.SetActive(false);
            calculation3Screen.SetActive(false);
            monitor.MonitorDown();
            monitor.Talk(12);
            firecracker.SetActive(true);

            stageCount = 599;
        }
    }

    public void Stage599()
    {
        if (stageCount == 599)
        {
            
            fadeCanvas.SetActive(true);

            tmpproduct = GameObject.FindWithTag("TempProduct");
            Destroy(tmpproduct);

            stageCount = 600;
            NextWait();
        }
    }



    public void Stage600() //������� ��� ����
    {
        if (stageCount == 600)
        {
            childObject.SetActive(false);
            ChapterStart();
            monitor.Talk(13);
            firecracker.SetActive(false);
            markText.text = "����������";
            bacode.transform.position = bacodeposition.position;
            spawnManager.productsSpawn();

            stageCount = 601;
        }
    }

    public void Stage601()
    {
        if (stageCount == 601)
        {
            fadeCanvas.SetActive(false);
            
            indicationText.text = "Ű�� x�� �����ּ���";
            arrow.SetActive(true);
            arrow.transform.position = new Vector3(-1.227f, 1.294f, -3.88f);

            stageCount = 610;
        }
    }

    public void Stage610()
    {
        if (stageCount == 610)
        {
            arrow.SetActive(false);
            indicationText.text = "����� ��ư�� �����ּ���";
            checkParticle.SetActive(true);
            stageCount = 620;
        }
    }

    public void Stage620()
    {
        if (stageCount == 620)
        {
            
            indicationText.text = "����ǰ�� ���ڵ�� ����ּ���";
            tmpproduct = GameObject.FindWithTag("TempProduct");
            tmpproduct.GetComponent<Outline>().enabled = true;
            bacode.GetComponent<Outline>().enabled = true;
            checkParticle.SetActive(false);
            stageCount = 630;
        }
    }

    public void Stage630()
    {
        if (stageCount == 630)
        {
            
            indicationText.text = "����Ű�� �����ּ���";
            posButton.youngManParticle.SetActive(true);
            stageCount = 698;
        }
    }

    public void Stage698()
    {
        if (stageCount == 698)
        {
            
            indicationText.text = "";
            posButton.youngManParticle.SetActive(false);
            discardScreen.SetActive(false);
            calculationScreen.SetActive(false);
            mainScreen.SetActive(true);

            monitor.MonitorDown();
            monitor.Talk(14);
            firecracker.SetActive(true);

            stageCount = 699;
        }
    }

    public void Stage699()
    {
        if (stageCount == 699)
        {
            
            fadeCanvas.SetActive(true);

            tmpproduct = GameObject.FindWithTag("TempProduct");
            Destroy(tmpproduct);

            stageCount = 700;
            NextWait();
        }
    }

    public void Stage700() //������� ����
    {
        if (stageCount == 700)
        {
            markText.text = "�������";
            ChapterStart();
            monitor.Talk(15);
            soju.SetActive(true);
            firecracker.SetActive(false);

            stageCount = 701;
        }
    }

    public void Stage701()
    {
        if (stageCount == 701)
        {
            
            indicationText.text = "������ư�� �����ּ���";
            fadeCanvas.SetActive(false);
            posButton.emptyParticle.SetActive(true);

            stageCount = 710;
        }
    }

    public void Stage710()
    {
        if (stageCount == 710)
        {
            
            indicationText.text = "�������� �´� ��ư�� �����ּ���";
            posButton.emptyParticle.SetActive(false);
            emptiesScreen.SetActive(true);

            emptiesParticle1.SetActive(true);

            stageCount = 720;
        }
    }

    public void Stage720()
    {
        if (stageCount == 720)
        {
            
            indicationText.text = "����� Ŭ���Ͽ��ּ���";
            emptiesParticle1.SetActive(false);
            emptiesParticle2.SetActive(true);

            stageCount = 730;
        }
    }

    public void Stage730()
    {
        if (stageCount == 730)
        {
            
            indicationText.text = "�����ڸ�ŭ ������ ������ ���������� �����ּ���";
            emptiesParticle2.SetActive(false);
            emptiesParticle3.SetActive(true);

            stageCount = 740;
        }
    }

    public void Stage740()
    {
        if (stageCount == 740)
        {
            
            indicationText.text = "Ȯ���� �����ּ���";
            emptiesParticle3.SetActive(false);
            emptiesParticle4.SetActive(true);

            stageCount = 750;
        }
    }

    public void Stage750()
    {
        if (stageCount == 750)
        {
            
            indicationText.text = "����Ű�� �����ּ���";
            posButton.youngManParticle.SetActive(true);
            emptiesParticle3.SetActive(false);

            stageCount = 798;
        }
    }

    public void Stage798()
    {
        if (stageCount == 798)
        {
            
            indicationText.text = "";
            posButton.youngManParticle.SetActive(false);
            calculation3Screen.SetActive(false);

            monitor.MonitorDown();
            monitor.Talk(16);
            firecracker.SetActive(true);

            stageCount = 799;
        }
    }

    public void Stage799()
    {
        if (stageCount == 799)
        {
            
            fadeCanvas.SetActive(true);
            soju.SetActive(false);

            stageCount = 800;
            NextWait();
        }
    }

    public void Stage800() //
    {
        if (stageCount == 800)
        {
            firecracker.SetActive(false);
            uiManager.Lobby();
        }
    }

}
