using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
*Deployment
*가구 배치, 회전, 좌우반전, 삭제, 충돌감지
*탁재민
*/
public class Deployment : MonoBehaviour
{
    public Renderer cubeColor;
    Color temp;    
    public bool iscollision;
    public bool isdeployment;
    public bool isrelocation;
    void Start()
    {
        //gameObject.GetComponent<standby>().enabled = false;
        isdeployment = false;
        iscollision = false;
        isrelocation = false;
        GetComponent<Collider>().isTrigger = false;
        cubeColor = gameObject.GetComponent<Renderer>();
        temp = cubeColor.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        //좌클릭으로 가구 배치, 충돌이 있거나, 재배치상황에서는 동작하지 않음
        if (Input.GetMouseButtonDown(0) && !iscollision && !isrelocation)
        {
            isdeployment = true;
            GetComponent<Collider>().isTrigger = true;
            Debug.Log("클릭");
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

        //아직 배치되지 않았을 시 우클릭으로 가구 회전
        if(!isdeployment && Input.GetMouseButton(1)){
            
            transform.Rotate (0, 0.5f, 0);
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
            
            Destroy(gameObject);
        }
    }
    
    //배치되지 않은 상태에서 가구 충돌 감지
    void OnTriggerEnter(Collider other){
        if(!isdeployment){
            iscollision = true;
            Debug.Log("Enter: 배치불가");
            cubeColor.material.color = Color.red;
        }
    }

    void OnTriggerStay(Collider other){
        if(!isdeployment){
            iscollision = true;
            Debug.Log("stay: 배치불가");
            cubeColor.material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other){
        if(!isdeployment){
            iscollision = false;
            Debug.Log("Eixt: 배치가능");
            cubeColor.material.color = temp;
        }
    }

    //배치된 상태의 가구 좌클릭시 재배치
    private void OnMouseDown(){
        if(isdeployment){
        isdeployment = false;
        isrelocation =  true;
        GetComponent<Collider>().isTrigger = false;
        Debug.Log("클릭");
        }
    }

}
