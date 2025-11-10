using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public int readyCardID;
    public bool cardReady = false;
    public GameObject readyCard;
    public void SetCardReady(GameObject setCard)
    {
        cardReady = true;
        readyCard = setCard;
    }
    public bool getReady()
    {
        return cardReady;
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
