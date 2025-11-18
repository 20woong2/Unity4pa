using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class CardStateManager : MonoBehaviour
{
    public CardStruct thiscard;
    public int thiscardID;
    public void SetState(int cardID, GameObject newCard) //        ī 忡          
    {
        Sprite sprite = Resources.Load<Sprite>("CardImages/" + DeckManager.CardArr[cardID].ImgPath);
        if (sprite == null)
        {
            Debug.LogError($"        Ʈ   ã           ϴ : {"CardImages/" + DeckManager.CardArr[cardID].ImgPath}");
            return;
        }
        SpriteRenderer sr = newCard.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sprite = sprite; // 2D         Ʈ     
        }
        else
        {
            Debug.LogWarning("SpriteRenderer       Ʈ   ã           ϴ .");
        }
        thiscardID = cardID;
        thiscard = DeckManager.CardArr[cardID];
    }

    public void SetBackCard(GameObject backcard, int cardid)
    {
        Sprite sprite = Resources.Load<Sprite>("CardImages/CardBackground");
        if (sprite == null)
        {
            Debug.LogError("카드 뒷면 이미지가 존재하지 않습니다.");
            return;
        }
        SpriteRenderer sr = backcard.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sprite = sprite; // 2D         Ʈ     
        }
        else
        {
            Debug.LogWarning("카드 뒷면 이미지가 존재하지 않습니다.");
        }
    }


    public void EnemySetState(int cardID, GameObject newCard) //        ī 忡          
    {
        Sprite sprite = Resources.Load<Sprite>("CardImages/" + DeckManager.CardBrr[cardID - 60].ImgPath);
        if (sprite == null)
        {
            Debug.LogError($"        Ʈ   ã           ϴ : {"CardImages/" + DeckManager.CardBrr[cardID - 60].ImgPath}");
            return;
        }
        SpriteRenderer sr = newCard.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sprite = sprite; // 2D         Ʈ     
        }
        else
        {
            Debug.LogWarning("SpriteRenderer       Ʈ   ã           ϴ .");
        }
        thiscardID = cardID;
        thiscard = DeckManager.CardBrr[cardID - 60];
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