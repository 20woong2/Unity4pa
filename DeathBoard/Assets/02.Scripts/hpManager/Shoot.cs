using UnityEngine;

public class Shoot : MonoBehaviour
{
    Player player;
    TurnManager turnManager;
    void OnMouseDown()
    {
       if(TurnManager.currentturn == 10)
        {
            player.enemy.attacked();
            Debug.Log(player.enemy.HP);
            TurnManager.currentturn = 11;
            TurnManager.turnend = true;
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
