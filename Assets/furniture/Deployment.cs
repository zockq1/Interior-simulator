using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
*Deployment
*가구 배치, 회전, 좌우반전, 삭제, 충돌감지
*B711205탁재민
*/
public class Deployment : MonoBehaviour
{
    private bool iscollision;
    private bool isdeployment;
    private bool isrelocation;
    control f_control;

    //변수 초기화 및 배치중이던 오브젝트 제거
    void Start()
    {
        isdeployment = false;
        iscollision = false;
        isrelocation = false;
        GetComponent<Collider>().isTrigger = false;
        GameObject.Find("control").GetComponent<control>().isdeploying = true;
        Destroy(GameObject.FindWithTag("Deploying"));
        gameObject.tag = "Deploying";
    }

    // Update is called once per frame
    void Update()
    {
        //좌클릭으로 가구 배치, 이미 배치 되었거나, 충돌이 있거나, 재배치 시작 상황에서는 동작하지 않음
        if (Input.GetMouseButtonDown(0) && !isdeployment && !iscollision && !isrelocation)
        {
            isdeployment = true;
            GetComponent<Collider>().isTrigger = true;
            Debug.Log("배치치치치ㅣㅊ치ㅣ");
            GameObject.Find("control").GetComponent<control>().isdeploying = false;
            gameObject.tag = "Deployed";
        }
        isrelocation =  false;

        //아직 배치되지 않았을 시 마우스 위치로 가구 이동
        if(!isdeployment){
            Ray ray;
            RaycastHit hit;
            int _layerMask = 1<<LayerMask.NameToLayer("floor");
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast (ray, out hit, 30.0f, _layerMask)){
                this.transform.position = new Vector3((float)hit.point.x, (float)(hit.point.y), (float)hit.point.z);
                Debug.Log(hit.normal);
            }
        }

        //아직 배치되지 않았을 시 우클릭으로 가구 회전(모델이 z축이 높이인 경우와, y축이 높이인 경우 확인)
        if(!isdeployment && Input.GetMouseButton(1) && (gameObject.layer == 9)){
            
            transform.Rotate (0, 0.5f, 0);
        }

        if(!isdeployment && Input.GetMouseButton(1) && (gameObject.layer == 8)){
            
            transform.Rotate (0, 0, .5f);
        }

        //아직 배치되지 않았을 시 휠 버튼으로 가구 좌우반전
        if(!isdeployment && Input.GetMouseButtonDown(2)){
            float x = transform.localScale.x;
            float y = transform.localScale.y;
            float z = transform.localScale.z;
            transform.localScale = new Vector3 (-x, y, z);
        }

        //아직 배치되지 않았을 시 Delete 버튼으로 가구 삭제
        if(!isdeployment && Input.GetKeyDown(KeyCode.Delete)){
            GameObject.Find("control").GetComponent<control>().isdeploying = false;
            Destroy(gameObject);
        }
    }
    
    //배치되지 않은 상태에서 가구 충돌 감지
    void OnTriggerEnter(Collider other){
        if(!isdeployment){
            iscollision = true;
            Debug.Log("Enter: 배치불가");
        }
    }

    void OnTriggerStay(Collider other){
        if(!isdeployment){
            iscollision = true;
            Debug.Log("stay: 배치불가");
        }
    }

    private void OnTriggerExit(Collider other){
        if(!isdeployment){
            iscollision = false;
            Debug.Log("Eixt: 배치가능");
        }
    }

    //배치된 상태의 가구 좌클릭시 재배치
    private void OnMouseDown(){
        f_control = GameObject.Find("control").GetComponent<control>();

        if(isdeployment && !f_control.isdeploying && f_control.mode == 2){
            isdeployment = false;
            isrelocation =  true;
            GetComponent<Collider>().isTrigger = false;
            GameObject.Find("control").GetComponent<control>().isdeploying = true;
            Debug.Log("asdasdsa");
            gameObject.tag = "Deploying";
        }
    }

}
