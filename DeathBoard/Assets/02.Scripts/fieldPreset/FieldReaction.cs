using UnityEngine;

public class FieldReaction : MonoBehaviour
{
    public bool haveCardNow;
    public FieldManager fieldManager;
    public int[] fieldPosition;
    GameObject thisField;
    public GameObject readyCard;
    public CardManager cardManager;
    void Awake()
    {
        cardManager = FindObjectOfType<CardManager>();
        if (cardManager == null)
        {
            Debug.LogError("CardManager를 찾을 수 없습니다.");
        }
    }
    void OnMouseDown()
    {
        readyCard = fieldManager.readyCard;
        SetCardOnField(readyCard);
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
            Destroy(setCard.GetComponent<CardReaction>());
        }
        else return;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisField = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
