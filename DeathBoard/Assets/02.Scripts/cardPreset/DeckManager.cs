using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public static CardStruct[] CardArr = new CardStruct[40];
    public static List<int> DeckList = new List<int>();
    public static List<int> GraveList = new List<int>();
    public static List<int> HandList = new List<int>();
    private int init = -1;
    void Init_Deck()
    {
        DeckList.Clear();

        List<int> tempList = new List<int>();

        // 0부터 39까지 숫자를 임시 리스트에 추가
        for (int i = 0; i < 40; i++)
        {
            tempList.Add(i);
        }

        // 랜덤 순서로 DeckList에 옮김 (셔플)
        while (tempList.Count > 0)
        {
            int randomIndex = Random.Range(0, tempList.Count);
            DeckList.Add(tempList[randomIndex]);
            tempList.RemoveAt(randomIndex);
        }
        foreach (int cardId in DeckList)
        {
            Debug.Log(cardId);
        }
        CardArr[0].HP = 10;
        CardArr[0].AP = 5;
        CardArr[0].State = 0;
        CardArr[0].CardId = 0;
        CardArr[0].AbilityId = 0;
        CardArr[0].ImgPath = "Cardimg1";
        CardArr[0].Context = "1111";
        CardArr[0].Position = new int[] { 0, 0 };

        CardArr[1].HP = 10;
        CardArr[1].AP = 5;
        CardArr[1].State = 0;
        CardArr[1].CardId = 1;
        CardArr[1].AbilityId = 0;
        CardArr[1].ImgPath = "Cardimg2";
        CardArr[1].Context = "22222";
        CardArr[1].Position = new int[] { 0, 0 };

        CardArr[2].HP = 10;
        CardArr[2].AP = 5;
        CardArr[2].State = 0;
        CardArr[2].CardId = 2;
        CardArr[2].AbilityId = 0;
        CardArr[2].ImgPath = "Cardimg3";
        CardArr[2].Context = "33333";
        CardArr[2].Position = new int[] { 0, 0 };

        CardArr[3].HP = 10;
        CardArr[3].AP = 5;
        CardArr[3].State = 0;
        CardArr[3].CardId = 3;
        CardArr[3].AbilityId = 0;
        CardArr[3].ImgPath = "Cardimg4";
        CardArr[3].Context = "";
        CardArr[3].Position = new int[] { 0, 0 };

        CardArr[4].HP = 10;
        CardArr[4].AP = 5;
        CardArr[4].State = 0;
        CardArr[4].CardId = 4;
        CardArr[4].AbilityId = 0;
        CardArr[4].ImgPath = "Cardimg5";
        CardArr[4].Context = "";
        CardArr[4].Position = new int[] { 0, 0 };

        CardArr[5].HP = 10;
        CardArr[5].AP = 5;
        CardArr[5].State = 0;
        CardArr[5].CardId = 5;
        CardArr[5].AbilityId = 0;
        CardArr[5].ImgPath = "Cardimg6";
        CardArr[5].Context = "";
        CardArr[5].Position = new int[] { 0, 0 };

        CardArr[6].HP = 10;
        CardArr[6].AP = 5;
        CardArr[6].State = 0;
        CardArr[6].CardId = 6;
        CardArr[6].AbilityId = 0;
        CardArr[6].ImgPath = "Cardimg7";
        CardArr[6].Context = "";
        CardArr[6].Position = new int[] { 0, 0 };

        CardArr[7].HP = 10;
        CardArr[7].AP = 5;
        CardArr[7].State = 0;
        CardArr[7].CardId = 7;
        CardArr[7].AbilityId = 0;
        CardArr[7].ImgPath = "Cardimg8";
        CardArr[7].Context = "";
        CardArr[7].Position = new int[] { 0, 0 };

        CardArr[8].HP = 10;
        CardArr[8].AP = 5;
        CardArr[8].State = 0;
        CardArr[8].CardId = 8;
        CardArr[8].AbilityId = 0;
        CardArr[8].ImgPath = "Cardimg9";
        CardArr[8].Context = "";
        CardArr[8].Position = new int[] { 0, 0 };

        CardArr[9].HP = 10;
        CardArr[9].AP = 5;
        CardArr[9].State = 0;
        CardArr[9].CardId = 9;
        CardArr[9].AbilityId = 0;
        CardArr[9].ImgPath = "Cardimg10";
        CardArr[9].Context = "";
        CardArr[9].Position = new int[] { 0, 0 };

        CardArr[10].HP = 10;
        CardArr[10].AP = 5;
        CardArr[10].State = 0;
        CardArr[10].CardId = 10;
        CardArr[10].AbilityId = 0;
        CardArr[10].ImgPath = "Cardimg11";
        CardArr[10].Context = "";
        CardArr[10].Position = new int[] { 0, 0 };

        CardArr[11].HP = 10;
        CardArr[11].AP = 5;
        CardArr[11].State = 0;
        CardArr[11].CardId = 11;
        CardArr[11].AbilityId = 0;
        CardArr[11].ImgPath = "Cardimg12";
        CardArr[11].Context = "";
        CardArr[11].Position = new int[] { 0, 0 };

        CardArr[12].HP = 10;
        CardArr[12].AP = 5;
        CardArr[12].State = 0;
        CardArr[12].CardId = 12;
        CardArr[12].AbilityId = 0;
        CardArr[12].ImgPath = "Cardimg13";
        CardArr[12].Context = "";
        CardArr[12].Position = new int[] { 0, 0 };

        CardArr[13].HP = 10;
        CardArr[13].AP = 5;
        CardArr[13].State = 0;
        CardArr[13].CardId = 13;
        CardArr[13].AbilityId = 0;
        CardArr[13].ImgPath = "Cardimg14";
        CardArr[13].Context = "";
        CardArr[13].Position = new int[] { 0, 0 };

        CardArr[14].HP = 10;
        CardArr[14].AP = 5;
        CardArr[14].State = 0;
        CardArr[14].CardId = 14;
        CardArr[14].AbilityId = 0;
        CardArr[14].ImgPath = "Cardimg15";
        CardArr[14].Context = "";
        CardArr[14].Position = new int[] { 0, 0 };

        CardArr[15].HP = 10;
        CardArr[15].AP = 5;
        CardArr[15].State = 0;
        CardArr[15].CardId = 15;
        CardArr[15].AbilityId = 0;
        CardArr[15].ImgPath = "Cardimg16";
        CardArr[15].Context = "";
        CardArr[15].Position = new int[] { 0, 0 };

        CardArr[16].HP = 10;
        CardArr[16].AP = 5;
        CardArr[16].State = 0;
        CardArr[16].CardId = 16;
        CardArr[16].AbilityId = 0;
        CardArr[16].ImgPath = "Cardimg17";
        CardArr[16].Context = "";
        CardArr[16].Position = new int[] { 0, 0 };

        CardArr[17].HP = 10;
        CardArr[17].AP = 5;
        CardArr[17].State = 0;
        CardArr[17].CardId = 17;
        CardArr[17].AbilityId = 0;
        CardArr[17].ImgPath = "Cardimg18";
        CardArr[17].Context = "";
        CardArr[17].Position = new int[] { 0, 0 };

        CardArr[18].HP = 10;
        CardArr[18].AP = 5;
        CardArr[18].State = 0;
        CardArr[18].CardId = 18;
        CardArr[18].AbilityId = 0;
        CardArr[18].ImgPath = "Cardimg19";
        CardArr[18].Context = "";
        CardArr[18].Position = new int[] { 0, 0 };

        CardArr[19].HP = 10;
        CardArr[19].AP = 5;
        CardArr[19].State = 0;
        CardArr[19].CardId = 19;
        CardArr[19].AbilityId = 0;
        CardArr[19].ImgPath = "Cardimg20";
        CardArr[19].Context = "";
        CardArr[19].Position = new int[] { 0, 0 };

        CardArr[20].HP = 10;
        CardArr[20].AP = 5;
        CardArr[20].State = 0;
        CardArr[20].CardId = 20;
        CardArr[20].AbilityId = 0;
        CardArr[20].ImgPath = "Cardimg21";
        CardArr[20].Context = "";
        CardArr[20].Position = new int[] { 0, 0 };

        CardArr[21].HP = 10;
        CardArr[21].AP = 5;
        CardArr[21].State = 0;
        CardArr[21].CardId = 21;
        CardArr[21].AbilityId = 0;
        CardArr[21].ImgPath = "Cardimg22";
        CardArr[21].Context = "";
        CardArr[21].Position = new int[] { 0, 0 };

        CardArr[22].HP = 10;
        CardArr[22].AP = 5;
        CardArr[22].State = 0;
        CardArr[22].CardId = 22;
        CardArr[22].AbilityId = 0;
        CardArr[22].ImgPath = "Cardimg23";
        CardArr[22].Context = "";
        CardArr[22].Position = new int[] { 0, 0 };

        CardArr[23].HP = 10;
        CardArr[23].AP = 5;
        CardArr[23].State = 0;
        CardArr[23].CardId = 23;
        CardArr[23].AbilityId = 0;
        CardArr[23].ImgPath = "Cardimg24";
        CardArr[23].Context = "";
        CardArr[23].Position = new int[] { 0, 0 };

        CardArr[24].HP = 10;
        CardArr[24].AP = 5;
        CardArr[24].State = 0;
        CardArr[24].CardId = 24;
        CardArr[24].AbilityId = 0;
        CardArr[24].ImgPath = "Cardimg25";
        CardArr[24].Context = "";
        CardArr[24].Position = new int[] { 0, 0 };

        CardArr[25].HP = 10;
        CardArr[25].AP = 5;
        CardArr[25].State = 0;
        CardArr[25].CardId = 25;
        CardArr[25].AbilityId = 0;
        CardArr[25].ImgPath = "Cardimg26";
        CardArr[25].Context = "";
        CardArr[25].Position = new int[] { 0, 0 };

        CardArr[26].HP = 10;
        CardArr[26].AP = 5;
        CardArr[26].State = 0;
        CardArr[26].CardId = 26;
        CardArr[26].AbilityId = 0;
        CardArr[26].ImgPath = "Cardimg27";
        CardArr[26].Context = "";
        CardArr[26].Position = new int[] { 0, 0 };

        CardArr[27].HP = 10;
        CardArr[27].AP = 5;
        CardArr[27].State = 0;
        CardArr[27].CardId = 27;
        CardArr[27].AbilityId = 0;
        CardArr[27].ImgPath = "Cardimg28";
        CardArr[27].Context = "";
        CardArr[27].Position = new int[] { 0, 0 };

        CardArr[28].HP = 10;
        CardArr[28].AP = 5;
        CardArr[28].State = 0;
        CardArr[28].CardId = 28;
        CardArr[28].AbilityId = 0;
        CardArr[28].ImgPath = "Cardimg29";
        CardArr[28].Context = "";
        CardArr[28].Position = new int[] { 0, 0 };

        CardArr[29].HP = 10;
        CardArr[29].AP = 5;
        CardArr[29].State = 0;
        CardArr[29].CardId = 29;
        CardArr[29].AbilityId = 0;
        CardArr[29].ImgPath = "Cardimg30";
        CardArr[29].Context = "";
        CardArr[29].Position = new int[] { 0, 0 };

        CardArr[30].HP = 10;
        CardArr[30].AP = 5;
        CardArr[30].State = 0;
        CardArr[30].CardId = 30;
        CardArr[30].AbilityId = 0;
        CardArr[30].ImgPath = "Cardimg31";
        CardArr[30].Context = "";
        CardArr[30].Position = new int[] { 0, 0 };

        CardArr[31].HP = 10;
        CardArr[31].AP = 5;
        CardArr[31].State = 0;
        CardArr[31].CardId = 31;
        CardArr[31].AbilityId = 0;
        CardArr[31].ImgPath = "Cardimg32";
        CardArr[31].Context = "";
        CardArr[31].Position = new int[] { 0, 0 };

        CardArr[32].HP = 10;
        CardArr[32].AP = 5;
        CardArr[32].State = 0;
        CardArr[32].CardId = 32;
        CardArr[32].AbilityId = 0;
        CardArr[32].ImgPath = "Cardimg33";
        CardArr[32].Context = "";
        CardArr[32].Position = new int[] { 0, 0 };

        CardArr[33].HP = 10;
        CardArr[33].AP = 5;
        CardArr[33].State = 0;
        CardArr[33].CardId = 33;
        CardArr[33].AbilityId = 0;
        CardArr[33].ImgPath = "Cardimg34";
        CardArr[33].Context = "";
        CardArr[33].Position = new int[] { 0, 0 };

        CardArr[34].HP = 10;
        CardArr[34].AP = 5;
        CardArr[34].State = 0;
        CardArr[34].CardId = 34;
        CardArr[34].AbilityId = 0;
        CardArr[34].ImgPath = "Cardimg35";
        CardArr[34].Context = "";
        CardArr[34].Position = new int[] { 0, 0 };

        CardArr[35].HP = 10;
        CardArr[35].AP = 5;
        CardArr[35].State = 0;
        CardArr[35].CardId = 35;
        CardArr[35].AbilityId = 0;
        CardArr[35].ImgPath = "Cardimg36";
        CardArr[35].Context = "";
        CardArr[35].Position = new int[] { 0, 0 };

        CardArr[36].HP = 10;
        CardArr[36].AP = 5;
        CardArr[36].State = 0;
        CardArr[36].CardId = 36;
        CardArr[36].AbilityId = 0;
        CardArr[36].ImgPath = "Cardimg37";
        CardArr[36].Context = "";
        CardArr[36].Position = new int[] { 0, 0 };

        CardArr[37].HP = 10;
        CardArr[37].AP = 5;
        CardArr[37].State = 0;
        CardArr[37].CardId = 37;
        CardArr[37].AbilityId = 0;
        CardArr[37].ImgPath = "Cardimg38";
        CardArr[37].Context = "";
        CardArr[37].Position = new int[] { 0, 0 };

        CardArr[38].HP = 10;
        CardArr[38].AP = 5;
        CardArr[38].State = 0;
        CardArr[38].CardId = 38;
        CardArr[38].AbilityId = 0;
        CardArr[38].ImgPath = "Cardimg39";
        CardArr[38].Context = "";
        CardArr[38].Position = new int[] { 0, 0 };

        CardArr[39].HP = 10;
        CardArr[39].AP = 5;
        CardArr[39].State = 0;
        CardArr[39].CardId = 39;
        CardArr[39].AbilityId = 0;
        CardArr[39].ImgPath = "Cardimg40";
        CardArr[39].Context = "";
        CardArr[39].Position = new int[] { 0, 0 };
    }
    public int DrawCard()
 {
        if (init == -1)
        {
            Init_Deck();
            init = 1;
        }
        if (DeckList.Count > 0)
        {
            int drawCardID = DeckList[0];
            DeckList.RemoveAt(0);
            return drawCardID;
        }
        else
        {
            Debug.LogWarning("덱이 비었습니다. 카드를 뽑을 수 없습니다.");
            return -1; ; //<- 일단 뭐라도 반환을 해야 코드가 굴러가요;
        }
 }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}



//CardStruct부분 작성후 DrawCard 작성(CardManager에 드로우한 카드의 정보를 구조체로 전달)
