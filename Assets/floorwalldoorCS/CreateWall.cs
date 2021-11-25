using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall : MonoBehaviour
{
    public GameObject WallPrefab1;//흰색 벽지 벽
    public GameObject WallPrefab2;//다른 벽지 벽
    public GameObject WallPrefab3;//다른 벽지 벽
    public GameObject WallPrefab4;//다른 벽지 벽
    private GameObject temp_wall; //UI 클릭을 통해 생성되어야 하는 벽.
    

    private GridPos gridpos; //GridPos로 부터 가져온 마우스 좌표.
    
    Vector3 mouse_Pos;
    private Vector3 tempPosLeft;
    private Vector3 tempPosRight;
    private Vector3 tempPosUp;
    private Vector3 tempPosDown;
    bool createPossibleWall = false; //모드 설정 체크
    private bool doubleCheckLeft = false; //벽 중복 생성 체크
    private bool doubleCheckRight = false; //벽 중복 생성 체크
    private bool doubleCheckUp = false; //벽 중복 생성 체크
    private bool doubleCheckDown = false; //벽 중복 생성 체크

    void Start()
    {

    }

    void Update()
    {

        //어떤 벽지를 선택할 것인지.
        temp_wall = WallPrefab1;//(임시)

        if (GameObject.Find("control").GetComponent<control>().mode == 1 && GameObject.Find("control").GetComponent<control>().mode_1 == 2)
        {
            createPossibleWall = true;
        }
        else
        {
            createPossibleWall = false;
        }

        //상하좌우 키보드를 누를 상태에서 마우스를 끌고가면 벽 생성.
        if (tempPosLeft != GameObject.Find("GridPos").GetComponent<GridPos>().mouse_Pos)
        {
            doubleCheckLeft = true;
        }
        if (tempPosRight != GameObject.Find("GridPos").GetComponent<GridPos>().mouse_Pos)
        {
            doubleCheckRight = true;
        }
        if (tempPosUp != GameObject.Find("GridPos").GetComponent<GridPos>().mouse_Pos)
        {
            doubleCheckUp = true;
        }
        if (tempPosDown != GameObject.Find("GridPos").GetComponent<GridPos>().mouse_Pos)
        {
            doubleCheckDown = true;
        }
        if (Input.GetMouseButton(0) == true  && createPossibleWall == true && doubleCheckLeft == true && GameObject.Find("control").GetComponent<control>().mode_1_direction==3)
        {
            
                gridpos = GameObject.Find("GridPos").GetComponent<GridPos>();
                tempPosLeft = gridpos.mouse_Pos;
                gridpos.mouse_Pos.x -= 0.5f;
                gridpos.mouse_Pos.z -= 0.5f;
                mouse_Pos.x = gridpos.mouse_Pos.x + 0.5f;
                mouse_Pos.y = 1.3f;
                mouse_Pos.z = gridpos.mouse_Pos.z + 0.1f;
                GameObject go = Instantiate(temp_wall) as GameObject;
                go.transform.position = mouse_Pos;
                doubleCheckLeft = false;

        }
        else if (Input.GetMouseButton(0) == true  && createPossibleWall == true && doubleCheckRight == true && GameObject.Find("control").GetComponent<control>().mode_1_direction == 4)
            {
                gridpos = GameObject.Find("GridPos").GetComponent<GridPos>();
                tempPosRight = gridpos.mouse_Pos;
                gridpos.mouse_Pos.x -= 0.5f;
                gridpos.mouse_Pos.z -= 0.5f;
                mouse_Pos.x = gridpos.mouse_Pos.x + 0.5f;
                mouse_Pos.y = 1.3f;
                mouse_Pos.z = gridpos.mouse_Pos.z + 0.9f;
                GameObject go = Instantiate(temp_wall) as GameObject;
                go.transform.position = mouse_Pos;
                doubleCheckRight = false;


        }
        else if (Input.GetMouseButton(0) == true  && createPossibleWall == true && doubleCheckUp == true && GameObject.Find("control").GetComponent<control>().mode_1_direction == 1)
        {
                gridpos = GameObject.Find("GridPos").GetComponent<GridPos>();
                tempPosUp = gridpos.mouse_Pos;
                gridpos.mouse_Pos.x -= 0.5f;
                gridpos.mouse_Pos.z -= 0.5f;
                mouse_Pos.x = gridpos.mouse_Pos.x + 0.1f;
                mouse_Pos.y = 1.3f;
                mouse_Pos.z = gridpos.mouse_Pos.z + 0.5f;
                GameObject go = Instantiate(temp_wall) as GameObject;
                go.transform.position = mouse_Pos;
                go.transform.rotation = Quaternion.Euler(0, 90, 0);
                doubleCheckUp = false;


        }
        else if (Input.GetMouseButton(0) == true  && createPossibleWall == true && doubleCheckDown == true && GameObject.Find("control").GetComponent<control>().mode_1_direction == 2)
        {
                gridpos = GameObject.Find("GridPos").GetComponent<GridPos>();
                tempPosDown = gridpos.mouse_Pos;
                gridpos.mouse_Pos.x -= 0.5f;
                gridpos.mouse_Pos.z -= 0.5f;
                mouse_Pos.x = gridpos.mouse_Pos.x + 0.9f;
                mouse_Pos.y = 1.3f;
                mouse_Pos.z = gridpos.mouse_Pos.z + 0.5f;
                GameObject go = Instantiate(temp_wall) as GameObject;
                go.transform.position = mouse_Pos;
                go.transform.rotation = Quaternion.Euler(0, 90, 0);
                doubleCheckDown = false;

        }
        
        //벽과 문 오른쪽 마우스 클릭으로 삭제
        if (Input.GetMouseButton(1) && createPossibleWall == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //카메라에서 레이를 쏜다.
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 30000))
            {
                Debug.Log(hit.transform.gameObject.tag);
                if (hit.transform.tag == "wall")
                {      
                    Destroy(hit.transform.gameObject);
                }

            }
         

        }


    }
}
