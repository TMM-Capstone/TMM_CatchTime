using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    System.Action _OnClickConformButton;
    // 싱글턴 패턴 ~~~~~~~~~~~~~~~~~~~~~~~~
    private static PopUpManager _instance;
    public static PopUpManager Instance
    {
        get
        {
            return _instance;
        }
    }
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    public GameObject _popup; // 인스펙터에서 넣어줄 예정

    // 시작하자마자 호출됨
    private void Awake()
    {
        _popup.SetActive(false); // 팝업은 처음에 꺼져있어야함
        DontDestroyOnLoad(this); // 씬이 넘어가도 이 스크립트는 파괴되면 안됨
        _instance = this; // PopUpManager가 NULL이 되지않도록
    }

    public void Open(System.Action OnClickConformButton)
    {
        _popup.SetActive(true);
        _OnClickConformButton = OnClickConformButton;
    }

    public void Close()
    {
        _popup.SetActive(false);
    }

    public void OnClickConformButton()
    {
        // 액션 콜백이 넘어왔을 때만(예외처리)
        if (_OnClickConformButton != null)
        {
            Debug.Log("확인 버튼 누름");
            _OnClickConformButton(); // 해당 델리게이트에 저장된 함수 실행
        }
        Close(); // 실행 후에는 창을 꺼준다.
    }

}