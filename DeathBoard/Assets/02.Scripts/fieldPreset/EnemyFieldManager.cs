using UnityEngine;
using System.Collections.Generic;

public class EnemyFieldManager : MonoBehaviour
{
    public FieldManager fieldManager;
    public EnemyHandManager enemyHandManager;
    public void EnemyFieldSet()
    {
        if(DeckManager.EnemyHandList.Count < 1)
        {
            return;
        }
        else
        {
            int setCount = Random.Range(0, DeckManager.EnemyHandList.Count);
            Debug.Log(setCount);
            for (int i = 0; i < setCount; i++)
            {
                
                int space = findXY();
                int cardID = DeckManager.EnemyHandList[Random.Range(0, DeckManager.EnemyHandList.Count)];
                DeckManager.CardBrr[cardID - 60].Position[0] = space / 10;
                DeckManager.CardBrr[cardID - 60].Position[1] = space % 10;
                fieldManager.CurrntField[space / 10, space % 10] = cardID;
                Debug.Log(cardID);
                Debug.Log(fieldManager.CurrntField[space / 10, space % 10]);
                GameObject thisCard = GameObject.FindWithTag(cardID.ToString());
                GameObject[] thiscards = GameObject.FindGameObjectsWithTag(cardID.ToString());
                thisCard.transform.position = new Vector3(3.95f + 0.425f * (space % 10), 1.97f, -1.275f + 0.625f * (space / 10));
                thisCard.transform.rotation = Quaternion.Euler(90f, transform.eulerAngles.y, 180f);
                thiscards[1].transform.position = new Vector3(3.95f + 0.425f * (space % 10), 1.97f-0.001f, -1.275f + 0.625f * (space / 10));
                thiscards[1].transform.rotation = Quaternion.Euler(270f, transform.eulerAngles.y, 180f);
                DeckManager.EnemyHandList.Remove(cardID);
                enemyHandManager.rePlaceCard();
                
            }
                
        }
    }
    int findXY()
    {
        int check4 = 0, check3 = 0;
        int setPlace = 0;
        List<int> RandX = new List<int>();
        for(int i = 0; i < 7; i++)
        {
            if (fieldManager.CurrntField[3, i] == null) check4 = 1;
            if (fieldManager.CurrntField[2, i] == null) check3 = 1;
        }
        if (check4 == 0 && check3 == 0) return 0;
        if(check4 == 1 && check3 == 0) setPlace += 30;
        if (check3 == 1 && check4 == 0) setPlace += 20;
        if (check3 == 1 && check4 == 1) setPlace = Random.Range(2, 4) * 10;
        for(int i = 0;i < 7; i++)
        {
            if (fieldManager.CurrntField[(setPlace/10), i] == null)
            {
                RandX.Add(i);
            }
        }
        if(fieldManager.CurrntField[2, 0] == null){
            RandX.Add(0);
        }
        if (fieldManager.CurrntField[2, 6] == null)
        {
            RandX.Add(6);
        }
        for(int i = 0; i< 7; i++)
        {
            if(fieldManager.CurrntField[1, i] != null)
            {
                RandX.Add(i);
            }
        }
        setPlace += RandX[Random.Range(0, RandX.Count)];
        Debug.LogWarning("findXY 진행");
        Debug.Log(setPlace);
        return setPlace;
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
