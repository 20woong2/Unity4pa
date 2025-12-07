using UnityEngine;
using UnityEngine.UI; // 페이드 효과용 이미지를 제어하기 위해
using System.Collections;
using UnityEngine.SceneManagement;

public class GameClearSequence : MonoBehaviour
{
    [Header("필수 연결")]
    [Tooltip("기존에 쓰던 다이얼로그 매니저를 연결하세요")]
    public DialogueManager dialogueManager;
    public TurnManager turnManager;

    [Tooltip("화면을 덮을 검은색 패널 (Image 컴포넌트)")]
    public Image fadeBlackImage;

    [Tooltip("흔들림 효과를 줄 대상 (보통 Dialogue가 있는 캔버스나 텍스트 오브젝트)")]
    public Transform shakeTarget;

    [Header("대사 설정 (수정 가능)")]
    [TextArea] public string text1 = "드디어… 이 지옥 같은 게임에서 벗어났군…";
    [TextArea] public string text2 = "축하한다… 이제 너의 차례다… 마음껏 즐기도록…";
    [TextArea] public string text3 = "그게 무슨…? 난 집으로 돌아갈거다! 이딴 게임에는 관심없어!";
    [TextArea] public string text4 = "나도... 누군가를 희생시켜 멈춰야만 해...";

    [Header("연출 설정")]
    public float fadeDuration = 3.0f; // 화면이 어두워지는 데 걸리는 시간
    public float shakeIntensity = 5.0f; // 얼마나 심하게 흔들릴지

    void OnEnable() // 이 프리팹이 켜지자마자(SetActive true) 실행
    {
        // 시작할 때 검은 화면은 투명하게 설정
        if (fadeBlackImage != null)
        {
            Color c = fadeBlackImage.color;
            c.a = 0f;
            fadeBlackImage.color = c;
        }

        turnManager.HelpOn = true;
        StartCoroutine(PlayEndingFlow());
    }

    IEnumerator PlayEndingFlow()
    {
        // 1. 첫 번째 대사
        dialogueManager.ShowMessage(text1);
        yield return WaitTyping(text1); // 다 써질 때까지 대기
        yield return new WaitForSecondsRealtime(2.0f); // 2초 대기

        // 2. 두 번째 대사
        dialogueManager.ShowMessage(text2);
        yield return WaitTyping(text2);
        yield return new WaitForSecondsRealtime(2.0f);

        // 3. 검은 화면 페이드인 시작 (코루틴 병렬 실행)
        StartCoroutine(FadeInBlackScreen());

        // 동시에 세 번째 대사
        dialogueManager.ShowMessage(text3);

        // 4. 어지러움 효과 시작 (텍스트나 화면 흔들기)
        StartCoroutine(ShakeEffect(3.0f)); // 3초간 흔들기

        yield return WaitTyping(text3);
        yield return new WaitForSecondsRealtime(2.0f);

        // 5. 마지막 대사
        dialogueManager.ShowMessage(text4);
        yield return WaitTyping(text4);

        yield return new WaitForSecondsRealtime(1.0f);

        // 이후 로직
        SceneManager.LoadScene("Game Clear");
    }

    // 텍스트 길이에 맞춰서 기다려주는 함수
    IEnumerator WaitTyping(string message)
    {
        // DialogueManager의 속도랑 비슷하게 계산 (글자수 * 속도 + 여유시간)
        float duration = message.Length * dialogueManager.typingSpeed + 1.0f;
        yield return new WaitForSecondsRealtime(duration);
    }

    // 화면을 천천히 어둡게 만드는 함수
    IEnumerator FadeInBlackScreen()
    {
        if (fadeBlackImage == null) yield break;

        float timer = 0f;
        Color startColor = fadeBlackImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime; // Realtime 사용
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);

            startColor.a = alpha;
            fadeBlackImage.color = startColor;

            yield return null;
        }

        // 확실하게 완전 검은색으로 마무리
        startColor.a = 1f;
        fadeBlackImage.color = startColor;
    }

    // 스크린을 흔드는 함수 (어지러움 효과)
    IEnumerator ShakeEffect(float duration)
    {
        if (shakeTarget == null) yield break;

        Vector3 originalPos = shakeTarget.localPosition;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.unscaledDeltaTime;
            // 랜덤한 위치로 shake
            shakeTarget.localPosition = originalPos + (Vector3)Random.insideUnitCircle * shakeIntensity;
            yield return null;
        }

        // 흔들림 끝난 후 제자리로
        shakeTarget.localPosition = originalPos;
    }
}