using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosButton : MonoBehaviour
{
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
    public Button num000;
    public Button num00;
    public Button clear;//
    public Button tenThousand;//
    public Button back;//
    public Button youngWoman;//
    public Button childWoman;//
    public Button takingOver;//
    public Button empty;//
    public Button shortcuts2;//
    public Button credit;//

    [Header("Particle")]
    public GameObject num00Particle;
    public GameObject num1Particle;
    public GameObject num4Particle;
    public GameObject num7Particle;

    public GameObject shortcuts2Particle;
    public GameObject ChildWomanParticle;
    public GameObject youngManParticle;
    public GameObject takingOverParticle;
    public GameObject emptyParticle;
    public GameObject creditParticle;

    [Header("Referense")]
    public GameObject mainScreen;
    public GameObject tenseScreen;
    public GameObject CalculationScreen;
    public GameObject Calculation2Screen;

    [Header("Audio")]
    AudioSource audioSource;
    public AudioClip buttonSound;

    public delegate void ButtonNumber();
    public static event ButtonNumber OnButtonNumber; // 버튼 눌렀을 때의 이벤트 구현
    public static string buttonNum { get; private set; } // 버튼 입력값 저장용

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();


        ////값 할당
        //numButton[11].onClick.AddListener(() => NumberClick("00"));
        //numButton[12].onClick.AddListener(() => NumberClick("000"));
        //numButton[13].onClick.AddListener(() => NumberClick("clear"));
        //numButton[14].onClick.AddListener(() => NumberClick("10000"));
        //numButton[15].onClick.AddListener(() => NumberClick("back"));

        ////UI 화면 제어
        //numButton[18].onClick.AddListener(() => mainScreen.SetActive(false));
        //numButton[18].onClick.AddListener(() => tenseScreen.SetActive(true));
        //numButton[21].onClick.AddListener(() => CalculationScreen.SetActive(false));
        //numButton[21].onClick.AddListener(() => Calculation2Screen.SetActive(true));

        //스테이지 진행
        num00.onClick.AddListener(() => StageManager.stageManager.Stage214());
        num00.onClick.AddListener(() => StageManager.stageManager.Stage213());
        num1.onClick.AddListener(() => StageManager.stageManager.Stage6());
        num1.onClick.AddListener(() => StageManager.stageManager.Stage8());
        num1.onClick.AddListener(() => StageManager.stageManager.Stage212());
        num4.onClick.AddListener(() => StageManager.stageManager.Stage10());
        num7.onClick.AddListener(() => StageManager.stageManager.Stage12());
        takingOver.onClick.AddListener(() => StageManager.stageManager.Stage4());
        credit.onClick.AddListener(() => StageManager.stageManager.Stage130());
        credit.onClick.AddListener(() => StageManager.stageManager.Stage470());
        youngWoman.onClick.AddListener(() => StageManager.stageManager.Stage198());
        youngWoman.onClick.AddListener(() => StageManager.stageManager.Stage220());
        youngWoman.onClick.AddListener(() => StageManager.stageManager.Stage498());
        childWoman.onClick.AddListener(() => StageManager.stageManager.Stage598());
        youngWoman.onClick.AddListener(() => StageManager.stageManager.Stage698());
        youngWoman.onClick.AddListener(() => StageManager.stageManager.Stage798());
        shortcuts2.onClick.AddListener(() => StageManager.stageManager.Stage398());
        empty.onClick.AddListener(() => StageManager.stageManager.Stage710());

        //사운드
        //for (int i = 0; i < numButton.Count; i++)
        //{
        //    int num = i;
        //    numButton[num].onClick.AddListener(() => SoundPlay());
        //}


        OnButtonNumber = ValueAssignment; // 비어있는곳에 값 할당
    }

    private void NumberClick(string num)
    {
        audioSource.PlayOneShot(buttonSound, 1.0f);
        buttonNum = num;
        OnButtonNumber();
    }

    private void SoundPlay()
    {
        audioSource.PlayOneShot(buttonSound, 1.0f);
    }

    private void ValueAssignment() { } // 이벤트에 값 할당용
}

//class MyButton
//{
//    string id;
//    Button btn;

//    public MyButton(string id, Button btn)
//    {
//        this.id = id;
//        this.btn = btn;
//    }

//    public Button Btn
//    {
//        get { return btn; }
//    }
//    public string Id
//    {
//        get { return id; }
//    }
//}