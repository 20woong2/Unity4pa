using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public class BattleManager : MonoBehaviour //공격 받고 hp 0 됐을때 상호작용 만들어야 함
{
    public FieldManager fieldManager;
    public EffectManager effectManager;
  //  public FieldReaction attackCardField;
    //public FieldReaction deffenceCardField;
    //public CardStateManager attackCardState;
    //public CardStateManager deffenceCardState;
    public TurnManager turnmanager;
    public Player player;
    private GameObject pos1;
    public CardSelecter cardselecter;
    public int DestroyPosition = -1; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public IEnumerator StartBattle()
    {
        GameObject mainCamera = Camera.main.gameObject; 
        BattleCameraMove battleCameraMove =  mainCamera.GetComponent<BattleCameraMove>();
        for (int i = 0; i < 7; i++)
        {
            if (fieldManager.CurrntField[1,i] != null)
            {
                GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[1,i].Value.ToString());
                Vector3 targetPosition = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y + 0.7f, thiscards[0].transform.position.z-0.5f);
                Quaternion targetRotation = Quaternion.Euler(55f, 0f, 0f);
                battleCameraMove.StartMoving(targetPosition, targetRotation);
                yield return new WaitForSeconds(1.5f); 
                MyCardAttack(fieldManager.CurrntField[1,i]);
                yield return new WaitForSeconds(1.5f); 
            }
        }
        for (int i = 0; i < 7; i++)
        {
            if (fieldManager.CurrntField[2,i] != null)
            {
                GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[2,i].Value.ToString());
                Vector3 targetPosition = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y + 0.7f, thiscards[0].transform.position.z+0.5f);
                Quaternion targetRotation = Quaternion.Euler(55f, 180f, 0f);
                battleCameraMove.StartMoving(targetPosition, targetRotation);
                yield return new WaitForSeconds(1.5f); 
                EnemyCardAttack(fieldManager.CurrntField[2,i]);
                yield return new WaitForSeconds(1.5f);
            }
        }
        pos1 = GameObject.FindWithTag("Pos1");
        battleCameraMove.StartMoving(pos1.transform.position, pos1.transform.rotation);
        yield return new WaitForSeconds(2f);
        TurnManager.turnend = true;
    }
    public void MyCardAttack(int? attackCardID)
    {
        
        Debug.Log("내카드 공격 실행");
        if(DeckManager.CardArr[attackCardID.Value].AP + DeckManager.CardArr[attackCardID.Value].ExAP > 0)
        {
            //왼쪽 위 적 기물 공격
            if(DeckManager.CardArr[attackCardID.Value].Position[1] >= 1)
            {
                if (fieldManager.CurrntField[2,DeckManager.CardArr[attackCardID.Value].Position[1]-1] != null)                                                                                 //상대 공격 줄에 카드 있다면 공격
                {
                    Debug.Log("왼 공격 실행");
                    DeckManager.CardBrr[fieldManager.CurrntField[2,DeckManager.CardArr[attackCardID.Value].Position[1]-1].Value-60].HP -= (DeckManager.CardArr[attackCardID.Value].AP + DeckManager.CardArr[attackCardID.Value].ExAP);
                    if(DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1].Value-60].HP + DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1].Value-60].ExHP <= 0)
                    {
                        DestroyPosition = DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1].Value-60].Position[1];
                        DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1].Value-60].Position[0] = -1;
                        DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1].Value-60].Position[1] = -1;
                        
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1].Value.ToString());
                        
                        foreach(GameObject card in thiscards) // thiscards[0]~[1]
                        {
                            FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                            if (fader != null)
                            {
                                fader.StartFadeOut();
                            }
                            else
                            {
                                Debug.LogWarning($"{gameObject.name} : fader가 발견되지 않습니다. 페이드 효과가 적용되지 않고 즉시 사라집니다.", fader);
                                card.SetActive(false);
                            }
                        }
                        effectManager.EnemyEffectCast(fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1].Value,4);
                        fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1] = null;
                        //카드 파괴, 필드에서 내리는 함수 작성
                    }
                    else if (DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1].Value-60].AbilityId == 6 && DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1].Value - 60].Position[0] != -1)
                    {
                        DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1].Value-60].State = 100;
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
                    Debug.Log("아군 직접공격 : " + (DeckManager.CardArr[attackCardID.Value].AP + DeckManager.CardArr[attackCardID.Value].ExAP) + " 공포게이지 : " + player.enemy.CP);
                }
            }

            //오른쪽 위 적 기물 공격
            if(DeckManager.CardArr[attackCardID.Value].Position[1] <= 5)
            {
                if (fieldManager.CurrntField[2,DeckManager.CardArr[attackCardID.Value].Position[1]+1] != null)                                                                                 //상대 공격 줄에 카드 있다면 공격
                {
                    Debug.Log("오른 공격 실행");
                    DeckManager.CardBrr[fieldManager.CurrntField[2,DeckManager.CardArr[attackCardID.Value].Position[1]+1].Value-60].HP -= (DeckManager.CardArr[attackCardID.Value].AP + DeckManager.CardArr[attackCardID.Value].ExAP);
                    if(DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1].Value-60].HP + DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1].Value-60].ExHP <= 0)
                    {
                        DestroyPosition = DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1].Value-60].Position[1];
                        DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1].Value-60].Position[0] = -1;
                        DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1].Value-60].Position[1] = -1;
                        
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1].Value.ToString());
                        
                        foreach (GameObject card in thiscards) // thiscards[0]~[1]
                        {
                            FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                            if (fader != null)
                            {
                                fader.StartFadeOut();
                            }
                            else
                            {
                                Debug.LogWarning($"{gameObject.name} : fader가 발견되지 않습니다. 페이드 효과가 적용되지 않고 즉시 사라집니다.", fader);
                                card.SetActive(false);
                            }
                        }
                        effectManager.EnemyEffectCast(fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1].Value,4);
                        fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1] = null;
                        //카드 파괴, 필드에서 내리는 함수 작성
                    }
                    else if (DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1].Value-60].AbilityId == 6 && DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1].Value - 60].Position[0] != -1)
                    {
                        DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1].Value-60].State = 100;
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
                    Debug.Log("아군 직접공격 : " + (DeckManager.CardArr[attackCardID.Value].AP + DeckManager.CardArr[attackCardID.Value].ExAP) + " 공포게이지 : " + player.enemy.CP);
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
        }
    }
    public void EnemyCardAttack(int? attackCardID)
    {
        if(DeckManager.CardBrr[attackCardID.Value-60].AP + DeckManager.CardBrr[attackCardID.Value-60].ExAP > 0)
        {
            if (fieldManager.CurrntField[1,DeckManager.CardBrr[attackCardID.Value-60].Position[1]] != null)                                                                                 //상대 공격 줄에 카드 있다면 공격
            {
                DeckManager.CardArr[fieldManager.CurrntField[1,DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value].HP -= (DeckManager.CardBrr[attackCardID.Value-60].AP + DeckManager.CardBrr[attackCardID.Value-60].ExAP);
                if (DeckManager.CardArr[fieldManager.CurrntField[1, DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value].HP + DeckManager.CardArr[fieldManager.CurrntField[1, DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value].ExHP <= 0)
                {
                    
                    //카드 파괴, 필드에서 내리는 함수 작성
                    
                    DestroyPosition = DeckManager.CardArr[fieldManager.CurrntField[1, DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value].Position[1];
                    DeckManager.CardArr[fieldManager.CurrntField[1, DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value].Position[0] = -1;
                    DeckManager.CardArr[fieldManager.CurrntField[1, DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value].Position[1] = -1;
                    GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[1, DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value.ToString());
                    
                    foreach (GameObject card in thiscards) // thiscards[0]~[1]
                    {
                        FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                        if (fader != null)
                        {
                            fader.StartFadeOut();
                        }
                        else
                        {
                            Debug.LogWarning($"{gameObject.name} : fader가 발견되지 않습니다. 페이드 효과가 적용되지 않고 즉시 사라집니다.", fader);
                            card.SetActive(false);
                        }
                    }

                    effectManager.EffectCast(fieldManager.CurrntField[1, DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value,4);
                    fieldManager.CurrntField[1, DeckManager.CardBrr[attackCardID.Value-60].Position[1]] = null;
                    
                }
                else if(DeckManager.CardArr[fieldManager.CurrntField[1,DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value].AbilityId == 6 && DeckManager.CardArr[fieldManager.CurrntField[1,DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value].Position[0] != -1)
                {
                    DeckManager.CardArr[fieldManager.CurrntField[1,DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value].State = 100;
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
                Debug.Log("상대 직접공격 : " + (DeckManager.CardBrr[attackCardID.Value - 60].AP + DeckManager.CardBrr[attackCardID.Value - 60].ExAP) + " 공포게이지 : " + player.user.CP);
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
        }
    }
}
