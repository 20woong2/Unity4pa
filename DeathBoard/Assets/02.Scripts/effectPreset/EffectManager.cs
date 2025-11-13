using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public void EffectAtSet(int cardID)
    {
        if (cardID < 0) { return; }
        if (DeckManager.CardArr[cardID].EffectTiming == 1)
        {
            EffectActive(cardID);
        }
        else return;
    }
    public void EffectAtNextTurn(int cardID)
    {

    }
    public void EffectAtEffectTurn(int cardID)
    {
        if (cardID < 0) { return; }
        if (DeckManager.CardArr[cardID].EffectTiming == 3)
        {
            EffectActive(cardID);
        }
        else return;
    }
    public void EffectAtDestroy(int cardID)
    {
        if (cardID < 0) { return; }
        if (DeckManager.CardArr[cardID].EffectTiming == 4)
        {
            EffectActive(cardID);
        }
        else return;
    }
    public void EffectAtNextTurnOfAttacked(int cardID)
    {

    }
    void EffectActive(int cardID)
    {

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
