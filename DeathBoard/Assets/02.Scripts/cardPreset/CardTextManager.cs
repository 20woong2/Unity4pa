using UnityEngine;
using TMPro;
public class CardTextManager : MonoBehaviour
{
    public FieldManager fieldManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<4;i++)
        {
            for(int j=0;j<7;j++)
            {
                if(fieldManager.CurrntField[i, j] != null)
                {
                    if(i<2 && DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].HP != 0)
                    {
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[i, j].Value.ToString());
                        TextMeshPro[] textMeshes = thiscards[0].GetComponentsInChildren<TextMeshPro>();
                        if(thiscards[0] != null && textMeshes[0] != null && textMeshes[1] != null)
                        {
                            textMeshes[0].text = (DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].HP + DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].ExHP).ToString();
                            if(DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].HP + DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].ExHP <= 0)
                            {
                                DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].Position[0] = -1;
                                DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].Position[1] = -1;
                                fieldManager.CurrntField[i,j] = null;
                                thiscards[0].SetActive(false);
                                thiscards[1].SetActive(false);
                            }
                            textMeshes[1].text = (DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].AP + DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].ExAP).ToString();
                            if(DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].AP + DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].ExAP <= 0)
                            {
                                textMeshes[1].text = "0";
                            }
                        }
                    }
                    else if(i>1 && DeckManager.CardBrr[fieldManager.CurrntField[i, j].Value-60].HP != 0)
                    {
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[i, j].Value.ToString());
                        TextMeshPro[] textMeshes = thiscards[0].GetComponentsInChildren<TextMeshPro>();
                        if(thiscards[0] != null && textMeshes[0] != null && textMeshes[1] != null)
                        {
                            textMeshes[0].text = (DeckManager.CardBrr[fieldManager.CurrntField[i, j].Value-60].HP + DeckManager.CardBrr[fieldManager.CurrntField[i, j].Value-60].ExHP).ToString();
                            if(DeckManager.CardBrr[fieldManager.CurrntField[i, j].Value-60].HP + DeckManager.CardBrr[fieldManager.CurrntField[i, j].Value-60].ExHP <= 0)
                            {
                                DeckManager.CardBrr[fieldManager.CurrntField[i, j].Value-60].Position[0] = -1;
                                DeckManager.CardBrr[fieldManager.CurrntField[i, j].Value-60].Position[1] = -1;
                                fieldManager.CurrntField[i,j] = null;
                                thiscards[0].SetActive(false);
                                thiscards[1].SetActive(false);
                            }
                            textMeshes[1].text = (DeckManager.CardBrr[fieldManager.CurrntField[i, j].Value-60].AP + DeckManager.CardBrr[fieldManager.CurrntField[i, j].Value-60].ExAP).ToString();
                            if(DeckManager.CardBrr[fieldManager.CurrntField[i, j].Value-60].AP + DeckManager.CardBrr[fieldManager.CurrntField[i, j].Value-60].ExAP <= 0)
                            {
                                textMeshes[1].text = "0";
                            }
                        }
                    }
                }
            }
        }
    }
}
