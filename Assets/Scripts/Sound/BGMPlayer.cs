using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    //���������� ��������� �ڵ� ���� �ϵ��� �Ѵ�

    [SerializeField]
    AudioClip Music; // ����� BGM
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
