using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class KiingController : MonoBehaviour
{
    // Animation Number = 0 : Idle, 1 : Run, 2 : Attack, 3 : Dead
    private int stateNum;
    public float timer;
    public Rigidbody2D rg2D;
    public Animator animator;

    void Start()
    {
        
    }
    void Update()
    {
        KingMove();

        KingAttack();

        KingJump();
    }
    private void KingMove()
    {
        // 무조건 -1,0,1이 나옴
        float h = Input.GetAxisRaw("Horizontal");
        if (h == 0f)
        {
            animator.SetInteger("State", 0);
        }
        else
        {
            animator.SetInteger("State", 1);

            this.rg2D.velocity = (new Vector2(h * 3f, 0));
            this.transform.localScale = new Vector3(h, 1, 1);
            if (Input.GetKey(KeyCode.KeypadEnter))
            {
                this.rg2D.velocity = (new Vector2(0, 0));
                animator.SetInteger("State", 0);
                animator.SetInteger("State", 2);
                this.timer += Time.deltaTime;
                if (timer >= 0.433)
                {
                    Debug.Log("AttackCompleted");
                    this.timer = 0;
                }
                animator.SetInteger("State", 0);
            }
        }
    }

    private void KingAttack()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            animator.SetInteger("State", 2);
        }
    }

    private void KingJump()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            this.rg2D.velocity = (new Vector2(0, 10f));
        }
        if (this.rg2D.velocity.y <= 10f && this.rg2D.velocity.y >= 8f)
        {
            animator.SetInteger("State", 5);
        }
        else if (this.rg2D.velocity.y > 0)
        {
            animator.SetInteger("State", 3);
        }
        else if (this.rg2D.velocity.y < 0 && this.rg2D.velocity.y>-8f)
        {
            animator.SetInteger("State", 6);
        }
        else if (this.rg2D.velocity.y <= -8f && this.rg2D.velocity.y >= -10f)
        {
            animator.SetInteger("State", 5);
        }
    }
}
