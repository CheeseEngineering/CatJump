using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class KingController : MonoBehaviour
{
    // Animation Number = 0 : Idle, 1 : Run, 2 : Attack, 3 : Dead
    private int stateNum;
    public float attacktimer;
    public Rigidbody2D rg2D;
    public Animator animator;
    
    // kingpig
    public GameObject kingPigGo;
    public KingPigController kingPigController;

    public float h;

    public float hp = 100;
    public float maxHp = 100;
    public float damage = 10;
    public float radius = 0.1f;

    public bool CanAttack;
    public bool isAttackCompleted;
    public bool isLongAttacking;
    public bool isShortAttacking;
    public bool isJumping;
    void Start()
    {
        kingPigController = kingPigGo.GetComponent<KingPigController>();

    }
    void Update()
    {
        KingMove();

        KingJump();

        KingDied();
    }
    private void KingMove()
    {
        // 무조건 -1,0,1이 나옴
        h = Input.GetAxisRaw("Horizontal");
        if (h == 0f || isLongAttacking)
        {
            if (isLongAttacking&&!isJumping)
            {
                this.rg2D.velocity = (new Vector2(0, 0));
                KingAttack();
            }
            animator.SetInteger("State", 0);
            if (this.rg2D.velocity.y == 0)
            {
                isJumping = false;
                KingAttack();
            }
        }
        else if(h!=0 && isLongAttacking ==false && this.rg2D.velocity.y ==0)
        {
                animator.SetInteger("State", 1);
                this.rg2D.velocity = (new Vector2(h * 3f, 0));
                this.transform.localScale = new Vector3(h, 1, 1);
                KingAttack();
        }
        else if (h != 0 && isLongAttacking == false && this.rg2D.velocity.y != 0)
        {
            this.rg2D.AddForce(new Vector2(h*5f, 0));
            this.transform.localScale = new Vector3(h, 1, 1);
            
        }
    }

    private void KingAttack()
    {
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            this.attacktimer += Time.deltaTime;
        }

        if((attacktimer<0.8 && attacktimer>0) && Input.GetKey(KeyCode.KeypadEnter) == false)
        {
            animator.SetInteger("State", 2);
            KingCanAttack();
            this.attacktimer = 0;
            this.isLongAttacking = false;
            Debug.Log("Short Attack Completed");
        }
        else if(attacktimer>=0.8 && Input.GetKey(KeyCode.KeypadEnter) == true)
        {
            this.isLongAttacking = true;
            animator.SetInteger("State", 2);
            this.isAttackCompleted = true;
            if (this.isAttackCompleted && attacktimer>1)
            {
                Debug.Log("Long Attack Completed");
                this.attacktimer = 0;
                KingCanAttack();
                this.isAttackCompleted = false;
                this.isLongAttacking = false;
            }
        }
    }

    private void KingJump()
    {
        this.isJumping = true;
        if (Input.GetKey(KeyCode.Space))
        {
            this.rg2D.velocity = (new Vector2(0, 10f));
        }
        if (this.rg2D.velocity.y <= 10f && this.rg2D.velocity.y >= 8f)
        {
            animator.SetInteger("State", 5);
            KingAttack();
        }
        else if (this.rg2D.velocity.y > 0)
        {
            animator.SetInteger("State", 3);
            KingAttack();
        }
        else if (this.rg2D.velocity.y < 0 && this.rg2D.velocity.y > -8f)
        {
            animator.SetInteger("State", 6);
            KingAttack();
        }
        else if (this.rg2D.velocity.y <= -8f && this.rg2D.velocity.y >= -10f)
        {
            animator.SetInteger("State", 5);
            KingAttack();
        }
    }

    private void KingDied()
    {
        if (this.hp <= 0)
        {
            this.hp = 0;
            animator.SetInteger("State", 4);
            Debug.Log("King이 죽었습니다.");
        }
    }

    private void KingCanAttack()
    {
        if (this.CanAttack&&kingPigController.isDead==false)
        {
            kingPigController.isAttacked = true;
        }
    }
}
