using UnityEngine;

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
        Debug.LogWarning("Ŭ�� ����");
        if (this.fieldPosition[0] < 2)
        {
            SetCardOnField(readyCard);
        }
    }

    void SetCardOnField(GameObject setCard)
    {
        if (setCard != null && fieldManager.CurrntField[fieldPosition[0], fieldPosition[1]] == null && fieldManager.getReady() && TurnManager.currentturn == 2)
        {
            CardStateManager stateScript = setCard.GetComponent<CardStateManager>();
            CardReaction reactionScript = setCard.GetComponent<CardReaction>();
            stateScript.thiscard.Position = fieldPosition;
            DeckManager.CardArr[stateScript.thiscard.CardId].Position = fieldPosition;
            fieldManager.CurrntField[DeckManager.CardArr[stateScript.thiscard.CardId].Position[0],DeckManager.CardArr[stateScript.thiscard.CardId].Position[1]] = stateScript.thiscard.CardId;
            if (cardManager != null)
            {
                cardManager.PlayCard(setCard);
            }
            fieldManager.cardReady = false;
            fieldManager.readyCard = null;
            setCard.transform.position = thisField.transform.position;
            setCard.transform.rotation = Quaternion.Euler(90f, transform.eulerAngles.y, transform.eulerAngles.z);
            reactionScript.originalPosition = thisField.transform.position;
            Destroy(setCard.GetComponent<CardReaction>());
            cardSelecter = FindAnyObjectByType<CardSelecter>();
            StartCoroutine(cardSelecter.CameraSmoothMoveRoutine());
            effectManager.EffectAtSet(stateScript.thiscardID);
            //여기서 Effect Manager -> EffectAtSet 으로 접근
        }
        else return;
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
