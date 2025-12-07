using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalSettingsManager : MonoBehaviour
{
    // 어디서든 접근할 수 있게 static으로 만듦 (싱글톤)
    public static GlobalSettingsManager Instance;

    [Header("기본 설정값 (처음 할 때)")]
    public bool defaultFullScreen = true;
    [Range(0f, 1f)] public float defaultVolume = 1.0f;
    public bool defaultPostProcess = true;
    public bool defaultVHS = true;

    [Header("현재 적용된 설정")]
    public bool isFullScreen;
    [Range(0f, 1f)] public float globalVolume;
    public bool usePostProcessing;
    public bool useVHSFilter;

    [Header("개발자 옵션")]
    public bool forceResetSaveData = false;  // 게임 시작 시 무조건 저장된 데이터를 싹 지우고 기본값으로 시작합니다.

    private void Awake()
    {
        // 싱글톤 패턴: 게임 내에 나(매니저)는 무조건 하나만 있어야 함
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 넘어가도 파괴되지 말아라

            // 테스트할 때 데이터 꼬이면 초기화하려고 만든 거
            if (forceResetSaveData)
            {
                PlayerPrefs.DeleteAll();
                print("데이터 리셋 완료");
            }

            LoadSettings(); // 켜지자마자 저장된 거 불러오기
        }
        else
        {
            // 만약 내가 또 생기면(중복) 그냥 없애버림
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        // 씬 로딩될 때마다 함수 연결
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        // 가끔 슬라이더랑 실제 소리랑 안 맞을 때가 있어서 매 프레임 강제로 맞춤
        if (AudioListener.volume != globalVolume)
        {
            AudioListener.volume = globalVolume;
        }
    }

    // 인스펙터에서 값 조절할 때 바로바로 소리 바뀌게 (테스트 편하게)
    private void OnValidate()
    {
        AudioListener.volume = globalVolume;
    }

    // 씬 이동 끝나면 호출됨
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplyGraphicsSettings();
        SetVolume(globalVolume);
    }

    public void ApplyGraphicsSettings()
    {

        if (isFullScreen)
        {
            // 현재 모니터의 최대 해상도로 '전체화면 창모드(Borderless)' 설정
            // (FullScreenWindow 모드가 Alt-Tab 전환도 빠르고 오류가 적음)
            Resolution maxRes = Screen.currentResolution;
            Screen.SetResolution(maxRes.width, maxRes.height, FullScreenMode.FullScreenWindow);
        }
        else
        {
            // 창모드로 전환 시 특정 사이즈로 강제 변경
            // 이렇게 해상도를 정해야 창모드로 확실하게 변함
            Screen.SetResolution(1600, 900, FullScreenMode.Windowed);
        }

        // 효과 오브젝트 찾기 (꺼져있으면 못 찾으니까 함수 따로 만듦)
        GameObject postProcessObj = FindObj("PostProcess");
        GameObject vhsObj = FindObj("VHSFilter");

        // 찾았으면 설정대로 끄거나 켜기
        if (postProcessObj != null) postProcessObj.SetActive(usePostProcessing);
        if (vhsObj != null) vhsObj.SetActive(useVHSFilter);

        // print("그래픽 설정 적용됨");
    }

    // 비활성화된(꺼진) 오브젝트도 찾아내는 함수
    GameObject FindObj(string name)
    {
        // 1. 켜져 있는 놈이면 바로 return
        GameObject activeObj = GameObject.Find(name);
        if (activeObj != null) return activeObj;

        // 2. 꺼져 있으면 씬 전체 뒤져야 함
        Scene activeScene = SceneManager.GetActiveScene();
        if (!activeScene.IsValid()) return null;

        // 최상위 오브젝트들 하나씩 검사
        foreach (GameObject root in activeScene.GetRootGameObjects())
        {
            if (root.name == name) return root;

            // 자식 오브젝트까지 뒤짐
            Transform result = root.transform.Find(name);
            if (result != null) return result.gameObject;
        }
        return null; 
    }

    public void SetVolume(float volume)
    {
        globalVolume = volume;
        AudioListener.volume = globalVolume;
    }

    // 저장하기 (PlayerPrefs 사용)
    public void SaveSettings()
    {
        // bool은 저장이 안 돼서 1(true), 0(false)으로 바꿔서 저장함
        PlayerPrefs.SetInt("FullScreen", isFullScreen ? 1 : 0);
        PlayerPrefs.SetFloat("Volume", globalVolume);
        PlayerPrefs.SetInt("PostProcess", usePostProcessing ? 1 : 0);
        PlayerPrefs.SetInt("VHS", useVHSFilter ? 1 : 0);

        PlayerPrefs.Save(); // 디스크에 쓰기

        // 저장했으니 한번 더 확실하게 적용
        ApplyGraphicsSettings();
        SetVolume(globalVolume);

        print("설정 저장");
    }

    // 불러오기
    void LoadSettings()
    {
        // 저장된 거 없으면 기본값(Default) 씀
        isFullScreen = PlayerPrefs.GetInt("FullScreen", defaultFullScreen ? 1 : 0) == 1;
        globalVolume = PlayerPrefs.GetFloat("Volume", defaultVolume);
        usePostProcessing = PlayerPrefs.GetInt("PostProcess", defaultPostProcess ? 1 : 0) == 1;
        useVHSFilter = PlayerPrefs.GetInt("VHS", defaultVHS ? 1 : 0) == 1;

        SetVolume(globalVolume);
        ApplyGraphicsSettings();
    }

    // 인스펙터에서 우클릭해서 초기화할 수 있게
    [ContextMenu("데이터 초기화")]
    public void ResetAllData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        print("초기화 완료. 기본값으로 돌아감");

        isFullScreen = defaultFullScreen;
        globalVolume = defaultVolume;
        usePostProcessing = defaultPostProcess;
        useVHSFilter = defaultVHS;

        ApplyGraphicsSettings();
        SetVolume(globalVolume);
    }
}