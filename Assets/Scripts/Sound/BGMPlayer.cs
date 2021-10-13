using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    //편의점에서 배경음악을 자동 실행 하도록 한다

    [SerializeField]
    AudioClip Music; // 사용할 BGM
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Play()
    {
        audioSource.PlayOneShot(Music, 1.0f);
    }
}
