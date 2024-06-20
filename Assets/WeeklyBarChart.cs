using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeeklyBarChart : MonoBehaviour
{
    public RectTransform barPrefab;
    public Transform barChartContainer;
    private Dictionary<System.DayOfWeek, RectTransform> bars = new Dictionary<System.DayOfWeek, RectTransform>();

    void Start()
    {
        InitializeBars();
        UpdateBarChart();
    }

    void InitializeBars()
    {
        foreach (System.DayOfWeek day in System.Enum.GetValues(typeof(System.DayOfWeek)))
        {
            RectTransform bar = Instantiate(barPrefab, barChartContainer);
            bar.name = day.ToString();
            bars[day] = bar;
        }
    }

    void UpdateBarChart()
    {
        int weekNumber = GetWeekOfYear();
        foreach (System.DayOfWeek day in System.Enum.GetValues(typeof(System.DayOfWeek)))
        {
            string workTimeKey = GetWeeklyKey("WorkTime", weekNumber, day);
            int dailyWorkTime = PlayerPrefs.GetInt(workTimeKey, 0);
            UpdateBar(bars[day], dailyWorkTime);
        }
    }

    void UpdateBar(RectTransform bar, int value)
    {
        float maxValue = 60f; // 최대 작업 시간을 60분으로 가정
        float normalizedValue = (float)value / maxValue;
        bar.sizeDelta = new Vector2(bar.sizeDelta.x, normalizedValue * 200); // 200은 최대 높이값
    }

    int GetWeekOfYear()
    {
        System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CurrentCulture;
        System.Globalization.Calendar calendar = ci.Calendar;
        System.DateTime now = System.DateTime.Now;
        return calendar.GetWeekOfYear(now, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
    }

    string GetWeeklyKey(string prefix, int weekNumber, System.DayOfWeek dayOfWeek)
    {
        return $"{prefix}_Week{weekNumber}_{dayOfWeek}";
    }
}