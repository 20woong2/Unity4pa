using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameClearScreenSequence : MonoBehaviour
{
    [Header("연결")]
    public GameObject mainCamera;
    public DialogueManager dialogueManager;
    public SceneLoader sceneLoader;
    public GameObject videoScreen;
    public GameObject realPostProcess; // Bloom을 위한 실제 PostProcess -> 기존에 사용하던 PostProcess는 Bloom을 제거함

    [Header("대사 간 지연 시간 설정")]
    public float delay = 1.0f;

    [Header("대사 설정 (수정 가능)")]
    [TextArea] public string text1 = "너는... 이 어둠 속에서 벗어날 수 없어.";
    [TextArea] public string text2 = "네가 시작이야, 새로운 고통의 씨앗...";
    [TextArea] public string text3 = "이 끝나지 않는 싸움에 빠져들게 될 거야.";
    [TextArea] public string text4 = "제발... 내가 무슨 잘못을 했는데... 왜 나를...";
    [TextArea] public string text5 = "이해하려 하지 마라... 너는 이제 내 게임의 일부일 뿐이야.";

    private GameObject pos1; // 게임 화면을 보여주기 위한 포지션
    private GameObject pos2; // VHS 스크린을 위한 포지션

    [Header("비디오 설정")]
    public VideoPlayer videoPlayer; // 비디오 플레이어
    public VideoClip[] videoClips; // 여러개의 비디오를 넣을 배열 (최대 개수: MAX_VIDEO_COUNT)

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos1 = GameObject.FindWithTag("Pos1");
        pos2 = GameObject.FindWithTag("Pos2");

        if (pos1 == null || pos2 == null)
        {
            Debug.LogWarning("포지션이 연결되지 않음");
        }

        if (mainCamera != null)
        {
            mainCamera.transform.SetPositionAndRotation(pos2.transform.position, pos2.transform.rotation);
        }
        else
        {
            Debug.LogWarning("메인 카메라가 연결되지 않음");
        }

        if (videoScreen != null)
        {
            videoScreen.SetActive(true);
        }
        else
        {
            Debug.LogWarning("videoScreen을 연결해 주세요.");
        }

            StartCoroutine(PlayClearScreenFlow());
    }

    IEnumerator PlayClearScreenFlow()
    {
        // 1. 첫 번째 대사
        dialogueManager.ShowMessage(text1);
        yield return WaitTyping(text1); // 다 써질 때까지 대기
        yield return new WaitForSecondsRealtime(delay);

        // 2. 두 번째 대사
        videoPlayer.clip = videoClips[1];
        dialogueManager.ShowMessage(text2);
        yield return WaitTyping(text2); // 다 써질 때까지 대기
        yield return new WaitForSecondsRealtime(delay);

        // 3. 세 번째 대사
        dialogueManager.ShowMessage(text3);
        yield return WaitTyping(text3); // 다 써질 때까지 대기
        yield return new WaitForSecondsRealtime(delay);

        // 4. 네 번째 대사
        videoPlayer.clip = videoClips[2];
        dialogueManager.ShowMessage(text4);
        yield return WaitTyping(text4); // 다 써질 때까지 대기
        yield return new WaitForSecondsRealtime(delay);

        // 5. 다섯 번째 대사

        mainCamera.GetComponent<CameraShake>().enabled = false;
        mainCamera.transform.SetPositionAndRotation(pos1.transform.position, pos1.transform.rotation);
        videoScreen.SetActive(false);
        CameraShake shaker = mainCamera.GetComponent<CameraShake>();

        if (shaker != null)
        {
            // Shake 끄기
            shaker.StopShake();
        }
        else
        {
            Debug.LogWarning("CameraShake가 Main Camera 인스펙터에 없습니다.");
        }

        dialogueManager.ShowMessage(text5);
        if (realPostProcess != null)
        {
            realPostProcess.SetActive(true);
        }
        else
        {
            Debug.Log("Bloom에 사용될 PostProcess가 연결되지 않았습니다.");
        }

        yield return WaitTyping(text5); // 다 써질 때까지 대기
        yield return new WaitForSecondsRealtime(delay*2);

        if (sceneLoader != null)
        {
            sceneLoader.LoadScene("Main");
        }
        else
        {
            Debug.LogWarning("Scene Loader가 연결되어 있지 않아 기본 로딩으로 Scene을 불러옵니다.");
            SceneManager.LoadScene("Main");
        }

    }

    IEnumerator WaitTyping(string message)
    {
        // DialogueManager의 속도랑 비슷하게 계산 (글자수 * 속도 + 여유시간)
        float duration = message.Length * dialogueManager.typingSpeed + 1.0f;
        yield return new WaitForSecondsRealtime(duration);
    }
}
