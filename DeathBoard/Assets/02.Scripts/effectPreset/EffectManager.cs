using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public void EffectAtSet(GameObject setCard)
    {
        if (setCard == null) { return; }
        CardStateManager stateScript = setCard.GetComponent<CardStateManager>();
        if (stateScript.thiscard.EffectTiming == 1)
        {
            EffectActive(setCard);
        }
        else return;
    }
    void EffectActive(GameObject effctCard)
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
