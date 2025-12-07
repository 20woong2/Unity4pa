using System.Collections;
using UnityEngine;


// Original By hye3193 (https://hye3193.tistory.com/44)
// Developer: Jinuk Lee

//카메라를 지속적으로 흔들어주는 스크립트

public class CameraShake : MonoBehaviour
{
    // shakeMagnitude(흔들기 강도): 기본 흔들림의 강도를 정하는 변수
    // SerializeField: private 변수도 노출되도록 한다.
    // Header는 inspector에서 보일 글씨를 생성한다.
    [Header("기본 흔들림 강도")]
    [SerializeField] float continuousMagnitude = 0.2f;

    // 카메라의 position을 저장하는 변수
    private Vector3 initPosition;

    // 현재 적용되고 있는 흔들림의 강도
    private float currentMagnitude;

    // SPACE 키를 누르고 화면이 전환할 때 강해지는 흔들림이 지속될 시간
    // intense: 강렬한
    private float intenseShakeTimer = 0f;

    // 현재 흔들고 있는지 확인용
    private bool isShaking = false;
    private Coroutine shakeCoroutine;


    void Start()
    {
        // 카메라의 초기 위치를 저장한다.
        initPosition = transform.position;
        // 기본 흔들림 속도로 시작
        currentMagnitude = continuousMagnitude;
        // 기본 흔들림을 위한 코루틴 시작
        StartShake();
    }


    //강한 흔들림을 위한 타이머를 매 프레임마다 검사한다.
    void Update()
    {
        // 강한 흔들림을 위한 타이머는 0 이하가 될 때까지
        if(intenseShakeTimer > 0)
        {
            // 매 프레임마다 감소된다.
            intenseShakeTimer -= Time.deltaTime;

            // 타이머가 끝나면
            if (intenseShakeTimer <= 0 )
            {
                // 기본 흔들림 속도로 복귀한다.
                currentMagnitude = continuousMagnitude;

            }
        }
    }

    public void StopShake()
    {
        if (shakeCoroutine != null)
        {
            StopCoroutine(shakeCoroutine);
        }

        isShaking = false;

        // (선택사항) 멈출 때 딱 정중앙으로 돌아오게 하려면 아래 주석 해제
        // transform.position = initPosition; 
    }

    // [핵심 2] 외부에서 다시 흔들기 시작하는 함수
    public void StartShake()
    {
        // 이미 흔들리고 있으면 중복 실행 방지
        if (isShaking) return;

        // [중요] 다시 시작할 때는 '현재 위치'를 새로운 기준점으로 잡음
        // 이렇게 해야 카메라를 다른 곳으로 옮긴 뒤에도 거기서부터 흔들림
        initPosition = transform.position;
        currentMagnitude = continuousMagnitude;
        isShaking = true;

        shakeCoroutine = StartCoroutine(ShakeLoop());
    }



    // 외부에서 호출하는 함수 (GameDirector)
    // 특정 동작이 수행되면(SPACE) 흔들림의 강도를 바꿔준다. 흔들리는 시간, 강도를 받아온다.
    // intense: 강렬한
    public void PlayIntenseShake(float duration, float magnitude)
    {
        // magnitude(강도)는 받아온 강도로
        currentMagnitude = magnitude;
        // duration(시간)도 받아온 시간으로(Timer 시간 설정)
        intenseShakeTimer = duration;      
    }

    // Coroutine은 Update가 아닌 함수에서도 코드를 반복적으로 사용할 수 있게 한다.
    // Coroutine은 또한 매 프레임을 반환하는 Update보다 효율적일 수 있다.
    // IEnumerator: Corutine의 반환형
    IEnumerator ShakeLoop()
    {
        // 3. while (true) -> 계속 실행하게
        while (true)
        {
            // 4. 매 프레임마다 초기 위치에서 랜덤한 값만큼 떨어진 위치로 카메라를 이동
            // Random.insideUnitCircle * shakeMagnitude -> 반지름이 1에서 currentMagnitude(현재 흔들기 강도) 만큼 곱한만큼의 원 내부의 임의의 점을 만듬.
            // (Vector3) x,y 값만 나타내는 기존의 Random.insideUnitCircle에서, transform.position initialPosition가 Vector3기 때문에 형변환함.
            transform.position = initPosition + (Vector3)Random.insideUnitCircle * currentMagnitude;

            // 5. 프레임마다 대기
            // 1프레임마다 실행되도록 조절해준다.
            yield return null;
        }
    }
}