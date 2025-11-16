using UnityEngine;

public class MoveManager : MonoBehaviour //
{
    public FieldManager fieldManager;
    public TurnManager turnmanager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartMoveTurn()
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
                moveCard.transform.position = new Vector3(3.95f + 0.425f * i, 2.00f, -1.275f + 0.625f);
                thiscards[1].transform.position = new Vector3(3.95f + 0.425f * i, 2.00f-0.001f, -1.275f + 0.625f);
                //어차피 카드 있는지 검사 CurrntField로 하고 빈칸인지 카드 있는지 무슨 카드 있는지 다 저걸로 하는데 상수 더해서 카드 옵젝 옮기면 안되려나?
                //(3.95f + 0.425f * j, 2.00f, -1.275f + 0.625f * i) 가 필드 오브젝트 좌표이고 여기서 j는 가로줄 i는 세로줄
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
                moveCard.transform.position = new Vector3(3.95f + 0.425f * i, 1.97f, -1.275f + 0.625f*2); 
                thiscards[1].transform.position = new Vector3(3.95f + 0.425f * i, 1.97f-0.001f, -1.275f + 0.625f*2); 
                Debug.Log(3);
                Debug.Log(2);
            }
        }
    }
}
