using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatControl2 : MonoBehaviour
{

    Animator animator;
    public bool LeftMove = false;
    public bool RightMove = false;
    Vector3 moveVelocity = Vector3.zero;
    float moveSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LeftMove)
        {
            animator.SetBool("Direction", false);
            moveVelocity = new Vector3(-0.10f, 0, 0);
            transform.position += moveVelocity * moveSpeed * Time.deltaTime;

            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * -1;
            transform.localScale = scale;
        }

        if (RightMove)
        {
            animator.SetBool("Direction", true);
            moveVelocity = new Vector3(+0.10f, 0, 0);
            transform.position += moveVelocity * moveSpeed * Time.deltaTime;

            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }

        AnimationUpdate();

    }

        void AnimationUpdate()
        {
            if (LeftMove || RightMove)
            {
                animator.SetBool("isWalking", true); // 이동 중 애니메이션 재생
            }
            else
            {
                animator.SetBool("isWalking", false); // 정지 상태 애니메이션 재생
            }
        }
 
}