using UnityEngine;
using System.Collections;

public class CardLeader : MonoBehaviour
{
    public GameObject newCard; // ���� ���� ī��
    public Transform cardPosition; // ī�� ������ ��ġ

    public GameObject moveCard; // �ִϸ��̼� ������ ī��
    

    public AudioClip cardInSound; // ī�� �Ŵ¼Ҹ�
    public AudioClip cardOutSound; // ī�� ���¼Ҹ�
    AudioSource audioSource;
    public Animator anim;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void CardIn()
    {
        moveCard.SetActive(true);
        anim.SetTrigger("isCardIn");
        audioSource.PlayOneShot(cardInSound, 1.0f);
    }

    public void CardOut()
    {
        audioSource.PlayOneShot(cardOutSound, 1.0f);
        anim.SetTrigger("isCardOut");
        StartCoroutine(CardOut2());
    }

    IEnumerator CardOut2()
    {
        yield return new WaitForSeconds(1f);
        moveCard.SetActive(false);
        Instantiate(newCard, cardPosition.transform.position, newCard.transform.rotation);
    }
}
