using UnityEngine;
using UnityEngine.EventSystems;

public class GameEndManager : MonoBehaviour
{
    [Header("UI 연결")]
    public GameObject gameOverScreen;
    public GameObject gameClearScreen;

    public void EnemyWin()
    {
        DisableClick();

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
        DisableClick();

        if (gameClearScreen != null)
        {
            gameClearScreen.SetActive(true);
        }
        else
        {
            Debug.LogWarning("gameClearScreen이 연결되지 않았습니다! Inspector에서 연결해주세요.");
        }
    }

    // 카메라에서 나가는 레이캐스트 끄는 함수
    void DisableClick()
    {

        // 메인 카메라 없으면 걍 리턴 (에러 방지)
        if (Camera.main == null) return;

        // 3D 오브젝트 클릭 감지 컴포넌트 찾아서 끄기
        var raycast3D = Camera.main.GetComponent<PhysicsRaycaster>();
        if (raycast3D != null) raycast3D.enabled = false;

        // 2D 오브젝트 클릭 감지 컴포넌트 찾아서 끄기 (혹시 몰라서 넣음)
        var raycast2D = Camera.main.GetComponent<Physics2DRaycaster>();
        if (raycast2D != null) raycast2D.enabled = false;
    }
}
