using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위해 필수!

public class MainMenuManager : MonoBehaviour
{
    // 인스펙터에서 이동할 씬의 이름을 적을 수 있도록 public 변수로 만듭니다.
    public string gameSceneName = "InGame"; // 예시: "InGame" 씬으로 이동

    // 이 함수를 버튼이 호출할 것입니다.
    // 'public'으로 선언해야 버튼의 OnClick() 이벤트에서 찾을 수 있습니다.
    public void StartGame()
    {
        // 이름으로 씬을 로드합니다.
        SceneManager.LoadScene(gameSceneName);
    }
}