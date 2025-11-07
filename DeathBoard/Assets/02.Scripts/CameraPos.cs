using UnityEngine;
using UnityEngine.EventSystems;

public class CameraPos : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    // Tag를 사용하는 이유? -> Tag가 속도가 더 빠름.

    // 메인카메라
    private GameObject mainCamera;

    // 기본 상태 시 카메라 위치
    private GameObject pos1;
    // 카드 선택 시 카메라 위치
    private GameObject pos2;

    // 현재 카메라 포지션과 로테이션을 저장할 변수
    private Vector3 currentPos;
    private Quaternion currentRot;

    void Start()
    {
        // 지정
        mainCamera = GameObject.FindWithTag("MainCamera");

        pos1 = GameObject.FindWithTag("Pos1");
        pos2 = GameObject.FindWithTag("Pos2");


        //첫 포지션은 포지션 1이겠지?
        // SetPositionAndRotation -> 포지션과 로테이션 세팅
        // mainCamera.transform.position = pos1.transform.position; 이런 형태로 굴려도 될거같긴 한데 두줄이라...
        mainCamera.transform.SetPositionAndRotation(currentPos, currentRot);
    }

    // FixedUpdate()는 Update()와 달리 Frame단위가 아닌 시간 단위로 측정되어 물리 연산을 할 때 유리하다.
    void FixedUpdate()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
