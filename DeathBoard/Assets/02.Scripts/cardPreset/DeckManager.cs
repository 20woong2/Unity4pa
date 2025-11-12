using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public static CardStruct[] CardArr = new CardStruct[60];//아군 카드
    public static CardStruct[] CardBrr = new CardStruct[60];//적 카드
    public static List<int> DeckList = new List<int>();//아군 덱리스트
    public static List<int> EnemyDeckList = new List<int>();//적 덱리스트
    public static List<int> GraveList = new List<int>();
    public static List<int> HandList = new List<int>();//아군 손패 리스트
    public static List<int> EnemyHandList = new List<int>();//적 손패 리스트
    private int init = -1;
    void Start()
    {
        DeckList.Clear();

        List<int> tempList = new List<int>();
        //아군 덱 섞기
        // 0부터 39까지 숫자를 임시 리스트에 추가
        for (int i = 0; i < 60; i++)
        {
            tempList.Add(i);
            CardArr[i].Position = new int[2];
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
        //아군 덱 기본 정보
        CardArr[0].HP = 10;
        CardArr[0].AP = 5;
        CardArr[0].State = 0;
        CardArr[0].CardId = 0;
        CardArr[0].AbilityId = 0;
        CardArr[0].ImgPath = "Cardimg1";
        CardArr[0].Context = "";
        CardArr[0].Position[0] = -1;
        CardArr[0].Position[1] = -1;

        CardArr[1].HP = 10;
        CardArr[1].AP = 5;
        CardArr[1].State = 0;
        CardArr[1].CardId = 1;
        CardArr[1].AbilityId = 0;
        CardArr[1].ImgPath = "Cardimg1";
        CardArr[1].Context = "";
        CardArr[1].Position[0] = -1;
        CardArr[1].Position[1] = -1;

        CardArr[2].HP = 10;
        CardArr[2].AP = 5;
        CardArr[2].State = 0;
        CardArr[2].CardId = 2;
        CardArr[2].AbilityId = 0;
        CardArr[2].ImgPath = "Cardimg2";
        CardArr[2].Context = "";
        CardArr[2].Position[0] = -1;
        CardArr[2].Position[1] = -1;

        CardArr[3].HP = 10;
        CardArr[3].AP = 5;
        CardArr[3].State = 0;
        CardArr[3].CardId = 3;
        CardArr[3].AbilityId = 0;
        CardArr[3].ImgPath = "Cardimg2";
        CardArr[3].Context = "";
        CardArr[3].Position[0] = -1;
        CardArr[3].Position[1] = -1;

        CardArr[4].HP = 10;
        CardArr[4].AP = 5;
        CardArr[4].State = 0;
        CardArr[4].CardId = 4;
        CardArr[4].AbilityId = 0;
        CardArr[4].ImgPath = "Cardimg3";
        CardArr[4].Context = "";
        CardArr[4].Position[0] = -1;
        CardArr[4].Position[1] = -1;

        CardArr[5].HP = 10;
        CardArr[5].AP = 5;
        CardArr[5].State = 0;
        CardArr[5].CardId = 5;
        CardArr[5].AbilityId = 0;
        CardArr[5].ImgPath = "Cardimg3";
        CardArr[5].Context = "";
        CardArr[5].Position[0] = -1;
        CardArr[5].Position[1] = -1;

        CardArr[6].HP = 10;
        CardArr[6].AP = 5;
        CardArr[6].State = 0;
        CardArr[6].CardId = 6;
        CardArr[6].AbilityId = 0;
        CardArr[6].ImgPath = "Cardimg4";
        CardArr[6].Context = "";
        CardArr[6].Position[0] = -1;
        CardArr[6].Position[1] = -1;

        CardArr[7].HP = 10;
        CardArr[7].AP = 5;
        CardArr[7].State = 0;
        CardArr[7].CardId = 7;
        CardArr[7].AbilityId = 0;
        CardArr[7].ImgPath = "Cardimg4";
        CardArr[7].Context = "";
        CardArr[7].Position[0] = -1;
        CardArr[7].Position[1] = -1;

        CardArr[8].HP = 10;
        CardArr[8].AP = 5;
        CardArr[8].State = 0;
        CardArr[8].CardId = 8;
        CardArr[8].AbilityId = 0;
        CardArr[8].ImgPath = "Cardimg5";
        CardArr[8].Context = "";
        CardArr[8].Position[0] = -1;
        CardArr[8].Position[1] = -1;

        CardArr[9].HP = 10;
        CardArr[9].AP = 5;
        CardArr[9].State = 0;
        CardArr[9].CardId = 9;
        CardArr[9].AbilityId = 0;
        CardArr[9].ImgPath = "Cardimg5";
        CardArr[9].Context = "";
        CardArr[9].Position[0] = -1;
        CardArr[9].Position[1] = -1;

        CardArr[10].HP = 10;
        CardArr[10].AP = 5;
        CardArr[10].State = 0;
        CardArr[10].CardId = 10;
        CardArr[10].AbilityId = 0;
        CardArr[10].ImgPath = "Cardimg6";
        CardArr[10].Context = "";
        CardArr[10].Position[0] = -1;
        CardArr[10].Position[1] = -1;

        CardArr[11].HP = 10;
        CardArr[11].AP = 5;
        CardArr[11].State = 0;
        CardArr[11].CardId = 11;
        CardArr[11].AbilityId = 0;
        CardArr[11].ImgPath = "Cardimg6";
        CardArr[11].Context = "";
        CardArr[11].Position[0] = -1;
        CardArr[11].Position[1] = -1;

        CardArr[12].HP = 10;
        CardArr[12].AP = 5;
        CardArr[12].State = 0;
        CardArr[12].CardId = 12;
        CardArr[12].AbilityId = 0;
        CardArr[12].ImgPath = "Cardimg7";
        CardArr[12].Context = "";
        CardArr[12].Position[0] = -1;
        CardArr[12].Position[1] = -1;

        CardArr[13].HP = 10;
        CardArr[13].AP = 5;
        CardArr[13].State = 0;
        CardArr[13].CardId = 13;
        CardArr[13].AbilityId = 0;
        CardArr[13].ImgPath = "Cardimg7";
        CardArr[13].Context = "";
        CardArr[13].Position[0] = -1;
        CardArr[13].Position[1] = -1;

        CardArr[14].HP = 10;
        CardArr[14].AP = 5;
        CardArr[14].State = 0;
        CardArr[14].CardId = 14;
        CardArr[14].AbilityId = 0;
        CardArr[14].ImgPath = "Cardimg8";
        CardArr[14].Context = "";
        CardArr[14].Position[0] = -1;
        CardArr[14].Position[1] = -1;

        CardArr[15].HP = 10;
        CardArr[15].AP = 5;
        CardArr[15].State = 0;
        CardArr[15].CardId = 15;
        CardArr[15].AbilityId = 0;
        CardArr[15].ImgPath = "Cardimg8";
        CardArr[15].Context = "";
        CardArr[15].Position[0] = -1;
        CardArr[15].Position[1] = -1;

        CardArr[16].HP = 10;
        CardArr[16].AP = 5;
        CardArr[16].State = 0;
        CardArr[16].CardId = 16;
        CardArr[16].AbilityId = 0;
        CardArr[16].ImgPath = "Cardimg9";
        CardArr[16].Context = "";
        CardArr[16].Position[0] = -1;
        CardArr[16].Position[1] = -1;

        CardArr[17].HP = 10;
        CardArr[17].AP = 5;
        CardArr[17].State = 0;
        CardArr[17].CardId = 17;
        CardArr[17].AbilityId = 0;
        CardArr[17].ImgPath = "Cardimg9";
        CardArr[17].Context = "";
        CardArr[17].Position[0] = -1;
        CardArr[17].Position[1] = -1;

        CardArr[18].HP = 10;
        CardArr[18].AP = 5;
        CardArr[18].State = 0;
        CardArr[18].CardId = 18;
        CardArr[18].AbilityId = 0;
        CardArr[18].ImgPath = "Cardimg10";
        CardArr[18].Context = "";
        CardArr[18].Position[0] = -1;
        CardArr[18].Position[1] = -1;

        CardArr[19].HP = 10;
        CardArr[19].AP = 5;
        CardArr[19].State = 0;
        CardArr[19].CardId = 19;
        CardArr[19].AbilityId = 0;
        CardArr[19].ImgPath = "Cardimg10";
        CardArr[19].Context = "";
        CardArr[19].Position[0] = -1;
        CardArr[19].Position[1] = -1;

        CardArr[20].HP = 10;
        CardArr[20].AP = 5;
        CardArr[20].State = 0;
        CardArr[20].CardId = 20;
        CardArr[20].AbilityId = 0;
        CardArr[20].ImgPath = "Cardimg11";
        CardArr[20].Context = "";
        CardArr[20].Position[0] = -1;
        CardArr[20].Position[1] = -1;

        CardArr[21].HP = 10;
        CardArr[21].AP = 5;
        CardArr[21].State = 0;
        CardArr[21].CardId = 21;
        CardArr[21].AbilityId = 0;
        CardArr[21].ImgPath = "Cardimg11";
        CardArr[21].Context = "";
        CardArr[21].Position[0] = -1;
        CardArr[21].Position[1] = -1;

        CardArr[22].HP = 10;
        CardArr[22].AP = 5;
        CardArr[22].State = 0;
        CardArr[22].CardId = 22;
        CardArr[22].AbilityId = 0;
        CardArr[22].ImgPath = "Cardimg12";
        CardArr[22].Context = "";
        CardArr[22].Position[0] = -1;
        CardArr[22].Position[1] = -1;

        CardArr[23].HP = 10;
        CardArr[23].AP = 5;
        CardArr[23].State = 0;
        CardArr[23].CardId = 23;
        CardArr[23].AbilityId = 0;
        CardArr[23].ImgPath = "Cardimg12";
        CardArr[23].Context = "";
        CardArr[23].Position[0] = -1;
        CardArr[23].Position[1] = -1;

        CardArr[24].HP = 10;
        CardArr[24].AP = 5;
        CardArr[24].State = 0;
        CardArr[24].CardId = 24;
        CardArr[24].AbilityId = 0;
        CardArr[24].ImgPath = "Cardimg13";
        CardArr[24].Context = "";
        CardArr[24].Position[0] = -1;
        CardArr[24].Position[1] = -1;

        CardArr[25].HP = 10;
        CardArr[25].AP = 5;
        CardArr[25].State = 0;
        CardArr[25].CardId = 25;
        CardArr[25].AbilityId = 0;
        CardArr[25].ImgPath = "Cardimg13";
        CardArr[25].Context = "";
        CardArr[25].Position[0] = -1;
        CardArr[25].Position[1] = -1;

        CardArr[26].HP = 10;
        CardArr[26].AP = 5;
        CardArr[26].State = 0;
        CardArr[26].CardId = 26;
        CardArr[26].AbilityId = 0;
        CardArr[26].ImgPath = "Cardimg14";
        CardArr[26].Context = "";
        CardArr[26].Position[0] = -1;
        CardArr[26].Position[1] = -1;

        CardArr[27].HP = 10;
        CardArr[27].AP = 5;
        CardArr[27].State = 0;
        CardArr[27].CardId = 27;
        CardArr[27].AbilityId = 0;
        CardArr[27].ImgPath = "Cardimg14";
        CardArr[27].Context = "";
        CardArr[27].Position[0] = -1;
        CardArr[27].Position[1] = -1;

        CardArr[28].HP = 10;
        CardArr[28].AP = 5;
        CardArr[28].State = 0;
        CardArr[28].CardId = 28;
        CardArr[28].AbilityId = 0;
        CardArr[28].ImgPath = "Cardimg15";
        CardArr[28].Context = "";
        CardArr[28].Position[0] = -1;
        CardArr[28].Position[1] = -1;

        CardArr[29].HP = 10;
        CardArr[29].AP = 5;
        CardArr[29].State = 0;
        CardArr[29].CardId = 29;
        CardArr[29].AbilityId = 0;
        CardArr[29].ImgPath = "Cardimg15";
        CardArr[29].Context = "";
        CardArr[29].Position[0] = -1;
        CardArr[29].Position[1] = -1;

        CardArr[30].HP = 10;
        CardArr[30].AP = 5;
        CardArr[30].State = 0;
        CardArr[30].CardId = 30;
        CardArr[30].AbilityId = 0;
        CardArr[30].ImgPath = "Cardimg16";
        CardArr[30].Context = "";
        CardArr[30].Position[0] = -1;
        CardArr[30].Position[1] = -1;

        CardArr[31].HP = 10;
        CardArr[31].AP = 5;
        CardArr[31].State = 0;
        CardArr[31].CardId = 31;
        CardArr[31].AbilityId = 0;
        CardArr[31].ImgPath = "Cardimg16";
        CardArr[31].Context = "";
        CardArr[31].Position[0] = -1;
        CardArr[31].Position[1] = -1;

        CardArr[32].HP = 10;
        CardArr[32].AP = 5;
        CardArr[32].State = 0;
        CardArr[32].CardId = 32;
        CardArr[32].AbilityId = 0;
        CardArr[32].ImgPath = "Cardimg17";
        CardArr[32].Context = "";
        CardArr[32].Position[0] = -1;
        CardArr[32].Position[1] = -1;

        CardArr[33].HP = 10;
        CardArr[33].AP = 5;
        CardArr[33].State = 0;
        CardArr[33].CardId = 33;
        CardArr[33].AbilityId = 0;
        CardArr[33].ImgPath = "Cardimg17";
        CardArr[33].Context = "";
        CardArr[33].Position[0] = -1;
        CardArr[33].Position[1] = -1;

        CardArr[34].HP = 10;
        CardArr[34].AP = 5;
        CardArr[34].State = 0;
        CardArr[34].CardId = 34;
        CardArr[34].AbilityId = 0;
        CardArr[34].ImgPath = "Cardimg18";
        CardArr[34].Context = "";
        CardArr[34].Position[0] = -1;
        CardArr[34].Position[1] = -1;

        CardArr[35].HP = 10;
        CardArr[35].AP = 5;
        CardArr[35].State = 0;
        CardArr[35].CardId = 35;
        CardArr[35].AbilityId = 0;
        CardArr[35].ImgPath = "Cardimg18";
        CardArr[35].Context = "";
        CardArr[35].Position[0] = -1;
        CardArr[35].Position[1] = -1;

        CardArr[36].HP = 10;
        CardArr[36].AP = 5;
        CardArr[36].State = 0;
        CardArr[36].CardId = 36;
        CardArr[36].AbilityId = 0;
        CardArr[36].ImgPath = "Cardimg19";
        CardArr[36].Context = "";
        CardArr[36].Position[0] = -1;
        CardArr[36].Position[1] = -1;

        CardArr[37].HP = 10;
        CardArr[37].AP = 5;
        CardArr[37].State = 0;
        CardArr[37].CardId = 37;
        CardArr[37].AbilityId = 0;
        CardArr[37].ImgPath = "Cardimg19";
        CardArr[37].Context = "";
        CardArr[37].Position[0] = -1;
        CardArr[37].Position[1] = -1;

        CardArr[38].HP = 10;
        CardArr[38].AP = 5;
        CardArr[38].State = 0;
        CardArr[38].CardId = 38;
        CardArr[38].AbilityId = 0;
        CardArr[38].ImgPath = "Cardimg20";
        CardArr[38].Context = "";
        CardArr[38].Position[0] = -1;
        CardArr[38].Position[1] = -1;

        CardArr[39].HP = 10;
        CardArr[39].AP = 5;
        CardArr[39].State = 0;
        CardArr[39].CardId = 39;
        CardArr[39].AbilityId = 0;
        CardArr[39].ImgPath = "Cardimg20";
        CardArr[39].Context = "";
        CardArr[39].Position[0] = -1;
        CardArr[39].Position[1] = -1;

        CardArr[40].HP = 10;
        CardArr[40].AP = 5;
        CardArr[40].State = 0;
        CardArr[40].CardId = 40;
        CardArr[40].AbilityId = 0;
        CardArr[40].ImgPath = "Cardimg21";
        CardArr[40].Context = "";
        CardArr[40].Position[0] = -1;
        CardArr[40].Position[1] = -1;

        CardArr[41].HP = 10;
        CardArr[41].AP = 5;
        CardArr[41].State = 0;
        CardArr[41].CardId = 41;
        CardArr[41].AbilityId = 0;
        CardArr[41].ImgPath = "Cardimg21";
        CardArr[41].Context = "";
        CardArr[41].Position[0] = -1;
        CardArr[41].Position[1] = -1;

        CardArr[42].HP = 10;
        CardArr[42].AP = 5;
        CardArr[42].State = 0;
        CardArr[42].CardId = 42;
        CardArr[42].AbilityId = 0;
        CardArr[42].ImgPath = "Cardimg22";
        CardArr[42].Context = "";
        CardArr[42].Position[0] = -1;
        CardArr[42].Position[1] = -1;

        CardArr[43].HP = 10;
        CardArr[43].AP = 5;
        CardArr[43].State = 0;
        CardArr[43].CardId = 43;
        CardArr[43].AbilityId = 0;
        CardArr[43].ImgPath = "Cardimg22";
        CardArr[43].Context = "";
        CardArr[43].Position[0] = -1;
        CardArr[43].Position[1] = -1;

        CardArr[44].HP = 10;
        CardArr[44].AP = 5;
        CardArr[44].State = 0;
        CardArr[44].CardId = 44;
        CardArr[44].AbilityId = 0;
        CardArr[44].ImgPath = "Cardimg23";
        CardArr[44].Context = "";
        CardArr[44].Position[0] = -1;
        CardArr[44].Position[1] = -1;

        CardArr[45].HP = 10;
        CardArr[45].AP = 5;
        CardArr[45].State = 0;
        CardArr[45].CardId = 45;
        CardArr[45].AbilityId = 0;
        CardArr[45].ImgPath = "Cardimg23";
        CardArr[45].Context = "";
        CardArr[45].Position[0] = -1;
        CardArr[45].Position[1] = -1;

        CardArr[46].HP = 10;
        CardArr[46].AP = 5;
        CardArr[46].State = 0;
        CardArr[46].CardId = 46;
        CardArr[46].AbilityId = 0;
        CardArr[46].ImgPath = "Cardimg24";
        CardArr[46].Context = "";
        CardArr[46].Position[0] = -1;
        CardArr[46].Position[1] = -1;

        CardArr[47].HP = 10;
        CardArr[47].AP = 5;
        CardArr[47].State = 0;
        CardArr[47].CardId = 47;
        CardArr[47].AbilityId = 0;
        CardArr[47].ImgPath = "Cardimg24";
        CardArr[47].Context = "";
        CardArr[47].Position[0] = -1;
        CardArr[47].Position[1] = -1;

        CardArr[48].HP = 10;
        CardArr[48].AP = 5;
        CardArr[48].State = 0;
        CardArr[48].CardId = 48;
        CardArr[48].AbilityId = 0;
        CardArr[48].ImgPath = "Cardimg25";
        CardArr[48].Context = "";
        CardArr[48].Position[0] = -1;
        CardArr[48].Position[1] = -1;

        CardArr[49].HP = 10;
        CardArr[49].AP = 5;
        CardArr[49].State = 0;
        CardArr[49].CardId = 49;
        CardArr[49].AbilityId = 0;
        CardArr[49].ImgPath = "Cardimg25";
        CardArr[49].Context = "";
        CardArr[49].Position[0] = -1;
        CardArr[49].Position[1] = -1;

        CardArr[50].HP = 10;
        CardArr[50].AP = 5;
        CardArr[50].State = 0;
        CardArr[50].CardId = 50;
        CardArr[50].AbilityId = 0;
        CardArr[50].ImgPath = "Cardimg26";
        CardArr[50].Context = "";
        CardArr[50].Position[0] = -1;
        CardArr[50].Position[1] = -1;

        CardArr[51].HP = 10;
        CardArr[51].AP = 5;
        CardArr[51].State = 0;
        CardArr[51].CardId = 51;
        CardArr[51].AbilityId = 0;
        CardArr[51].ImgPath = "Cardimg26";
        CardArr[51].Context = "";
        CardArr[51].Position[0] = -1;
        CardArr[51].Position[1] = -1;

        CardArr[52].HP = 10;
        CardArr[52].AP = 5;
        CardArr[52].State = 0;
        CardArr[52].CardId = 52;
        CardArr[52].AbilityId = 0;
        CardArr[52].ImgPath = "Cardimg27";
        CardArr[52].Context = "";
        CardArr[52].Position[0] = -1;
        CardArr[52].Position[1] = -1;

        CardArr[53].HP = 10;
        CardArr[53].AP = 5;
        CardArr[53].State = 0;
        CardArr[53].CardId = 53;
        CardArr[53].AbilityId = 0;
        CardArr[53].ImgPath = "Cardimg27";
        CardArr[53].Context = "";
        CardArr[53].Position[0] = -1;
        CardArr[53].Position[1] = -1;

        CardArr[54].HP = 10;
        CardArr[54].AP = 5;
        CardArr[54].State = 0;
        CardArr[54].CardId = 54;
        CardArr[54].AbilityId = 0;
        CardArr[54].ImgPath = "Cardimg28";
        CardArr[54].Context = "";
        CardArr[54].Position[0] = -1;
        CardArr[54].Position[1] = -1;

        CardArr[55].HP = 10;
        CardArr[55].AP = 5;
        CardArr[55].State = 0;
        CardArr[55].CardId = 55;
        CardArr[55].AbilityId = 0;
        CardArr[55].ImgPath = "Cardimg28";
        CardArr[55].Context = "";
        CardArr[55].Position[0] = -1;
        CardArr[55].Position[1] = -1;

        CardArr[56].HP = 10;
        CardArr[56].AP = 5;
        CardArr[56].State = 0;
        CardArr[56].CardId = 56;
        CardArr[56].AbilityId = 0;
        CardArr[56].ImgPath = "Cardimg29";
        CardArr[56].Context = "";
        CardArr[56].Position[0] = -1;
        CardArr[56].Position[1] = -1;

        CardArr[57].HP = 10;
        CardArr[57].AP = 5;
        CardArr[57].State = 0;
        CardArr[57].CardId = 57;
        CardArr[57].AbilityId = 0;
        CardArr[57].ImgPath = "Cardimg29";
        CardArr[57].Context = "";
        CardArr[57].Position[0] = -1;
        CardArr[57].Position[1] = -1;

        CardArr[58].HP = 10;
        CardArr[58].AP = 5;
        CardArr[58].State = 0;
        CardArr[58].CardId = 58;
        CardArr[58].AbilityId = 0;
        CardArr[58].ImgPath = "Cardimg30";
        CardArr[58].Context = "";
        CardArr[58].Position[0] = -1;
        CardArr[58].Position[1] = -1;

        CardArr[59].HP = 10;
        CardArr[59].AP = 5;
        CardArr[59].State = 0;
        CardArr[59].CardId = 59;
        CardArr[59].AbilityId = 0;
        CardArr[59].ImgPath = "Cardimg30";
        CardArr[59].Context = "";
        CardArr[59].Position[0] = -1;
        CardArr[59].Position[1] = -1;
    }
    public int DrawCard()
    {
        if (init == -1)
        {
            
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
    

    // Update is called once per frame
    void Update()
    {

    }
}



//CardStruct부분 작성후 DrawCard 작성(CardManager에 드로우한 카드의 정보를 구조체로 전달)
