using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    public Vector2 moveForce;

    public bool isMoveButtonDown;
    public bool isJumpButtonDown;

    private float timer;
    void Start()
    {
        this.rigidbody2D = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        UseAnimation();
        Move();
    }
    private void Move()
    {
        this.rigidbody2D.AddForce(moveForce);
        moveForce = Vector2.zero;
        
    }

    private void UseAnimation()
    {
        if (isMoveButtonDown == true)
        {
            animator.SetBool("isMoveButtonDown", true);
            isMoveButtonDown = false;
        }
        else if(isMoveButtonDown == false)
        {
            animator.SetBool("isMoveButtonDown", false);
        }
        if (isJumpButtonDown == true)
        {
            animator.SetBool("isJumped", true);
            isJumpButtonDown = false;
        }
        else if (isJumpButtonDown == false && timer>1)
        {
            animator.SetBool("isJumped", false);
            timer = 0;
        }
    }

}
