using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveController : MonoBehaviour
{

    Rigidbody rigidbody;
    public float speedZ = 5f;
    public float swipeSpeed;
    public bool isMove = true;
    

    public Camera cam;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        
        
    }


    void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            if (isMove == true)
            {
                Move();
            }


        }
        
    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            rigidbody.MovePosition(transform.position += Vector3.forward * speedZ * Time.deltaTime);
        }
            
        //rigidbody.AddForce(Vector3.forward * speedZ * Time.deltaTime,ForceMode.Impulse); // addforce versiyon
    }

    void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.position.z;

        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 50))
        {
            Vector3 hitVec = hit.point;
            hitVec.y = transform.position.y;
            hitVec.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, hitVec, Time.deltaTime * swipeSpeed);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("waitArea"))
        {
            Debug.Log("test2");
            isMove = false;
            rigidbody.isKinematic = true;
            //LevelEndAnim();
            other.enabled = false;//tek sefer �al��t�racak.
            other.GetComponent<Lifts>().enabled = true;

        }
       
       
    }
    private void LevelEndAnim()
    {
        transform.DOMoveZ(transform.position.z + 4f, 1f).SetEase(Ease.InOutQuad).SetLoops(2, LoopType.Yoyo);
        
    }
   
}
