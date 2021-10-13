using UnityEngine;

public class CardPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 카드 받으면 스테이지 매니저에 있는것 실행
        if (other.gameObject.tag == "CREDITCARD")
        {
            Destroy(other.gameObject);
            StageManager.stageManager.Stage120();
            StageManager.stageManager.Stage460();
            StageManager.stageManager.Stage550();
        }
    }
}
