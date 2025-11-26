using UnityEngine;
using System.Collections;
public class MoveManager : MonoBehaviour //
{
    public FieldManager fieldManager;
    public TurnManager turnmanager;
    public EffectManager effectManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public IEnumerator StartMoveTurn()
    {
        for (int i = 0; i < 7; i++)
        {
            if (fieldManager.CurrntField[0, i] != null && fieldManager.CurrntField[1, i] == null)
            {
                
                fieldManager.CurrntField[1, i] = fieldManager.CurrntField[0, i];
                fieldManager.CurrntField[0, i] = null;
                DeckManager.CardArr[fieldManager.CurrntField[1, i].Value].Position[0] = 1;
                GameObject moveCard = GameObject.FindWithTag(fieldManager.CurrntField[1, i].ToString());
                GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[1, i].ToString());
                MoveCardSmooth moveCardSmooth1 = moveCard.GetComponent<MoveCardSmooth>();
                MoveCardSmooth moveCardSmooth2 = thiscards[1].GetComponent<MoveCardSmooth>();
                Vector3 targetPosition1 = new Vector3(3.95f + 0.425f * i, 2.00f, -1.275f + 0.625f);
                Vector3 targetPosition2 = new Vector3(3.95f + 0.425f * i, 2.00f-0.001f, -1.275f + 0.625f);
                Quaternion targetRotation1 = Quaternion.Euler(90f, 0f, 0f);
                Quaternion targetRotation2 = Quaternion.Euler(-90f, 0f, -180f);
                moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                
                //어차피 카드 있는지 검사 CurrntField로 하고 빈칸인지 카드 있는지 무슨 카드 있는지 다 저걸로 하는데 상수 더해서 카드 옵젝 옮기면 안되려나?
                //(3.95f + 0.425f * j, 2.00f, -1.275f + 0.625f * i) 가 필드 오브젝트 좌표이고 여기서 j는 가로줄 i는 세로줄
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
                yield return new WaitForSeconds(1.5f); 
            }
        }
        for (int i = 0; i < 7; i++)
        {
            if (fieldManager.CurrntField[3, i] != null && fieldManager.CurrntField[2, i] == null)
            {
                fieldManager.CurrntField[2, i] = fieldManager.CurrntField[3, i];
                fieldManager.CurrntField[3, i] = null;
                DeckManager.CardBrr[fieldManager.CurrntField[2, i].Value - 60].Position[0] = 2;
                GameObject moveCard = GameObject.FindWithTag(fieldManager.CurrntField[2, i].ToString());
                GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[2, i].ToString());
                MoveCardSmooth moveCardSmooth1 = moveCard.GetComponent<MoveCardSmooth>();
                MoveCardSmooth moveCardSmooth2 = thiscards[1].GetComponent<MoveCardSmooth>();
                Vector3 targetPosition1 = new Vector3(3.95f + 0.425f * i, 1.97f, -1.275f + 0.625f*2); 
                Vector3 targetPosition2 = new Vector3(3.95f + 0.425f * i, 1.97f-0.001f, -1.275f + 0.625f*2); 
                Quaternion targetRotation1 = Quaternion.Euler(90f, 0f, -180f);
                Quaternion targetRotation2 = Quaternion.Euler(-90f, 0f, -180f);
                moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
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
                yield return new WaitForSeconds(1.5f); 
            }
            
        }
        yield return new WaitForSeconds(1f); 
        TurnManager.turnend = true;
    }
}
