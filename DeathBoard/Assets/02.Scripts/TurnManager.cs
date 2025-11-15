using UnityEngine;
using System.Collections.Generic;
public class TurnManager : MonoBehaviour
{   
    public CardManager cardmanager;
    public EnemyCardManager enemycardmanager;
    public static int currentturn = 1;
    public static bool turnend = false;
    public MoveManager movemanager;
    public BattleManager battlemanager;
    public EnemyFieldManager enemyFieldManager;
    public EffectManager effectManager;
    public FieldManager fieldManager;
    //현재 턴(1->카드 드로우 단계, 2->카드 내려놓기 단계, 3->적카드 내려놓기 단계, 4->카드 효과실행 단계, 5->공격단계,6->뒷열 카드 전진 단계, 7->카드 효과실행 단계2, 8->공격단계2, 9->뒷열 카드 전진 단계2, 10->총격 선택, 11->상대방 검사 선택)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i=0;i<2;i++)
        {
            cardmanager.DrawHand();
            enemycardmanager.DrawHand();
        }
        
        NextTurn();
    }

    // Update is called once per frame
    
    public void NextTurn(){
        turnend = false;
        if(currentturn == 1)//드로우턴
        {
            cardmanager.DrawHand();
            enemycardmanager.DrawHand();
            currentturn = 2;
            turnend = true;
        }
        else if(currentturn == 2)//카드내려놓기
        {
            currentturn = 3;
            turnend = true;
        }
        else if(currentturn == 3)//적카드내려놓기
        {
            enemyFieldManager.EnemyFieldSet();
            currentturn = 4;
            turnend = true;
        }
        else if(currentturn == 4)//카드효과실행
        {
            
            for(int i=1;i>=0;i--)
            {
                for(int j=0;j<7;j++)
                {
                    if(fieldManager.CurrntField[i,j] != null)
                    {
                        Debug.LogWarning(fieldManager.CurrntField[i,j].Value);
                        effectManager.EffectCast(fieldManager.CurrntField[i,j].Value,3);
                        
                    }
                }
            }
            for(int i=2;i<4;i++)
            {
                for(int j=0;j<7;j++)
                {
                    if(fieldManager.CurrntField[i,j] != null)
                    {
                        effectManager.EnemyEffectCast(fieldManager.CurrntField[i,j].Value,3);
                    }
                }
            }
            currentturn = 5;
            turnend = true;
        }
        else if(currentturn == 5)//공격단계
        {
            currentturn = 6; 
            battlemanager.StartBattle();
            turnend = true;
                
        }
        else if(currentturn == 6)//뒷열카드전진
        {
            currentturn = 7;   
            movemanager.StartMoveTurn();
            turnend = true;
        }
        else if(currentturn == 7)//효과실행2
        {
            currentturn = 8;
            for(int i=0;i<DeckManager.HandList.Count;i++)
            {
                effectManager.EffectCast(DeckManager.HandList[i],3);
            }
            for(int i=0;i<DeckManager.EnemyHandList.Count;i++)
            {
                effectManager.EffectCast(DeckManager.EnemyHandList[i],3);
            }
            turnend = true;
        }
        else if (currentturn == 8)//공격단계2
        {
            currentturn = 9;
            battlemanager.StartBattle();
            turnend = true;
        }
        else if (currentturn == 9)//뒷열전진2
        {
            currentturn = 10;
            movemanager.StartMoveTurn();
            turnend = true;
        }
        else if (currentturn == 10)//총격선택
        {
            currentturn = 11;
            turnend = true;
        }
        else if(currentturn == 11)//상대총격선택
        {
            currentturn = 1;
            turnend = true;
        }
    }
    void Update()
    {
        if(turnend == true)
        {
            NextTurn();
        }
    }
}
