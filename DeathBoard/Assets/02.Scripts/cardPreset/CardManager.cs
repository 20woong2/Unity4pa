using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public HandManager handManager;
    public DeckManager deckmanager;
    // 이 필드는 현재 AddCard 메서드에서 로컬 변수로 덮어쓰기 되므로 사용되지 않습니다.
    public GameObject newCard;
    public GameObject previewCardUI;

    void Start()
    {
        // 초기화 로직
    }

    void Update()
    {
        // 예시: R 키를 누를 때마다 카드를 생성합니다.
        if (Input.GetKeyDown(KeyCode.R) && DeckManager.HandList.Count < 7)
        {
            int cardID;
            cardID = deckmanager.DrawCard();
            if (cardID >= 0) AddCard(cardID); //받아온 카드를 패에 추가
            else Debug.Log("덱 빔");
        }
    }
    public void DrawHand()
    {
        if(DeckManager.HandList.Count < 7)
        {
            int cardID;
            cardID = deckmanager.DrawCard();
            if (cardID >= 0) AddCard(cardID); //받아온 카드를 패에 추가
            else Debug.Log("덱 빔");
        }
    }

    public void PlayCard(GameObject playedCard)
    {
        // HandManager 리스트에서 카드 제거
        bool removed = DeckManager.HandList.Remove(int.Parse(playedCard.tag));
        if (removed)
        {
            // 카드 수 감소 및 남은 카드 재배치
            
            handManager.rePlaceCard();

            CardReaction reactionScript = playedCard.GetComponent<CardReaction>();

            // 미리보기 UI 제거
            if (reactionScript != null && reactionScript.previewCardUI != null)
            {
                Destroy(reactionScript.previewCardUI);
            }
        }
        else
        {
            Debug.LogWarning("PlayCard: Hand 리스트에서 카드를 찾지 못했습니다.");
        }
    }

    public void AddCard(int cardID)
    {
        // 프리팹이 연결되어 있는지 확인
        if (cardPrefab != null)
        {
            // 1. 카드 복사본 생성 및 초기 위치 설정
            GameObject spawnedCard = Instantiate(cardPrefab, new Vector3(0f, 0f, 0f), Quaternion.Euler(26f, 0f, 0f));
            spawnedCard.tag = cardID.ToString();
            // 2. 미리보기 UI 생성 및 Canvas에 연결
            Transform canvasTransform = GameObject.Find("Canvas")?.transform;
            GameObject newPreview = Instantiate(previewCardUI, canvasTransform);

            // 3. HandManager에 카드 추가 및 NumOfHand 증가
            handManager.HandPlus(cardID);

            // 4. 스크립트 접근 및 정보 설정
            CardReaction reactionScript = spawnedCard.GetComponent<CardReaction>();
            CardStateManager stateScript = spawnedCard.GetComponent<CardStateManager>();

            reactionScript.SetPreview(newPreview, cardID);
            stateScript.SetState(cardID, spawnedCard);

            // 5. 모든 정보 설정 후, 카드의 위치를 재배치하여 정렬합니다. (이 호출이 누락되었었습니다.)
            handManager.rePlaceCard();
        }
    }
}