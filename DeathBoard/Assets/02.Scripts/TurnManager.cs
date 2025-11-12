using UnityEngine;

public class TurnManager : MonoBehaviour
{   
    public CardManager cardmanager;
    public static int currentturn = 1;
    public static bool turnend = false;
    //현재 턴(1->카드 드로우 단계, 2->카드 내려놓기 단계, 3->적카드 내려놓기 단계, 4->카드 효과실행 단계, 5->공격단계,6->카드 효과실행단계2)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i=0;i<2;i++)
        {
            cardmanager.DrawHand();
        }
        
        NextTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextTurn(){
        if(currentturn == 1)//드로우턴
        {
            cardmanager.DrawHand();
            currentturn = 2;
            NextTurn();
        }
        else if(currentturn == 2)
        {
            currentturn = 3;
        }
        else if(currentturn == 3)
        {
            currentturn = 4;               
        }
        else if(currentturn == 4)
        {
            currentturn = 5;     
        }
        else if(currentturn == 5)
        {
            currentturn = 6;     
        }
        else if(currentturn == 6)
        {
            currentturn = 1;      
        }
    }
}
