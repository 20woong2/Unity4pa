using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FadeOut : MonoBehaviour
{

    [Header("FadeOut Duration")]
    public float fadeOutDuration = 1.0f;

    [Header("Effects")]
    public GameObject vfx_fire;
    private ParticleSystem fireParticle;

    void Awake()
    {
        // 미리 파티클 시스템을 찾아둡니다.
        if (vfx_fire != null)
        {
            fireParticle = vfx_fire.GetComponent<ParticleSystem>();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartFadeOut()
    {
        StartCoroutine(FadeOutProcess());
    }

    IEnumerator FadeOutProcess()
    {
        if (vfx_fire != null)
        {
            vfx_fire.SetActive(true);
        }

        Renderer render = GetComponent<Renderer>();
        // 렌더러를 못 찾으면
        if (render == null )
        {
            Debug.LogWarning($"{gameObject.name} : Renderer가 발견되지 않습니다. 페이드 효과가 적용되지 않고 즉시 사라집니다.", gameObject);

            gameObject.SetActive(false);
            yield break; // 코루틴을 나가버립니다. 
        }

        Color startColor = render.material.color;
        float timer = 0f;
        bool isFireStopped = false; // 불 껐는지 체크용

        while ( timer < fadeOutDuration )
        {
            timer += Time.deltaTime;
            // 1에서 0으로 내립니다.
            // timer/fadeOutDuration -> 진행도가 커져 최종적으로 1이 됩니다.
            float newAlpha = Mathf.Lerp(1f, 0f, timer/fadeOutDuration);

            Color newColor = startColor;
            newColor.a = newAlpha;
            render.material.color = newColor;

            if (!isFireStopped && newAlpha < 0.3f)
            {
                if (fireParticle != null) fireParticle.Stop(); // 더 이상 불꽃 생성 안 함
                isFireStopped = true;
            }

            yield return null; // 프레임마다 대기
        }

        if (vfx_fire != null)
        {
            vfx_fire.SetActive(false);
        }

        gameObject.SetActive(false);

        // 카드의 Color값을 원래대로 복구
        startColor.a = 1f;
        render.material.color = startColor;
    }

}
