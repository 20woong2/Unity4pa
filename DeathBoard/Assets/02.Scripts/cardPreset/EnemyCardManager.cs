using UnityEngine;
using UnityEngine.UI;
public class EnemyCardManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public DeckManager deckmanager;
    public EnemyHandManager enemyhandmanager;
    // 이 필드는 현재 AddCard 메서드에서 로컬 변수로 덮어쓰기 되므로 사용되지 않습니다.
    public GameObject newCard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DrawHand()
    {
        if(DeckManager.EnemyHandList.Count < 7)
        {
            int cardID;
            cardID = deckmanager.EnemyDrawCard();
            if (cardID >= 0) AddCard(cardID); //받아온 카드를 패에 추가
            else Debug.Log("덱 빔");
        }
    }
    public void AddCard(int cardID)
    {
        // 프리팹이 연결되어 있는지 확인
        if (cardPrefab != null)
        {
            // 1. 카드 복사본 생성 및 초기 위치 설정
            GameObject spawnedCard = Instantiate(cardPrefab, new Vector3(0f,0f,0f), Quaternion.Euler(26f, 180f, 0f));
            spawnedCard.tag = cardID.ToString();
            // 2. 미리보기 UI 생성 및 Canvas에 연결
           

            // 3. HandManager에 카드 추가 및 NumOfHand 증가
            enemyhandmanager.HandPlus(cardID);

            // 4. 스크립트 접근 및 정보 설정
            
            CardStateManager stateScript = spawnedCard.GetComponent<CardStateManager>();

            
            stateScript.EnemySetState(cardID, spawnedCard);

            // 5. 모든 정보 설정 후, 카드의 위치를 재배치하여 정렬합니다. (이 호출이 누락되었었습니다.)
            enemyhandmanager.rePlaceCard();
        }
    }
}
