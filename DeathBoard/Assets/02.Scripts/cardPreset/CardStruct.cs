using UnityEngine;

public struct CardStruct 
{
    public int CardId;
    public int HP;
    public int AP;
    public int State;
    public int AbilityId;
    public string ImgPath;
    public string Context;
    public int[] Position;
    public int EffectTiming;
    public CardStruct(int hp, int ap, int state, int id, int Aid, string Img, string text, int timing)
    {
        HP = hp;
        AP = ap;
        State = state;
        CardId = id;
        AbilityId = Aid;
        ImgPath = Img;
        Context = text;
        EffectTiming = timing;
        Position = new int[2];  // 배열 초기화
    }
};
