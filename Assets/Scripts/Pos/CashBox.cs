using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashBox : MonoBehaviour
{
    [Header("Sound")]
    public AudioClip openSfx;
    public AudioClip closeSfx;

    AudioSource audioSource;
    Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Counter"))
        {
            Destroy(other.gameObject);
            StageManager.stageManager.Stage211();
        }
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // 오디오 소스 등록
    }
    public void CashBoxOpen()
    {
        audioSource.PlayOneShot(openSfx, 1.0f);
        anim.SetTrigger("isOpen");
    }

    public void CashBoxClose()
    {
        audioSource.PlayOneShot(closeSfx, 1.0f);
        anim.SetTrigger("isClose");
    }

}
