using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public Slider volumeSlider;

    // UI 켜질 때 실행됨
    private void OnEnable()
    {
        if (GlobalSettingsManager.Instance == null) return;

        // 설정창 켰을 때 슬라이더 위치가 이상하면 안 되니까 현재 볼륨으로 맞춰줌
        if (volumeSlider != null)
            volumeSlider.value = GlobalSettingsManager.Instance.globalVolume;
    }

    // --- UI 이벤트 연결 부분 ---

    // 슬라이더 움직일 때마다 호출 (Dynamic float 연결 필수!)
    public void OnVolumeChanged(float value)
    {
        // print("볼륨 조절 중: " + value); 
        if (GlobalSettingsManager.Instance != null)
        {
            GlobalSettingsManager.Instance.SetVolume(value);
        }
    }

    // --- 전체화면 버튼 ---
    // 화살표 함수(=>) 써서 한 줄로 줄임. 기능은 똑같음.

    public void OnClickFullScreenOn() => SetFullScreen(true);
    public void OnClickFullScreenOff() => SetFullScreen(false);

    private void SetFullScreen(bool isFull)
    {
        if (GlobalSettingsManager.Instance != null)
        {
            GlobalSettingsManager.Instance.isFullScreen = isFull;
            GlobalSettingsManager.Instance.ApplyGraphicsSettings();
        }
    }

    // --- 후처리(PostProcess) 버튼 ---

    public void OnClickPostProcessOn() => SetPostProcess(true);
    public void OnClickPostProcessOff() => SetPostProcess(false);

    private void SetPostProcess(bool isOn)
    {
        if (GlobalSettingsManager.Instance != null)
        {
            GlobalSettingsManager.Instance.usePostProcessing = isOn;
            GlobalSettingsManager.Instance.ApplyGraphicsSettings();
        }
    }

    // --- VHS 필터 버튼 ---

    public void OnClickVHSOn() => SetVHS(true);
    public void OnClickVHSOff() => SetVHS(false);

    private void SetVHS(bool isOn)
    {
        if (GlobalSettingsManager.Instance != null)
        {
            GlobalSettingsManager.Instance.useVHSFilter = isOn;
            GlobalSettingsManager.Instance.ApplyGraphicsSettings();
        }
    }

    // --- 저장 버튼 눌렀을 때 ---
    public void OnApplyButtonClicked()
    {
        if (GlobalSettingsManager.Instance != null)
        {
            // 저장하기 전에 슬라이더 값 한번 더 확실하게 넣어줌 (보험)
            if (volumeSlider != null)
                GlobalSettingsManager.Instance.SetVolume(volumeSlider.value);

            GlobalSettingsManager.Instance.SaveSettings();
        }

        gameObject.SetActive(false); // 설정창 닫기
    }
}