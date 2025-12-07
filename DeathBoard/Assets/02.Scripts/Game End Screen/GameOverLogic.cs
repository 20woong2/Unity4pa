using UnityEngine;
using UnityEngine.SceneManagement; // 비상용(SceneManager) 사용을 위해 추가
using System.Collections;

public class GameOverSceneLoader : MonoBehaviour
{
    [Header("설정")]
    [Tooltip("이동할 Scene의 이름")]
    public string mainSceneName = "MainScene";

    [Tooltip("몇 초 뒤에 넘어갈지 설정")]
    public float delaySeconds = 5.0f;

    [Tooltip("사용할 DialogueManager와 text")]
    public DialogueManager dialogueManager;
    [TextArea]public string gameoverText;

    void Start()
    {
        dialogueManager.ShowMessage(gameoverText);
        // 프리팹이 생성되자마자 카운트다운(코루틴) 시작
        StartCoroutine(LoadMainSceneAfterDelay());
    }

    IEnumerator LoadMainSceneAfterDelay()
    {
        // 게임 오버 시에는 보통 Time.timeScale을 0으로 설정하여 게임을 멈출 것을 대비하여...
        // WaitForSeconds 대신 실제 시간(Realtime)을 사용하는 WaitForSecondsRealtime을 써야 딜레이가 작동합니다.
        yield return new WaitForSecondsRealtime(delaySeconds);

        // 다음 Scene으로 넘어갈 때 시간이 멈춰있으면 안 되므로, 정상 속도로 초기화해줍니다.
        Time.timeScale = 1f;

        // Scene에 존재하는 SceneLoader(또는 매니저)를 직접 찾아서 실행합니다
        // 이 스크립트는 프리팹에 붙어있어서 씬에 있는 SceneLoader를 미리 연결할 수 없습니다.
        SceneLoader loader = FindFirstObjectByType<SceneLoader>();

        if (loader != null)
        {
            loader.LoadScene(mainSceneName);
        }
        else
        {
            // 혹시라도 SceneLoader를 찾지 못했다면(씬에 없음), 비상용으로 기본 이동
            Debug.LogWarning("SceneLoader를 찾을 수 없습니다. SceneManager.LoadScene을 사용합니다.");
            SceneManager.LoadScene(mainSceneName);
        }
    }
}