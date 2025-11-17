using UnityEngine;
using UnityEngine.Rendering;

public class Player
{
    int HP = 5;
    int CP = 0;
    int randomStack = 0;
    void attacked()
    {
        if (this.CP == 0)
        {
            this.randomStack = 0;
        }
        else if(this.CP <= 20)
        {
            this.randomStack = 5;
        }
        else if(this.CP <= 30)
        {
            this.randomStack = 15;
        }
        else if(this.CP <= 40)
        {
            this.randomStack = 50;
        }
        else if(this.CP < 50)
        {
            this.randomStack = 75;
        }
        else
        {
            this.randomStack = 100;
        }
        int attacked = Random.Range(1, 101);
        if (attacked <= this.randomStack)
        {
            this.HP--;
        }
    }
}
