using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public HandManager handManager;
    public DeckManager deckmanager;
    public GameObject newCard;
    public GameObject previewCardUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 예시: R 키를 누를 때마다 카드를 생성합니다.
        if (Input.GetKeyDown(KeyCode.R))
        {
            int cardID;
            cardID = deckmanager.DrawCard();
            if(cardID>=0) AddCard(cardID); //받아온 카드를 패에 추가
            else Debug.Log("덱 빔");

        }
    }

    public void AddCard(int cardID)
    {
        // 프리팹이 연결되어 있는지 확인
        if (cardPrefab != null)
        {

            // Instantiate 함수를 사용하여 프리팹의 복사본을 생성합니다.
            // Vector3.zero: 월드 좌표 (0, 0, 0)
            // Quaternion.identity: 회전 없음 (기본값)
            
            //HandManager.hand.Add(newCard); -> 덱 메니저 완성 후 적용
            GameObject newCard = Instantiate(cardPrefab, handManager.PlaceNewCard(),  Quaternion.Euler(26f, 0f, 0f)); //<- 위치 세팅인데 여기서 필요할까? HandManager에서 처리가 가능하지 않을까?
            Transform canvasTransform = GameObject.Find("Canvas")?.transform;
            GameObject newPreview = Instantiate(previewCardUI, canvasTransform);//게임오브젝트로 받은후
            
            handManager.HandPlus(newCard); //매개변수로 newCard를 주면 그걸 기준으로 handManager 안에서 새 카드 내용 받은걸로 오브젝트 생성, 배치가 가능하지 않을까?
            handManager.rePlaceCard();
            CardReaction reactionScript = newCard.GetComponent<CardReaction>(); //만들어진(뽑은) 카드의 reaction 스크립트에 접근
            CardStateManager stateScript = newCard.GetComponent<CardStateManager>();
            reactionScript.SetPreview(newPreview, cardID); //reaction 스크립트에 접근하여 그 안의 SetPreview 함수를 이용해서 newCard와 함께 만들어진 newPreview를 연결
            stateScript.SetState(cardID, newCard);
            // *이후 HandManager 등으로 넘겨서 패에 추가하는 로직이 필요합니다.*
        }
    }
}
