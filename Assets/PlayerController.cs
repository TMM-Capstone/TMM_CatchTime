using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;
    public float moveSpeed = 5f; // �̵� �ӵ�
    private bool isMovingLeft = false; // ���� �̵� �� ����
    private bool isMovingRight = false; // ���� �̵� �� ����

    void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // �������� �̵�
        if (isMovingLeft)
        {
            MoveLeft();
        }
        // �������� �̵�
        else if (isMovingRight)
        {
            MoveRight();
        }
    }

    // �������� �̵�
    public void MoveLeft()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        playerSpriteRenderer.flipX = true; // �̹��� ����
    }

    // �������� �̵�
    public void MoveRight()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        playerSpriteRenderer.flipX = false; // �̹��� ����
    }

    // ���� ��ư�� ������ �� ȣ��Ǵ� �޼���
    public void OnLeftButtonDown()
    {
        isMovingLeft = true;
    }

    // ���� ��ư�� ������ �� ȣ��Ǵ� �޼���
    public void OnLeftButtonUp()
    {
        isMovingLeft = false;
    }

    // ���� ��ư�� ������ �� ȣ��Ǵ� �޼���
    public void OnRightButtonDown()
    {
        isMovingRight = true;
    }

    // ���� ��ư�� ������ �� ȣ��Ǵ� �޼���
    public void OnRightButtonUp()
    {
        isMovingRight = false;
    }
}