using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public Vector2 moveForce;
    void Start()
    {
        this.rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        this.rigidbody2D.AddForce(moveForce);
        moveForce = Vector2.zero;
        
    }
}
