using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPos : MonoBehaviour
{
    public float m_fSpeed = 300.0f;
    public Vector3 mouse_Pos;
    bool PlanMode = false; //도면모드 ON/OFF;
    void Start()
    {
        mouse_Pos = transform.position;
    }

    void Update()
    {
        //도면모드 ON / OFF => 마우스 좌표가 항상 양수가 되는 위치로 카메라 둘것.
        if(GameObject.Find("control").GetComponent<control>().mode == 1){
            PlanMode = true;
        }
        else{
            PlanMode = false;
        }

       //도면모드일때, 쿼드가 마우스 따라다니기.
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
        else
        {
            mouse_Pos.y = -1000.0f;
            transform.position = mouse_Pos;
        }
    }
}
