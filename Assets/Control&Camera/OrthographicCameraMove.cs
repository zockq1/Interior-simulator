using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*OrthographicCameraMove
*WASD 이용해 카메라 이동
*B711205탁재민
*/
public class OrthographicCameraMove : MonoBehaviour
{
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
            transform.Translate(Vector3.up * Time.deltaTime * 3);
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Time.deltaTime * 3);
        }

        float wheel = Input.GetAxis("Mouse ScrollWheel");
        this.GetComponent<Camera>().orthographicSize -= wheel * 2;
        

    }
}
