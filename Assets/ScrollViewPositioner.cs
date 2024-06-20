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
        // ��ũ�� ��ġ�� �� ���� ����
        scrollRect.verticalNormalizedPosition = 1f;
    }
}