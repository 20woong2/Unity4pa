using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Player player;
    public TurnManager turnManager;
    void OnMouseDown()
    {
       if(TurnManager.currentturn == 10)
        {
            Debug.Log("before: " + player.enemy.CP);
            player.enemy.attacked();
            Debug.Log("after: " + player.enemy.CP);
            Debug.Log("now HP: " + player.enemy.HP);
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
