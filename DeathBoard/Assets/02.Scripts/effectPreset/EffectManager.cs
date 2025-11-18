using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public void EffectCast(int cardID , int timing)
    {
        if(timing == 1)
        {
            if(DeckManager.CardArr[cardID].AbilityId == 5)
            {

            }
            else if(DeckManager.CardArr[cardID].AbilityId == 8)
            {
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 9)
            {
                
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
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 2)
            {
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 4)
            {
                
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
        else if(timing == 5)
        {
            if(DeckManager.CardArr[cardID].AbilityId == 6)
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
