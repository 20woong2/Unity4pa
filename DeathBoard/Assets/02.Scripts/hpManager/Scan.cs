using UnityEngine;

public class Scan : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Player player;
    public void scanAttack()
    {
        if(TurnManager.currentturn == 11)
        {
            int per = Random.Range(1, 101);
            if (per <= player.user.CP * 2)
            {
                player.user.attacked();
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
