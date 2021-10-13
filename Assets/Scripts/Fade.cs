using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour //스테이지 전환시 페이드 효과
{
    public Image image;
    public Animator anim;

    public void FadeIn()
    {
        anim.SetTrigger("isIn");
    }

    public void FadeOut()
    {
        anim.SetTrigger("isOut");
    }

    public void FadeInOut()
    {
        StartCoroutine(FadeInOutCoroutine());
    }

    IEnumerator FadeInOutCoroutine()
    {
        anim.SetTrigger("isIn");
        yield return new WaitForSeconds(2f);
        StageManager.stageManager.ChapterStarted();
        anim.SetTrigger("isOut");
    }
}
