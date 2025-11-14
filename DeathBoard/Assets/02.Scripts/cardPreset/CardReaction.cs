using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CardReaction : MonoBehaviour //카드와 마우스 간의 상호작용
{
    private Vector3 originalScale; // 확대에서 되돌아 갈 원래 크기
    public Vector3 originalPosition; // 원래 위치 저장을 위해 추가
    private readonly float hoverScaleFactor = 1.1f; // 확대
    private readonly float hoverZOffset = -0.1f; // Z축으로 나올 거리 (마우스 올려놓은 카드 강조)
    public GameObject previewCardUI; // 좌상단 카드 설명
    public bool zoomIn;
    public CardStateManager cardstatemanager;
    public FieldManager fieldManager;
    private GameObject thisCard;
    public CardSelecter cardSelecter;
    void Start()
    {
        originalScale = transform.localScale;
        originalPosition = transform.localPosition;  //기존의 크기, 위치 저장
        thisCard = this.gameObject;

        if (previewCardUI != null)
        {
            previewCardUI.SetActive(false);
            zoomIn = false;
        }
    }
    public void SetPreview(GameObject preview, int cardid)
    {
        previewCardUI = preview;    

        RawImage imageComponent;
        imageComponent = previewCardUI.GetComponent<RawImage>();
        Texture texture = Resources.Load<Texture>("CardImages/" + DeckManager.CardArr[cardid].ImgPath);
        if (imageComponent == null)
        {
            imageComponent = previewCardUI.GetComponentInChildren<RawImage>();
        }
        if (imageComponent != null)
        {
            
                if (texture != null)
                {
                    imageComponent.texture = texture;
                }
                else
                {
                    Debug.LogWarning($"경로에서 스프라이트를 찾을 수 없습니다: {"CardImages/" + DeckManager.CardArr[cardid].ImgPath}");
                }
        }
        else
            {
                Debug.LogWarning("Image 컴포넌트를 찾지 못했습니다.");
            }
    }
    public void SetImg(){

        
    }
    void OnMouseEnter()
    {
        if(int.Parse(thisCard.tag) < 60)
        {
            // 크기 확대
            originalPosition = transform.localPosition;
            transform.localScale = originalScale * hoverScaleFactor;

            // Z축 위치 조정 (앞으로 나오게)
            transform.localPosition = new Vector3(originalPosition.x, (originalPosition.y + 0.1f), originalPosition.z + hoverZOffset);

            // 미리보기 UI 활성화
            if (previewCardUI != null)
            {
                previewCardUI.SetActive(true);
                zoomIn = true;
            }
        }
    }
    void OnMouseDown()
    {
        if(int.Parse(thisCard.tag) < 60)
        {
            fieldManager = FindAnyObjectByType<FieldManager>();
            cardSelecter = FindAnyObjectByType<CardSelecter>();
            fieldManager.SetCardReady(thisCard);
            StartCoroutine(cardSelecter.CameraSmoothMoveRoutine());
        }
    }
    void OnMouseExit()
    {
        // 크기 복원
        transform.localScale = originalScale;

        // Z축 위치 복원
        transform.localPosition = originalPosition;

        // 미리보기 UI 비활성화
        if (previewCardUI != null)
        {
            previewCardUI.SetActive(false);
            zoomIn = false;
        }
    }
}
