using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CustomerAI : MonoBehaviour
{
    [Header("ExistingObject")]
    public GameObject bababaObject; // 손하위에 바나나 생성
    public GameObject cardObject; // 손하위에 카드 생성
    public GameObject cashObject; // 손하위에 현금 생성

    [Header ("NewObject")]
    public GameObject newbanana;
    public GameObject newCard;
    public GameObject newCash;

    NavMeshAgent nav;
    Animator ani;
    AudioSource moveSound;
    Rigidbody rigid;

    [Header("CustomerSetting")]
    [SerializeField] bool moving; // 움직이는 손님인지 아닌지 체크
    public Collider[] points; // 손님 이동 목표
    
    Quaternion newRotation; // 손님이 볼 방향
    int customerState = 0; // 손님이 목표에 닿았는지 확인

    private readonly int hashWalk = Animator.StringToHash("isWalk");
    private readonly int hashPetting = Animator.StringToHash("isPetting");
    private readonly int hashPickUp = Animator.StringToHash("isPickUp");
    private readonly int hashTalk = Animator.StringToHash("isTalk");

    public void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        moveSound = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody>();

        if (moving)
        StartCoroutine(Enter());
    }

    IEnumerator Turn() // 손님 방향 회전
    {
        float time = 0;
        while (time < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            time += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 5);
        }
    }

    void Moving(int count) //움직일때
    {
        nav.SetDestination(points[count].transform.position);
        nav.isStopped = false;
        ani.SetBool(hashWalk, true);
        moveSound.UnPause();
    }

    void NotMoving() // 멈출때
    {
        nav.velocity = Vector3.zero;
        nav.isStopped = true;
        ani.SetBool(hashWalk, false);
        moveSound.Pause();
        rigid.velocity = Vector3.zero;
    }

    IEnumerator Enter() //진열대까지 이동 하며 행동
    {
        Moving(0); //진열대로 이동

        yield return new WaitUntil(() => customerState == 1); //진열대 도착
        NotMoving();

        newRotation = Quaternion.LookRotation(-transform.right);
        StartCoroutine(Turn());
        yield return new WaitForSeconds(2f);
        

        ani.SetTrigger(hashPetting);

        yield return new WaitForSeconds(2f);
        bababaObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        newRotation = Quaternion.LookRotation(-transform.right);
        StartCoroutine(Turn());

        Moving(1); // 카운터로 이동

        yield return new WaitUntil(() => customerState==2); //카운터 도착
        NotMoving();
        StageManager.stageManager.stage103();
        newRotation = Quaternion.LookRotation(transform.right);
        StartCoroutine(Turn());
    }

    public void BananaDrop() // 바나나 드랍
    { StartCoroutine(BananaDroping()); }

    IEnumerator BananaDroping()
    {
        bababaObject.SetActive(true);
        ani.SetTrigger(hashPickUp);
        yield return new WaitForSeconds(1f);
        bababaObject.SetActive(false);
        Instantiate(newbanana, bababaObject.transform.position, bababaObject.transform.rotation); // 바나나 생성

    }

    public void CardDrop() // 카드 드랍
    { StartCoroutine(CardDroping()); }

    IEnumerator CardDroping()
    {
        float time = 0;
        while (time < 0.5f)
        {
            time += Time.deltaTime;
            transform.Rotate(new Vector3(0, -30f, 0) * Time.deltaTime, Space.World);
        }

        cardObject.SetActive(true);
        ani.SetTrigger(hashPickUp);
        yield return new WaitForSeconds(1f);
        cardObject.SetActive(false);
        Instantiate(newCard, cardObject.transform.position, cardObject.transform.rotation); // 카드 생성
        
        yield return new WaitForSeconds(1f);

        time = 0;
        while (time < 0.5f)
        {
            time += Time.deltaTime;
            transform.Rotate(new Vector3(0, 30f, 0) * Time.deltaTime, Space.World);
        }
    }

    public void CashDrop() // 현금 드랍
    { StartCoroutine(CashDroping()); }

    IEnumerator CashDroping()
    {
        float time = 0; // 손님 회전
        while (time < 0.5f)
        {
            time += Time.deltaTime;
            transform.Rotate(new Vector3(0, -30f, 0) * Time.deltaTime, Space.World);
        }

        cashObject.SetActive(true);
        ani.SetTrigger(hashPickUp);

        yield return new WaitForSeconds(1f);

        cashObject.SetActive(false);
        Instantiate(newCash, cashObject.transform.position, cashObject.transform.rotation); // 현금 생성

        yield return new WaitForSeconds(1f);

        time = 0;
        while (time < 0.5f)
        {
            time += Time.deltaTime;
            transform.Rotate(new Vector3(0, 30f, 0) * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other) // 손님 이동
    {
        if (points[customerState] == other)
        { customerState++; }
    }

    public void Pickup()
    { ani.SetTrigger(hashPickUp); }

    public void Talk()
    { ani.SetTrigger(hashTalk); }

    public void ReceiveMoney()
    {
        StartCoroutine(ReceivingMoney());
    }

    IEnumerator ReceivingMoney()
    {
        Pickup();
        yield return new WaitForSeconds(0.5f * Time.deltaTime);
        GameObject tmpObj = GameObject.Find("CustomerMoney");
        Destroy(tmpObj);
        tmpObj = GameObject.FindWithTag("TempProduct");
        Destroy(tmpObj);
    }

    public void ReceiveCard()
    {
        StartCoroutine(ReceivingCard());
    }

    IEnumerator ReceivingCard()
    {
        Pickup();
        yield return new WaitForSeconds(0.5f * Time.deltaTime);
        GameObject tmpObj = GameObject.FindWithTag("RECIVECREDITCARD");
        Destroy(tmpObj);
        tmpObj = GameObject.FindWithTag("TempProduct");
        Destroy(tmpObj);
    }

    public void Exit()
    {
        StartCoroutine(Exitng());
    }

    IEnumerator Exitng()
    {
        Pickup();

        yield return new WaitForSeconds(50f * Time.deltaTime);

        GameObject tmpObj = GameObject.FindWithTag("TempProduct");
        Destroy(tmpObj);
        tmpObj = GameObject.FindWithTag("RECIVECREDITCARD");
        Destroy(tmpObj);


        yield return new WaitForSeconds(200f * Time.deltaTime);

        Moving(2);

        yield return new WaitForSeconds(5f);

        NotMoving();
    }
}
