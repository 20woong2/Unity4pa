using UnityEngine;
using TMPro;
public class CardTextManager : MonoBehaviour
{
    public FieldManager fieldManager;
    public EffectManager effectManager;
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
                    if(i<=1)
                    {
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[i, j].Value.ToString());
                        TextMeshPro[] textMeshes = thiscards[0].GetComponentsInChildren<TextMeshPro>();
                        if(thiscards[0] != null)
                        {
                            if(textMeshes != null && textMeshes.Length > 1)
                            {
                                textMeshes[0].text = (DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].HP + DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].ExHP).ToString();
                                textMeshes[1].text = (DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].AP + DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].ExAP).ToString();
                                if(DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].AP + DeckManager.CardArr[fieldManager.CurrntField[i, j].Value].ExAP <= 0)
                                {
                                    textMeshes[1].text = "0";
                                }
                            }
                        }
                    }
                    else if(i>1)
                    {
                        GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[i, j].Value.ToString());
                        TextMeshPro[] textMeshes = thiscards[0].GetComponentsInChildren<TextMeshPro>();
                        if(thiscards[0] != null)
                        {
                            if(textMeshes != null && textMeshes.Length > 1)
                            {
                                textMeshes[0].text = (DeckManager.CardBrr[fieldManager.CurrntField[i, j].Value-60].HP + DeckManager.CardBrr[fieldManager.CurrntField[i, j].Value-60].ExHP).ToString();
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
}
