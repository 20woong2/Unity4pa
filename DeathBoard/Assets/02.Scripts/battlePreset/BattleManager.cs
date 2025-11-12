using UnityEngine;

public class BattleManager : MonoBehaviour //공격 받고 hp 0 됐을때 상호작용 만들어야 함
{
    public FieldManager fieldManager;
    public FieldReaction attackCardField;
    public FieldReaction deffenceCardField;
    public CardStateManager attackCardState;
    public CardStateManager deffenceCardState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartBattle()
    {
        for (int i = 0; i < 7; i++)
        {
            if (fieldManager.CurrntField[1,i] != null)
            {
                MyCardAttack(fieldManager.CurrntField[1,i]);
            }
        }
        for (int i = 0; i < 7; i++)
        {
            if (fieldManager.CurrntField[2,i] != null)
            {
                EnemyCardAttack(fieldManager.CurrntField[2,i]);
            }
        }
    }
    public void MyCardAttack(int? attackCardID)
    {
        //왼쪽 위 적 기물 공격
        if(DeckManager.CardArr[attackCardID.Value].Position[1] >= 1)
        {
            if (fieldManager.CurrntField[2,DeckManager.CardArr[attackCardID.Value].Position[1]-1] != null)                                                                                 //상대 공격 줄에 카드 있다면 공격
            {
                DeckManager.CardArr[fieldManager.CurrntField[2,DeckManager.CardArr[attackCardID.Value].Position[1]-1].Value].HP -= DeckManager.CardArr[attackCardID.Value].AP;
            }
            else if(fieldManager.CurrntField[3,DeckManager.CardArr[attackCardID.Value].Position[1]-1] != null)
            {
                DeckManager.CardArr[fieldManager.CurrntField[3,DeckManager.CardArr[attackCardID.Value].Position[1]-1].Value].HP -= DeckManager.CardArr[attackCardID.Value].AP;
            }
            else
            {
                //상대 직접 공격(공포 수치 상승)
            }
        }

        //오른쪽 위 적 기물 공격
        if(DeckManager.CardArr[attackCardID.Value].Position[1] <= 5)
        {
            if (fieldManager.CurrntField[2,DeckManager.CardArr[attackCardID.Value].Position[1]+1] != null)                                                                                 //상대 공격 줄에 카드 있다면 공격
            {
                DeckManager.CardArr[fieldManager.CurrntField[2,DeckManager.CardArr[attackCardID.Value].Position[1]+1].Value].HP -= DeckManager.CardArr[attackCardID.Value].AP;
            }
            else if(fieldManager.CurrntField[3,DeckManager.CardArr[attackCardID.Value].Position[1]+1] != null)
            {
                DeckManager.CardArr[fieldManager.CurrntField[3,DeckManager.CardArr[attackCardID.Value].Position[1]+1].Value].HP -= DeckManager.CardArr[attackCardID.Value].AP;
            }
            else
            {
                //상대 직접 공격(공포 수치 상승)
            }
        }
    }
    public void EnemyCardAttack(int? attackCardID)
    {
        
        
        if (fieldManager.CurrntField[1,DeckManager.CardArr[attackCardID.Value].Position[1]] != null)                                                                                 //상대 공격 줄에 카드 있다면 공격
        {
            DeckManager.CardArr[fieldManager.CurrntField[1,DeckManager.CardArr[attackCardID.Value].Position[1]].Value].HP -= DeckManager.CardArr[attackCardID.Value].AP;
        }
        else if(fieldManager.CurrntField[0,DeckManager.CardArr[attackCardID.Value].Position[1]] != null)
        {
            DeckManager.CardArr[fieldManager.CurrntField[0,DeckManager.CardArr[attackCardID.Value].Position[1]].Value].HP -= DeckManager.CardArr[attackCardID.Value].AP;
        }
        else
        {
            //상대 직접 공격(공포 수치 상승)
        }
        
    }
}
