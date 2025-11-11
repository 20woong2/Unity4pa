using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CardSelecter : MonoBehaviour, IPointerDownHandler
{

    // �ڵ� �ۼ� : ������
    // Tag�� ����ϴ� ����? -> Tag�� �ӵ��� �� ����.

    [Header("Move Duration")]
    public float moveDuration = 1.0f;

    // ����ī�޶�
    private GameObject mainCamera;
    // �⺻ ���� �� ī�޶� ��ġ�� ����ִ� ������Ʈ
    private GameObject pos1;
    // ī�� ���� �� ī�޶� ��ġ�� ����ִ� ������Ʈ
    private GameObject pos2;

    // Hover, pressed state�� ������ ����
    private bool isHovered = false;
    private bool isPressed = false;

    void Start()
    {
        // ����
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

    public IEnumerator CameraSmoothMoveRoutine()
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