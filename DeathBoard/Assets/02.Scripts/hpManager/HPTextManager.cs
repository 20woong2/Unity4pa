using UnityEngine;
using TMPro;
public class HPTextManager : MonoBehaviour
{
    public TextMeshProUGUI HPText;
    public Player player;
    void Start()
    {
        UpdateScoreDisplay();
    }
    private void UpdateScoreDisplay()
    {
        HPText.text = "\nPlayer HP: " + player.user.HP + "\nEnemy HP: " + player.enemy.HP;
    }
    void Update()
    {
        UpdateScoreDisplay(); 
    }
}