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
            attackCardField = fieldManager.field[i + 7].GetComponent<FieldReaction>();
            if (attackCardField.haveCardNow)
            {
                MyCardAttack(attackCardField.readyCard);
            }
        }
        for (int i = 0; i < 7; i++)
        {
            attackCardField = fieldManager.field[i + 14].GetComponent<FieldReaction>();
            if (attackCardField.haveCardNow)
            {
                EnemyCardAttack(attackCardField.readyCard);
            }
        }
    }
    public void MyCardAttack(GameObject attackCard)
    {
        attackCardState = attackCard.GetComponent<CardStateManager>();
        deffenceCardField = fieldManager.field[14 + attackCardState.thiscard.Position[1] - 1].GetComponent<FieldReaction>(); //첫번째 공격 대상 지정 (왼쪽 대각선)
        if (deffenceCardField.haveCardNow && attackCardState.thiscard.Position[1] - 1 >= 0)                                                                                 //상대 공격 줄에 카드 있다면 공격
        {
            deffenceCardState = deffenceCardField.readyCard.GetComponent<CardStateManager>();
            deffenceCardState.thiscard.HP -= attackCardState.thiscard.AP;
        }
        else
        {
            deffenceCardField = fieldManager.field[21 + attackCardState.thiscard.Position[1] - 1].GetComponent<FieldReaction>(); //상대 공격 줄에 카드가 없다면 그 라인 대기줄에 카드 있는지 확인 -> 있다면 공격
            if (deffenceCardField.haveCardNow && attackCardState.thiscard.Position[1] - 1 >= 0)
            {
                deffenceCardState = deffenceCardField.readyCard.GetComponent<CardStateManager>();
                deffenceCardState.thiscard.HP -= attackCardState.thiscard.AP;
            }
            else                                                                                                                //상대 세로줄이 전부 비었다면 상대 직접 공격
            {
                //상대 직접 공격 코드
            }
        }

        deffenceCardField = fieldManager.field[14 + attackCardState.thiscard.Position[1] + 1].GetComponent<FieldReaction>(); //두번째 공격 대상 지정 (오른쪽 대각선)
        if (deffenceCardField.haveCardNow && attackCardState.thiscard.Position[1] + 1 < 7)                                                                                 //상대 공격 줄에 카드 있다면 공격
        {
            deffenceCardState = deffenceCardField.readyCard.GetComponent<CardStateManager>();
            deffenceCardState.thiscard.HP -= attackCardState.thiscard.AP;
        }
        else
        {
            deffenceCardField = fieldManager.field[21 + attackCardState.thiscard.Position[1] + 1].GetComponent<FieldReaction>(); //상대 공격 줄에 카드가 없다면 그 라인 대기줄에 카드 있는지 확인 -> 있다면 공격
            if (deffenceCardField.haveCardNow && attackCardState.thiscard.Position[1] + 1 < 7)
            {
                deffenceCardState = deffenceCardField.readyCard.GetComponent<CardStateManager>();
                deffenceCardState.thiscard.HP -= attackCardState.thiscard.AP;
            }
            else                                                                                                                //상대 세로줄이 전부 비었다면 상대 직접 공격
            {
                //상대 직접 공격 코드
            }
        }
    }
    public void EnemyCardAttack(GameObject attackCard)
    {
        attackCardState = attackCard.GetComponent<CardStateManager>();
        deffenceCardField = fieldManager.field[7 + attackCardState.thiscard.Position[1]].GetComponent<FieldReaction>(); //공격 대상 지정 (정면)
        if (deffenceCardField.haveCardNow)                                                                                 //플레이어 공격 줄에 카드 있다면 공격
        {
            deffenceCardState = deffenceCardField.readyCard.GetComponent<CardStateManager>();
            deffenceCardState.thiscard.HP -= attackCardState.thiscard.AP;
        }
        else
        {
            deffenceCardField = fieldManager.field[attackCardState.thiscard.Position[1]].GetComponent<FieldReaction>(); //플레이어 공격 줄에 카드가 없다면 그 라인 대기줄에 카드 있는지 확인 -> 있다면 공격
            if (deffenceCardField.haveCardNow)
            {
                deffenceCardState = deffenceCardField.readyCard.GetComponent<CardStateManager>();
                deffenceCardState.thiscard.HP -= attackCardState.thiscard.AP;
            }
            else                                                                                                                //세로줄이 전부 비었다면 플레이어 직접 공격
            {
                //플레이어 직접 공격 코드
            }
        }
    }
}
