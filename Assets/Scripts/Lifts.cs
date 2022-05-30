using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class Lifts : MonoBehaviour
{
    public int liftPoint;
    public MoveController moveController;
    public GameObject platform;
    public int level = 1;
    public TextMeshProUGUI textCount;
    private int count=0;

    public void Awake()
    {
        liftPoint = -1;
        moveController = GameObject.FindObjectOfType<MoveController>();
        textCount=GameObject.FindObjectOfType<TextMeshProUGUI>();
        SetTextCount();


    }

    private void Update()
    {
        
            if (liftPoint>=10)
            {
                
                platform.transform.DOLocalMoveY(0.761322f, 0.05f).SetEase(Ease.InQuad).OnComplete(()=>continueGame());
            }
            
    }

    public void continueGame()
    {
        moveController.isMove = true; 
        
        
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(CompareTag("lift"))
        {
            liftPoint++;
            count = liftPoint;
            SetTextCount();

        }
        
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            Destroy(coll.gameObject);
        }
    }

    private void SetTextCount()
    {
        textCount.text = "Balls" + count.ToString() + "/10";
    }
}
