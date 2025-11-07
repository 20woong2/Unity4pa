using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

// Developer: Jinuk Lee

// AudioSource 컴포넌트가 반드시 필요함을 명시
// AudioSourc가 없다면 강제로 추가함 / 삭제 불가
[RequireComponent(typeof(AudioSource))]
public class introDirector : MonoBehaviour
{
    // 키 입력을 막아줄 변수 (true: 입력 금지)
    private bool isInputBlocked = true;

    // 최대 비디오 개수를 정의 (const: 상수, 선언과 동시에 값을 할당)
    private const int MAX_VIDEO_COUNT = 8;

    // SPACE 키를 누른 횟수 카운트
    [Header("이벤트 카운트")]
    private int pressCount = 0;

    [Header("스페이스 바 사이의 딜레이")]
    public float spaceBarDelay = 2.0f;

    [Header("마지막에 이동할 Scene")]
    public string nextSceneName = "InGame";

    [Header("비디오 설정")]
    public VideoPlayer videoPlayer; // 비디오 플레이어
    public VideoClip[] videoClips; // 여러개의 비디오를 넣을 배열 (최대 개수: MAX_VIDEO_COUNT)

    [Header("오디오 설정")]
    public AudioClip spacebarSound; // SPACE 키를 눌렀을 때 재생 될 효과음
    // AudioSource가 private인 이유: 어차피 밖(Audio Source)에서 뭘 해도 그 값은 사용 안함
    private AudioSource audioSource; // 오디오 소스 (오디오 재생)

    [Header("SPACE 키 KeyDown 시 카메라 흔들림 설정")]
    // cameraShakeScript 에 Main Camera를 끌어오는 이유 : 메인 카메라에 사용할 CameraShake가 있다
    // 유니티는 Main Camera만 끌어놔도 자동으로 CameraShake로 가도록 설계되어있다.
    public CameraShake cameraShakeScript; // Main Camera의 CameraShake 스크립트
    public float intenseShakeDuration = 0.5f; // 강하게 흔들 강도
    public float intenseShakeMagnitude = 0.5f; // 강하게 흔들 시간

