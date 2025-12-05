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
    public bool battleexist = false;

    void Start()
    {
        battleexist = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public IEnumerator StartBattle()
    {
        GameObject mainCamera = Camera.main.gameObject; 
        BattleCameraMove battleCameraMove =  mainCamera.GetComponent<BattleCameraMove>();
        for (int i = 0; i < 7; i++)
        {
            if (fieldManager.CurrntField[1,i] != null)
            {
                battleexist = true;
                GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[1,i].Value.ToString());
                Vector3 targetPosition = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y + 0.7f, thiscards[0].transform.position.z-0.5f);
                Quaternion targetRotation = Quaternion.Euler(55f, 0f, 0f);
                battleCameraMove.StartMoving(targetPosition, targetRotation);
                yield return new WaitForSeconds(1.5f); 
                StartCoroutine(MyCardAttack(fieldManager.CurrntField[1,i]));
                yield return new WaitForSeconds(1.5f);
                if(i>0 && fieldManager.CurrntField[2,i-1] != null)
                {
                    yield return new WaitForSeconds(2f);
                }
                if(i>0 && fieldManager.CurrntField[2,i-1] == null && fieldManager.CurrntField[3,i-1] == null)
                {
                    yield return new WaitForSeconds(2f);
                }
                if(i<6 && fieldManager.CurrntField[2,i+1] != null)
                {
                    yield return new WaitForSeconds(2f);
                }
                if(i<6 && fieldManager.CurrntField[2,i+1] == null && fieldManager.CurrntField[3,i+1] == null)
                {
                    yield return new WaitForSeconds(2f);
                }
            }
        }
        for (int i = 0; i < 7; i++)
        {
            if (fieldManager.CurrntField[2,i] != null)
            {
                battleexist = true;
                GameObject[] thiscards = GameObject.FindGameObjectsWithTag(fieldManager.CurrntField[2,i].Value.ToString());
                Vector3 targetPosition = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y + 0.7f, thiscards[0].transform.position.z+0.5f);
                Quaternion targetRotation = Quaternion.Euler(55f, 180f, 0f);
                battleCameraMove.StartMoving(targetPosition, targetRotation);
                yield return new WaitForSeconds(1.5f); 
                StartCoroutine(EnemyCardAttack(fieldManager.CurrntField[2,i]));
                yield return new WaitForSeconds(1.5f);
                if(fieldManager.CurrntField[1,i] != null)
                {
                    yield return new WaitForSeconds(2f);
                }
                if(fieldManager.CurrntField[1,i] == null && fieldManager.CurrntField[0,i] == null)
                {
                    yield return new WaitForSeconds(2f);
                }
            }
        }
        if(battleexist == true)
        {
            battleexist = false;
            pos1 = GameObject.FindWithTag("Pos1");
            battleCameraMove.StartMoving(pos1.transform.position, pos1.transform.rotation);
        }
        yield return new WaitForSeconds(2f);
        TurnManager.turnend = true;
    }
    public IEnumerator MyCardAttack(int? attackCardID)
    {
        GameObject mainCamera = Camera.main.gameObject; 
        BattleCameraMove battleCameraMove =  mainCamera.GetComponent<BattleCameraMove>();
        
        Debug.Log("내카드 공격 실행");
        if(DeckManager.CardArr[attackCardID.Value].AP + DeckManager.CardArr[attackCardID.Value].ExAP > 0)
        {
            //왼쪽 위 적 기물 공격
            if(DeckManager.CardArr[attackCardID.Value].Position[1] >= 1)
            {
                if (fieldManager.CurrntField[2,DeckManager.CardArr[attackCardID.Value].Position[1]-1] != null)                                                                                 //상대 공격 줄에 카드 있다면 공격
                {
                    Debug.Log("왼 공격 실행");
                    

                    GameObject[] thiscards = GameObject.FindGameObjectsWithTag(attackCardID.Value.ToString());
                    Vector3 Origin1 = thiscards[0].transform.position;
                    Vector3 Origin2 = thiscards[1].transform.position;
                    MoveCardSmooth moveCardSmooth1 = thiscards[0].GetComponent<MoveCardSmooth>();
                    MoveCardSmooth moveCardSmooth2 = thiscards[1].GetComponent<MoveCardSmooth>();
                    Vector3 targetPosition1 = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y+0.1f, thiscards[0].transform.position.z); 
                    Vector3 targetPosition2 = new Vector3(thiscards[1].transform.position.x, thiscards[1].transform.position.y+0.1f, thiscards[1].transform.position.z);
                    Quaternion targetRotation1 = Quaternion.Euler(90f, 0f, 0f);
                    Quaternion targetRotation2 = Quaternion.Euler(-90f, 0f, -180f);
                    
                    moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                    moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                    yield return new WaitForSeconds(1f);
                    targetPosition1 = new Vector3(thiscards[0].transform.position.x-0.3f, thiscards[0].transform.position.y, thiscards[0].transform.position.z + 0.2f); 
                    targetPosition2 = new Vector3(thiscards[1].transform.position.x-0.3f, thiscards[1].transform.position.y, thiscards[1].transform.position.z + 0.2f);
                    moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                    moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                    yield return new WaitForSeconds(0.5f);
                    DeckManager.CardBrr[fieldManager.CurrntField[2,DeckManager.CardArr[attackCardID.Value].Position[1]-1].Value-60].HP -= (DeckManager.CardArr[attackCardID.Value].AP + DeckManager.CardArr[attackCardID.Value].ExAP);
                    
                    if (fieldManager.CurrntField[2,DeckManager.CardArr[attackCardID.Value].Position[1]-1] != null && DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1].Value-60].AbilityId == 6 && DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1].Value - 60].Position[0] != -1)
                    {
                        DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] - 1].Value-60].State = 100;
                    }
                    targetPosition1 = Origin1; 
                    targetPosition2 = Origin2;
                    moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                    moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                    yield return new WaitForSeconds(0.5f);
                }
                else if(fieldManager.CurrntField[3,DeckManager.CardArr[attackCardID.Value].Position[1]-1] != null)
                {
                    yield break;
                }
                else
                {
                Debug.Log("아군 직접공격 : ");
                    GameObject[] thiscards = GameObject.FindGameObjectsWithTag(attackCardID.Value.ToString());
                    Vector3 Origin1 = thiscards[0].transform.position;
                    Vector3 Origin2 = thiscards[1].transform.position;
                    Vector3 targetPosition = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y + 0.7f, thiscards[0].transform.position.z-0.5f);
                    Quaternion targetRotation = Quaternion.Euler(30f, 0f, 0f);
                    battleCameraMove.StartMoving(targetPosition, targetRotation);
                    MoveCardSmooth moveCardSmooth1 = thiscards[0].GetComponent<MoveCardSmooth>();
                    MoveCardSmooth moveCardSmooth2 = thiscards[1].GetComponent<MoveCardSmooth>();
                    Vector3 targetPosition1 = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y+0.1f, thiscards[0].transform.position.z); 
                    Vector3 targetPosition2 = new Vector3(thiscards[1].transform.position.x, thiscards[1].transform.position.y+0.1f, thiscards[1].transform.position.z);
                    Quaternion targetRotation1 = Quaternion.Euler(90f, 0f, 0f);
                    Quaternion targetRotation2 = Quaternion.Euler(-90f, 0f, -180f);
                    moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                    moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                    yield return new WaitForSeconds(0.5f);
                    targetPosition1 = new Vector3(thiscards[0].transform.position.x-0.4f, thiscards[0].transform.position.y, thiscards[0].transform.position.z); 
                    targetPosition2 = new Vector3(thiscards[1].transform.position.x-0.4f, thiscards[1].transform.position.y, thiscards[1].transform.position.z);
                    moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                    moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                    yield return new WaitForSeconds(0.5f);
                    targetPosition1 = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y, thiscards[0].transform.position.z + 1.5f); 
                    targetPosition2 = new Vector3(thiscards[1].transform.position.x, thiscards[1].transform.position.y, thiscards[1].transform.position.z + 1.5f);
                    moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                    moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                    yield return new WaitForSeconds(0.5f);
                    player.enemy.CP += (DeckManager.CardArr[attackCardID.Value].AP + DeckManager.CardArr[attackCardID.Value].ExAP);
                    //상대 직접 공격(공포 수치 상승)
                    Debug.Log("아군 직접공격 : " + (DeckManager.CardArr[attackCardID.Value].AP + DeckManager.CardArr[attackCardID.Value].ExAP) + " 공포게이지 : " + player.enemy.CP);
                    targetPosition1 = Origin1; 
                    targetPosition2 = Origin2;

                    moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                    moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                    yield return new WaitForSeconds(0.5f);
                    targetPosition = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y + 0.7f, thiscards[0].transform.position.z-0.5f);
                    targetRotation = Quaternion.Euler(55f, 0f, 0f);
                    battleCameraMove.StartMoving(targetPosition, targetRotation);
                }
                yield return new WaitForSeconds(1f);
            }

            //오른쪽 위 적 기물 공격
            if(DeckManager.CardArr[attackCardID.Value].Position[1] <= 5)
            {
                if (fieldManager.CurrntField[2,DeckManager.CardArr[attackCardID.Value].Position[1]+1] != null)                                                                                 //상대 공격 줄에 카드 있다면 공격
                {
                    Debug.Log("오른 공격 실행");

                    GameObject[] thiscards = GameObject.FindGameObjectsWithTag(attackCardID.Value.ToString());
                    Vector3 Origin1 = thiscards[0].transform.position;
                    Vector3 Origin2 = thiscards[1].transform.position;
                    MoveCardSmooth moveCardSmooth1 = thiscards[0].GetComponent<MoveCardSmooth>();
                    MoveCardSmooth moveCardSmooth2 = thiscards[1].GetComponent<MoveCardSmooth>();
                    Vector3 targetPosition1 = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y+0.1f, thiscards[0].transform.position.z); 
                    Vector3 targetPosition2 = new Vector3(thiscards[1].transform.position.x, thiscards[1].transform.position.y+0.1f, thiscards[1].transform.position.z);
                    Quaternion targetRotation1 = Quaternion.Euler(90f, 0f, 0f);
                    Quaternion targetRotation2 = Quaternion.Euler(-90f, 0f, -180f);
                    
                    moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                    moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                    yield return new WaitForSeconds(1f);
                    targetPosition1 = new Vector3(thiscards[0].transform.position.x+0.3f, thiscards[0].transform.position.y, thiscards[0].transform.position.z + 0.2f); 
                    targetPosition2 = new Vector3(thiscards[1].transform.position.x+0.3f, thiscards[1].transform.position.y, thiscards[1].transform.position.z + 0.2f);
                    moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                    moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                    yield return new WaitForSeconds(0.5f);
                    DeckManager.CardBrr[fieldManager.CurrntField[2,DeckManager.CardArr[attackCardID.Value].Position[1]+1].Value-60].HP -= (DeckManager.CardArr[attackCardID.Value].AP + DeckManager.CardArr[attackCardID.Value].ExAP);
                    
                    
                    if (fieldManager.CurrntField[2,DeckManager.CardArr[attackCardID.Value].Position[1]+1] != null && DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1].Value-60].AbilityId == 6 && DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1].Value - 60].Position[0] != -1)
                    {
                        DeckManager.CardBrr[fieldManager.CurrntField[2, DeckManager.CardArr[attackCardID.Value].Position[1] + 1].Value-60].State = 100;
                    }
                    targetPosition1 = Origin1; 
                    targetPosition2 = Origin2;
                    moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                    moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                    yield return new WaitForSeconds(0.5f);
                }
                else if(fieldManager.CurrntField[3,DeckManager.CardArr[attackCardID.Value].Position[1]+1] != null)
                {
                    yield break;
                }
                else
                {
                    GameObject[] thiscards = GameObject.FindGameObjectsWithTag(attackCardID.Value.ToString());
                    Vector3 Origin1 = thiscards[0].transform.position;
                    Vector3 Origin2 = thiscards[1].transform.position;
                    Vector3 targetPosition = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y + 0.7f, thiscards[0].transform.position.z-0.5f);
                    Quaternion targetRotation = Quaternion.Euler(30f, 0f, 0f);
                    battleCameraMove.StartMoving(targetPosition, targetRotation);
                    MoveCardSmooth moveCardSmooth1 = thiscards[0].GetComponent<MoveCardSmooth>();
                    MoveCardSmooth moveCardSmooth2 = thiscards[1].GetComponent<MoveCardSmooth>();
                    Vector3 targetPosition1 = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y+0.1f, thiscards[0].transform.position.z); 
                    Vector3 targetPosition2 = new Vector3(thiscards[1].transform.position.x, thiscards[1].transform.position.y+0.1f, thiscards[1].transform.position.z);
                    Quaternion targetRotation1 = Quaternion.Euler(90f, 0f, 0f);
                    Quaternion targetRotation2 = Quaternion.Euler(-90f, 0f, -180f);
                    moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                    moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                    yield return new WaitForSeconds(0.5f);
                    targetPosition1 = new Vector3(thiscards[0].transform.position.x+0.4f, thiscards[0].transform.position.y, thiscards[0].transform.position.z); 
                    targetPosition2 = new Vector3(thiscards[1].transform.position.x+0.4f, thiscards[1].transform.position.y, thiscards[1].transform.position.z);
                    moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                    moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                    yield return new WaitForSeconds(0.5f);
                    targetPosition1 = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y, thiscards[0].transform.position.z + 1.5f); 
                    targetPosition2 = new Vector3(thiscards[1].transform.position.x, thiscards[1].transform.position.y, thiscards[1].transform.position.z + 1.5f);
                    moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                    moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                    yield return new WaitForSeconds(0.5f);
                    player.enemy.CP += (DeckManager.CardArr[attackCardID.Value].AP + DeckManager.CardArr[attackCardID.Value].ExAP);
                    //상대 직접 공격(공포 수치 상승)
                    Debug.Log("아군 직접공격 : " + (DeckManager.CardArr[attackCardID.Value].AP + DeckManager.CardArr[attackCardID.Value].ExAP) + " 공포게이지 : " + player.enemy.CP);

                    targetPosition1 = Origin1; 
                    targetPosition2 = Origin2;

                    moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                    moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                    yield return new WaitForSeconds(0.5f);
                    targetPosition = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y + 0.7f, thiscards[0].transform.position.z-0.5f);
                    targetRotation = Quaternion.Euler(55f, 0f, 0f);
                    battleCameraMove.StartMoving(targetPosition, targetRotation);
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
    public IEnumerator EnemyCardAttack(int? attackCardID)
    {
        GameObject mainCamera = Camera.main.gameObject; 
        BattleCameraMove battleCameraMove =  mainCamera.GetComponent<BattleCameraMove>();
        if(DeckManager.CardBrr[attackCardID.Value-60].AP + DeckManager.CardBrr[attackCardID.Value-60].ExAP > 0)
        {
            if (fieldManager.CurrntField[1,DeckManager.CardBrr[attackCardID.Value-60].Position[1]] != null)                                                                                 //상대 공격 줄에 카드 있다면 공격
            {

                GameObject[] thiscards = GameObject.FindGameObjectsWithTag(attackCardID.Value.ToString());
                Vector3 Origin1 = thiscards[0].transform.position;
                Vector3 Origin2 = thiscards[1].transform.position;
                MoveCardSmooth moveCardSmooth1 = thiscards[0].GetComponent<MoveCardSmooth>();
                MoveCardSmooth moveCardSmooth2 = thiscards[1].GetComponent<MoveCardSmooth>();
                Vector3 targetPosition1 = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y+0.1f, thiscards[0].transform.position.z); 
                Vector3 targetPosition2 = new Vector3(thiscards[1].transform.position.x, thiscards[1].transform.position.y+0.1f, thiscards[1].transform.position.z);
                Quaternion targetRotation1 = Quaternion.Euler(90f, -180f, 0f);
                Quaternion targetRotation2 = Quaternion.Euler(-90f, 0f, 0f); 
                    
                moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                yield return new WaitForSeconds(1f);
                targetPosition1 = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y, thiscards[0].transform.position.z - 0.2f); 
                targetPosition2 = new Vector3(thiscards[1].transform.position.x, thiscards[1].transform.position.y, thiscards[1].transform.position.z - 0.2f);
                moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                yield return new WaitForSeconds(0.5f);


                DeckManager.CardArr[fieldManager.CurrntField[1,DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value].HP -= (DeckManager.CardBrr[attackCardID.Value-60].AP + DeckManager.CardBrr[attackCardID.Value-60].ExAP);
                

                
                if(fieldManager.CurrntField[1,DeckManager.CardBrr[attackCardID.Value-60].Position[1]] != null && DeckManager.CardArr[fieldManager.CurrntField[1,DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value].AbilityId == 6 && DeckManager.CardArr[fieldManager.CurrntField[1,DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value].Position[0] != -1)
                {
                    DeckManager.CardArr[fieldManager.CurrntField[1,DeckManager.CardBrr[attackCardID.Value-60].Position[1]].Value].State = 100;
                }

                targetPosition1 = Origin1; 
                targetPosition2 = Origin2;
                moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                yield return new WaitForSeconds(0.5f);
            }
            else if(fieldManager.CurrntField[0,DeckManager.CardBrr[attackCardID.Value-60].Position[1]] != null)
            {
                yield break;
            }
            else
            {
                GameObject[] thiscards = GameObject.FindGameObjectsWithTag(attackCardID.Value.ToString());
                    Vector3 Origin1 = thiscards[0].transform.position;
                    Vector3 Origin2 = thiscards[1].transform.position;
                    Vector3 targetPosition = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y + 0.7f, thiscards[0].transform.position.z+0.5f);
                    Quaternion targetRotation = Quaternion.Euler(30f, 180f, 0f);
                    battleCameraMove.StartMoving(targetPosition, targetRotation);
                    MoveCardSmooth moveCardSmooth1 = thiscards[0].GetComponent<MoveCardSmooth>();
                    MoveCardSmooth moveCardSmooth2 = thiscards[1].GetComponent<MoveCardSmooth>();
                    Vector3 targetPosition1 = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y+0.1f, thiscards[0].transform.position.z); 
                    Vector3 targetPosition2 = new Vector3(thiscards[1].transform.position.x, thiscards[1].transform.position.y+0.1f, thiscards[1].transform.position.z);
                    Quaternion targetRotation1 = Quaternion.Euler(90f, -180f, 0f);
                    Quaternion targetRotation2 = Quaternion.Euler(-90f, 0f, 0f); 
                    moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                    moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                    yield return new WaitForSeconds(0.5f);
                    targetPosition1 = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y, thiscards[0].transform.position.z - 1.5f); 
                    targetPosition2 = new Vector3(thiscards[1].transform.position.x, thiscards[1].transform.position.y, thiscards[1].transform.position.z - 1.5f);
                    moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                    moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                    yield return new WaitForSeconds(0.5f);
                player.user.CP += (DeckManager.CardBrr[attackCardID.Value - 60].AP + DeckManager.CardBrr[attackCardID.Value - 60].ExAP);
                //상대 직접 공격(공포 수치 상승)
                Debug.Log("상대 직접공격 : " + (DeckManager.CardBrr[attackCardID.Value - 60].AP + DeckManager.CardBrr[attackCardID.Value - 60].ExAP) + " 공포게이지 : " + player.user.CP);

                targetPosition1 = Origin1; 
                targetPosition2 = Origin2;

                moveCardSmooth1.StartMoving(targetPosition1,targetRotation1);
                moveCardSmooth2.StartMoving(targetPosition2,targetRotation2);
                yield return new WaitForSeconds(0.5f);
                targetPosition = new Vector3(thiscards[0].transform.position.x, thiscards[0].transform.position.y + 0.7f, thiscards[0].transform.position.z+0.5f);
                targetRotation = Quaternion.Euler(55f, 180f, 0f);
                battleCameraMove.StartMoving(targetPosition, targetRotation);
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
