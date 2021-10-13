using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CustomerAI : MonoBehaviour
{
    [Header("ExistingObject")]
    public GameObject bababaObject; // �������� �ٳ��� ����
    public GameObject cardObject; // �������� ī�� ����
    public GameObject cashObject; // �������� ���� ����

    [Header ("NewObject")]
    public GameObject newbanana;
    public GameObject newCard;
    public GameObject newCash;

    NavMeshAgent nav;
    Animator ani;
    AudioSource moveSound;
    Rigidbody rigid;

    [Header("CustomerSetting")]
    [SerializeField] bool moving; // �����̴� �մ����� �ƴ��� üũ
    public Collider[] points; // �մ� �̵� ��ǥ
    
    Quaternion newRotation; // �մ��� �� ����
    int customerState = 0; // �մ��� ��ǥ�� ��Ҵ��� Ȯ��

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

    IEnumerator Turn() // �մ� ���� ȸ��
    {
        float time = 0;
        while (time < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            time += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 5);
        }
    }

    void Moving(int count) //�����϶�
    {
        nav.SetDestination(points[count].transform.position);
        nav.isStopped = false;
        ani.SetBool(hashWalk, true);
        moveSound.UnPause();
    }

    void NotMoving() // ���⶧
    {
        nav.velocity = Vector3.zero;
        nav.isStopped = true;
        ani.SetBool(hashWalk, false);
        moveSound.Pause();
        rigid.velocity = Vector3.zero;
    }

    IEnumerator Enter() //��������� �̵� �ϸ� �ൿ
    {
        Moving(0); //������� �̵�

        yield return new WaitUntil(() => customerState == 1); //������ ����
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

        Moving(1); // ī���ͷ� �̵�

        yield return new WaitUntil(() => customerState==2); //ī���� ����
        NotMoving();
        StageManager.stageManager.stage103();
        newRotation = Quaternion.LookRotation(transform.right);
        StartCoroutine(Turn());
    }

    public void BananaDrop() // �ٳ��� ���
    { StartCoroutine(BananaDroping()); }

    IEnumerator BananaDroping()
    {
        bababaObject.SetActive(true);
        ani.SetTrigger(hashPickUp);
        yield return new WaitForSeconds(1f);
        bababaObject.SetActive(false);
        Instantiate(newbanana, bababaObject.transform.position, bababaObject.transform.rotation); // �ٳ��� ����

    }

    public void CardDrop() // ī�� ���
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
        Instantiate(newCard, cardObject.transform.position, cardObject.transform.rotation); // ī�� ����
        
        yield return new WaitForSeconds(1f);

        time = 0;
        while (time < 0.5f)
        {
            time += Time.deltaTime;
            transform.Rotate(new Vector3(0, 30f, 0) * Time.deltaTime, Space.World);
        }
    }

    public void CashDrop() // ���� ���
    { StartCoroutine(CashDroping()); }

    IEnumerator CashDroping()
    {
        float time = 0; // �մ� ȸ��
        while (time < 0.5f)
        {
            time += Time.deltaTime;
            transform.Rotate(new Vector3(0, -30f, 0) * Time.deltaTime, Space.World);
        }

        cashObject.SetActive(true);
        ani.SetTrigger(hashPickUp);

        yield return new WaitForSeconds(1f);

        cashObject.SetActive(false);
        Instantiate(newCash, cashObject.transform.position, cashObject.transform.rotation); // ���� ����

        yield return new WaitForSeconds(1f);

        time = 0;
        while (time < 0.5f)
        {
            time += Time.deltaTime;
            transform.Rotate(new Vector3(0, 30f, 0) * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other) // �մ� �̵�
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
