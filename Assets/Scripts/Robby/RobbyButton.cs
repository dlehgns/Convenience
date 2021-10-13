using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RobbyButton : MonoBehaviour
{
    [Header("MainWindow")]
    public Button newStart;
    public Button exit;

    [Header("StartWindow")]
    public Button newStart_;
    public Button tense;
    public Button card;
    public Button cash;
    public Button withHold;
    public Button keepingCoupon;
    public Button schoolMeal;
    public Button expirtDate;
    public Button emptyBottle;

    private void Start()
    {
        exit.onClick.AddListener(() => Exit());
        newStart.onClick.AddListener(() => GotoMain(0));
        newStart_.onClick.AddListener(() => GotoMain(0));
        tense.onClick.AddListener(() => GotoMain(0));
        card.onClick.AddListener(() => GotoMain(100));
        cash.onClick.AddListener(() => GotoMain(200));
        withHold.onClick.AddListener(() => GotoMain(300));
        keepingCoupon.onClick.AddListener(() => GotoMain(400));
        schoolMeal.onClick.AddListener(() => GotoMain(500));
        expirtDate.onClick.AddListener(() => GotoMain(600));
        emptyBottle.onClick.AddListener(() => GotoMain(700));
    }

    public void GotoMain(int Num)
    {
        MainManager.mainManager.stageNum = Num; // 메인 매니저에 변수저장
        SceneManager.LoadScene(2); // 로딩창으로 씬변경
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


}
