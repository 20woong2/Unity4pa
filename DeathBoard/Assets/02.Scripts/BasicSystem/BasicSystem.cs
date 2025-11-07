using UnityEngine;

public class BasicSystem : MonoBehaviour
{
    // 게임 종료
    public void GameExit()
    {
    #if UNITY_EDITOR // 유니티 에디터에서는...
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
