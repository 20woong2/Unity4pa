using UnityEngine;

public class Trunconverter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown(){
        if(TurnManager.currentturn==2)
        {
            TurnManager.currentturn = 3;
            TurnManager.turnend = true;
        }
    }
}
