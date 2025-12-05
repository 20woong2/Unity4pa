using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ObjectHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{

    // �ڵ� �ۼ� : ������
    // Tag�� ����ϴ� ����? -> Tag�� �ӵ��� �� ����.

    [Header("Object Hover Height (in Mouse Hover)")]
    public float hoverHeight = 0.1f;

    [Header("Audio Settings")]
    public AudioClip clickSound;

    private AudioSource audioSource;
    

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
        //transform.Find("Subtitle").gameObject.SetActive(true);
        //transform.Find("Spot Light").gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Vector3.down = new Vector3(0, -1, 0)
        isHovered = true;
        transform.position += Vector3.down * hoverHeight;
        //transform.Find("Subtitle").gameObject.SetActive(false);
        //transform.Find("Spot Light").gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        audioSource.PlayOneShot(clickSound);
    }
}