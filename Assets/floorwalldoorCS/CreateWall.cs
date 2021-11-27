using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateWall : MonoBehaviour
{
    /*
     * B911035 김세환
     * 도면 모드 상태에서 벽 생성을 가능하도록함.
     * 벽 텍스쳐를 UI로 선택하고, 방향UI로 방향을 지정 후에 마우스 클릭으로 문 생성 가능.
     * GridPos.cs 로 부터 마우스에 대한 xz평면의 좌표를 가져오고,
     * 그 좌표를 이용하여 좌표값 일부의 수정을 거쳐 해당 quad내의 상하좌우에 벽(wallPrefabClone)이 생성되도록함.
     * 생성된 벽을 지우고 싶으면, 마우스 오른쪽키를 누르면, 빛을 쏴서 해당 ray가 wallprefab에 맞게 되면 wallprefabClone을 삭제함.
     * 텍스쳐이미지는 직접 그린것이 아닌, 적합한 이미지를 가져옴.
     */


    public GameObject WallPrefab1;//흰색 벽지 벽
    public GameObject WallPrefab2;//다른 벽지 벽
    public GameObject WallPrefab3;//다른 벽지 벽
    public GameObject WallPrefab4;//다른 벽지 벽
    private GameObject temp_wall; //UI 클릭을 통해 생성되어야 하는 벽.
    

    private GridPos gridpos; //GridPos로 부터 가져온 마우스 좌표.
    
    Vector3 mouse_Pos;
    private Vector3 tempPosLeft; //중복 설치 방지를 위해 이전에 설치된 문이 놓인 좌표 임시 저장.
    private Vector3 tempPosRight; //중복 설치 방지를 위해 이전에 설치된 문이 놓인 좌표 임시 저장.
    private Vector3 tempPosUp; //중복 설치 방지를 위해 이전에 설치된 문이 놓인 좌표 임시 저장.
    private Vector3 tempPosDown; //중복 설치 방지를 위해 이전에 설치된 문이 놓인 좌표 임시 저장.
    bool createPossibleWall = false; //모드 설정 체크
    private bool doubleCheckLeft = false; //벽 중복 생성 체크
    private bool doubleCheckRight = false; //벽 중복 생성 체크
    private bool doubleCheckUp = false; //벽 중복 생성 체크
    private bool doubleCheckDown = false; //벽 중복 생성 체크

    void Start()
    {
        temp_wall = WallPrefab1;
    }

    //temp_wall 에 프리팹 설정 함수
    public void setWallPrefab1()
    {
        temp_wall = WallPrefab1;
    }
    public void setWallPrefab2()
    {
        temp_wall = WallPrefab2;
    }
    public void setWallPrefab3()
    {
        temp_wall = WallPrefab3;
    }
    public void setWallPrefab4()
    {
        temp_wall = WallPrefab4;
    }

    
    void Update()
    {
        //벽 생성 모드 ON/OFF
        if (GameObject.Find("control").GetComponent<control>().mode == 1 && GameObject.Find("control").GetComponent<control>().mode_1 == 2 && !EventSystem.current.IsPointerOverGameObject())
        {
            createPossibleWall = true;
        }
        else
        {
            createPossibleWall = false;
        }

        //문이 하나의 격자 내에서 중복 생성되는 것을 방지하는 조건문.
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

        //상하좌우 선택을 하고, 마우스 왼쪽을 클릭한 상태에서 끌고가면 벽 생성(왼쪽벽)
        if (Input.GetMouseButton(0) == true  && createPossibleWall == true && doubleCheckLeft == true && GameObject.Find("control").GetComponent<control>().mode_1_direction==3 && !EventSystem.current.IsPointerOverGameObject())
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

        //상하좌우 선택을 하고, 마우스 왼쪽을 클릭한 상태에서 끌고가면 벽 생성(오른쪽벽)
        else if (Input.GetMouseButton(0) == true  && createPossibleWall == true && doubleCheckRight == true && GameObject.Find("control").GetComponent<control>().mode_1_direction == 4 && !EventSystem.current.IsPointerOverGameObject())
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

        //상하좌우 선택을 하고, 마우스 왼쪽을 클릭한 상태에서 끌고가면 벽 생성(위쪽벽)
        else if (Input.GetMouseButton(0) == true  && createPossibleWall == true && doubleCheckUp == true && GameObject.Find("control").GetComponent<control>().mode_1_direction == 1 && !EventSystem.current.IsPointerOverGameObject())
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

        //상하좌우 선택을 하고, 마우스 왼쪽을 클릭한 상태에서 끌고가면 벽 생성(아래쪽벽)
        else if (Input.GetMouseButton(0) == true  && createPossibleWall == true && doubleCheckDown == true && GameObject.Find("control").GetComponent<control>().mode_1_direction == 2 && !EventSystem.current.IsPointerOverGameObject())
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
                if (hit.transform.tag == "wall") //tag가 wall이면 해당 clone을 삭제한다.
                {      
                    Destroy(hit.transform.gameObject);
                }

            }
         

        }


    }

   

}
