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

    private int lastWorkTime; // ���� �۾� �ð� ���� ����
    private int lastRestTime; // ���� �޽� �ð� ���� ����

    void Start()
    {
        // Slider�� �ּҰ��� �ִ밪 ����
        workSlider.minValue = 0;
        workSlider.maxValue = 60;
        breakSlider.minValue = 0;
        breakSlider.maxValue = 60;

        // Slider�� ������ ����
        workSlider.wholeNumbers = true;
        breakSlider.wholeNumbers = true;

        // �Ǹ𵵷� ��ư�� ���� ���� ����
        pomodoroButtonColor = pomodoroButton.GetComponent<Image>().color;

        workSlider.onValueChanged.AddListener(delegate { UpdateWorkTime(); });
        breakSlider.onValueChanged.AddListener(delegate { UpdateBreakTime(); });
        startButton.onClick.AddListener(delegate { StartTimer(); });
        pomodoroButton.onClick.AddListener(delegate { TogglePomodoroMode(); });
        lastTimeButton.onClick.AddListener(delegate { ShowLastTime(); });

        // �ʱ� �ؽ�Ʈ ����
        UpdateWorkTime();
        UpdateBreakTime();

        // ����� ���� �۾� �ð��� �޽� �ð� �ҷ�����
        lastWorkTime = PlayerPrefs.GetInt("LastWorkTime", 0);
        lastRestTime = PlayerPrefs.GetInt("LastRestTime", 0);
    }

    void UpdateWorkTime()
    {
        int workTimeMinutes = Mathf.RoundToInt(workSlider.value / sliderStep) * sliderStep; // 5�� ����� �ݿø�
        workSlider.value = workTimeMinutes; // ��Ȯ�� ���� �����ϱ� ���� Slider�� ���� ������Ʈ
        workTimeText.text = FormatTime(workTimeMinutes);
    }

    void UpdateBreakTime()
    {
        int breakTimeMinutes = Mathf.RoundToInt(breakSlider.value / sliderStep) * sliderStep; // 5�� ����� �ݿø�
        breakSlider.value = breakTimeMinutes; // ��Ȯ�� ���� �����ϱ� ���� Slider�� ���� ������Ʈ
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

        // ���� ���õ� �ð��� ����
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
        // ����� ���� �۾� �ð��� �޽� �ð��� ����
        workSlider.value = lastWorkTime;
        breakSlider.value = lastRestTime;

        // ������ ���� ������Ʈ�Ͽ� �ؽ�Ʈ�� ǥ��
        UpdateWorkTime();
        UpdateBreakTime();

        if (lastWorkTime == 0 && lastRestTime == 0)
        {
            ShowLastTimeImage();
        }
    }

    void ShowLastTimeImage()
    {
        lastTimeImage.gameObject.SetActive(true); // �̹����� Ȱ��ȭ�Ͽ� ���̰� ��
        StartCoroutine(FadeOutLastTimeImage()); // �̹��� fade out�� ���� �ڷ�ƾ ����
    }

    IEnumerator FadeOutLastTimeImage()
    {
        yield return new WaitForSeconds(1f); // 1�� ���
        lastTimeImage.gameObject.SetActive(false); // �̹����� ��Ȱ��ȭ�Ͽ� ����
    }
}