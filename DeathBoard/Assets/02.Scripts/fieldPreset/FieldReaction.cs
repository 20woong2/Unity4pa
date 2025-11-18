using UnityEngine;
using System.Collections;
public class FieldReaction : MonoBehaviour
{
    public FieldManager fieldManager;
    public int[] fieldPosition;
    GameObject thisField;
    public GameObject readyCard;
    public CardManager cardManager;
    public CardSelecter cardSelecter;
    public DeckManager deckmanager;
    public EffectManager effectManager;
    void OnMouseDown()
    {
        readyCard = fieldManager.readyCard;
        if (this.fieldPosition[0] < 2)
        {
            StartCoroutine(SetCardOnField(readyCard));
        }
    }

    IEnumerator SetCardOnField(GameObject setCard)
    {
        if (setCard != null && fieldManager.CurrntField[fieldPosition[0], fieldPosition[1]] == null && fieldManager.getReady() && TurnManager.currentturn == 2)
        {
            CardStateManager stateScript = setCard.GetComponent<CardStateManager>();
            CardReaction reactionScript = setCard.GetComponent<CardReaction>();
            GameObject[] thiscards = GameObject.FindGameObjectsWithTag(setCard.tag);
            stateScript.thiscard.Position = (int[])fieldPosition.Clone();
            DeckManager.CardArr[stateScript.thiscard.CardId].Position = fieldPosition;
            fieldManager.CurrntField[DeckManager.CardArr[stateScript.thiscard.CardId].Position[0], DeckManager.CardArr[stateScript.thiscard.CardId].Position[1]] = stateScript.thiscard.CardId;
            if (cardManager != null)
            {
                cardManager.PlayCard(setCard);
            }
            fieldManager.cardReady = false;
            fieldManager.readyCard = null;
            DeckManager.CardArr[stateScript.thiscard.CardId].Position = (int[])fieldPosition.Clone();
            setCard.transform.position = thisField.transform.position;
            setCard.transform.rotation = Quaternion.Euler(90f, transform.eulerAngles.y, transform.eulerAngles.z);
            thiscards[1].transform.rotation = Quaternion.Euler(270f, transform.eulerAngles.y, 180f);
            reactionScript.originalPosition = thisField.transform.position;
            reactionScript.originalPosition.y = reactionScript.originalPosition.y - 0.001f;
            thiscards[1].transform.position = reactionScript.originalPosition;
            reactionScript.originalPosition.y = reactionScript.originalPosition.y + 0.001f;
            Destroy(setCard.GetComponent<CardReaction>());
            cardSelecter = FindAnyObjectByType<CardSelecter>();
            StartCoroutine(cardSelecter.CameraSmoothMoveRoutine());
            effectManager.EffectCast(stateScript.thiscardID, 1);
            if (DeckManager.CardArr[stateScript.thiscard.CardId].HP <= 0)
            {
                yield return new WaitForSeconds(0.5f);
                fieldManager.CurrntField[DeckManager.CardArr[stateScript.thiscard.CardId].Position[0], DeckManager.CardArr[stateScript.thiscard.CardId].Position[1]] = null;
                DeckManager.CardArr[stateScript.thiscard.CardId].Position[0] = -1;
                DeckManager.CardArr[stateScript.thiscard.CardId].Position[1] = -1;
                thiscards[0].SetActive(false);
                thiscards[1].SetActive(false);
            }
            //여기서 Effect Manager -> EffectAtSet 으로 접근
        }
        else
        {
            yield return new WaitForSeconds(0.1f); 
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        fieldManager = FindAnyObjectByType<FieldManager>();
        cardManager = FindAnyObjectByType<CardManager>();
        fieldPosition = new int[2];
        thisField = this.gameObject;
    }

    void Strat()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}