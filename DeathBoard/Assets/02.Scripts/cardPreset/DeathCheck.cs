using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class DeathCheck : MonoBehaviour
{
    public FieldManager fieldManager;
    public EffectManager effectManager;
    private bool isWaiting = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<4;i++)
        {
            for(int j=0;j<7;j++)
            {
                if(fieldManager.CurrntField[i, j] != null)
                {
                    if(i<=1)
                    {
                        
                        
                            if(DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].HP + DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].ExHP <= 0)
                            {
                                if (!isWaiting)
                                {
                                    StartCoroutine(DelayAction(i,j));
                                }
                                
                            }
                    }
                    else if(i>1)
                    {
                        
                        
                            if(DeckManager.CardBrr[fieldManager.CurrntField[i, j].Value-60].HP + DeckManager.CardBrr[fieldManager.CurrntField[i, j].Value-60].ExHP <= 0)
                            {
                                if (!isWaiting)
                                {
                                    StartCoroutine(DelayAction(i,j));
                                }
                                
                            }
                    }
                }
                            
            }
        }
    }
    IEnumerator DelayAction(int i, int j)
    {
        isWaiting = true;
        // 지연 시간 (예: 1초)
        yield return new WaitForSeconds(0.5f);
        if(i<=1)
        {
            GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[i, j].Value.ToString());
                                DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].Position[0] = -1;
                                DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].Position[1] = -1;
                                fieldManager.CurrntField[i,j] = null;
                                thiscards[0].SetActive(false);
                                thiscards[1].SetActive(false);
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
        else if(i>1)
        {
            GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[i, j].Value.ToString());
            DeckManager.CardBrr[fieldManager.CurrntField[i, j].Value-60].Position[0] = -1;
                                DeckManager.CardBrr[fieldManager.CurrntField[i, j].Value-60].Position[1] = -1;
                                fieldManager.CurrntField[i,j] = null;
                                thiscards[0].SetActive(false);
                                thiscards[1].SetActive(false);
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
        isWaiting = false;
    }
}
