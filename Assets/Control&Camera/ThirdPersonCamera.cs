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
    private Vector2 anchor, current, pos;
     private float X;
     private float Y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        float wheel = Input.GetAxis("Mouse ScrollWheel");
        this.GetComponent<Camera>().fieldOfView -= wheel * 20;
        

        
            if(Input.GetMouseButton(1)) {
                transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * 3, Input.GetAxis("Mouse X") * 3, 0));
                X = transform.rotation.eulerAngles.x;
                Y = transform.rotation.eulerAngles.y;
                transform.rotation = Quaternion.Euler(X, Y, 0);
            }
        
         

    }
}
