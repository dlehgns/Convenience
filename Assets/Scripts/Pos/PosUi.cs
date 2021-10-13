using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosUi : MonoBehaviour
{
    public Button[] buttons;
    AudioSource audioSource;
    public AudioClip buttonSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].onClick.AddListener(() => ButtonClick());
        }

        buttons[15].onClick.AddListener(() => StageManager.stageManager.Stage750());
        buttons[14].onClick.AddListener(() => StageManager.stageManager.Stage730());
        buttons[57].onClick.AddListener(() => StageManager.stageManager.Stage720());
        buttons[24].onClick.AddListener(() => StageManager.stageManager.Stage620());
        buttons[17].onClick.AddListener(() => StageManager.stageManager.Stage540());
        buttons[30].onClick.AddListener(() => StageManager.stageManager.Stage540());
        buttons[31].onClick.AddListener(() => StageManager.stageManager.Stage560());
        buttons[20].onClick.AddListener(() => StageManager.stageManager.Stage450());
        buttons[29].onClick.AddListener(() => StageManager.stageManager.Stage230());
        buttons[33].onClick.AddListener(() => StageManager.stageManager.Stage140());
        buttons[33].onClick.AddListener(() => StageManager.stageManager.Stage480());
        buttons[37].onClick.AddListener(() => StageManager.stageManager.Stage420());
        buttons[37].onClick.AddListener(() => StageManager.stageManager.Stage520());
        buttons[39].onClick.AddListener(() => StageManager.stageManager.Stage430());
        buttons[41].onClick.AddListener(() => StageManager.stageManager.Stage98());
        buttons[43].onClick.AddListener(() => StageManager.stageManager.Stage530());

    }

    private void ButtonClick() // 버튼 클릭시 사운드 실행
    {
        audioSource.PlayOneShot(buttonSound, 1.0f);
    }
}
