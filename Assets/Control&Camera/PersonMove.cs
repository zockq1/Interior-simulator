using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*FirstPersonCamera
*WASD 이용해 1인칭 오브젝트
*마우스로 카메라 좌우 회전
*B711205탁재민
*/
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
        gameObject.GetComponent<Renderer>().enabled = false;//오브젝트 보이지 않게
        GetComponent<Rigidbody>().velocity = Vector3.zero;  //벽에 부딪혀도 안튕겨나가게
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        if(GameObject.Find("control").GetComponent<control>().mode == 3){
            Y += Input.GetAxis("Mouse X") * 3 ; //카메라를 위아래로 드래그 한만큼 키존 카메라 각도에 더함
            transform.rotation = Quaternion.Euler(0, Y, 0);

            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * 3 * Time.deltaTime);
        }
    }
}
