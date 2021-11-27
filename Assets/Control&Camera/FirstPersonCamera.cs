using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*FirstPersonCamera
*마우스로 카메라 회전
*B711205탁재민
*/
public class FirstPersonCamera : MonoBehaviour
{
    private float X;
    private float Y;
    
    void Start()
    {
        //초기 카메라 각도 받아오기
        X = transform.eulerAngles.x;
        Y = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("control").GetComponent<control>().mode == 3){
            X += -Input.GetAxis("Mouse Y") * 3; //카메라를 좌우로 이동 한만큼 키존 카메라 각도에 더함
            Y += Input.GetAxis("Mouse X") * 3 ; //카메라를 위아래로 이동 한만큼 키존 카메라 각도에 더함
            X = Mathf.Clamp(X, -45, 80);
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }
    }
}
