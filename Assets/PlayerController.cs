using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;
    public float moveSpeed = 5f; // 이동 속도
    private bool isMovingLeft = false; // 좌측 이동 중 여부
    private bool isMovingRight = false; // 우측 이동 중 여부

    void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 좌측으로 이동
        if (isMovingLeft)
        {
            MoveLeft();
        }
        // 우측으로 이동
        else if (isMovingRight)
        {
            MoveRight();
        }
    }

    // 좌측으로 이동
    public void MoveLeft()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        playerSpriteRenderer.flipX = true; // 이미지 반전
    }

    // 우측으로 이동
    public void MoveRight()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        playerSpriteRenderer.flipX = false; // 이미지 반전
    }

    // 좌측 버튼을 눌렀을 때 호출되는 메서드
    public void OnLeftButtonDown()
    {
        isMovingLeft = true;
    }

    // 좌측 버튼을 떼었을 때 호출되는 메서드
    public void OnLeftButtonUp()
    {
        isMovingLeft = false;
    }

    // 우측 버튼을 눌렀을 때 호출되는 메서드
    public void OnRightButtonDown()
    {
        isMovingRight = true;
    }

    // 우측 버튼을 떼었을 때 호출되는 메서드
    public void OnRightButtonUp()
    {
        isMovingRight = false;
    }
}