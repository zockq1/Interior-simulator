using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMove : MonoBehaviour
{
    private float Y;
    
    void Start()
    {
        //초기 카메라 각도 받아오기
        Y = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        if(GameObject.Find("control").GetComponent<control>().mode == 3){
            Y += Input.GetAxis("Mouse X") * 3 ; //카메라를 위아래로 드래그 한만큼 키존 카메라 각도에 더함
            transform.rotation = Quaternion.Euler(0, Y, 0);

            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * 3 * Time.deltaTime);
        }
    }
}
