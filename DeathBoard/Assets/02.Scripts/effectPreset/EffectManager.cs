using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public FieldManager fieldManager;
    public Player player;
    public void EffectCast(int cardID , int timing)
    {
        if(timing == 1)
        {
            if(DeckManager.CardArr[cardID].AbilityId == 5)
            {
                if(DeckManager.CardArr[cardID].Position[0]==0 && fieldManager.CurrntField[3, DeckManager.CardArr[cardID].Position[1]] != null)
                {
                    DeckManager.CardBrr[fieldManager.CurrntField[3, DeckManager.CardArr[cardID].Position[1]].Value-60].ExHP -= 2;
                    if(DeckManager.CardBrr[fieldManager.CurrntField[3, DeckManager.CardArr[cardID].Position[1]].Value-60].ExHP + DeckManager.CardBrr[fieldManager.CurrntField[3, DeckManager.CardArr[cardID].Position[1]].Value-60].HP <= 0)
                    {
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[3, DeckManager.CardArr[cardID].Position[1]].Value.ToString());
                        fieldManager.CurrntField[3, DeckManager.CardArr[cardID].Position[1]] = null;
                        DeckManager.CardBrr[fieldManager.CurrntField[3, DeckManager.CardArr[cardID].Position[1]].Value-60].Position[0] = -1;
                        DeckManager.CardBrr[fieldManager.CurrntField[3, DeckManager.CardArr[cardID].Position[1]].Value-60].Position[1] = -1;
                        thiscards[0].SetActive(false);
                        thiscards[1].SetActive(false);
                    }
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 8)
            {
                player.user.HP -= 1;
                player.enemy.CP = 50;
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 9)
            {
                int BiggestAP = 0;
                int BigID = -1;
                for(int i=2;i<4;i++)
                {
                    for(int j=0;j<7;j++)
                    {
                        if(fieldManager.CurrntField[i,j] != null)
                        {
                            if(BiggestAP < (DeckManager.CardBrr[fieldManager.CurrntField[i,j].Value-60].AP + DeckManager.CardBrr[fieldManager.CurrntField[i,j].Value-60].ExAP))
                            {
                                BiggestAP = DeckManager.CardBrr[fieldManager.CurrntField[i,j].Value-60].AP + DeckManager.CardBrr[fieldManager.CurrntField[i,j].Value-60].ExAP;
                                BigID = fieldManager.CurrntField[i,j].Value;
                            }
                        }
                    }
                }
                if(BigID != -1)
                {
                    GameObject[] thiscards = GameObject.FindGameObjectsWithTag(BigID.ToString());
                    fieldManager.CurrntField[DeckManager.CardBrr[BigID-60].Position[0], DeckManager.CardBrr[BigID-60].Position[1]] = null;
                    DeckManager.CardBrr[BigID-60].Position[0] = -1;
                    DeckManager.CardBrr[BigID-60].Position[1] = -1;
                    thiscards[0].SetActive(false);
                    thiscards[1].SetActive(false);
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 10)
            {
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 11)
            {
                if (DeckManager.CardArr[cardID].Position[0] == 1)
                {
                    DeckManager.CardArr[cardID].ExHP -= 3;
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 12)
            {
                if (DeckManager.CardArr[cardID].Position[0] == 0)
                {
                    DeckManager.CardArr[cardID].ExHP += 3;
                }

            }
            else if(DeckManager.CardArr[cardID].AbilityId == 13)
            {
                player.user.CP += 5;
                DeckManager.CardArr[cardID].ExAP += 3;
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 17)
            {
                
                if (DeckManager.CardArr[cardID].Position[0] == 1)
                {
                    if(fieldManager.CurrntField[0,DeckManager.CardArr[cardID].Position[1]] != null)
                    {
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[0, DeckManager.CardArr[cardID].Position[1]].Value.ToString());
                        DeckManager.CardArr[fieldManager.CurrntField[0, DeckManager.CardArr[cardID].Position[1]].Value].Position[0] = -1;
                        DeckManager.CardArr[fieldManager.CurrntField[0, DeckManager.CardArr[cardID].Position[1]].Value].Position[1] = -1;
                        fieldManager.CurrntField[0, DeckManager.CardArr[cardID].Position[1]] = null;
                        thiscards[0].SetActive(false);
                        thiscards[1].SetActive(false);
                        player.user.CP -= 10;
                    }
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 21)
            {
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 22)
            {
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 23)
            {
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 24)
            {
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 25)
            {
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 26)
            {
                List<int> CardList = new List<int>();
                for(int i = 0; i < 4; i++)
                {
                    for(int j = 0; j < 7; j++){
                        if(fieldManager.CurrntField[i, j] != null && fieldManager.CurrntField[i, j].Value != cardID)
                        {
                            CardList.Add(fieldManager.CurrntField[i, j].Value);
                        }
                    }
                }
                for(int i = 0; i < 3; i++)
                {
                    if (CardList != null && CardList.Count > 0)
                    {
                        int target = Random.Range(0, CardList.Count);
                        int targetID = CardList[target];
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(targetID.ToString());
                        if (targetID < 60)
                        {
                            fieldManager.CurrntField[DeckManager.CardArr[targetID].Position[0], DeckManager.CardArr[targetID].Position[1]] = null;
                            DeckManager.CardArr[targetID].Position[0] = -1;
                            DeckManager.CardArr[targetID].Position[1] = -1;
                        }
                        else
                        {
                            fieldManager.CurrntField[DeckManager.CardBrr[targetID - 60].Position[0], DeckManager.CardBrr[targetID - 60].Position[1]] = null;
                            DeckManager.CardBrr[targetID - 60].Position[0] = -1;
                            DeckManager.CardBrr[targetID - 60].Position[1] = -1;
                        }
                        thiscards[0].SetActive(false);
                        thiscards[1].SetActive(false);
                        CardList.Remove(targetID);
                    }
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 27)
            {
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 29)
            {
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 30)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (fieldManager.CurrntField[0, i] != null) 
                    { 
                    int temp = fieldManager.CurrntField[0, i].Value;
                    fieldManager.CurrntField[0, i] = fieldManager.CurrntField[1, i];
                    fieldManager.CurrntField[1, i] = temp;
                    }else if(fieldManager.CurrntField[1, i] != null)
                    {
                        fieldManager.CurrntField[0, i] = fieldManager.CurrntField[1, i];
                        fieldManager.CurrntField[1, i] = null;
                    }
                    if (fieldManager.CurrntField[0, i] != null)
                    {
                        DeckManager.CardArr[fieldManager.CurrntField[0, i].Value].Position[0] = 0;
                        GameObject moveCard = GameObject.FindWithTag(fieldManager.CurrntField[0, i].ToString());
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[0, i].ToString());
                        moveCard.transform.position = new Vector3(3.95f + 0.425f * i, 2.00f, -1.275f);
                        thiscards[1].transform.position = new Vector3(3.95f + 0.425f * i, 2.00f - 0.001f, -1.275f);
                    }
                    if (fieldManager.CurrntField[1, i] != null)
                    {
                        DeckManager.CardArr[fieldManager.CurrntField[1, i].Value].Position[0] = 1;
                        GameObject moveCard = GameObject.FindWithTag(fieldManager.CurrntField[1, i].ToString());
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[1, i].ToString());
                        moveCard.transform.position = new Vector3(3.95f + 0.425f * i, 2.00f, -1.275f + 0.625f);
                        thiscards[1].transform.position = new Vector3(3.95f + 0.425f * i, 2.00f - 0.001f, -1.275f + 0.625f);
                    }

                    if (fieldManager.CurrntField[2, i] != null)
                    {
                        int temp2 = fieldManager.CurrntField[2, i].Value;
                        fieldManager.CurrntField[2, i] = fieldManager.CurrntField[3, i];
                        fieldManager.CurrntField[3, i] = temp2;
                    }
                    else if (fieldManager.CurrntField[3, i] != null)
                    {
                        fieldManager.CurrntField[2, i] = fieldManager.CurrntField[3, i];
                        fieldManager.CurrntField[3, i] = null;
                    }
                    if (fieldManager.CurrntField[2, i] != null)
                    {
                        DeckManager.CardBrr[fieldManager.CurrntField[2, i].Value - 60].Position[0] = 2;
                        GameObject moveCard = GameObject.FindWithTag(fieldManager.CurrntField[2, i].ToString());
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[2, i].ToString());
                        moveCard.transform.position = new Vector3(3.95f + 0.425f * i, 2.00f, -1.275f + 0.625f*2);
                        thiscards[1].transform.position = new Vector3(3.95f + 0.425f * i, 2.00f - 0.001f, -1.275f + 0.625f * 2);
                    }
                    if (fieldManager.CurrntField[3, i] != null)
                    {
                        DeckManager.CardBrr[fieldManager.CurrntField[3, i].Value - 60].Position[0] = 3;
                        GameObject moveCard = GameObject.FindWithTag(fieldManager.CurrntField[3, i].ToString());
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[3, i].ToString());
                        moveCard.transform.position = new Vector3(3.95f + 0.425f * i, 2.00f, -1.275f + 0.625f * 3);
                        thiscards[1].transform.position = new Vector3(3.95f + 0.425f * i, 2.00f - 0.001f, -1.275f +  0.625f * 3);
                    }
                }
            }
        }
        else if(timing == 2)
        {
            if(DeckManager.CardArr[cardID].AbilityId == 1)
            {
                DeckManager.CardArr[cardID].HP = 1;
                DeckManager.CardArr[cardID].ExHP = 0;
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 2)
            {
                if(DeckManager.CardArr[cardID].Position[0] == 0)
                {
                    GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[1, DeckManager.CardArr[cardID].Position[1]].Value.ToString());
                    DeckManager.CardArr[fieldManager.CurrntField[1, DeckManager.CardArr[cardID].Position[1]].Value].Position[0] = -1;
                    DeckManager.CardArr[fieldManager.CurrntField[1, DeckManager.CardArr[cardID].Position[1]].Value].Position[1] = -1;
                    fieldManager.CurrntField[1, DeckManager.CardArr[cardID].Position[1]] = null;
                    thiscards[0].SetActive(false);
                    thiscards[1].SetActive(false);
                    DeckManager.CardArr[cardID].ExAP += 2;
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 4)
            {
                
                GameObject[] thiscards = GameObject.FindGameObjectsWithTag(cardID.ToString());
                fieldManager.CurrntField[DeckManager.CardArr[cardID].Position[0], DeckManager.CardArr[cardID].Position[1]] = null;
                DeckManager.CardArr[cardID].Position[0] = -1;
                DeckManager.CardArr[cardID].Position[1] = -1;
                thiscards[0].SetActive(false);
                thiscards[1].SetActive(false);
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 6 && DeckManager.CardArr[cardID].State == 101)
            {
                DeckManager.CardArr[cardID].ExAP += 2;
            }
        }
        else if(timing == 3)
        {
            if(DeckManager.CardArr[cardID].AbilityId == 16)
            {
                player.user.CP += 10;
                player.enemy.CP += 10;
            }
        }
        else if(timing == 4)
        {
            if(DeckManager.CardArr[cardID].AbilityId == 14)
            {
                DeckManager.CardArr[fieldManager.CurrntField[0, DeckManager.CardArr[cardID].Position[1]].Value].AP += 2;
            }
        }
    }
    public void EnemyEffectCast(int cardID , int timing)
    {
        if(timing == 1)
        {
            if(DeckManager.CardBrr[cardID-60].AbilityId == 5)
            {

            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 8)
            {
                
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 9)
            {
                
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 10)
            {
                
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 11)
            {
                
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 12)
            {
                
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 13)
            {
                
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 17)
            {
                
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 21)
            {
                
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 22)
            {
                
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 23)
            {
                
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 24)
            {
                
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 25)
            {
                
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 26)
            {
                
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 27)
            {
                
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 29)
            {
                
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 30)
            {
                
            }
        }
        else if(timing == 2)
        {
            if(DeckManager.CardBrr[cardID-60].AbilityId == 1)
            {
                
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 2)
            {
                
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 4)
            {
                
            }
        }
        else if(timing == 3)
        {
            if(DeckManager.CardBrr[cardID-60].AbilityId == 16)
            {
                
            }
        }
        else if(timing == 4)
        {
            if(DeckManager.CardBrr[cardID-60].AbilityId == 14)
            {
                
            }
        }
        else if(timing == 5)
        {
            if(DeckManager.CardBrr[cardID-60].AbilityId == 6)
            {
                
            }
        }

        
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
