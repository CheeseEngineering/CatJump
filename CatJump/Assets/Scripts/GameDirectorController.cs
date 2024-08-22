using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirectorController : MonoBehaviour
{
    // CatController
    public GameObject Cat;
    public CatController CatController;


    void Start()
    {
        CatController = Cat.GetComponent<CatController>();
    }

    // Update is called once per frame
    void Update()
    {
        CatControllerDirecting();


    }

    private void CatControllerDirecting()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            CatController.moveForce = new Vector2(-1*7f, 0);
            Cat.transform.localScale = new Vector3(-1, 1, 1);
            Debug.Log("��������Ű �Է�");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            CatController.moveForce = new Vector2(1*7f, 0);
            Cat.transform.localScale = new Vector3(1, 1, 1);
            Debug.Log("��������Ű �Է�");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            CatController.moveForce = new Vector2(0, 1*250f);
            Debug.Log("�����̽� �Է�");
        }
    }
}