    // OnValidate() 함수는 인스펙터에서 값이 변경될 때마다 호출된다.
    // 비디오의 최대 개수를 제한하는 함수
    void OnValidate()
    {
        // 내가 정한 최대 비디오 개수를 넘었다면
        if (videoClips.Length > MAX_VIDEO_COUNT)
        {
            // Log 띄우기
            Debug.LogWarning("비디오 클립은 최대 " + MAX_VIDEO_COUNT + "개까지만 할당할 수 있습니다. 초과된 항목은 무시됩니다.");

            // 리스트가 수정하기 쉽기 때문에 리스트로
            // 배열은 크기 조절이 어렵지만, 리스트는 크기 조절이 쉽다.
            // ex) 값을 버리고 크기를 조절하는 것이 불가능. 이미 할당된 크기가 있어서.
            // videoClips(배열)의 값을 새로운 리스트 tempList에 복사
            // List<T>: T만 담는 리스트가 됨.
            // tempList에 videoClips의 값을 받아서 넣어주자.
            List<VideoClip> tempList = new List<VideoClip>(videoClips);
            // tempList.GetRange(a, b) a부터 b개 까지만 잘라서 새로운 리스트로
            // toArray() -> 배열로 형변환
            // 얘는 결국 크기 조절이 아니라 새로 대입이다!
            videoClips = tempList.GetRange(0, MAX_VIDEO_COUNT).ToArray();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // getComponent로 오디오 컴포넌트를 가져옵니다.
        // 이 스크립트를 지정할 GameObject에 Audio Source를 할당합니다.
        audioSource = GetComponent<AudioSource>();

        // 유효성 검사 -> 문제 있으면 에러 로그 표시
        ValidationForIntroDirector();
        
        // 비디오 클립의 길이가 0 이상이고 videoPlayer가 존재하면

        // 첫번째 비디오 재생
        if (videoClips.Length > 0 && videoPlayer != null)
        {
            videoPlayer.clip = videoClips[0]; // Video Player의 Video Clip을 첫번째 순서의 영상으로
            videoPlayer.Play(); // 플레이

            // 일정 시간 이후에 입력 금지를 해제하는 코루틴을 시작시킵니다.
            StartCoroutine(EnableInputAfterDelay(9.0f));
        }

    }

    IEnumerator EnableInputAfterDelay(float delay)
    {
        // 지정된 시간만큼 딜레이(입력 금지)
        // yield return : 멈춤 지시
        // new WaitForSeconds(변수): 변수만큼 타이머를 맞춘다!
        // 게임 속도(Time.timeScale)의 영향을 받습니다.
        // new가 들어가는 이유: 하나의 객체 취급
        yield return new WaitForSeconds(delay);

        // delay가 지나면
        isInputBlocked = false; // 입력 금지를 해제합니다.
        Debug.Log("입력 금지 해제까지 " + delay + "초 걸렸습니다."); // (확인용 로그)
    }

    IEnumerator InputKeyDelay(float delay)
    {
        // 지정된 시간만큼 딜레이(입력 금지)
        // yield return : 멈춤 지시
        // new WaitForSeconds(변수): 변수만큼 타이머를 맞춘다!
        // 게임 속도(Time.timeScale)의 영향을 받습니다.
        // new가 들어가는 이유: 하나의 객체 취급
        yield return new WaitForSeconds(delay);

        // delay가 지나면
        isInputBlocked = false; // 입력 금지를 해제합니다.
        Debug.Log("입력 금지 해제까지 " + delay + "초 걸렸습니다."); // (확인용 로그)
    }

    // Update is called once per frame
    void Update()
    {
        // 구식(Old) KeyDown 감지기 때문에, Project Settings -> Player -> Other Settings의 Active Input Handling을 Both로 해주어야 한다.
        // 입력이 막히지 않았고(false), SPACE 키가 눌리면
        if (!isInputBlocked && Input.GetKeyDown(KeyCode.Space))
        {
            PressSpaceHandler(); // 핸들러 실행
        }
    }

    // 유효성 검사 -> 문제 있으면 에러 로그 표시
    private void ValidationForIntroDirector()
    {
        if (cameraShakeScript == null) Debug.LogError("CameraShake 스크립트가 할당되지 않았습니다.");
        if (videoPlayer == null) Debug.LogError("Video Player가 할당되지 않았습니다.");
        if (videoClips.Length == 0) Debug.LogError("할당된 Video Clip이 없습니다.");
    }

    private void PressSpaceHandler()
    {
        // if로 검사하는 이유는? -> NullReferenceException (null 참조 방지)를 위해...
        // 검사하기 때문에 빈 공간으로 남겨져 있어도 null을 참조하는 오류가 생기지 않고 함수를 건너뜀으로서 안정성 확보.

        // 카메라 흔들자!
        if (cameraShakeScript != null) // 카메라 흔들기 스크립트가 있다면
        {
            //cameraShakeScript의 강한 흔들림을 만들어주는 함수를 호출한다.
            // intense: 강렬한
            cameraShakeScript.PlayIntenseShake(intenseShakeDuration, intenseShakeMagnitude);
        }

        // 효과음 재생!
        if (spacebarSound != null) // 소리가 있다면
        {
            // PlayOneShot: 소리가 겹쳐서 재생될 수 있게 함
            // 그냥 Play() 하면 오류나는 이유
            // 1. Play()는 오디오 소스에 있는 소리를 재생, PlayOneShot(어쩌구)는 어쩌구 소리를 바로 재생 가능
            // 2. Play()는 기존 소리를 종료하고 재생하나, PlayOneShot(어쩌구)는 소리를 중첩해서 들리게 할 수 있다.
            // 즉, 한개의 스피커로 비디오와 오디오를 재생하는 경우에 사용 가능!
            // 한 개의 오브젝트가 여러개의 오디오 소스를 사용하는 경우와는 아예 다르다. 하나의 오디오 소스에 중첩 소리가 가능하도록 하는 것이다!
            audioSource.PlayOneShot(spacebarSound);
        }

        // 비디오 클립 전환!
        // 일정 시간 후 클릭 허용
        isInputBlocked = true;
        StartCoroutine(InputKeyDelay(spaceBarDelay));
        pressCount++; // 카운트 1 증가

        if (pressCount < videoClips.Length) // 할당할 비디오 개수보다 작을 때까지만
        {
            // pressCount(눌린 횟수)에 따른 비디오 순차 재생
            videoPlayer.clip = videoClips[pressCount];
            videoPlayer.Play();
            
        }
        else
        {
            // 비디오 전부 보고 나서 다음 Scene으로 전환
            videoPlayer.Stop();
            LoadingSceneManager.LoadScene(nextSceneName);
        }
    }
}
