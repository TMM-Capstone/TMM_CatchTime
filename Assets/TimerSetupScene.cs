using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Text = TMPro.TextMeshProUGUI;

public class TimerSetupScene : MonoBehaviour
{
    public Slider workSlider;
    public Slider breakSlider;
    public Text workTimeText;
    public Text breakTimeText;
    public Button startButton;
    public Button pomodoroButton;
    public Button lastTimeButton;
    public Image lastTimeImage;

    private int sliderStep = 5;
    private Color pomodoroButtonColor;

    private int lastWorkTime; // 이전 작업 시간 저장 변수
    private int lastRestTime; // 이전 휴식 시간 저장 변수

    void Start()
    {
        // Slider의 최소값과 최대값 설정
        workSlider.minValue = 0;
        workSlider.maxValue = 60;
        breakSlider.minValue = 0;
        breakSlider.maxValue = 60;

        // Slider의 단위값 설정
        workSlider.wholeNumbers = true;
        breakSlider.wholeNumbers = true;

        // 뽀모도로 버튼의 원래 색상 저장
        pomodoroButtonColor = pomodoroButton.GetComponent<Image>().color;

        workSlider.onValueChanged.AddListener(delegate { UpdateWorkTime(); });
        breakSlider.onValueChanged.AddListener(delegate { UpdateBreakTime(); });
        startButton.onClick.AddListener(delegate { StartTimer(); });
        pomodoroButton.onClick.AddListener(delegate { TogglePomodoroMode(); });
        lastTimeButton.onClick.AddListener(delegate { ShowLastTime(); });

        // 초기 텍스트 설정
        UpdateWorkTime();
        UpdateBreakTime();

        // 저장된 이전 작업 시간과 휴식 시간 불러오기
        lastWorkTime = PlayerPrefs.GetInt("LastWorkTime", 0);
        lastRestTime = PlayerPrefs.GetInt("LastRestTime", 0);
    }

    void UpdateWorkTime()
    {
        int workTimeMinutes = Mathf.RoundToInt(workSlider.value / sliderStep) * sliderStep; // 5의 배수로 반올림
        workSlider.value = workTimeMinutes; // 정확한 값을 설정하기 위해 Slider의 값을 업데이트
        workTimeText.text = FormatTime(workTimeMinutes);
    }

    void UpdateBreakTime()
    {
        int breakTimeMinutes = Mathf.RoundToInt(breakSlider.value / sliderStep) * sliderStep; // 5의 배수로 반올림
        breakSlider.value = breakTimeMinutes; // 정확한 값을 설정하기 위해 Slider의 값을 업데이트
        breakTimeText.text = FormatTime(breakTimeMinutes);
    }

    string FormatTime(int minutes)
    {
        int hours = minutes / 60;
        int remainingMinutes = minutes % 60;
        return string.Format("{0:00}:{1:00}", hours, remainingMinutes);
    }

    void StartTimer()
    {
        int workTime = Mathf.RoundToInt(workSlider.value);
        int breakTime = Mathf.RoundToInt(breakSlider.value);

        // 현재 선택된 시간을 저장
        PlayerPrefs.SetInt("LastWorkTime", workTime);
        PlayerPrefs.SetInt("LastRestTime", breakTime);

        PlayerPrefs.SetInt("WorkTime", workTime);
        PlayerPrefs.SetInt("BreakTime", breakTime);

        SceneManager.LoadScene("WorkTimerScene");
    }

    void TogglePomodoroMode()
    {
        int pomodoroWorkTime = 25;
        int pomodoroBreakTime = 5;

        workSlider.value = pomodoroWorkTime;
        breakSlider.value = pomodoroBreakTime;

        UpdateWorkTime();
        UpdateBreakTime();
    }

    void ShowLastTime()
    {
        // 저장된 이전 작업 시간과 휴식 시간을 설정
        workSlider.value = lastWorkTime;
        breakSlider.value = lastRestTime;

        // 설정된 값을 업데이트하여 텍스트로 표시
        UpdateWorkTime();
        UpdateBreakTime();

        if (lastWorkTime == 0 && lastRestTime == 0)
        {
            ShowLastTimeImage();
        }
    }

    void ShowLastTimeImage()
    {
        lastTimeImage.gameObject.SetActive(true); // 이미지를 활성화하여 보이게 함
        StartCoroutine(FadeOutLastTimeImage()); // 이미지 fade out을 위한 코루틴 시작
    }

    IEnumerator FadeOutLastTimeImage()
    {
        yield return new WaitForSeconds(1f); // 1초 대기
        lastTimeImage.gameObject.SetActive(false); // 이미지를 비활성화하여 숨김
    }
}