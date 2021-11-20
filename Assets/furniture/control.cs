using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*control
*모드체크, 배치중인지 체크
*mode 1 -> 도면 작성 모드
*mode 2 -> 가구 배치 모드
*mode 3 -> 1인칭 모드
*B711205탁재민
*/
public class control : MonoBehaviour
{
    public int mode;
    public Camera camera1, camera2, camera3;
    public bool isdeploying;
    void Start()
    {
        mode = 1;
        isdeploying = false;
        SwitchingTo1();
    }

    void Update()
    {
        //키보드로 모드 변경, 변경 시 배치중이던 가구 삭제
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchingTo1();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchingTo2();
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchingTo3();
        }
    }

    public void SwitchingTo1(){
        mode = 1;
        Destroy(GameObject.FindWithTag("Deploying"));
        camera1.enabled = true;
        camera1.tag = "MainCamera";
        camera2.enabled = false;
        camera2.tag = "StandbyCamera";
        camera3.enabled = false;
        camera3.tag = "StandbyCamera";
    }

    public void SwitchingTo2(){
        mode = 2;
        Destroy(GameObject.FindWithTag("Deploying"));
        camera1.enabled = false;
        camera1.tag = "StandbyCamera";
        camera2.enabled = true;
        camera2.tag = "MainCamera";
        camera3.enabled = false;
        camera3.tag = "StandbyCamera";
    }

    public void SwitchingTo3(){
        mode = 3;
        Destroy(GameObject.FindWithTag("Deploying"));
        camera1.enabled = false;
        camera1.tag = "StandbyCamera";
        camera2.enabled = false;
        camera2.tag = "StandbyCamera";
        camera3.enabled = true;
        camera3.tag = "MainCamera";
    }

}
