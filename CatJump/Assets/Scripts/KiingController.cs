using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class KiingController : MonoBehaviour
{
    // Animation Number = 0 : Idle, 1 : Run, 2 : Attack, 3 : Dead
    private int stateNum;
    private int Count;
    public Rigidbody2D rg2D;
    public Animator animator;

    void Start()
    {
        
    }
    void Update()
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
            if (h < 0)
            {
                this.rg2D.AddForce(new Vector2(h * 10f, 0));
                this.transform.localScale = new Vector3(h, 1, 1);
            }
            else if (h > 0)
            {
                this.rg2D.AddForce(new Vector2(h * 10f, 0));
                this.transform.localScale = new Vector3(h, 1, 1);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("State", 2);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.rg2D.AddForce(new Vector2(0, 10f));
            animator.SetInteger("State", 3);
        }



    }
}
