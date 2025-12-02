using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFlash : MonoBehaviour
{
    public Image flashImage;      // ScreenFlash 이미지

    public float orangeTime  = 0.05f;  // 주황색 유지 시간
    public float fadeInTime  = 0.03f;  // 주황 → 검정으로 어두워지는 속도
    public float holdTime    = 10f;    // 완전 검은 상태 유지 시간
    public float fadeOutTime = 0.2f;   // 다시 돌아오는 속도

    void Awake()
    {
        if (flashImage == null)
            flashImage = GetComponent<Image>();

        gameObject.SetActive(false);
    }

    public void DoFlash()
    {
        Debug.Log("화면 호출");
        gameObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        // 0) 완전 투명에서 시작
        flashImage.color = new Color(0, 0, 0, 0);

        // 1) 주황색으로 번쩍
        Color orange = new Color(1f, 0.6f, 0.2f, 1f);   // 밝은 주황
        flashImage.color = orange;
        yield return new WaitForSecondsRealtime(orangeTime);

        // 2) 주황 → 검정으로 페이드 인
        float t = 0f;
        while (t < fadeInTime)
        {
            t += Time.unscaledDeltaTime;
            float lerp = Mathf.Clamp01(t / fadeInTime);
            // 색만 주황→검정으로 보간, 알파는 1 유지
            Color c = Color.Lerp(orange, Color.black, lerp);
            flashImage.color = c;
            yield return null;
        }

        // 3) 완전 검정 유지
        flashImage.color = Color.black;
        yield return new WaitForSecondsRealtime(holdTime);

        // 4) 검정 → 투명으로 페이드 아웃
        t = 0f;
        while (t < fadeOutTime)
        {
            t += Time.unscaledDeltaTime;
            float a = Mathf.Lerp(1f, 0f, t / fadeOutTime);
            flashImage.color = new Color(0, 0, 0, a);
            yield return null;
        }

        yield return new WaitForSecondsRealtime(2f);
        gameObject.SetActive(false);
    }
}