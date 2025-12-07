using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    [Header("게임 오버 화면 (패배)")]
    public GameObject gameOverScreen;
    [Header("게임 클리어 화면 (승리)")]
    public GameObject gameClearScreen; // 새로 추가된 부분!

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void EnemyWin()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
        else
        {
            Debug.LogWarning("연결된 gameOverScreen를 찾을 수 없음. inspector를 확인해 보세요.");
        }

    }

    public void PlayerWin()
    {
        if (gameClearScreen != null)
        {
            gameClearScreen.SetActive(true);
        }
        else
        {
            Debug.LogWarning("gameClearScreen이 연결되지 않았습니다! Inspector에서 연결해주세요.");
        }
    }
}
