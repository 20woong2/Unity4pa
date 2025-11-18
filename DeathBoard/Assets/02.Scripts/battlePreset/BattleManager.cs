using UnityEngine;
using System.Collections;
public class BattleManager : MonoBehaviour //공격 받고 hp 0 됐을때 상호작용 만들어야 함
{
    public FieldManager fieldManager;
  //  public FieldReaction attackCardField;
    //public FieldReaction deffenceCardField;
    //public CardStateManager attackCardState;
    //public CardStateManager deffenceCardState;
    public TurnManager turnmanager;
    public Player player;
    bool end = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public IEnumerator StartBattle()
    {
        for (int i = 0; i < 7; i++)
        {
            if (fieldManager.CurrntField[1,i] != null)
            {
                MyCardAttack(fieldManager.CurrntField[1,i]);
                yield return new WaitForSeconds(0.5f); 
            }
        }
        for (int i = 0; i < 7; i++)
        {
            if (fieldManager.CurrntField[2,i] != null)
            {
                EnemyCardAttack(fieldManager.CurrntField[2,i]);
                yield return new WaitForSeconds(0.5f); 
            }
        }
        TurnManager.turnend = true;
    }
    public void MyCardAttack(int? attackCardID)
    {
        
        
        //왼쪽 위 적 기물 공격
        if(DeckManager.CardArr[attackCardID.Value].Position[1] >= 1)
        {
            if (fieldManager.CurrntField[2,DeckManager.CardArr[attackCardID.Value].Position[1]-1] != null)                                                                                 //상대 공격 줄에 카드 있다면 공격
            {
                DeckManager.CardBrr[fieldManager.CurrntField[2,DeckManager.CardArr[attackCardID.Value].Position[1]-1].Value-60].ExHP -= (DeckManager.CardArr[attackCardID.Value].AP + DeckManager.CardArr[attackCardID.Value].ExAP);
                if(DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1].Value-60].HP + DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1].Value-60].ExHP <= 0)
                {
                    DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1].Value-60].Position[0] = -1;
                    DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1].Value-60].Position[1] = -1;
                    
                    GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1].Value.ToString());
                    fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1] = null;
                    thiscards[0].SetActive(false);
                    thiscards[1].SetActive(false);
                    //카드 파괴, 필드에서 내리는 함수 작성
                }
            }
            else if(fieldManager.CurrntField[3,DeckManager.CardArr[attackCardID.Value].Position[1]-1] != null)
            {
                return;
            }
            else
            {
                player.enemy.CP += (DeckManager.CardArr[attackCardID.Value].AP + DeckManager.CardArr[attackCardID.Value].ExAP);
                //상대 직접 공격(공포 수치 상승)
            }
        }

        //오른쪽 위 적 기물 공격
        if(DeckManager.CardArr[attackCardID.Value].Position[1] <= 5)
        {
            if (fieldManager.CurrntField[2,DeckManager.CardArr[attackCardID.Value].Position[1]+1] != null)                                                                                 //상대 공격 줄에 카드 있다면 공격
            {
                DeckManager.CardBrr[fieldManager.CurrntField[2,DeckManager.CardArr[attackCardID.Value].Position[1]+1].Value-60].ExHP -= (DeckManager.CardArr[attackCardID.Value].AP + DeckManager.CardArr[attackCardID.Value].ExAP);
                if(DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1].Value-60].HP + DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1].Value-60].ExHP <= 0)
                {
                    DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1].Value-60].Position[0] = -1;
                    DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1].Value-60].Position[1] = -1;
                    
                    GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1].Value.ToString());
                    fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1] = null;
                    thiscards[0].SetActive(false);
                    thiscards[1].SetActive(false);
                    //카드 파괴, 필드에서 내리는 함수 작성
                }
            }
            else if(fieldManager.CurrntField[3,DeckManager.CardArr[attackCardID.Value].Position[1]+1] != null)
            {
                return;
            }
            else
            {
                player.enemy.CP += (DeckManager.CardArr[attackCardID.Value].AP + DeckManager.CardArr[attackCardID.Value].ExAP);
                //상대 직접 공격(공포 수치 상승)
            }
        }
    }
    public void EnemyCardAttack(int? attackCardID)
    {
        if (fieldManager.CurrntField[1,DeckManager.CardBrr[attackCardID.Value-60].Position[1]] != null)                                                                                 //상대 공격 줄에 카드 있다면 공격
        {
            DeckManager.CardArr[fieldManager.CurrntField[1,DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value].ExHP -= (DeckManager.CardBrr[attackCardID.Value-60].AP + DeckManager.CardBrr[attackCardID.Value-60].ExAP);
            if (DeckManager.CardArr[fieldManager.CurrntField[1, DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value].HP + DeckManager.CardArr[fieldManager.CurrntField[1, DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value].ExHP <= 0)
            {
                
                //카드 파괴, 필드에서 내리는 함수 작성
                DeckManager.CardArr[fieldManager.CurrntField[1, DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value].Position[0] = -1;
                DeckManager.CardArr[fieldManager.CurrntField[1, DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value].Position[1] = -1;


                GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[1, DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value.ToString());
                fieldManager.CurrntField[1, DeckManager.CardBrr[attackCardID.Value-60].Position[1]] = null;
                thiscards[0].SetActive(false);
                thiscards[1].SetActive(false);

            }
        }
        else if(fieldManager.CurrntField[0,DeckManager.CardBrr[attackCardID.Value-60].Position[1]] != null)
        {
            return;
        }
        else
        {
            player.user.CP += (DeckManager.CardBrr[attackCardID.Value - 60].AP + DeckManager.CardBrr[attackCardID.Value - 60].ExAP);
            //상대 직접 공격(공포 수치 상승)
        }
        
    }
}
