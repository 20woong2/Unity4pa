using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class HandManager : MonoBehaviour
{
    public int NumOfHand = 0;
    public List<GameObject> hand = new List<GameObject>();
    public GameObject Pos1;

    private readonly float PosX = 5.225f;
    private readonly float moveX = -1.3f * 0.12f; //카드가 추가될 때마다 좌측으로 1.3만큼 이동
    private readonly float PosY = 2.3f;
    private readonly float PosZ = -1.8f; //카드의 Y, Z축은 카드 매수와 관계없이 고정
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        Pos1 = GameObject.FindWithTag("Pos1");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public Vector3 PlaceNewCard()
    {
        Vector3 newCardPosition = new Vector3(NumOfHand * (moveX * (-1)) + Pos1.transform.position.x, PosY, PosZ - (0.001f * NumOfHand)); ; //카드의 가로 길이는 1
        return newCardPosition;
    }
    public void HandPlus(GameObject newCard)
    {
        this.NumOfHand++;
        hand.Add(newCard);
    }
    public void rePlaceCard()
    {
        for (int i = 0; i < hand.Count-1; i++)
        {
            GameObject thisCard = hand[i];
            CardReaction reactionScript = thisCard.GetComponent<CardReaction>();
            Vector3 position = reactionScript.originalPosition;
            Vector3 targetPosition = new Vector3(
                ((hand.Count-1) - i*2)*moveX + PosX,
                PosY,
                PosZ - (0.001f * i)
            );
            if (reactionScript.zoomIn == false)
            {
                position = targetPosition;
                thisCard.transform.position = position;
            }
            else
            {

                position = targetPosition;
                thisCard.transform.localPosition = position;
                reactionScript.originalPosition = position;
            }
        }
    }
}