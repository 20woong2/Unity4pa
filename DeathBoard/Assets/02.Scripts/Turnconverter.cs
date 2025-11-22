using UnityEngine;

public class Trunconverter : MonoBehaviour
{
    public EffectManager effectManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown(){
        if(effectManager.effectstart == false)
        {
            if(TurnManager.currentturn==2)
            {
                TurnManager.currentturn = 3;
                TurnManager.turnend = true;
            }
            if (TurnManager.currentturn == 10)
            {
                TurnManager.currentturn = 11;
                TurnManager.turnend = true;
            }
        }
        
    }
}
