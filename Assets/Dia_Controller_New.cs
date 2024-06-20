using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class Dia_Controller_New : MonoBehaviour
{
    public static int DiaInt;
    public static Text DiaText;
    public static GameObject Message; // �޽��� ������Ʈ
    public static Text MSG; // �޽��� ����

    public static float Timer; // Ÿ�̸�
    public static bool TimeSet; // Ÿ�̸� �۵�����

    // Start is called before the first frame update
    void Start()
    {
        DiaText = GameObject.Find("Canvas").transform.Find("Dia").transform.Find("Text").gameObject.GetComponent<Text>(); // DiaText�� Canvas/Dia/Text�� �ִ� Text�Դϴ�.

        Message = GameObject.Find("Canvas").transform.Find("Message").gameObject; // Message�� Canvas�ȿ� �ִ� Message �� ������Ʈ�Դϴ�.
        MSG = GameObject.Find("Canvas").transform.Find("Message").transform.Find("Text").gameObject.GetComponent<Text>();

        DiaInt = PlayerPrefs.GetInt("Dia", 0); // PlayerPrefs ���� ����Ǿ��ִ� 'Dia'�� �ҷ��� DiaInt�� �����մϴ�. ���࿡ ����� ������ ���ٸ� 0�� �����մϴ�.

        Message.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Dia", DiaInt); // DiaInt�� PlayerPrefs ����  ����Ǿ��ִ� 'Dia'�� �����մϴ�.
        DiaText.text = DiaInt.ToString(); //DiaText�� Text�� DiaInt�� ����մϴ�.

        if (TimeSet == true) // TimeSet�� True��
        {
            Timer += Time.deltaTime; // Ÿ�̸Ӱ� �۵��մϴ�.
            if (Timer > 2.0f) // 2�ʰ� ������
            {
                Message.SetActive(false);
                MSG.text = null;
                Timer = 0;
                TimeSet = false;
            }
        }
    }

    public void GetMoney() //���� ����ϴ�.
    {
        DiaInt += 10;
        Debug.Log("���̾� ��");
    }

    public void lostMoney() // ���� �ҽ��ϴ�.
    {
        if (DiaInt >= 30) // CoinInt�� 40�̻��̶��
        {
            DiaInt -= 30; // CoinInt�� 40 �پ��ϴ�.
            Debug.Log("�� �Ҿ���..");
        }
        else // ���࿡ �����ϴٸ�
        {
            Message.SetActive(true); // �޽��� ������Ʈ�� Ȱ��ȭ�մϴ�. 
            MSG.text = "���� �����մϴ�".ToString(); // MSG�� Text�� "���� �����մϴ�"�� ����մϴ�.
            TimeSet = true; // TimeSet�� true�� �մϴ�.
        }
    }
}
