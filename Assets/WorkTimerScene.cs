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
    public Image filledImage; // Filled �̹����� Image ������Ʈ
    public TextMeshProUGUI fadeInOutText; // Fade in/out �� �ؽ�Ʈ

    private int workTimeInSeconds; // �� ������ ����� ���� �߰�
    private float timerElapsed; // ����� �ð�
    private float fillDuration = 1.0f; // ä������ �� �ɸ��� �ð�
    private float fadeDuration = 1.0f; // Fade in/out�� �ɸ��� �ð�
    private bool fadeInTextFinished = false; // Fade In�� �Ϸ�Ǿ����� ���θ� �����ϴ� ����

    void Start()
    {
        workTimeInSeconds = PlayerPrefs.GetInt("WorkTime"); // ����ڷκ��� �� ������ �۾� �ð��� �Է� ����

        // �ʱ⿡ filled �̹����� ����� ���� fillAmount�� 0���� ����
        filledImage.fillAmount = 0f;

        StartCoroutine(StartWorkTimer());
        StartCoroutine(FadeInOutText());
    }

    IEnumerator StartWorkTimer()
    {
        while (workTimeInSeconds >= 0) // workTimeInSeconds�� 0 �̻��� ������ �ݺ�
        {
            timerText.text = FormatTime(workTimeInSeconds); // �ؽ�Ʈ�� ǥ��
            float fillTarget = 1f - ((float)workTimeInSeconds / (float)PlayerPrefs.GetInt("WorkTime")); // ä���� ��ǥ�� ���

            // filled �̹����� ����� ���� ä��� ����
            StartCoroutine(FillImage(fillTarget));

            // Ÿ�̸Ӱ� 00:01�� �Ǿ��� �� �ؽ�Ʈ Fade Out ����
            if (workTimeInSeconds == 1 && fadeInTextFinished)
            {
                StartCoroutine(FadeOutText());
            }

            yield return new WaitForSeconds(1); // 1�ʸ��� ����
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
            filledImage.fillAmount = Mathf.Lerp(initialFillAmount, targetFillAmount, timer / fillDuration); // �����Ͽ� �ε巴�� ä����
            yield return null;
        }

        filledImage.fillAmount = targetFillAmount; // ��ǥ���� �����ϸ� ��Ȯ�� ä����
    }

    IEnumerator FadeInOutText()
    {
        fadeInOutText.color = new Color(fadeInOutText.color.r, fadeInOutText.color.g, fadeInOutText.color.b, 0f); // �ʱ⿡ ���İ��� 0���� �����Ͽ� �����ϰ� ��

        // Fade In
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeInOutText.color = new Color(fadeInOutText.color.r, fadeInOutText.color.g, fadeInOutText.color.b, alpha);
            yield return null;
        }

        // Fade In�� �Ϸ�Ǹ� fadeInTextFinished�� true�� ����
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