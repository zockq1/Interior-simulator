using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*control
*모드체크, 배치중인지 체크
*mode == 1 -> 도면 작성 모드
* L mode_1 == 1 -> 바닥 배치 모드
* L mode_1 == 2 -> 벽 배치 모드
* L mode_1 == 3 -> 문 배치 모드
*   벽, 문 배치 방향
* L mode_1_direction == 1 -> 상
* L mode_1_direction == 2 -> 하
* L mode_1_direction == 3 -> 좌
* L mode_1_direction == 4 -> 우
*
*mode == 2 -> 가구 배치 모드
*mode == 3 -> 1인칭 모드
*B711205탁재민
*/
public class control : MonoBehaviour
{
    public int mode;    //1:도면 작성, 2:가구 배치, 3:1인칭
    public int mode_1;  //도면 작성 1:바닥, 2:벽, 3:문
    public int mode_1_direction;//벽, 문 배치 1:상, 2:하, 3:좌, 4:우
    public Camera camera1, camera2, camera3;
    public bool isdeploying;
    void Start()
    {
        mode = 1;
        mode_1 = 1;
        mode_1_direction = 1;
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SwitchingToFloor(){
        mode_1 = 1;
    }

    public void SwitchingToWall(){
        mode_1 = 2;
    }

    public void SwitchingToDoor(){
        mode_1 = 3;
    }

    public void SwitchingToUp(){
        mode_1_direction = 1;
    }

    public void SwitchingToDown(){
        mode_1_direction = 2;
    }

    public void SwitchingToLeft(){
        mode_1_direction = 3;
    }

    public void SwitchingToRight(){
        mode_1_direction = 4;
    }
}
