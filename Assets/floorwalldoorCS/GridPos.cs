using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPos : MonoBehaviour
{

    /*
     * B911035 김세환
     * 도면 모드에서 격자 중심으로 바닥 , 벽, 문을 생성 가능하도록함.
     * 도면 모드에서 1X1사이즈의 격자 내 위치를 표시하는 Quad를 생성.
     * 카메라에서 ray를 쏘고, ray가 xz평면과 충돌하는 지점에서의 좌표값을 알아냄.
     * 그 좌표를 이용, 마우스가 이동함에 따라, Quad가 xz평면의 격자에 맞추어 따라감.
     * 도면모드가 끝나면 Quad는 사라짐.
     */
    
    public float m_fSpeed = 300.0f; //quad가 마우스를 따라가는 이동 속도 변수
    public Vector3 mouse_Pos; //마우스 좌표 위치 저장 변수.
    bool PlanMode = false; //도면모드 ON/OFF 변수;

    void Start()
    {
        mouse_Pos = transform.position;
    }

    void Update()
    {
        //도면모드 ON / OFF
        if(GameObject.Find("control").GetComponent<control>().mode == 1){
            PlanMode = true;
        }
        else{
            PlanMode = false;
        }

        //도면모드일때, 쿼드가 마우스를 따라다니도록 함.
        if(PlanMode == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000f))
            {
                mouse_Pos = hit.point;
                mouse_Pos.y = transform.position.y;
            }
            if(mouse_Pos.x < 0)
            {
                mouse_Pos.x = (int)mouse_Pos.x + 0.5f-1.0f;
            }
            else
            {
                mouse_Pos.x = (int)mouse_Pos.x + 0.5f;
            }
            if(mouse_Pos.z < 0)
            {
                mouse_Pos.z = (int)mouse_Pos.z + 0.5f -1.0f;
            }
            else
            {
                mouse_Pos.z = (int)mouse_Pos.z + 0.5f;
            }
            mouse_Pos.y = 0.1f;
            
            transform.position = mouse_Pos;
        }
        //도면 모드가 아닐때, quad가 보이지 않음.
        else
        {
            mouse_Pos.y = -1000.0f;
            transform.position = mouse_Pos;
        }
    }
}
