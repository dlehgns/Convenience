using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monitor : MonoBehaviour
{
    [Header ("Reference")]
    public StageManager stageManager;
    public MonitorText monitorText;

    [Header("Text")]
    public Text msgText; // 모니터 글자
    
    Animator anim; // 모니터 위아래 이동

    int talkIndex = 0;
    int talkId;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Talk(int id) // 대화 시작 여기를 불러오기
    {
        talkId = id;
        TalkRepeat(id);
    }
    public void TalkRepeat(int id)
    {
        string talkData = monitorText.GetTalk(id, talkIndex);
        if (talkData == null)  // 대화가 끝나면 실행
        {
            talkIndex = 0;
            TextEnd();
            return;
        }
        else  // 대화가 안끝났을경우 반복
        {
            StartCoroutine(EffectStart(talkData));
            talkIndex++;
        }
    }

    IEnumerator EffectStart(string sentence) // 한글자씩 나오는 이팩트
    {
        msgText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            yield return new WaitForSeconds(5f * Time.deltaTime); //한글자씩 나오는 간격
            msgText.text += letter;
            yield return null;
        }
        yield return new WaitForSeconds(20f * Time.deltaTime);// 다음 글자들이 나올때까지 잠시 텀
        TalkRepeat(talkId);
    }

    public void TextEnd() // 글자 반복 출력이 끝나면 시작
    {
        stageManager.Stage1(); 
        stageManager.Stage3();
        stageManager.Stage99();
        stageManager.Stage101();
        stageManager.Stage199();
        stageManager.Stage201();
        stageManager.Stage299();
        stageManager.Stage301();
        stageManager.Stage399();
        stageManager.Stage401();
        stageManager.Stage499();
        stageManager.Stage501();
        stageManager.Stage599();
        stageManager.Stage601();
        stageManager.Stage699();
        stageManager.Stage701();
        stageManager.Stage799();

        if (   stageManager.stageCount == 4
            || stageManager.stageCount == 103
            || stageManager.stageCount == 205
            || stageManager.stageCount == 305
            || stageManager.stageCount == 405
            || stageManager.stageCount == 505
            || stageManager.stageCount == 610
            || stageManager.stageCount == 710 )
        {
            StartCoroutine(TxtEndMonitorUP());
        }

        if (stageManager.stageCount == 98)
        {
            stageManager.Stage99();
        }
    }

    IEnumerator TxtEndMonitorUP()
    {
        yield return new WaitForSeconds(1.0f);
        MonitorUp();
    }
    //-------------------------------------------------------------------
    
    public void MonitorUp()
    {
        anim.SetTrigger("isUp");
    }
    public void MonitorDown()
    {
        anim.SetTrigger("isDown");
    }
}
