using UnityEngine;
using System.Collections.Generic;
using System.Collections;
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
    public Player player;
    public Shoot shoot;
    public Scan scan;
    public GameObject tvObj;
    public bool HelpOn = false;
    //현재 턴(1->카드 드로우 단계, 2->카드 내려놓기 단계, 3->적카드 내려놓기 단계, 4->카드 효과실행 단계, 5->공격단계,6->뒷열 카드 전진 단계, 7->카드 효과실행 단계2, 8->공격단계2, 9->뒷열 카드 전진 단계2, 10->총격 선택, 11->상대방 검사 선택)


    private Transform TV_turn;
    private Transform TV_summon;
    private Transform TV_attack;
    private Transform TV_bullet;

    public void HelpCancel()
    {
        HelpOn = false;
    }
    void TvChange(string name) {
        TV_turn.localPosition = new Vector3(0f, 10f, 0f);
        TV_summon.localPosition = new Vector3(0f, 10f, 0f);
        TV_attack.localPosition = new Vector3(0f, 10f, 0f);
        TV_bullet.localPosition = new Vector3(0f, 10f, 0f);
        
        switch (name) {
            case "turn" :
                TV_turn.localPosition = new Vector3(0f, 0f, 0f);
                break;
            case "summon" :
                TV_summon.localPosition = new Vector3(0f, 0f, 0f);
                break;
            case "attack" :
                TV_attack.localPosition = new Vector3(0f, 0f, 0f);
                break;
            case "bullet" :
                 TV_bullet.localPosition = new Vector3(0f, 0f, 0f);
                 break;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HelpOn = false;
        currentturn = 1;
        turnend = false;
        Debug.Log("게임시작");
        TV_turn = tvObj.transform.Find("TV_turn");
        TV_summon = tvObj.transform.Find("TV_summon");
        TV_attack = tvObj.transform.Find("TV_attack");
        TV_bullet = tvObj.transform.Find("TV_bullet");
        
        TV_turn.localPosition = new Vector3(0f, 10f, 0f);
        TV_summon.localPosition = new Vector3(0f, 10f, 0f);
        TV_attack.localPosition = new Vector3(0f, 10f, 0f);
        TV_bullet.localPosition = new Vector3(0f, 10f, 0f);

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
            for(int i=1;i>=0;i--)
            {
                for(int j=0;j<7;j++)
                {
                    if(fieldManager.CurrntField[i,j] != null)
                    {
                        DeckManager.CardArr[fieldManager.CurrntField[i,j].Value].State += 1;
                    }
                    if(fieldManager.CurrntField[i,j] != null && DeckManager.CardArr[fieldManager.CurrntField[i,j].Value].State == 1)
                    {
                        effectManager.EffectCast(fieldManager.CurrntField[i,j].Value,2);
                    }
                    else if(fieldManager.CurrntField[i,j] != null && DeckManager.CardArr[fieldManager.CurrntField[i,j].Value].State == 101)
                    {
                        effectManager.EffectCast(fieldManager.CurrntField[i,j].Value,2);
                    }
                }
            }
            for(int i=2;i<4;i++)
            {
                for(int j=0;j<7;j++)
                {
                    if(fieldManager.CurrntField[i,j] != null)
                    {
                        DeckManager.CardBrr[fieldManager.CurrntField[i,j].Value-60].State++;
                    }
                    if(fieldManager.CurrntField[i,j] != null && DeckManager.CardBrr[fieldManager.CurrntField[i,j].Value-60].State == 1)
                    {
                        effectManager.EnemyEffectCast(fieldManager.CurrntField[i,j].Value,2);
                    }
                    else if(fieldManager.CurrntField[i,j] != null && DeckManager.CardBrr[fieldManager.CurrntField[i,j].Value-60].State == 101)
                    {
                        effectManager.EnemyEffectCast(fieldManager.CurrntField[i,j].Value,2);
                    }
                }
            }
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
            cardmanager.DrawHand();
            enemycardmanager.DrawHand();
            currentturn = 2;
            turnend = true;
        }
        else if(currentturn == 2)//카드내려놓기
        {
            TvChange("summon");
        }
        else if(currentturn == 3)//적카드내려놓기
        {
            StartCoroutine(enemyFieldManager.EnemyFieldSet());
            
        }
        else if(currentturn == 4)//카드효과실행
        {
            Debug.Log("효과턴");
            for(int i=1;i>=0;i--)
            {
                for(int j=0;j<7;j++)
                {
                    if(fieldManager.CurrntField[i,j] != null)
                    {
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
            for(int i=1;i>=0;i--)
            {
                for(int j=0;j<7;j++)
                {
                    if(fieldManager.CurrntField[i,j] != null)
                    {
                        DeckManager.CardArr[fieldManager.CurrntField[i,j].Value].ExHP = 0;
                        DeckManager.CardArr[fieldManager.CurrntField[i,j].Value].ExAP = 0;
                    }
                }
            }
            for(int i=1;i>=0;i--)
            {
                for(int j=0;j<7;j++)
                {
                    if(fieldManager.CurrntField[i,j] != null)
                    {
                        effectManager.EffectCast(fieldManager.CurrntField[i,j].Value,5);
                    }
                }
            }
            currentturn = 5;
            turnend = true;
        }
        else if(currentturn == 5)//공격단계
        {
            Debug.Log("공격격턴1");
            TvChange("attack");
            StartCoroutine(battlemanager.StartBattle());
            currentturn = 6; 
            turnend = false;
        }
        else if(currentturn == 6)//뒷열카드전진
        {
            Debug.Log("전진턴1");   
            StartCoroutine(movemanager.StartMoveTurn());
            currentturn = 7;
            turnend = false;
            
        }
        else if(currentturn == 7)//효과실행2
        {
            for(int i=1;i>=0;i--)
            {
                for(int j=0;j<7;j++)
                {
                    if(fieldManager.CurrntField[i,j] != null)
                    {
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
            for(int i=1;i>=0;i--)
            {
                for(int j=0;j<7;j++)
                {
                    if(fieldManager.CurrntField[i,j] != null)
                    {
                        DeckManager.CardArr[fieldManager.CurrntField[i,j].Value].ExHP = 0;
                        DeckManager.CardArr[fieldManager.CurrntField[i,j].Value].ExAP = 0;
                    }
                }
            }
            for(int i=1;i>=0;i--)
            {
                for(int j=0;j<7;j++)
                {
                    if(fieldManager.CurrntField[i,j] != null)
                    {
                        effectManager.EffectCast(fieldManager.CurrntField[i,j].Value,5);
                    }
                }
            }
            currentturn = 8;
            turnend = true;
        }
        else if (currentturn == 8)//공격단계2
        {
            
            TvChange("attack");
            StartCoroutine(battlemanager.StartBattle());
            currentturn = 9;
            turnend = false;
        }
        else if (currentturn == 9)//뒷열전진2
        {
            StartCoroutine(movemanager.StartMoveTurn());
            currentturn = 10;
            turnend = false;
        }
        else if (currentturn == 10)//총격선택
        {
            TvChange("bullet");
            
        }
        else if(currentturn == 11)//상대총격선택
        {
            StartCoroutine(scan.scanAttack());
            
        }
    }
    void Update()
    {
        if(turnend == true)
        {
            NextTurn();
        }
        if(player.user.HP<=0)
        {
            //유저승리
        }
        else if(player.enemy.HP<=0)
        {
            //적 승리
        }
    }
}
