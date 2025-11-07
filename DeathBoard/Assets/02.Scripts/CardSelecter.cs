using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CardSelecter : MonoBehaviour, IPointerDownHandler
{

    // 코드 작성 : 이진욱
    // Tag를 사용하는 이유? -> Tag가 속도가 더 빠름.

    [Header("Move Duration")]
    public float moveDuration = 1.0f;

    // 메인카메라
    private GameObject mainCamera;
    // 기본 상태 시 카메라 위치를 담고있는 오브젝트
    private GameObject pos1;
    // 카드 선택 시 카메라 위치를 담고있는 오브젝트
    private GameObject pos2;

    // Hover, pressed state를 저장할 변수
    private bool isHovered = false;
    private bool isPressed = false;

    void Start()
    {
        // 지정
        mainCamera = GameObject.FindWithTag("MainCamera");
        pos1 = GameObject.FindWithTag("Pos1");
        pos2 = GameObject.FindWithTag("Pos2");

        // init
        mainCamera.transform.SetPositionAndRotation(pos1.transform.position, pos1.transform.rotation);
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        StartCoroutine(CameraSmoothMoveRoutine());
        /* 
        if (!isPressed)
        {
            isPressed = true;
            mainCamera.transform.SetPositionAndRotation(pos2.transform.position, pos2.transform.rotation);
        }
        else
        {
            isPressed = false;
            mainCamera.transform.SetPositionAndRotation(pos1.transform.position, pos1.transform.rotation);
        }
        */
    }

    IEnumerator CameraSmoothMoveRoutine()
    {

        float t;
        float elapsedTime = 0f;

        if (!isPressed)
        {
            isPressed = (!isPressed);
            while (elapsedTime < moveDuration)
            {
                elapsedTime += Time.deltaTime;
                t = elapsedTime / moveDuration;
                t = Mathf.SmoothStep(0f, 1f, t);
                mainCamera.transform.position = Vector3.Lerp(pos1.transform.position, pos2.transform.position, t);
                mainCamera.transform.rotation = Quaternion.Slerp(pos1.transform.rotation, pos2.transform.rotation, t);
                yield return null;
            }
            mainCamera.transform.SetPositionAndRotation(pos2.transform.position, pos2.transform.rotation);
        }
        else
        {
            isPressed = (!isPressed);
            while (elapsedTime < moveDuration)
            {
                elapsedTime += Time.deltaTime;
                t = elapsedTime / moveDuration;
                t = Mathf.SmoothStep(0f, 1f, t);
                mainCamera.transform.position = Vector3.Lerp(pos2.transform.position, pos1.transform.position, t);
                mainCamera.transform.rotation = Quaternion.Slerp(pos2.transform.rotation, pos1.transform.rotation, t);
                yield return null;
            }
            mainCamera.transform.SetPositionAndRotation(pos1.transform.position, pos1.transform.rotation);
        }
        
    }
}