using UnityEngine;
using System.Collections;

public class CameraAttackMove : MonoBehaviour
{
    public TurnManager turnManager;
    private Vector3 startPosition; 
    private Vector3 endPosition;
    private Quaternion startRotation; 
    private Quaternion endRotation;  

    Vector3 originalPosition;
    Quaternion originalRotation;

    //보드판 위치
    private int i;
    private int j;

    private bool isClear = false;

    //이동에 걸리는 시간
    public float duration = 1.0f;





    void Start()
    {

        //보드판 (0,1)로 초기 위치 설정
        i = 1; j = 0;
        startPosition = new Vector3(3.95f + 0.425f * j,   2.00f + 1,   -1.275f + 0.625f * i -1);
        endPosition = new Vector3(3.95f + 0.425f * (j+1),   2.00f + 1,   -1.275f + 0.625f * i -1);

        startRotation = Quaternion.Euler(30f, 0f, 0f); 
        endRotation = Quaternion.Euler(30f, 0f, 0f); 

        
        
    }





    void Update()
    {


        // 하나씩 실행
        if (isClear) {
            if (j>6) 
            {
                //끝내는 판정
                StartCoroutine(MoveRoutine(transform.position, originalPosition, transform.rotation, originalRotation, duration));
                isClear = false;
                

            }
            else 
            {
                isClear = false;
                StartCoroutine(MoveRoutine(startPosition, endPosition, startRotation, endRotation, duration));
            }
        }

    }

    public void cameraMove() {

        originalPosition = transform.position;
        originalRotation = transform.rotation;

        //보드판 (0,1)로 초기 위치 설정
        i = 1; j = 0;
        startPosition = new Vector3(3.95f + 0.425f * j,   2.00f + 1,   -1.275f + 0.625f * i -1);
        endPosition = new Vector3(3.95f + 0.425f * (j+1),   2.00f + 1,   -1.275f + 0.625f * i -1);


        StartCoroutine(timeDelay());
        
    }





    // 위치와 회전을 처리하는 코루틴 함수
    IEnumerator MoveRoutine(Vector3 startP, Vector3 endP, Quaternion startR, Quaternion endR, float moveDuration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            float t = elapsedTime / moveDuration;
            t = Mathf.SmoothStep(0f, 1f, t);
            
            // 위치는 Vector3.Lerp 
            transform.position = Vector3.Lerp(startP, endP, t);
            
            // 회전은 Quaternion.Slerp 
            transform.rotation = Quaternion.Slerp(startR, endR, t); 
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }



        // // 목표 위치(endP)에 도달할 때까지 반복
        // while (transform.position != endP)
        // {
        //     // 1 프레임 동안 이동할 거리를 계산: 속도 * 시간
        //     float step = currentSpeed * Time.deltaTime; 

        //     // 현재 위치에서 endP 방향으로 step만큼 이동
        //     transform.position = Vector3.MoveTowards(transform.position, endP, step);
            
        //     // 2. 회전 로직: Slerp 유지 (Lerp보다 Slerp가 회전에 적합)
        //     // 회전은 이동 속도에 맞춰야 하므로, 남은 거리에 비례하여 Slerp의 t 값을 계산합니다.
        //     float remainingDistance = Vector3.Distance(transform.position, endP);
        //     float totalDistance = Vector3.Distance(startP, endP);
            
        //     // 이동 진행률에 따라 회전 보간 (t=0이면 시작, t=1이면 끝)
        //     float t = 1f - (remainingDistance / totalDistance);
            
        //     transform.rotation = Quaternion.Slerp(startR, endR, t); 

        //     yield return null;
        // }




        // 최종 위치와 회전 확정
        transform.SetPositionAndRotation(endP, endR);

        //다음 실행용 값 수정
        j++;
        if (j<=7) isClear = true;
        startPosition = new Vector3(3.95f + 0.425f * (j-1),   2.00f + 1,   -1.275f + 0.625f * i -1);
        endPosition = new Vector3(3.95f + 0.425f * j,   2.00f + 1,   -1.275f + 0.625f * i -1);
    }


    IEnumerator timeDelay() {
        yield return new WaitForSecondsRealtime(2.0f);
        StartCoroutine(MoveRoutine(transform.position, startPosition, transform.rotation, startRotation, duration));
    }




}
