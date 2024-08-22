using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class KingController : MonoBehaviour
{
    // Animation Number = 0 : Idle, 1 : Run, 2 : Attack, 3 : Dead
    private int stateNum;
    public float timer;
    public Rigidbody2D rg2D;
    public Animator animator;
    
    // kingpig
    public GameObject kingPigGo;
    public KingPigController kingPigController;

    public float hp = 100;
    public float maxHp = 100;
    public float damage = 10;
    public float radius = 2;

    public bool CanAttack;

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
        float h = Input.GetAxisRaw("Horizontal");
        if (h == 0f)
        {
            animator.SetInteger("State", 0);
            KingAttack();
        }
        else
        {
            animator.SetInteger("State", 1);

            this.rg2D.velocity = (new Vector2(h * 3f, 0));
            this.transform.localScale = new Vector3(h, 1, 1);
            KingAttack();
        }
    }

    private void KingAttack()
    {

        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            this.rg2D.velocity = (new Vector2(0, 0));
            animator.SetInteger("State", 0);
            animator.SetInteger("State", 2);

            this.timer += Time.deltaTime%1;
            if (timer >= 0.433)
            {
                Debug.Log("AttackCompleted");
                this.timer = 0;
                KingCanAttack();
            }
            animator.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            animator.SetInteger("State", 2);
            KingCanAttack();
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
        else if (this.rg2D.velocity.y < 0 && this.rg2D.velocity.y > -8f)
        {
            animator.SetInteger("State", 6);
        }
        else if (this.rg2D.velocity.y <= -8f && this.rg2D.velocity.y >= -10f)
        {
            animator.SetInteger("State", 5);
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
            kingPigController.hp -= this.damage;
            Debug.Log($"KingPig의 남은 체력 : {kingPigController.hp}/{kingPigController.maxHp}");
            kingPigController.isAttacked = true;

        }
    }
}
