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
    public EffectManager effectManager;
    public TurnManager turnManager;
    void Start()
    {
        fieldManager = FindAnyObjectByType<FieldManager>();
        cardSelecter = FindAnyObjectByType<CardSelecter>();
        effectManager = FindAnyObjectByType<EffectManager>();
        turnManager = FindAnyObjectByType<TurnManager>();
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
    void OnMouseEnter()
    {
        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(thisCard.tag);
        if (int.Parse(thisCard.tag) < 60 && thiscards[0] == thisCard && DeckManager.CardArr[int.Parse(thisCard.tag)].Position[0] == -1 && turnManager.HelpOn == false)
        {
            // 크기 확대
            originalPosition = transform.localPosition;
            transform.localScale = originalScale * hoverScaleFactor;

            // Z축 위치 조정 (앞으로 나오게)
            transform.localPosition = new Vector3(originalPosition.x, (originalPosition.y + 0.1f), originalPosition.z + hoverZOffset);

            thiscards[1].transform.localScale = originalScale * hoverScaleFactor;
            thiscards[1].transform.position = new Vector3(originalPosition.x, (originalPosition.y + 0.1f), originalPosition.z + hoverZOffset + 0.001f);
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
        if(turnManager.HelpOn == false)
        {
            Debug.Log("카드 클릭");
            if (int.Parse(thisCard.tag) < 60 && effectManager.effectstart == false && DeckManager.CardArr[int.Parse(thisCard.tag)].Position[0] == -1)
            {
                fieldManager.SetCardReady(thisCard);
                StartCoroutine(cardSelecter.CameraSmoothMoveRoutine());
            }
            if(int.Parse(thisCard.tag) < 60)
            {
                if(effectManager.effectstart == true && DeckManager.CardArr[int.Parse(thisCard.tag)].Position[0] != -1 && fieldManager.CurrntField[DeckManager.CardArr[int.Parse(thisCard.tag)].Position[0],DeckManager.CardArr[int.Parse(thisCard.tag)].Position[1]] != null && effectManager.effectCardID != null && int.Parse(thisCard.tag) != effectManager.effectCardID.Value)
                {
                    Debug.Log("설치선택");
                    effectManager.ChooseEffect(int.Parse(thisCard.tag) , effectManager.effectCardID.Value);
                }
                else if(effectManager.effectstart == true && effectManager.effectCardID != null && int.Parse(thisCard.tag) != effectManager.effectCardID.Value && DeckManager.CardArr[effectManager.effectCardID.Value].AbilityId == 25 && DeckManager.CardArr[int.Parse(thisCard.tag)].Position[0] == -1)
                {
                    Debug.Log("덱선택");
                    effectManager.ChooseEffect(int.Parse(thisCard.tag) , effectManager.effectCardID.Value);
                }
            }
            
            else if(int.Parse(thisCard.tag) >= 60)
            {
                if(effectManager.effectstart == true && DeckManager.CardBrr[int.Parse(thisCard.tag)-60].Position[0] != -1 && fieldManager.CurrntField[DeckManager.CardBrr[int.Parse(thisCard.tag)-60].Position[0],DeckManager.CardBrr[int.Parse(thisCard.tag)-60].Position[1]] != null && effectManager.effectCardID != null && int.Parse(thisCard.tag) != effectManager.effectCardID.Value)
                {
                    Debug.Log("설치선택");
                    effectManager.ChooseEffect(int.Parse(thisCard.tag) , effectManager.effectCardID.Value);
                }
            }
        }
    }
    void OnMouseExit()
    {
        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(thisCard.tag);
        if (int.Parse(thisCard.tag) < 60 && thiscards[0] == thisCard && DeckManager.CardArr[int.Parse(thisCard.tag)].Position[0] == -1)
        {
            // 크기 복원
            transform.localScale = originalScale;
            thiscards[1].transform.localScale = originalScale;
            // Z축 위치 복원
            transform.localPosition = originalPosition;
            thiscards[1].transform.position = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z + 0.001f);
            // 미리보기 UI 비활성화
            if (previewCardUI != null)
            {
                previewCardUI.SetActive(false);
                zoomIn = false;
            }
        }
    }
}
