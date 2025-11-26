using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class EnemyFieldManager : MonoBehaviour
{
    public FieldManager fieldManager;
    public EnemyHandManager enemyHandManager;
    public EffectManager effectManager;
    private GameObject pos1;
    public IEnumerator EnemyFieldSet()
    {
        
        if(DeckManager.EnemyHandList.Count < 1)
        {
            yield break;
        }
        else
        {
            GameObject mainCamera = Camera.main.gameObject; 
            BattleCameraMove battleCameraMove =  mainCamera.GetComponent<BattleCameraMove>();
            pos1 = GameObject.FindWithTag("Pos1");
            Vector3 targetPosition = new Vector3(pos1.transform.position.x, pos1.transform.position.y + 0.5f, pos1.transform.position.z+2.6f);
            Quaternion targetRotation = Quaternion.Euler(75f, 0f, 0f);
            battleCameraMove.StartMoving(targetPosition, targetRotation);
            yield return new WaitForSeconds(1.5f);
            int setCount = Random.Range(1, DeckManager.EnemyHandList.Count);
            for (int i = 0; i < setCount; i++)
            {
                
                int space = findXY();
                
                if (space == 0) yield break;
                int cardID = DeckManager.EnemyHandList[Random.Range(0, DeckManager.EnemyHandList.Count)];
                DeckManager.EnemyHandList.Remove(cardID);
                DeckManager.CardBrr[cardID - 60].Position[0] = space / 10;
                DeckManager.CardBrr[cardID - 60].Position[1] = space % 10;
                fieldManager.CurrntField[space / 10, space % 10] = cardID;
                
                GameObject thisCard = GameObject.FindWithTag(cardID.ToString());
                GameObject[] thiscards = GameObject.FindGameObjectsWithTag(cardID.ToString());
                thisCard.transform.position = new Vector3(3.95f + 0.425f * (space % 10), 1.97f, -1.275f + 0.625f * (space / 10));
                thisCard.transform.rotation = Quaternion.Euler(90f, transform.eulerAngles.y, 180f);
                thiscards[1].transform.position = new Vector3(3.95f + 0.425f * (space % 10), 1.97f-0.001f, -1.275f + 0.625f * (space / 10));
                thiscards[1].transform.rotation = Quaternion.Euler(270f, transform.eulerAngles.y, 180f);
                enemyHandManager.rePlaceCard();
                effectManager.EnemyEffectCast(cardID, 1);
                for(int p=1;p>=0;p--)
                {
                    for(int q=0;q<7;q++)
                    {
                        if(fieldManager.CurrntField[p,q] != null)
                        {
                            DeckManager.CardArr[fieldManager.CurrntField[p,q].Value].ExHP = 0;
                            DeckManager.CardArr[fieldManager.CurrntField[p,q].Value].ExAP = 0;
                        }
                    }
                }
                for(int p=2;p<4;p++)
                {
                    for(int q=0;q<7;q++)
                    {
                        if(fieldManager.CurrntField[p,q] != null)
                        {
                            DeckManager.CardBrr[fieldManager.CurrntField[p,q].Value-60].ExHP = 0;
                            DeckManager.CardBrr[fieldManager.CurrntField[p,q].Value-60].ExAP = 0;
                        }
                    }
                }
                for(int p=1;p>=0;p--)
                {
                    for(int q=0;q<7;q++)
                    {
                        if(fieldManager.CurrntField[p,q] != null)
                        {
                            effectManager.EffectCast(fieldManager.CurrntField[p,q].Value,5);
                        }
                    }
                }
                for(int p=2;p<4;p++)
                {
                    for(int q=0;q<7;q++)
                    {
                        if(fieldManager.CurrntField[p,q] != null)
                        {
                            effectManager.EnemyEffectCast(fieldManager.CurrntField[p,q].Value,5);
                        }
                    }
                }
                yield return new WaitForSeconds(1.5f); 
            }
            battleCameraMove.StartMoving(pos1.transform.position, pos1.transform.rotation);
            yield return new WaitForSeconds(2f); 
            TurnManager.currentturn = 4;
            TurnManager.turnend = true;
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
