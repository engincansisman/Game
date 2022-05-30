using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Lifts : MonoBehaviour
{
    public int liftPoint;
    public MoveController moveController;
    public GameObject platform;
    public int level = 1;

    public void Awake()
    {
        moveController = GameObject.FindObjectOfType<MoveController>();
    }

    private void Update()
    {
        
            if (liftPoint==10)
            {
                platform.transform.DOLocalMoveY(0.761322f, 10f).SetEase(Ease.InQuad).OnComplete(()=>continueGame());
            }
            
    }

    public void continueGame()
    {
        
        moveController.isMove = true;
        level++;
        if (level == 3 )
        {
            moveController.isMove = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(CompareTag("lift"))
        {
            liftPoint++;
            
        }
        if (other.gameObject.tag=="Ball")
        {
            Destroy(other);
        }

        
        
     

    }


}
