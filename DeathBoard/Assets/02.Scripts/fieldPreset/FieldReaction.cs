using UnityEngine;

public class FieldReaction : MonoBehaviour
{
    public bool haveCardNow;
    public FieldManager fieldManager;
    public int[] fieldPosition;
    GameObject thisField;
    public GameObject readyCard;
    public CardManager cardManager;
    public CardSelecter cardSelecter;
    void OnMouseDown()
    {
        readyCard = fieldManager.readyCard;
        Debug.LogWarning("클릭 받음");
        if (this.fieldPosition[0] < 2)
        {
            SetCardOnField(readyCard);
        }
    }

    void SetCardOnField(GameObject setCard)
    {
        if (setCard != null && haveCardNow == false && fieldManager.getReady())
        {
            haveCardNow = true;
            CardStateManager stateScript = setCard.GetComponent<CardStateManager>();
            stateScript.thiscard.Position = fieldPosition;
            if (cardManager != null)
            {
                cardManager.PlayCard(setCard);
            }
            fieldManager.cardReady = false;
            fieldManager.readyCard = null;
            setCard.transform.position = thisField.transform.position;
            stateScript.thiscard.Position = fieldPosition;
            setCard.transform.rotation = Quaternion.Euler(90f, transform.eulerAngles.y, transform.eulerAngles.z);
            haveCardNow = true;
            Destroy(setCard.GetComponent<CardReaction>());
            cardSelecter = FindAnyObjectByType<CardSelecter>();
            StartCoroutine(cardSelecter.CameraSmoothMoveRoutine());
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
        haveCardNow = false;
    }

    void Strat()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
