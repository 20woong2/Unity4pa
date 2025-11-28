using UnityEngine;

public class EscMenuManager : MonoBehaviour
{
    private bool isActived = false;
    public CardSelecter cardSelecter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardSelecter = FindAnyObjectByType<CardSelecter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TurnManager.currentturn == 2 || TurnManager.currentturn == 10)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(cardSelecter.CameraSmoothMoveRoutine());
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isActived)
            {
                GameObject.Find("Canvas").transform.Find("Esc Screen").gameObject.SetActive(true);
                isActived = true;
            }
            else
            {
                GameObject.Find("Canvas").transform.Find("Esc Screen").gameObject.SetActive(false);
                isActived = false;
            }
        }
    }
}
