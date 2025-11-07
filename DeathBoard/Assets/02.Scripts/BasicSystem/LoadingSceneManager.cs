using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingSceneManager : MonoBehaviour
{

    public static string nextScene;

    [Header("최소 로딩 시간")]
    public float minLoadingTime = 1.5f;

    [Header("Canvas Object 설정")]
    public Slider progresssBar; // 로딩 바(Slider)
    public TextMeshProUGUI loadingProgressText; // 로딩 진행 텍스트

    void Start()
    {
        // 시작하자마자 코루틴 실행
        StartCoroutine(LoadingSceneProcess());
    }
    // 다른 스크립트에서 이 함수를 호출 가능
    // static의 역할 : 객체 생성 없이 즉시 호출 가능
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName; // 받아온 Scene의 이름을 저장
        SceneManager.LoadScene("Loading"); // 중간에 Loading Scene을 불러온다.
    }

    IEnumerator LoadingSceneProcess()

    {

        // LoadingScene: 동기, Scene을 불러오면서 다른 작업이 불가능
        // LoadingSceneAsync: 비동기, Scene을 불러오면서 다른 작업이 가능하도록 함
        // AsyncOperation: 비동기적 연산을 위한 코루틴
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);

        // allowSceneActivation: 장면이 준비되는 즉시 장면을 활성화할까요?
        // Scene이 바로 넘어가지 않게(어색하지 않게)
        op.allowSceneActivation = false;

        float timer = 0f;

        while (!op.isDone)
        {
            // 매 프레임 대기
            yield return null;

            // 타이머 사용
            // Time.deltaTime 누적
            timer += Time.deltaTime;

            // 유니티의 비동기 로딩은 0.9에서 멈춘다고 한다! (나머지 0.1은 Scene을 전환하는 데 사용)
            // 진행이 0.9 미만일 때는...
            if(op.progress < 0.9f)
            {
                progresssBar.value = op.progress; // ProgressBar의 값을 진행도로 합니다.
            }
            // 0.9 부터는...
            else
            {
                // ProgressBar를 채워주는 연출
                progresssBar.value = 1f;

                // 만약에 1이 된다면!
                // float 변수는 1.0이 안 될 수도 있어서 이렇게!
                if (progresssBar.value >= 0.99f && timer > minLoadingTime)
                {
                    // Scene 전환을 허용해줍니다.
                    op.allowSceneActivation = true;
                }
            }
        }
        
    }
}
