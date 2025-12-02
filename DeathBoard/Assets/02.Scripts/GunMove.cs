using UnityEngine;

public class GunMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 targetPosition;          // 이동할 목표 위치
    public Quaternion targetRotation;       // 회전 목표값
    public float smoothTime = 0.2f;
    public float rotationSmoothTime = 0.2f;

    private Vector3 velocity = Vector3.zero;
    private float rotationVelocity;         // 회전 속도(스무딩용)
    private bool shouldMove = false;

    void LateUpdate()
    {
        if (shouldMove)
        {
            // 위치 부드럽게 이동
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            // 회전 부드럽게 이동 (Slerp를 사용하여 부드러운 쿼터니언 보간)
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime / rotationSmoothTime);

            // 목표 근처에 도달하면 이동 종료
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f &&
                Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                shouldMove = false;
            }
        }
    }

    // 외부에서 호출해 위치와 회전 모두 설정하며 이동 시작
    public void StartMoving(Vector3 newTargetPosition, Quaternion newTargetRotation)
    {
        targetPosition = newTargetPosition;
        targetRotation = newTargetRotation;
        shouldMove = true;
    }
}
