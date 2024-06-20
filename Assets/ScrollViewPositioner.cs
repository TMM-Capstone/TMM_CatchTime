using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewPositioner : MonoBehaviour
{
    private ScrollRect scrollRect;

    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        // 스크롤 위치를 맨 위로 설정
        scrollRect.verticalNormalizedPosition = 1f;
    }
}