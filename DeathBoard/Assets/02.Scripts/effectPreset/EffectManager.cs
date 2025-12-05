using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
public class EffectManager : MonoBehaviour
{
    public FieldManager fieldManager;
    public FieldReaction fieldReaction;
    public HandManager handManager;
    public CardManager cardManager;
    public EnemyHandManager enemyHandManager;
    public EnemyCardManager enemyCardManager;
    public BattleManager battleManager;
    public Player player;
    public bool effectstart = false;
    public int? effectCardID = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        effectstart = false;
        effectCardID = null;
    }
    
    public void EffectCast(int cardID , int timing)
    {
        if(timing == 1)
        {
            if(DeckManager.CardArr[cardID].AbilityId == 5)
            {
                if(DeckManager.CardArr[cardID].Position[0]==0 && fieldManager.CurrntField[3, DeckManager.CardArr[cardID].Position[1]] != null)
                {
                    DeckManager.CardBrr[fieldManager.CurrntField[3, DeckManager.CardArr[cardID].Position[1]].Value-60].HP -= 2;
                    if(DeckManager.CardBrr[fieldManager.CurrntField[3, DeckManager.CardArr[cardID].Position[1]].Value-60].ExHP + DeckManager.CardBrr[fieldManager.CurrntField[3, DeckManager.CardArr[cardID].Position[1]].Value-60].HP <= 0)
                    {   
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[3, DeckManager.CardArr[cardID].Position[1]].Value.ToString());
                        fieldManager.CurrntField[3, DeckManager.CardArr[cardID].Position[1]] = null;
                        DeckManager.CardBrr[fieldManager.CurrntField[3, DeckManager.CardArr[cardID].Position[1]].Value-60].Position[0] = -1;
                        DeckManager.CardBrr[fieldManager.CurrntField[3, DeckManager.CardArr[cardID].Position[1]].Value-60].Position[1] = -1;
                        foreach (GameObject card in thiscards) // thiscards[0]~[1]
                                {
                                    FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                                    if (fader != null)
                                    {
                                        fader.StartFadeOut();
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"{gameObject.name} : fader�� �߰ߵ��� �ʽ��ϴ�. ���̵� ȿ���� ������� �ʰ� ��� ������ϴ�.", fader);
                                        card.SetActive(false);
                                    }
                                }
                    }
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 8)
            {
                player.user.HP -= 1;
                player.enemy.CP = 50;
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 9)
            {
                int BiggestAP = 0;
                int BigID = -1;
                for(int i=2;i<4;i++)
                {
                    for(int j=0;j<7;j++)
                    {
                        if(fieldManager.CurrntField[i,j] != null)
                        {
                            if(BiggestAP < (DeckManager.CardBrr[fieldManager.CurrntField[i,j].Value-60].AP + DeckManager.CardBrr[fieldManager.CurrntField[i,j].Value-60].ExAP))
                            {
                                BiggestAP = DeckManager.CardBrr[fieldManager.CurrntField[i,j].Value-60].AP + DeckManager.CardBrr[fieldManager.CurrntField[i,j].Value-60].ExAP;
                                BigID = fieldManager.CurrntField[i,j].Value;
                            }
                        }
                    }
                }
                if(BigID != -1)
                {
                    GameObject[] thiscards = GameObject.FindGameObjectsWithTag(BigID.ToString());
                    fieldManager.CurrntField[DeckManager.CardBrr[BigID-60].Position[0], DeckManager.CardBrr[BigID-60].Position[1]] = null;
                    DeckManager.CardBrr[BigID-60].Position[0] = -1;
                    DeckManager.CardBrr[BigID-60].Position[1] = -1;
                    foreach (GameObject card in thiscards) // thiscards[0]~[1]
                                {
                                    FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                                    if (fader != null)
                                    {
                                        fader.StartFadeOut();
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"{gameObject.name} : fader�� �߰ߵ��� �ʽ��ϴ�. ���̵� ȿ���� ������� �ʰ� ��� ������ϴ�.", fader);
                                        card.SetActive(false);
                                    }
                                }
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 10)
            {
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 11)
            {
                if (DeckManager.CardArr[cardID].Position[0] == 1)
                {
                    DeckManager.CardArr[cardID].HP -= 3;
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 12)
            {
                if (DeckManager.CardArr[cardID].Position[0] == 0)
                {
                    DeckManager.CardArr[cardID].HP += 3;
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 13)
            {
                player.user.CP += 5;
                DeckManager.CardArr[cardID].AP += 3;
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 17)
            {
                if (DeckManager.CardArr[cardID].Position[0] == 1)
                {
                    if(fieldManager.CurrntField[0,DeckManager.CardArr[cardID].Position[1]] != null)
                    {
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[0, DeckManager.CardArr[cardID].Position[1]].Value.ToString());
                        DeckManager.CardArr[fieldManager.CurrntField[0, DeckManager.CardArr[cardID].Position[1]].Value].Position[0] = -1;
                        DeckManager.CardArr[fieldManager.CurrntField[0, DeckManager.CardArr[cardID].Position[1]].Value].Position[1] = -1;
                        fieldManager.CurrntField[0, DeckManager.CardArr[cardID].Position[1]] = null;
                        foreach (GameObject card in thiscards) // thiscards[0]~[1]
                                {
                                    FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                                    if (fader != null)
                                    {
                                        fader.StartFadeOut();
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"{gameObject.name} : fader�� �߰ߵ��� �ʽ��ϴ�. ���̵� ȿ���� ������� �ʰ� ��� ������ϴ�.", fader);
                                        card.SetActive(false);
                                    }
                                }
                        player.user.CP -= 10;
                    }
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 21)
            {
                bool cardexist = false;
                for(int i=0;i<2;i++)
                {
                    for(int j=0; j<7;j++)
                    {
                        if(fieldManager.CurrntField[i,j] != null && fieldManager.CurrntField[i,j].Value != cardID)
                        {
                            cardexist = true;
                            break;
                        }
                    }
                }
                if(cardexist == true)
                {
                    effectstart = true;
                    effectCardID = cardID;
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 22)
            {
                bool cardexist = false;
                
                for(int i=0; i<7;i++)
                {
                    if(fieldManager.CurrntField[2,i] != null)
                    {
                        cardexist = true;
                        break;
                    }
                }
                
                if(cardexist == true)
                {
                    effectstart = true;
                    effectCardID = cardID;
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 23)
            {
                bool cardexist = false;
                for(int i=0; i<7;i++)
                {
                    if(fieldManager.CurrntField[1,i] != null && fieldManager.CurrntField[1,i].Value != cardID)
                    {
                        if(fieldManager.CurrntField[0,i] == null)
                        {
                            cardexist = true;
                            break;
                        }
                        else if(fieldManager.CurrntField[0,i].Value == cardID)
                        {
                            cardexist = true;
                            break;
                        }
                    }
                }

                if(cardexist == true)
                {
                    effectstart = true;
                    effectCardID = cardID;
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 24)
            {
                
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 25)
            {
                if (DeckManager.HandList.Count > 0)
                {
                    effectstart = true;
                    effectCardID = cardID;
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 26)
            {
                List<int> CardList = new List<int>();
                for(int i = 0; i < 4; i++)
                {
                    for(int j = 0; j < 7; j++){
                        if(fieldManager.CurrntField[i, j] != null && fieldManager.CurrntField[i, j].Value != cardID)
                        {
                            CardList.Add(fieldManager.CurrntField[i, j].Value);
                        }
                    }
                }
                for(int i = 0; i < 3; i++)
                {
                    if (CardList != null && CardList.Count > 0)
                    {
                        int target = Random.Range(0, CardList.Count);
                        int targetID = CardList[target];
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(targetID.ToString());
                        if (targetID < 60)
                        {
                            fieldManager.CurrntField[DeckManager.CardArr[targetID].Position[0], DeckManager.CardArr[targetID].Position[1]] = null;
                            DeckManager.CardArr[targetID].Position[0] = -1;
                            DeckManager.CardArr[targetID].Position[1] = -1;
                        }
                        else
                        {
                            fieldManager.CurrntField[DeckManager.CardBrr[targetID - 60].Position[0], DeckManager.CardBrr[targetID - 60].Position[1]] = null;
                            DeckManager.CardBrr[targetID - 60].Position[0] = -1;
                            DeckManager.CardBrr[targetID - 60].Position[1] = -1;
                        }
                        foreach (GameObject card in thiscards) // thiscards[0]~[1]
                                {
                                    FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                                    if (fader != null)
                                    {
                                        fader.StartFadeOut();
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"{gameObject.name} : fader�� �߰ߵ��� �ʽ��ϴ�. ���̵� ȿ���� ������� �ʰ� ��� ������ϴ�.", fader);
                                        card.SetActive(false);
                                    }
                                }
                        CardList.Remove(targetID);
                    }
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 27)
            {
                bool cardexist = false;
                for(int i=0;i<2;i++)
                {
                    for(int j=0; j<7;j++)
                    {
                        if(fieldManager.CurrntField[i,j] != null && fieldManager.CurrntField[i,j].Value != cardID)
                        {
                            cardexist = true;
                            break;
                        }
                    }
                }
                if(cardexist == true)
                {
                    effectstart = true;
                    effectCardID = cardID;
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 28)
            {
                for(int i=0;i<7;i++)
                {
                    if(fieldManager.CurrntField[1,i] != null && fieldManager.CurrntField[1,i].Value != cardID && fieldManager.CurrntField[2,i] != null)
                    {
                        DeckManager.CardArr[fieldManager.CurrntField[1,i].Value].AP -= 2;
                        DeckManager.CardArr[fieldManager.CurrntField[1,i].Value].HP += 2;
                    }
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 29)
            {
                bool cardexist = false;
                for(int i=2;i<4;i++)
                {
                    for(int j=0; j<7;j++)
                    {
                        if(fieldManager.CurrntField[i,j] != null && fieldManager.CurrntField[i,j].Value != cardID)
                        {
                            cardexist = true;
                            break;
                        }
                    }
                }
                if(cardexist == true)
                {
                    effectstart = true;
                    effectCardID = cardID;
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 30)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (fieldManager.CurrntField[0, i] != null) 
                    { 
                        int temp = fieldManager.CurrntField[0, i].Value;
                        fieldManager.CurrntField[0, i] = fieldManager.CurrntField[1, i];
                        fieldManager.CurrntField[1, i] = temp;
                    }
                    else if(fieldManager.CurrntField[1, i] != null)
                    {
                        fieldManager.CurrntField[0, i] = fieldManager.CurrntField[1, i];
                        fieldManager.CurrntField[1, i] = null;
                    }
                    if (fieldManager.CurrntField[0, i] != null)
                    {
                        DeckManager.CardArr[fieldManager.CurrntField[0, i].Value].Position[0] = 0;
                        GameObject moveCard = GameObject.FindWithTag(fieldManager.CurrntField[0, i].ToString());
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[0, i].ToString());
                        moveCard.transform.position = new Vector3(3.95f + 0.425f * i, 2.00f, -1.275f);
                        thiscards[1].transform.position = new Vector3(3.95f + 0.425f * i, 2.00f - 0.001f, -1.275f);
                    }
                    if (fieldManager.CurrntField[1, i] != null)
                    {
                        DeckManager.CardArr[fieldManager.CurrntField[1, i].Value].Position[0] = 1;
                        GameObject moveCard = GameObject.FindWithTag(fieldManager.CurrntField[1, i].ToString());
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[1, i].ToString());
                        moveCard.transform.position = new Vector3(3.95f + 0.425f * i, 2.00f, -1.275f + 0.625f);
                        thiscards[1].transform.position = new Vector3(3.95f + 0.425f * i, 2.00f - 0.001f, -1.275f + 0.625f);
                    }

                    if (fieldManager.CurrntField[2, i] != null)
                    {
                        int temp2 = fieldManager.CurrntField[2, i].Value;
                        fieldManager.CurrntField[2, i] = fieldManager.CurrntField[3, i];
                        fieldManager.CurrntField[3, i] = temp2;
                    }
                    else if (fieldManager.CurrntField[3, i] != null)
                    {
                        fieldManager.CurrntField[2, i] = fieldManager.CurrntField[3, i];
                        fieldManager.CurrntField[3, i] = null;
                    }
                    if (fieldManager.CurrntField[2, i] != null)
                    {
                        DeckManager.CardBrr[fieldManager.CurrntField[2, i].Value - 60].Position[0] = 2;
                        GameObject moveCard = GameObject.FindWithTag(fieldManager.CurrntField[2, i].ToString());
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[2, i].ToString());
                        moveCard.transform.position = new Vector3(3.95f + 0.425f * i, 2.00f, -1.275f + 0.625f*2);
                        thiscards[1].transform.position = new Vector3(3.95f + 0.425f * i, 2.00f - 0.001f, -1.275f + 0.625f * 2);
                    }
                    if (fieldManager.CurrntField[3, i] != null)
                    {
                        DeckManager.CardBrr[fieldManager.CurrntField[3, i].Value - 60].Position[0] = 3;
                        GameObject moveCard = GameObject.FindWithTag(fieldManager.CurrntField[3, i].ToString());
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[3, i].ToString());
                        moveCard.transform.position = new Vector3(3.95f + 0.425f * i, 2.00f, -1.275f + 0.625f * 3);
                        thiscards[1].transform.position = new Vector3(3.95f + 0.425f * i, 2.00f - 0.001f, -1.275f +  0.625f * 3);
                    }
                }
            }
        }
        else if(timing == 2)
        {
            if(DeckManager.CardArr[cardID].AbilityId == 1)
            {
                DeckManager.CardArr[cardID].HP = 1;
                DeckManager.CardArr[cardID].ExHP = 0;
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 2)
            {
                if(DeckManager.CardArr[cardID].Position[0] == 0)
                {
                    GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[1, DeckManager.CardArr[cardID].Position[1]].Value.ToString());
                    DeckManager.CardArr[fieldManager.CurrntField[1, DeckManager.CardArr[cardID].Position[1]].Value].Position[0] = -1;
                    DeckManager.CardArr[fieldManager.CurrntField[1, DeckManager.CardArr[cardID].Position[1]].Value].Position[1] = -1;
                    fieldManager.CurrntField[1, DeckManager.CardArr[cardID].Position[1]] = null;
                    foreach (GameObject card in thiscards) // thiscards[0]~[1]
                                {
                                    FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                                    if (fader != null)
                                    {
                                        fader.StartFadeOut();
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"{gameObject.name} : fader�� �߰ߵ��� �ʽ��ϴ�. ���̵� ȿ���� ������� �ʰ� ��� ������ϴ�.", fader);
                                        card.SetActive(false);
                                    }
                                }
                    DeckManager.CardArr[cardID].AP += 2;
                }
            }
            
            else if(DeckManager.CardArr[cardID].AbilityId == 4)
            {
                
                GameObject[] thiscards = GameObject.FindGameObjectsWithTag(cardID.ToString());
                fieldManager.CurrntField[DeckManager.CardArr[cardID].Position[0], DeckManager.CardArr[cardID].Position[1]] = null;
                DeckManager.CardArr[cardID].Position[0] = -1;
                DeckManager.CardArr[cardID].Position[1] = -1;
                foreach (GameObject card in thiscards) // thiscards[0]~[1]
                                {
                                    FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                                    if (fader != null)
                                    {
                                        fader.StartFadeOut();
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"{gameObject.name} : fader�� �߰ߵ��� �ʽ��ϴ�. ���̵� ȿ���� ������� �ʰ� ��� ������ϴ�.", fader);
                                        card.SetActive(false);
                                    }
                                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 6 && DeckManager.CardArr[cardID].State == 101)
            {
                DeckManager.CardArr[cardID].AP += 2;
            }
        }
        else if(timing == 3)
        {
            if(DeckManager.CardArr[cardID].AbilityId == 16)
            {
                player.user.CP += 10;
                player.enemy.CP += 10;
            }
        }
        else if(timing == 4)
        {
            if(DeckManager.CardArr[cardID].AbilityId == 14)
            {
                if (fieldManager.CurrntField[0, battleManager.DestroyPosition] != null)
                {
                    DeckManager.CardArr[fieldManager.CurrntField[0, battleManager.DestroyPosition].Value].AP += 2;
                }
            }
            battleManager.DestroyPosition = -1;
        }
        else if(timing == 5)
        {
            if(DeckManager.CardArr[cardID].AbilityId == 3)
            {
                if(DeckManager.CardArr[cardID].Position[1] > 0 && DeckManager.CardArr[cardID].Position[1] < 6 && fieldManager.CurrntField[DeckManager.CardArr[cardID].Position[0],DeckManager.CardArr[cardID].Position[1]-1] != null && fieldManager.CurrntField[DeckManager.CardArr[cardID].Position[0],DeckManager.CardArr[cardID].Position[1]+1] != null)
                {
                    DeckManager.CardArr[fieldManager.CurrntField[DeckManager.CardArr[cardID].Position[0],DeckManager.CardArr[cardID].Position[1]-1].Value].ExAP -= 1;
                    DeckManager.CardArr[fieldManager.CurrntField[DeckManager.CardArr[cardID].Position[0],DeckManager.CardArr[cardID].Position[1]+1].Value].ExAP -= 1;
                    DeckManager.CardArr[cardID].ExHP += 2;
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 7)
            {
                if(DeckManager.CardArr[cardID].Position[0] == 1 && fieldManager.CurrntField[2, DeckManager.CardArr[cardID].Position[1]] != null)
                {
                    DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[cardID].Position[1]].Value-60].ExAP += 1;
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 15)
            {
                if(DeckManager.CardArr[cardID].Position[1] > 0 && DeckManager.CardArr[cardID].Position[1] < 6 && fieldManager.CurrntField[DeckManager.CardArr[cardID].Position[0],DeckManager.CardArr[cardID].Position[1]-1] != null && fieldManager.CurrntField[DeckManager.CardArr[cardID].Position[0],DeckManager.CardArr[cardID].Position[1]+1] != null)
                {
                    DeckManager.CardArr[cardID].ExHP += 1;
                    DeckManager.CardArr[cardID].ExAP += 1;
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 18)
            {
                if(DeckManager.CardArr[cardID].Position[0] == 1 && fieldManager.CurrntField[2, DeckManager.CardArr[cardID].Position[1]] != null)
                {
                    DeckManager.CardArr[cardID].ExHP += 2;
                    DeckManager.CardArr[cardID].ExAP -= 2;
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 19)
            {
                if(DeckManager.CardArr[cardID].Position[0] == 1 && fieldManager.CurrntField[0, DeckManager.CardArr[cardID].Position[1]] != null)
                {
                    DeckManager.CardArr[cardID].ExAP += 2;
                }
            }
            else if(DeckManager.CardArr[cardID].AbilityId == 20)
            {
                if(DeckManager.CardArr[cardID].Position[0] == 0 && fieldManager.CurrntField[1, DeckManager.CardArr[cardID].Position[1]] != null)
                {
                    DeckManager.CardArr[fieldManager.CurrntField[1, DeckManager.CardArr[cardID].Position[1]].Value].ExHP += 3;
                }
            }
        }
    }
    public void ChooseEffect(int targetid, int cardid)
    {
        int effectnum = DeckManager.CardArr[cardid].AbilityId;
        if(effectnum == 21 && targetid < 60)
        {
            Debug.Log("21ī�� ����");

            DeckManager.CardArr[targetid].AP += 2;
            DeckManager.CardArr[targetid].HP += 2;
            effectstart = false;
            effectCardID = null;
        }
        else if(effectnum == 22 && targetid >= 60)
        {
            Debug.Log("22ī�� ����");
            GameObject[] thiscards = GameObject.FindGameObjectsWithTag(targetid.ToString());
            fieldManager.CurrntField[DeckManager.CardBrr[targetid-60].Position[0], DeckManager.CardBrr[targetid-60].Position[1]] = null;
            DeckManager.CardBrr[targetid-60].Position[0] = -1;
            DeckManager.CardBrr[targetid-60].Position[1] = -1;
            foreach (GameObject card in thiscards) // thiscards[0]~[1]
                                {
                                    FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                                    if (fader != null)
                                    {
                                        fader.StartFadeOut();
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"{gameObject.name} : fader�� �߰ߵ��� �ʽ��ϴ�. ���̵� ȿ���� ������� �ʰ� ��� ������ϴ�.", fader);
                                        card.SetActive(false);
                                    }
                                }
            effectstart = false;
            effectCardID = null;
        }
        else if(effectnum == 23 && targetid < 60)
        {
            if(fieldManager.CurrntField[1,DeckManager.CardArr[targetid].Position[1]] != null && fieldManager.CurrntField[0,DeckManager.CardArr[targetid].Position[1]] == null)
            {
                Debug.Log("23ī�� ����");
                fieldManager.CurrntField[1, DeckManager.CardArr[targetid].Position[1]] = null;
                DeckManager.CardArr[targetid].Position[0] = 0;
                fieldManager.CurrntField[0, DeckManager.CardArr[targetid].Position[1]] = targetid;
                GameObject[] thiscards = GameObject.FindGameObjectsWithTag(targetid.ToString());
                thiscards[0].transform.position = new Vector3(3.95f + 0.425f * DeckManager.CardArr[targetid].Position[1], 2.00f, -1.275f);
                thiscards[1].transform.position = new Vector3(3.95f + 0.425f * DeckManager.CardArr[targetid].Position[1], 2.00f-0.001f, -1.275f);
                effectstart = false;
                effectCardID = null;
            }
        }
        else if(effectnum == 25 && targetid < 60)
        {
            if(DeckManager.HandList.Contains(targetid))
            {
                Debug.Log("25ī�� ����");
                DeckManager.HandList.Remove(targetid);
                GameObject[] thiscards = GameObject.FindGameObjectsWithTag(targetid.ToString());
                foreach (GameObject card in thiscards) // thiscards[0]~[1]
                                {
                                    FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                                    if (fader != null)
                                    {
                                        fader.StartFadeOut();
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"{gameObject.name} : fader�� �߰ߵ��� �ʽ��ϴ�. ���̵� ȿ���� ������� �ʰ� ��� ������ϴ�.", fader);
                                        card.SetActive(false);
                                    }
                                }
                handManager.rePlaceCard();
                player.enemy.CP += 10;
                effectstart = false;
                effectCardID = null;
            }
        }
        else if(effectnum == 27 && targetid < 60)
        {
            Debug.Log("27ī�� ����");
            GameObject[] thiscards = GameObject.FindGameObjectsWithTag(targetid.ToString());
            fieldManager.CurrntField[DeckManager.CardArr[targetid].Position[0], DeckManager.CardArr[targetid].Position[1]] = null;
            DeckManager.CardArr[targetid].Position[0] = -1;
            DeckManager.CardArr[targetid].Position[1] = -1;
            foreach (GameObject card in thiscards) // thiscards[0]~[1]
                                {
                                    FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                                    if (fader != null)
                                    {
                                        fader.StartFadeOut();
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"{gameObject.name} : fader�� �߰ߵ��� �ʽ��ϴ�. ���̵� ȿ���� ������� �ʰ� ��� ������ϴ�.", fader);
                                        card.SetActive(false);
                                    }
                                }
            cardManager.DrawHand();
            cardManager.DrawHand();
            effectstart = false;
            effectCardID = null;
        }
        else if(effectnum == 29 && targetid >= 60)
        {
            Debug.Log("29ī�� ����");
            DeckManager.CardBrr[targetid-60].AP -= 2;
            effectstart = false;
            effectCardID = null;
        }
    }
    public void EnemyEffectCast(int cardID , int timing)
    {
        if(timing == 1)
        {
            if (DeckManager.CardBrr[cardID - 60].AbilityId == 5)
            {
                if (DeckManager.CardBrr[cardID - 60].Position[0] == 3 && fieldManager.CurrntField[0, DeckManager.CardBrr[cardID - 60].Position[1]] != null)
                {
                    DeckManager.CardArr[fieldManager.CurrntField[0, DeckManager.CardBrr[cardID - 60].Position[1]].Value - 60].HP -= 2;
                    if (DeckManager.CardArr[fieldManager.CurrntField[0, DeckManager.CardBrr[cardID - 60].Position[1]].Value - 60].ExHP + DeckManager.CardArr[fieldManager.CurrntField[0, DeckManager.CardBrr[cardID - 60].Position[1]].Value - 60].HP <= 0)
                    {
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[0, DeckManager.CardBrr[cardID - 60].Position[1]].Value.ToString());
                        fieldManager.CurrntField[0, DeckManager.CardBrr[cardID - 60].Position[1]] = null;
                        DeckManager.CardArr[fieldManager.CurrntField[0, DeckManager.CardBrr[cardID - 60].Position[1]].Value - 60].Position[0] = -1;
                        DeckManager.CardArr[fieldManager.CurrntField[0, DeckManager.CardBrr[cardID - 60].Position[1]].Value - 60].Position[1] = -1;
                        foreach (GameObject card in thiscards) // thiscards[0]~[1]
                                {
                                    FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                                    if (fader != null)
                                    {
                                        fader.StartFadeOut();
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"{gameObject.name} : fader�� �߰ߵ��� �ʽ��ϴ�. ���̵� ȿ���� ������� �ʰ� ��� ������ϴ�.", fader);
                                        card.SetActive(false);
                                    }
                                }
                    }
                }
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 8)
            {
                player.enemy.HP -= 1;
                player.user.CP = 50;
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 9)
            {
                int BiggestAP = 0;
                int BigID = -1;
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (fieldManager.CurrntField[i, j] != null)
                        {
                            if (BiggestAP < (DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].AP + DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].ExAP))
                            {
                                BiggestAP = DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].AP + DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].ExAP;
                                BigID = fieldManager.CurrntField[i, j].Value;
                            }
                        }
                    }
                }
                if (BigID != -1)
                {
                    GameObject[] thiscards = GameObject.FindGameObjectsWithTag(BigID.ToString());
                    fieldManager.CurrntField[DeckManager.CardArr[BigID].Position[0], DeckManager.CardArr[BigID].Position[1]] = null;
                    DeckManager.CardArr[BigID].Position[0] = -1;
                    DeckManager.CardArr[BigID].Position[1] = -1;
                    foreach (GameObject card in thiscards) // thiscards[0]~[1]
                                {
                                    FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                                    if (fader != null)
                                    {
                                        fader.StartFadeOut();
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"{gameObject.name} : fader�� �߰ߵ��� �ʽ��ϴ�. ���̵� ȿ���� ������� �ʰ� ��� ������ϴ�.", fader);
                                        card.SetActive(false);
                                    }
                                }
                }
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 10)
            {

            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 11)
            {
                if (DeckManager.CardBrr[cardID - 60].Position[0] == 2)
                {
                    DeckManager.CardBrr[cardID - 60].HP -= 3;
                }
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 12)
            {
                if (DeckManager.CardBrr[cardID - 60].Position[0] == 3)
                {
                    DeckManager.CardBrr[cardID - 60].HP += 3;
                }
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 13)
            {
                player.enemy.CP += 5;
                DeckManager.CardBrr[cardID - 60].AP += 3;
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 17)
            {
                if (DeckManager.CardBrr[cardID - 60].Position[0] == 2)
                {
                    if (fieldManager.CurrntField[3, DeckManager.CardBrr[cardID - 60].Position[1]] != null)
                    {
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[3, DeckManager.CardBrr[cardID - 60].Position[1]].Value.ToString());
                        DeckManager.CardBrr[fieldManager.CurrntField[3, DeckManager.CardBrr[cardID - 60].Position[1]].Value-60].Position[0] = -1;
                        DeckManager.CardBrr[fieldManager.CurrntField[3, DeckManager.CardBrr[cardID - 60].Position[1]].Value-60].Position[1] = -1;
                        fieldManager.CurrntField[3, DeckManager.CardBrr[cardID - 60].Position[1]] = null;
                        foreach (GameObject card in thiscards) // thiscards[0]~[1]
                                {
                                    FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                                    if (fader != null)
                                    {
                                        fader.StartFadeOut();
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"{gameObject.name} : fader�� �߰ߵ��� �ʽ��ϴ�. ���̵� ȿ���� ������� �ʰ� ��� ������ϴ�.", fader);
                                        card.SetActive(false);
                                    }
                                }
                        player.enemy.CP -= 10;
                    }
                }
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 21)
            {
                List<int> targetList = new List<int>();
                for (int i = 2; i < 4; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (fieldManager.CurrntField[i, j] != null && !(i == DeckManager.CardBrr[cardID - 60].Position[0] && j == DeckManager.CardBrr[cardID - 60].Position[1]))
                        {
                            targetList.Add(i * 10 + j);
                        }
                    }
                }
                if (targetList.Count > 0)
                {
                    int target = Random.Range(0, targetList.Count);
                    DeckManager.CardBrr[fieldManager.CurrntField[targetList[target] / 10, targetList[target] % 10].Value - 60].AP += 2;
                    DeckManager.CardBrr[fieldManager.CurrntField[targetList[target] / 10, targetList[target] % 10].Value - 60].HP += 2;
                }
                else
                {
                    return;
                }
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 22)
            {
                List<int> targetList = new List<int>();

                for (int j = 0; j < 7; j++)
                {
                    if (fieldManager.CurrntField[1, j] != null)
                    {
                        targetList.Add(j);
                    }
                }
                if (targetList.Count > 0)
                {
                    int target = Random.Range(0, targetList.Count);
                    GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[1, targetList[target]].Value.ToString());
                    DeckManager.CardArr[fieldManager.CurrntField[1, targetList[target]].Value].Position[0] = -1;
                    DeckManager.CardArr[fieldManager.CurrntField[1, targetList[target]].Value].Position[1] = -1;
                    fieldManager.CurrntField[1, targetList[target]] = null;
                    foreach (GameObject card in thiscards) // thiscards[0]~[1]
                                {
                                    FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                                    if (fader != null)
                                    {
                                        fader.StartFadeOut();
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"{gameObject.name} : fader�� �߰ߵ��� �ʽ��ϴ�. ���̵� ȿ���� ������� �ʰ� ��� ������ϴ�.", fader);
                                        card.SetActive(false);
                                    }
                                }
                }
                else
                {
                    return;
                }
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 23)
            {
                List<int> targetList = new List<int>();

                for (int j = 0; j < 7; j++)
                {
                    if (fieldManager.CurrntField[2, j] != null && fieldManager.CurrntField[3, j] == null && fieldManager.CurrntField[2, j].Value != cardID)
                    {
                        targetList.Add(j);
                    }
                }
                if (targetList.Count > 0)
                {
                    int target = Random.Range(0, targetList.Count);
                    GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[2, targetList[target]].Value.ToString());
                    DeckManager.CardBrr[fieldManager.CurrntField[2, targetList[target]].Value - 60].Position[0] = 3;
                    fieldManager.CurrntField[3, targetList[target]] = fieldManager.CurrntField[2, targetList[target]];
                    fieldManager.CurrntField[2, targetList[target]] = null;
                    thiscards[0].transform.position = new Vector3(3.95f + 0.425f * targetList[target], 2.00f, 0.6f);
                    thiscards[1].transform.position = new Vector3(3.95f + 0.425f * targetList[target], 2.00f - 0.001f, 0.6f);
                    //ī�� ������ �̵� �ڵ� �߰�
                }
                else
                {
                    return;
                }
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 24)
            {

            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 25)
            {
                if (DeckManager.EnemyHandList.Count > 0)
                {
                    int target = Random.Range(0, DeckManager.EnemyHandList.Count);
                    GameObject[] thiscards = GameObject.FindGameObjectsWithTag(DeckManager.EnemyHandList[target].ToString());
                    foreach (GameObject card in thiscards) // thiscards[0]~[1]
                                {
                                    FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                                    if (fader != null)
                                    {
                                        fader.StartFadeOut();
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"{gameObject.name} : fader�� �߰ߵ��� �ʽ��ϴ�. ���̵� ȿ���� ������� �ʰ� ��� ������ϴ�.", fader);
                                        card.SetActive(false);
                                    }
                                }
                    DeckManager.EnemyHandList.RemoveAt(target);
                    enemyHandManager.rePlaceCard();
                    player.user.CP += 10;
                }
                else
                {
                    return;
                }
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 26)
            {
                List<int> CardList = new List<int>();
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (fieldManager.CurrntField[i, j] != null && fieldManager.CurrntField[i, j].Value != cardID)
                        {
                            CardList.Add(fieldManager.CurrntField[i, j].Value);
                        }
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    if (CardList != null && CardList.Count > 0)
                    {
                        int target = Random.Range(0, CardList.Count);
                        int targetID = CardList[target];
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(targetID.ToString());
                        if (targetID < 60)
                        {
                            fieldManager.CurrntField[DeckManager.CardArr[targetID].Position[0], DeckManager.CardArr[targetID].Position[1]] = null;
                            DeckManager.CardArr[targetID].Position[0] = -1;
                            DeckManager.CardArr[targetID].Position[1] = -1;
                        }
                        else
                        {
                            fieldManager.CurrntField[DeckManager.CardBrr[targetID - 60].Position[0], DeckManager.CardBrr[targetID - 60].Position[1]] = null;
                            DeckManager.CardBrr[targetID - 60].Position[0] = -1;
                            DeckManager.CardBrr[targetID - 60].Position[1] = -1;
                        }
                        foreach (GameObject card in thiscards) // thiscards[0]~[1]
                                {
                                    FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                                    if (fader != null)
                                    {
                                        fader.StartFadeOut();
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"{gameObject.name} : fader�� �߰ߵ��� �ʽ��ϴ�. ���̵� ȿ���� ������� �ʰ� ��� ������ϴ�.", fader);
                                        card.SetActive(false);
                                    }
                                }
                        CardList.Remove(targetID);
                    }
                }
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 27)
            {
                List<int> targetList = new List<int>();
                for (int i = 2; i < 4; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (fieldManager.CurrntField[i, j] != null && !(i == DeckManager.CardBrr[cardID - 60].Position[0] && j == DeckManager.CardBrr[cardID - 60].Position[1]))
                        {
                            targetList.Add(i * 10 + j);
                        }
                    }
                }
                if (targetList.Count > 0)
                {
                    int target = Random.Range(0, targetList.Count);
                    GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[targetList[target] / 10, targetList[target] % 10].Value.ToString());

                    DeckManager.CardBrr[fieldManager.CurrntField[targetList[target] / 10, targetList[target] % 10].Value - 60].Position[0] = -1;
                    DeckManager.CardBrr[fieldManager.CurrntField[targetList[target] / 10, targetList[target] % 10].Value - 60].Position[1] = -1;
                    fieldManager.CurrntField[targetList[target] / 10, targetList[target] % 10] = null;
                    foreach (GameObject card in thiscards) // thiscards[0]~[1]
                                {
                                    FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                                    if (fader != null)
                                    {
                                        fader.StartFadeOut();
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"{gameObject.name} : fader�� �߰ߵ��� �ʽ��ϴ�. ���̵� ȿ���� ������� �ʰ� ��� ������ϴ�.", fader);
                                        card.SetActive(false);
                                    }
                                }
                    enemyCardManager.DrawHand();
                    enemyCardManager.DrawHand();
                }
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 29)
            {
                List<int> targetList = new List<int>();
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (fieldManager.CurrntField[i, j] != null)
                        {
                            targetList.Add(i * 10 + j);
                        }
                    }
                }
                if (targetList.Count > 0)
                {
                    int target = Random.Range(0, targetList.Count);
                    DeckManager.CardArr[fieldManager.CurrntField[targetList[target] / 10, targetList[target] % 10].Value].AP -= 2;
                }
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 28)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (fieldManager.CurrntField[2, i] != null && fieldManager.CurrntField[2, i].Value != cardID && fieldManager.CurrntField[1, i] != null)
                    {
                        DeckManager.CardBrr[fieldManager.CurrntField[2, i].Value - 60].AP -= 2;
                        DeckManager.CardBrr[fieldManager.CurrntField[2, i].Value - 60].HP += 2;
                    }
                }
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 30)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (fieldManager.CurrntField[0, i] != null)
                    {
                        int temp = fieldManager.CurrntField[0, i].Value;
                        fieldManager.CurrntField[0, i] = fieldManager.CurrntField[1, i];
                        fieldManager.CurrntField[1, i] = temp;
                    }
                    else if (fieldManager.CurrntField[1, i] != null)
                    {
                        fieldManager.CurrntField[0, i] = fieldManager.CurrntField[1, i];
                        fieldManager.CurrntField[1, i] = null;
                    }
                    if (fieldManager.CurrntField[0, i] != null)
                    {
                        DeckManager.CardArr[fieldManager.CurrntField[0, i].Value].Position[0] = 0;
                        GameObject moveCard = GameObject.FindWithTag(fieldManager.CurrntField[0, i].ToString());
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[0, i].ToString());
                        moveCard.transform.position = new Vector3(3.95f + 0.425f * i, 2.00f, -1.275f);
                        thiscards[1].transform.position = new Vector3(3.95f + 0.425f * i, 2.00f - 0.001f, -1.275f);
                    }
                    if (fieldManager.CurrntField[1, i] != null)
                    {
                        DeckManager.CardArr[fieldManager.CurrntField[1, i].Value].Position[0] = 1;
                        GameObject moveCard = GameObject.FindWithTag(fieldManager.CurrntField[1, i].ToString());
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[1, i].ToString());
                        moveCard.transform.position = new Vector3(3.95f + 0.425f * i, 2.00f, -1.275f + 0.625f);
                        thiscards[1].transform.position = new Vector3(3.95f + 0.425f * i, 2.00f - 0.001f, -1.275f + 0.625f);
                    }

                    if (fieldManager.CurrntField[2, i] != null)
                    {
                        int temp2 = fieldManager.CurrntField[2, i].Value;
                        fieldManager.CurrntField[2, i] = fieldManager.CurrntField[3, i];
                        fieldManager.CurrntField[3, i] = temp2;
                    }
                    else if (fieldManager.CurrntField[3, i] != null)
                    {
                        fieldManager.CurrntField[2, i] = fieldManager.CurrntField[3, i];
                        fieldManager.CurrntField[3, i] = null;
                    }
                    if (fieldManager.CurrntField[2, i] != null)
                    {
                        DeckManager.CardBrr[fieldManager.CurrntField[2, i].Value - 60].Position[0] = 2;
                        GameObject moveCard = GameObject.FindWithTag(fieldManager.CurrntField[2, i].ToString());
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[2, i].ToString());
                        moveCard.transform.position = new Vector3(3.95f + 0.425f * i, 2.00f, -1.275f + 0.625f * 2);
                        thiscards[1].transform.position = new Vector3(3.95f + 0.425f * i, 2.00f - 0.001f, -1.275f + 0.625f * 2);
                    }
                    if (fieldManager.CurrntField[3, i] != null)
                    {
                        DeckManager.CardBrr[fieldManager.CurrntField[3, i].Value - 60].Position[0] = 3;
                        GameObject moveCard = GameObject.FindWithTag(fieldManager.CurrntField[3, i].ToString());
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[3, i].ToString());
                        moveCard.transform.position = new Vector3(3.95f + 0.425f * i, 2.00f, -1.275f + 0.625f * 3);
                        thiscards[1].transform.position = new Vector3(3.95f + 0.425f * i, 2.00f - 0.001f, -1.275f + 0.625f * 3);
                    }
                }
            }
        }
        else if(timing == 2)
        {
            if(DeckManager.CardBrr[cardID-60].AbilityId == 1)
            {
                DeckManager.CardBrr[cardID - 60].HP = 1;
                DeckManager.CardBrr[cardID - 60].ExHP = 0;
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 2)
            {
                if (DeckManager.CardBrr[cardID - 60].Position[0] == 3)
                {
                    GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[2, DeckManager.CardBrr[cardID - 60].Position[1]].Value.ToString());
                    DeckManager.CardBrr[fieldManager.CurrntField[1, DeckManager.CardBrr[cardID - 60].Position[1]].Value].Position[0] = -1;
                    DeckManager.CardBrr[fieldManager.CurrntField[1, DeckManager.CardBrr[cardID - 60].Position[1]].Value].Position[1] = -1;
                    fieldManager.CurrntField[2, DeckManager.CardBrr[cardID - 60].Position[1]] = null;
                    foreach (GameObject card in thiscards) // thiscards[0]~[1]
                                {
                                    FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                                    if (fader != null)
                                    {
                                        fader.StartFadeOut();
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"{gameObject.name} : fader�� �߰ߵ��� �ʽ��ϴ�. ���̵� ȿ���� ������� �ʰ� ��� ������ϴ�.", fader);
                                        card.SetActive(false);
                                    }
                                }
                    DeckManager.CardBrr[cardID - 60].AP += 2;
                }
            }
            else if(DeckManager.CardBrr[cardID-60].AbilityId == 4)
            {
                GameObject[] thiscards = GameObject.FindGameObjectsWithTag(cardID.ToString());
                fieldManager.CurrntField[DeckManager.CardBrr[cardID - 60].Position[0], DeckManager.CardBrr[cardID - 60].Position[1]] = null;
                DeckManager.CardBrr[cardID - 60].Position[0] = -1;
                DeckManager.CardBrr[cardID - 60].Position[1] = -1;
                foreach (GameObject card in thiscards) // thiscards[0]~[1]
                                {
                                    FadeOut fader = card.gameObject.GetComponent<FadeOut>();
                                    if (fader != null)
                                    {
                                        fader.StartFadeOut();
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"{gameObject.name} : fader�� �߰ߵ��� �ʽ��ϴ�. ���̵� ȿ���� ������� �ʰ� ��� ������ϴ�.", fader);
                                        card.SetActive(false);
                                    }
                                }
            }
        }
        else if(timing == 3)
        {
            if(DeckManager.CardBrr[cardID-60].AbilityId == 16)
            {
                player.user.CP += 10;
                player.enemy.CP += 10;
            }
        }
        else if(timing == 4)
        {
            if(DeckManager.CardBrr[cardID-60].AbilityId == 14)
            {
                if (fieldManager.CurrntField[3, battleManager.DestroyPosition] != null)
                {
                    DeckManager.CardBrr[fieldManager.CurrntField[3, battleManager.DestroyPosition].Value - 60].AP += 2;
                }
            }
            battleManager.DestroyPosition = -1;
        }
        else if(timing == 5)
        {
            if (DeckManager.CardBrr[cardID - 60].AbilityId == 3)
            {
                if (DeckManager.CardBrr[cardID - 60].Position[1] > 0 && DeckManager.CardBrr[cardID - 60].Position[1] < 6 && fieldManager.CurrntField[DeckManager.CardBrr[cardID - 60].Position[0], DeckManager.CardBrr[cardID - 60].Position[1] - 1] != null && fieldManager.CurrntField[DeckManager.CardBrr[cardID - 60].Position[0], DeckManager.CardBrr[cardID - 60].Position[1] + 1] != null)
                {
                    DeckManager.CardBrr[fieldManager.CurrntField[DeckManager.CardBrr[cardID - 60].Position[0], DeckManager.CardBrr[cardID - 60].Position[1] - 1].Value].ExAP -= 1;
                    DeckManager.CardBrr[fieldManager.CurrntField[DeckManager.CardBrr[cardID - 60].Position[0], DeckManager.CardBrr[cardID - 60].Position[1] + 1].Value].ExAP -= 1;
                    DeckManager.CardBrr[cardID - 60].ExHP += 2;
                }
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 6 && DeckManager.CardBrr[cardID - 60].State == 101)
            {
                DeckManager.CardBrr[cardID - 60].AP += 2;
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 7)
            {
                if (DeckManager.CardBrr[cardID - 60].Position[0] == 1 && fieldManager.CurrntField[1, DeckManager.CardBrr[cardID - 60].Position[1]] != null)
                {
                    DeckManager.CardArr[fieldManager.CurrntField[1, DeckManager.CardBrr[cardID - 60].Position[1]].Value - 60].ExAP += 1;
                }
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 15)
            {
                if (DeckManager.CardBrr[cardID - 60].Position[1] > 0 && DeckManager.CardBrr[cardID - 60].Position[1] < 6 && fieldManager.CurrntField[DeckManager.CardBrr[cardID - 60].Position[0], DeckManager.CardBrr[cardID - 60].Position[1] - 1] != null && fieldManager.CurrntField[DeckManager.CardBrr[cardID - 60].Position[0], DeckManager.CardBrr[cardID - 60].Position[1] + 1] != null)
                {
                    DeckManager.CardBrr[cardID - 60].ExHP += 1;
                    DeckManager.CardBrr[cardID - 60].ExAP += 1;
                }
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 18)
            {
                if (DeckManager.CardBrr[cardID - 60].Position[0] == 2 && fieldManager.CurrntField[1, DeckManager.CardBrr[cardID - 60].Position[1]] != null)
                {
                    DeckManager.CardBrr[cardID - 60].ExHP += 2;
                    DeckManager.CardBrr[cardID - 60].ExAP -= 2;
                }
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 19)
            {
                if (DeckManager.CardBrr[cardID - 60].Position[0] == 2 && fieldManager.CurrntField[3, DeckManager.CardBrr[cardID - 60].Position[1]] != null)
                {
                    DeckManager.CardBrr[cardID - 60].ExAP += 2;
                }
            }
            else if (DeckManager.CardBrr[cardID - 60].AbilityId == 20)
            {
                if (DeckManager.CardBrr[cardID - 60].Position[0] == 3 && fieldManager.CurrntField[2, DeckManager.CardBrr[cardID - 60].Position[1]] != null)
                {
                    DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardBrr[cardID - 60].Position[1]].Value].ExHP += 3;
                }
            }
        }

        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
