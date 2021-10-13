using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoor : MonoBehaviour // 손님 지나갈때 편의점 출입구 문 여닫는것
{
    public Animator rightDoorAnim;
    public Animator leftDoorAnim;

    AudioSource audioSource;
    public AudioClip doorOpenSound;
    public AudioClip doorCloseSound;


    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) // 손님 접촉시 문열기 애니메이션 실행
    {
        if (other.tag == "Customer")
        {
            audioSource.PlayOneShot(doorOpenSound, 1.0f);
            rightDoorAnim.SetTrigger("isOpen");
            leftDoorAnim.SetTrigger("isOpen");
        }
    }

    private void OnTriggerExit(Collider other) // 손님 접촉해제시 문닫기 애니메이션 실행
    {
        if (other.tag == "Customer")
        {
            audioSource.PlayOneShot(doorCloseSound, 1.0f);
            rightDoorAnim.SetTrigger("isClose");
            leftDoorAnim.SetTrigger("isClose");
        }
    }
}
