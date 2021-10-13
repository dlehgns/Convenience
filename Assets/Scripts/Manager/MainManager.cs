using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager mainManager { get; private set; }
    public int stageNum;

    public void Awake()
    {

        if (mainManager != null)
        {
            Destroy(gameObject);
            return;
        }

        mainManager = this;
        DontDestroyOnLoad(gameObject);
    }
}
