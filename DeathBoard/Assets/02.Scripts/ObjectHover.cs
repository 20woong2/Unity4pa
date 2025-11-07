using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ObjectHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{

    // 코드 작성 : 이진욱
    // Tag를 사용하는 이유? -> Tag가 속도가 더 빠름.

    [Header("Object Hover Height (in Mouse Hover)")]
    public float hoverHeight = 0.1f;

    [Header("Audio Settings")]
    public AudioClip clickSound;

    private AudioSource audioSource;
    

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
        audioSource = GetComponent<AudioSource>();
        mainCamera = GameObject.FindWithTag("MainCamera");
        pos1 = GameObject.FindWithTag("Pos1");
        pos2 = GameObject.FindWithTag("Pos2");

        // init
        mainCamera.transform.SetPositionAndRotation(pos1.transform.position, pos1.transform.rotation);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Vector3.up = new Vector3(0, 1, 0)
        isHovered = true;
        transform.position += Vector3.up * hoverHeight;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Vector3.down = new Vector3(0, -1, 0)
        isHovered = true;
        transform.position += Vector3.down * hoverHeight;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        audioSource.PlayOneShot(clickSound);
    }
}