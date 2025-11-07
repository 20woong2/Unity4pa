using System.Collections;
using UnityEngine;


// Original By hye3193 (https://hye3193.tistory.com/44)
// Developer: Jinuk Lee

//카메라를 지속적으로 흔들어주는 스크립트

public class ContinuousCameraShake : MonoBehaviour
{
    // shakeMagnitude(흔들기 강도): 흔들림의 강도를 정하는 변수
    // SerializeField: private 변수도 노출되도록 한다.
    [SerializeField] float shakeMagnitude = 0.2f;

    // 카메라의 position을 저장하는 변수
    Vector3 initPosition;

    void Start()
    {
        // 1. 카메라의 초기 위치를 저장한다.
        initPosition = transform.position;

        // 2. 흔들림을 위한 코루틴 시작
        StartCoroutine(Shake());
    }

    // Coroutine은 Update가 아닌 함수에서도 코드를 반복적으로 사용할 수 있게 한다.
    // Coroutine은 또한 매 프레임을 반환하는 Update보다 효율적일 수 있다.
    // IEnumerator: Corutine의 반환형
    IEnumerator Shake()
    {
        // 3. while (true) -> 계속 실행하게
        while (true)
        {
            // 4. 매 프레임마다 초기 위치에서 랜덤한 값만큼 떨어진 위치로 카메라를 이동
            // Random.insideUnitCircle * shakeMagnitude -> 반지름이 1에서 shakeMagnitude(흔들기 강도) 만큼 곱한만큼의 원 내부의 임의의 점을 만듬.
            // (Vector3) x,y 값만 나타내는 기존의 Random.insideUnitCircle에서, transform.position initialPosition가 Vector3기 때문에 형변환함.
            transform.position = initPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;

            // 5. 프레임마다 대기
            // 1프레임마다 실행되도록 조절해준다.
            yield return null;
        }
    }
}