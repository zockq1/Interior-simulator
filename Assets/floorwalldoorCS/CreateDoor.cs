using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateDoor : MonoBehaviour
{
    /*
     * B911035 김세환
     * 도면 모드 상태에서 문을 생성 가능하도록함.
     * 문 텍스쳐를 UI로 선택하고, 방향UI로 방향을 지정 후에 마우스 클릭으로 문 생성 가능.
     * GridPos로 부터 마우스에 대한 xz평면의 좌표를 가져오고,
     * 그 좌표를 이용하여 일부 수정을 거쳐 해당 quad내의 상하좌우에 문(doorPrefabClone)이 생성되도록함.
     * 생성된 문들은 GameObject로 리스트에 저장됨.
     * 생성된 문을 지우고 싶으면, Delete 키를 통해 지움.(리스트에서 doorPrefabClone이 삭제됨)
     * 문은 벽과는 다르게, 회전축이 경첩 중심에 있도록 변경.
     * 회전축이 경첩 중심에 있어, 좌우에따라 생성되는 프리팹이 다름.
     * 텍스쳐이미지는 직접 그린것이 아닌, 적합한 이미지를 가져옴.
     */

    //문 프리팹 변수
    public GameObject DoorPrefab1_1;//문짝1-1
    public GameObject DoorPrefab1_2;//문짝1-2
    public GameObject DoorPrefab2_1;//문짝2-1
    public GameObject DoorPrefab2_2;//문짝2-2
    private GameObject temp_door1; //현재 설치되어야 하는 문에 대한 프리팹 저장 변수.
    private GameObject temp_door2; //현재 설치되어야 하는 문에 대한 프리팹 저장 변수.

    private GridPos gridpos; //GridPos로 부터 가져온 마우스 좌표.

    // Start is called before the first frame update
    List<GameObject> doorCloneList = new List<GameObject>(); //문 prefabClone 리스트에 저장.
    int cloneNum = 0; //문prefab클론 생성 개수.
    private Vector3 mouse_Pos;
    private Vector3 tempPosLeft; //중복 설치 방지를 위해 이전에 설치된 문이 놓인 좌표 임시 저장.
    private Vector3 tempPosRight; //중복 설치 방지를 위해 이전에 설치된 문이 놓인 좌표 임시 저장.
    private Vector3 tempPosUp; //중복 설치 방지를 위해 이전에 설치된 문이 놓인 좌표 임시 저장.
    private Vector3 tempPosDown; //중복 설치 방지를 위해 이전에 설치된 문이 놓인 좌표 임시 저장.
    private bool createPossibleDoor = false;
    private bool doubleCheckLeft = false; //문 중복 생성 체크
    private bool doubleCheckRight = false; //문 중복 생성 체크
    private bool doubleCheckUp = false; //문 중복 생성 체크
    private bool doubleCheckDown = false; //문 중복 생성 체크

    void Start()
    {
        mouse_Pos = transform.position;
        temp_door1 = DoorPrefab1_1;
        temp_door2 = DoorPrefab1_2;
    }

    //temp_door 에 프리팹 설정 함수
    public void setDoorPrefab1()
    {
        temp_door1 = DoorPrefab1_1;
        temp_door2 = DoorPrefab1_2;
    }
    public void setDoorPrefab2()
    {
        temp_door1 = DoorPrefab2_1;
        temp_door2 = DoorPrefab2_2;
    }


    // Update is called once per frame
    void Update()
    {
        
        //문설치 모드 On / Off
        if (GameObject.Find("control").GetComponent<control>().mode == 1 && GameObject.Find("control").GetComponent<control>().mode_1 == 3 && !EventSystem.current.IsPointerOverGameObject())
        {
            createPossibleDoor = true;
        }
        else
        {
            createPossibleDoor = false;
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

        //상하좌우 선택을 하고, 마우스 왼쪽을 클릭한 상태에서 끌고가면 문 생성(왼쪽문)
        if (Input.GetMouseButton(0) == true && createPossibleDoor == true && doubleCheckLeft && GameObject.Find("control").GetComponent<control>().mode_1_direction == 3 && !EventSystem.current.IsPointerOverGameObject())
        {
            gridpos = GameObject.Find("GridPos").GetComponent<GridPos>();
            tempPosLeft = gridpos.mouse_Pos;
            gridpos.mouse_Pos.x -= 0.5f;
            gridpos.mouse_Pos.z -= 0.5f;
            mouse_Pos.x = gridpos.mouse_Pos.x + 0.95f;
            mouse_Pos.y = 1.3f;
            mouse_Pos.z = gridpos.mouse_Pos.z + 0.049f;
            GameObject go = Instantiate(temp_door1) as GameObject;
            go.transform.position = mouse_Pos;
            doorCloneList.Add(go);
            cloneNum += 1;
            doubleCheckLeft = false;

        }
        //상하좌우 선택을 하고, 마우스 왼쪽을 클릭한 상태에서 끌고가면 문 생성(오른쪽문)
        else if (Input.GetMouseButton(0) == true && createPossibleDoor == true && doubleCheckRight && GameObject.Find("control").GetComponent<control>().mode_1_direction == 4 && !EventSystem.current.IsPointerOverGameObject())
        {
            gridpos = GameObject.Find("GridPos").GetComponent<GridPos>();
            tempPosRight = gridpos.mouse_Pos;
            gridpos.mouse_Pos.x -= 0.5f;
            gridpos.mouse_Pos.z -= 0.5f;
            mouse_Pos.x = gridpos.mouse_Pos.x + 0.95f;
            mouse_Pos.y = 1.3f;
            mouse_Pos.z = gridpos.mouse_Pos.z + 0.95f;
            GameObject go = Instantiate(temp_door1) as GameObject;
            go.transform.position = mouse_Pos;
            doorCloneList.Add(go);
            cloneNum += 1;
            doubleCheckRight = false;
        }
        //상하좌우 선택을 하고, 마우스 왼쪽을 클릭한 상태에서 끌고가면 문 생성(위쪽문)
        else if (Input.GetMouseButton(0) == true && createPossibleDoor == true && doubleCheckUp && GameObject.Find("control").GetComponent<control>().mode_1_direction == 1 && !EventSystem.current.IsPointerOverGameObject())
        {
            gridpos = GameObject.Find("GridPos").GetComponent<GridPos>();
            tempPosUp = gridpos.mouse_Pos;
            gridpos.mouse_Pos.x -= 0.5f;
            gridpos.mouse_Pos.z -= 0.5f;
            mouse_Pos.x = gridpos.mouse_Pos.x + 0.04f;
            mouse_Pos.y = 1.3f;
            mouse_Pos.z = gridpos.mouse_Pos.z + 0.95f;
            GameObject go = Instantiate(temp_door2) as GameObject;
            go.transform.position = mouse_Pos;
            doorCloneList.Add(go);
            cloneNum += 1;
            doubleCheckUp = false;

        }
        //상하좌우 선택을 하고, 마우스 왼쪽을 클릭한 상태에서 끌고가면 벽 생성(아래쪽벽)
        else if (Input.GetMouseButton(0) == true && createPossibleDoor == true && doubleCheckDown && GameObject.Find("control").GetComponent<control>().mode_1_direction == 2 && !EventSystem.current.IsPointerOverGameObject())
        {
            gridpos = GameObject.Find("GridPos").GetComponent<GridPos>();
            tempPosDown = gridpos.mouse_Pos;
            gridpos.mouse_Pos.x -= 0.5f;
            gridpos.mouse_Pos.z -= 0.5f;
            mouse_Pos.x = gridpos.mouse_Pos.x + 0.951f;
            mouse_Pos.y = 1.3f;
            mouse_Pos.z = gridpos.mouse_Pos.z + 0.95f;
            GameObject go = Instantiate(temp_door2) as GameObject;
            go.transform.position = mouse_Pos;
            doorCloneList.Add(go);
            cloneNum += 1;
            doubleCheckDown = false;
        }

        //delete 로 문 삭제
        if (Input.GetKey(KeyCode.Delete) == true && createPossibleDoor == true)
        {
            Debug.Log("문 삭제 ON");
            if (cloneNum - 1 >= 0)
            {
                Destroy(doorCloneList[cloneNum - 1]);
                doorCloneList.RemoveAt(cloneNum - 1);
                cloneNum -= 1;
            }

        }

        //문 오른쪽 마우스 클릭으로 삭제
        if (Input.GetMouseButton(1) && createPossibleDoor == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //카메라에서 레이를 쏜다.
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 30000))
            {
                if (hit.transform.tag == "door")
                {
                    Destroy(hit.transform.gameObject);
                }

            }

        }
    }

    
    
}
    
