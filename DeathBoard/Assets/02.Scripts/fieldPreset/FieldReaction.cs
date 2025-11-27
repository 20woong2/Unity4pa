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
        if (this.fieldPosition[0] < 2 && effectManager.effectstart == false)
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


            MoveCardSmooth moveCardSmooth1 = setCard.GetComponent<MoveCardSmooth>();
            MoveCardSmooth moveCardSmooth2 = thiscards[1].GetComponent<MoveCardSmooth>();
            Vector3 targetPosition1 = new Vector3(thisField.transform.position.x, thisField.transform.position.y + 0.001f, thisField.transform.position.z);
            Vector3 targetPosition2 = new Vector3(thisField.transform.position.x, thisField.transform.position.y, thisField.transform.position.z);
            Quaternion targetRotation1 = Quaternion.Euler(90f, transform.eulerAngles.y, transform.eulerAngles.z);
            Quaternion targetRotation2 = Quaternion.Euler(270f, transform.eulerAngles.y, 180f);
            moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
            moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
            reactionScript.originalPosition = new Vector3(thisField.transform.position.x, thisField.transform.position.y + 0.001f, thisField.transform.position.z);
            
            cardSelecter = FindAnyObjectByType<CardSelecter>();
            StartCoroutine(cardSelecter.CameraSmoothMoveRoutine());
            yield return new WaitForSeconds(1f); 
            effectManager.EffectCast(stateScript.thiscardID, 1);
            for(int i=1;i>=0;i--)
            {
                for(int j=0;j<7;j++)
                {
                    if(fieldManager.CurrntField[i,j] != null)
                    {
                        DeckManager.CardArr[fieldManager.CurrntField[i,j].Value].ExHP = 0;
                        DeckManager.CardArr[fieldManager.CurrntField[i,j].Value].ExAP = 0;
                    }
                }
            }
            for(int i=1;i>=0;i--)
            {
                for(int j=0;j<7;j++)
                {
                    if(fieldManager.CurrntField[i,j] != null)
                    {
                        effectManager.EffectCast(fieldManager.CurrntField[i,j].Value,5);
                    }
                }
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