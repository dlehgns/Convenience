using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public string sceneName;
    public Image progressBar;

    private void Start()
    {
        StartCoroutine(LoadSceneProcess(sceneName));
    }

    IEnumerator LoadSceneProcess(string sceneName)
    {
        yield return new WaitForSeconds(0.5f); // 시작하자마자 렉 안걸리게 하기 위한 잠깐의 텀

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName); // 다음씬 미리 로드
        operation.allowSceneActivation = false;

        while (!operation.isDone) // 만약 로딩씬이 완료되지 않았을 경우
        {
            yield return null; // 유니티로 제어권을 넘겨줘서 진행바가 차오르게 만듬

            if (operation.progress < 0.9f) // 로딩하기
            {
                progressBar.fillAmount += 5f * Time.deltaTime;
                //progressBar.value = operation.progress;
            }
            else // 진행도가 90% 를 넘어가게 되면 페이크 로딩을 보여줌
            {
                //timer += Time.unscaledDeltaTime;
                progressBar.fillAmount += 0.3f * Time.deltaTime;
                //progressBar.value = Mathf.Lerp(0.9f, 1f, timer);
                if (progressBar.fillAmount >= 1f)
                {
                    operation.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
