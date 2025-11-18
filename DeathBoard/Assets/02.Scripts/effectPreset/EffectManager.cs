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
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 12)
            {
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 13)
            {
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 17)
            {
                
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
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 27)
            {
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 29)
            {
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 30)
            {
                
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
                
            }
        }
        else if(timing == 4)
        {
            if(DeckManager.CardArr[cardID].AbilityId == 14)
            {
                
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
