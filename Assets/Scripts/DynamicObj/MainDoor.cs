using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoor : MonoBehaviour // �մ� �������� ������ ���Ա� �� ���ݴ°�
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

    private void OnTriggerEnter(Collider other) // �մ� ���˽� ������ �ִϸ��̼� ����
    {
        if (other.tag == "Customer")
        {
            audioSource.PlayOneShot(doorOpenSound, 1.0f);
            rightDoorAnim.SetTrigger("isOpen");
            leftDoorAnim.SetTrigger("isOpen");
        }
    }

    private void OnTriggerExit(Collider other) // �մ� ���������� ���ݱ� �ִϸ��̼� ����
    {
        if (other.tag == "Customer")
        {
            audioSource.PlayOneShot(doorCloseSound, 1.0f);
            rightDoorAnim.SetTrigger("isClose");
            leftDoorAnim.SetTrigger("isClose");
        }
    }
}
