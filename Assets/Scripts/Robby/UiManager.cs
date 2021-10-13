using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public Fade fade;
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ButtonSound()
    {
        audioSource.Play();
    }

    public void Lobby()
    {
        SceneManager.LoadScene(1); // 로비로
    }
    public void Convi(int Num)
    {
        MainManager.mainManager.stageNum = Num;
        SceneManager.LoadScene(2); // 로딩창으로
    }
}
