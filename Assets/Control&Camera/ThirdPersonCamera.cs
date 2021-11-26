using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*OrthographicCameraMove
*WASD 이용해 카메라 이동
*마우스 휠로 줌인, 줌아웃
*B711205탁재민
*/
public class ThirdPersonCamera : MonoBehaviour
{
    
    private float X;
    private float Y;
    
    void Start()
    {
        //초기 카메라 각도 받아오기
        X = transform.eulerAngles.x;
        Y = transform.eulerAngles.y;
    }

    
    void Update()
    {
        //앞뒤상하좌우 이동
        if(GameObject.Find("control").GetComponent<control>().mode == 2){
            if(Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * Time.deltaTime * 3);
            }

            if(Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime * 3);
            }

            if(Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * 3);
            }

            if(Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * Time.deltaTime * 3);
            }

            if(Input.GetKey(KeyCode.Space))
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3);
            }

            if(Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Vector3.down * Time.deltaTime * 3);
            }

            //카메라 회전
            if(Input.GetMouseButton(1)) {
                X += -Input.GetAxis("Mouse Y") * 3; //카메라를 좌우로 드래그 한만큼 키존 카메라 각도에 더함
                Y += Input.GetAxis("Mouse X") * 3 ; //카메라를 위아래로 드래그 한만큼 키존 카메라 각도에 더함
                transform.rotation = Quaternion.Euler(X, Y, 0);
            }
        }
         

    }
}
