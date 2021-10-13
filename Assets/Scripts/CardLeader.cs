using UnityEngine;
using System.Collections;

public class CardLeader : MonoBehaviour
{
    public GameObject newCard; // 새로 만들 카드
    public Transform cardPosition; // 카드 리스폰 위치

    public GameObject moveCard; // 애니메이션 보여줄 카드
    

    public AudioClip cardInSound; // 카드 꼽는소리
    public AudioClip cardOutSound; // 카드 뺴는소리
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
