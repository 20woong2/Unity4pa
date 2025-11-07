using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class CardStateManager : MonoBehaviour
{
    public CardStruct thiscard;
    
    public void SetState(int cardID, GameObject newCard) // 복제된 카드에 정보 삽입
    {
        Sprite sprite = Resources.Load<Sprite>("CardImages/" + DeckManager.CardArr[cardID].ImgPath);
        if(sprite == null)
        {
            Debug.LogError($"스프라이트를 찾을 수 없습니다: {"CardImages/" + DeckManager.CardArr[cardID].ImgPath}");
            return;
        }
        SpriteRenderer sr = newCard.GetComponent<SpriteRenderer>();
        if(sr != null)
        {
            sr.sprite = sprite; // 2D 스프라이트 변경
        }
        else
        {
            Debug.LogWarning("SpriteRenderer 컴포넌트를 찾을 수 없습니다.");
        }
        thiscard = DeckManager.CardArr[cardID];
        Debug.Log("카드아이디 : " + thiscard.CardId);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
