using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPos : MonoBehaviour
{
    public float m_fSpeed = 300.0f;
    Vector3 mouse_Pos;
    bool PlanMode = false; //도면모드 ON/OFF;
    void Start()
    {
        mouse_Pos = transform.position;
    }

    void Update()
    {
        //도면모드 ON / OFF => 마우스 좌표가 항상 양수가 되는 위치로 카메라 둘것.
        PlanMode = true;


        //마우스를 통해 그리드 이동.
        if (Input.GetMouseButtonDown(0) && PlanMode == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000f))
            {
                mouse_Pos = hit.point;
                mouse_Pos.y = transform.position.y;
            }
            mouse_Pos.x = (int)mouse_Pos.x + 0.5f;
            mouse_Pos.y = 0.1f;
            mouse_Pos.z = (int)mouse_Pos.z + 0.5f;
            transform.position = mouse_Pos;
        }
        if (Input.GetMouseButton(0) && PlanMode == true)
        {
            //마우스 드래그 중
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000f))
            {
                mouse_Pos = hit.point;
                mouse_Pos.y = transform.position.y;
            }
            transform.position = mouse_Pos;
        }

        if (Input.GetMouseButtonUp(0) && PlanMode == true) //마우스 뗌
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000f))
            {
                mouse_Pos = hit.point;
                mouse_Pos.y = transform.position.y;
            }
            mouse_Pos.x = (int)mouse_Pos.x + 0.5f;
            mouse_Pos.y = 0.01f;
            mouse_Pos.z = (int)mouse_Pos.z + 0.5f;
            transform.position = mouse_Pos;
        }
    }
}
