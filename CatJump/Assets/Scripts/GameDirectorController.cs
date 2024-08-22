using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameDirectorController : MonoBehaviour
{
    public GameObject kingGo;
    public GameObject kingPigGo;

    private KingController kingController;
    private KingPigController kingPigController;

    private float timer;
    public bool CanAttack;
    void Start()
    {
        kingController =  kingGo.GetComponent<KingController>();
        kingPigController = kingPigGo.GetComponent<KingPigController>();
    }
    void Update()
    {
        IsInAttackRange();
        PigisDead();
    }

    private void IsInAttackRange()
    {
        float DistanceX = Mathf.Abs (kingGo.transform.position.x - kingPigGo.transform.position.x);
        float DistanceY = Mathf.Abs(kingGo.transform.position.y - kingPigGo.transform.position.y);
        float Range = kingController.radius + kingPigController.radius;
        if (DistanceX <= Range && DistanceY <= Range)
        {
            CanAttack = true;
            kingController.CanAttack = true;
            kingPigController.CanAttack = true;
        }
        else
        {
            CanAttack=false;
            kingController.CanAttack = false;
            kingPigController.CanAttack = false;
        }
    }
    private void PigisDead()
    {
        if (kingPigController.isDead == true)
        {
            timer += Time.deltaTime % 3f;
            if (timer >= 2.0)
            {
                kingPigGo.SetActive(false);
            }
        }
    }
}
