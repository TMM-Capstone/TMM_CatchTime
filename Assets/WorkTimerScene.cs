using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Text = TMPro.TextMeshProUGUI;

public class WorkTimerScene : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public Image filledImage; // Filled 이미지의 Image 컴포넌트
    public TextMeshProUGUI fadeInOutText; // Fade in/out 할 텍스트

    private int workTimeInSeconds; // 초 단위로 계산할 변수 추가
    private float timerElapsed; // 경과된 시간
    private float fillDuration = 1.0f; // 채워지는 데 걸리는 시간
    private float fadeDuration = 1.0f; // Fade in/out에 걸리는 시간
    private bool fadeInTextFinished = false; // Fade In이 완료되었는지 여부를 추적하는 변수

    void Start()
    {
        workTimeInSeconds = PlayerPrefs.GetInt("WorkTime"); // 사용자로부터 초 단위의 작업 시간을 입력 받음

        // 초기에 filled 이미지를 숨기기 위해 fillAmount를 0으로 설정
        filledImage.fillAmount = 0f;

        StartCoroutine(StartWorkTimer());
        StartCoroutine(FadeInOutText());
    }

    IEnumerator StartWorkTimer()
    {
        while (workTimeInSeconds >= 0) // workTimeInSeconds이 0 이상일 때까지 반복
        {
            timerText.text = FormatTime(workTimeInSeconds); // 텍스트로 표시
            float fillTarget = 1f - ((float)workTimeInSeconds / (float)PlayerPrefs.GetInt("WorkTime")); // 채워질 목표량 계산

            // filled 이미지를 숨기고 나서 채우기 시작
            StartCoroutine(FillImage(fillTarget));

            // 타이머가 00:01이 되었을 때 텍스트 Fade Out 시작
            if (workTimeInSeconds == 1 && fadeInTextFinished)
            {
                StartCoroutine(FadeOutText());
            }

            yield return new WaitForSeconds(1); // 1초마다 갱신
            workTimeInSeconds--;
        }
        SceneManager.LoadScene("BreakTimerScene");
    }

    IEnumerator FillImage(float targetFillAmount)
    {
        float timer = 0f;
        float initialFillAmount = filledImage.fillAmount;

        while (timer < fillDuration)
        {
            timer += Time.deltaTime;
            filledImage.fillAmount = Mathf.Lerp(initialFillAmount, targetFillAmount, timer / fillDuration); // 보간하여 부드럽게 채워짐
            yield return null;
        }

        filledImage.fillAmount = targetFillAmount; // 목표량에 도달하면 정확히 채워짐
    }

    IEnumerator FadeInOutText()
    {
        fadeInOutText.color = new Color(fadeInOutText.color.r, fadeInOutText.color.g, fadeInOutText.color.b, 0f); // 초기에 알파값을 0으로 설정하여 투명하게 함

        // Fade In
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeInOutText.color = new Color(fadeInOutText.color.r, fadeInOutText.color.g, fadeInOutText.color.b, alpha);
            yield return null;
        }

        // Fade In이 완료되면 fadeInTextFinished를 true로 설정
        fadeInTextFinished = true;
    }

    IEnumerator FadeOutText()
    {
        // Fade Out
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            fadeInOutText.color = new Color(fadeInOutText.color.r, fadeInOutText.color.g, fadeInOutText.color.b, alpha);
            yield return null;
        }
    }

    string FormatTime(int seconds)
    {
        int minutes = seconds / 60;
        int remainingSeconds = seconds % 60;
        return string.Format("{0:00}:{1:00}", minutes, remainingSeconds);
    }
}