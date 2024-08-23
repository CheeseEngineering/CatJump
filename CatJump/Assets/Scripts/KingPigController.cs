using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingPigController : MonoBehaviour
{
    public GameObject kingGo;
    public KingController kingController;

    public Animator animator;
    public Rigidbody2D rg2D;

    public float radius = 0.1f;
    public float hp = 100;
    public float maxHp = 100;
    public float damage = 10;

    public bool CanAttack;
    public bool isAttacked;
    public bool isDead;
    void Start()
    {
       kingController = kingGo.GetComponent<KingController>();
    }
    void Update()
    {
        KingPigIsAttacked();
        KingPigDied();
    }
    public void KingPigDied()
    {
        if (this.hp<=0 && this.isDead==false)
        {
            this.hp = 0;
            Debug.Log("KingPig가 죽었습니다.");
            animator.SetInteger("PigState", 2);
            this.isDead = true;
        }
    }
    public void KingPigIsAttacked()
    {
        
        if (this.isAttacked && this.isDead==false)
        {
            Debug.Log("KingPig가 공격당했습니다.");
            rg2D.AddForce(new Vector2(25f, 50f));
            animator.SetInteger("PigState", 1);
            this.hp -= kingController.damage;
            Debug.Log($"KingPig의 남은 체력 : {this.hp}/{this.maxHp}");
            this.isAttacked = false;
        }
        else if(this.isAttacked==false && this.isDead == false)
        {
            animator.SetInteger("PigState", 0);
        }
    }
}
