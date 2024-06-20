using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    System.Action _OnClickConformButton;
    // �̱��� ���� ~~~~~~~~~~~~~~~~~~~~~~~~
    private static PopUpManager _instance;
    public static PopUpManager Instance
    {
        get
        {
            return _instance;
        }
    }
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    public GameObject _popup; // �ν����Ϳ��� �־��� ����

    // �������ڸ��� ȣ���
    private void Awake()
    {
        _popup.SetActive(false); // �˾��� ó���� �����־����
        DontDestroyOnLoad(this); // ���� �Ѿ�� �� ��ũ��Ʈ�� �ı��Ǹ� �ȵ�
        _instance = this; // PopUpManager�� NULL�� �����ʵ���
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
        // �׼� �ݹ��� �Ѿ���� ����(����ó��)
        if (_OnClickConformButton != null)
        {
            Debug.Log("Ȯ�� ��ư ����");
            _OnClickConformButton(); // �ش� ��������Ʈ�� ����� �Լ� ����
        }
        Close(); // ���� �Ŀ��� â�� ���ش�.
    }

}