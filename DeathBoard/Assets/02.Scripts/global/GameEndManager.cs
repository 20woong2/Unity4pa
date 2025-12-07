using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    [Header("UI 연결")]
    public GameObject gameOverScreen;
    public GameObject gameClearScreen;

    [Header("raycast block 설정")]
    public bool blockMouseInput = true; // 게임 오버 및 클리어 화면에서 클릭 막을지 여부

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
