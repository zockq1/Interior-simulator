using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofMove : MonoBehaviour
{
    Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha4) == true)
        {
            targetPos = transform.position;
            targetPos.y = 2.2f ;
            transform.position = targetPos;
        }
    }
}
