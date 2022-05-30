using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y> 1.3f)
        {
            transform.position = new Vector3(transform.position.x, 1.3f, transform.position.z);
        }
    }
}
