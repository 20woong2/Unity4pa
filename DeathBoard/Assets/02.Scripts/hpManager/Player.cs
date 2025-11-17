using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public struct PlayerStruct
    {
        public int HP; //hp
        public int CP; //공포게이지
        public int randomStack; //공포게이지 따른 확률
        public void attacked()

        {
            if (this.CP == 0)
            {
                this.randomStack = 0;
            }
            else if (this.CP <= 20)
            {
                this.randomStack = 5;
            }
            else if (this.CP <= 30)
            {
                this.randomStack = 15;
            }
            else if (this.CP <= 40)
            {
                this.randomStack = 50;
            }
            else if (this.CP < 50)
            {
                this.randomStack = 75;
            }
            else
            {
                this.randomStack = 100;
            }
            int attacked = Random.Range(1, 101);
            this.CP = 0;
            if (attacked <= this.randomStack)
            {
                this.HP--;
            }
        }
        PlayerStruct(int HP, int CP, int randomStack)
        {
            this.HP = HP;
            this.CP = CP;
            this.randomStack = randomStack;
        }
    }
    public PlayerStruct user;
    public PlayerStruct enemy;
    void Start()
    {
        user.HP = 5;
        user.CP = 0;
        user.randomStack = 0;
        enemy.HP = 5;
        enemy.CP = 0;
        enemy.randomStack = 0;
    }
}
