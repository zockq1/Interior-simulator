using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDoor : MonoBehaviour
{
    public GameObject DoorPrefab1_1;//문짝1-1
    public GameObject DoorPrefab1_2;//문짝1-2
    public GameObject DoorPrefab2_1;//문짝2-1
    public GameObject DoorPrefab2_2;//문짝2-2
    private GameObject temp_door1;
    private GameObject temp_door2;

    private GridPos gridpos; //GridPos로 부터 가져온 마우스 좌표.

    // Start is called before the first frame update
    List<GameObject> doorCloneList = new List<GameObject>();
    int cloneNum = 0;
    private Vector3 mouse_Pos;
    private Vector3 tempPosLeft;
    private Vector3 tempPosRight;
    private Vector3 tempPosUp;
    private Vector3 tempPosDown;
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

    //temp_door 에 프리팹 설정.
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
        
        //벽설치 모드 On / Off
        if (GameObject.Find("control").GetComponent<control>().mode == 1 && GameObject.Find("control").GetComponent<control>().mode_1 == 3)
        {
            createPossibleDoor = true;
        }
        else
        {
            createPossibleDoor = false;
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
        if (Input.GetMouseButton(0) == true && createPossibleDoor == true && doubleCheckLeft && GameObject.Find("control").GetComponent<control>().mode_1_direction == 3)
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
        else if (Input.GetMouseButton(0) == true && createPossibleDoor == true && doubleCheckRight && GameObject.Find("control").GetComponent<control>().mode_1_direction == 4)
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
        else if (Input.GetMouseButton(0) == true && createPossibleDoor == true && doubleCheckUp && GameObject.Find("control").GetComponent<control>().mode_1_direction == 1)
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

        else if (Input.GetMouseButton(0) == true && createPossibleDoor == true && doubleCheckDown && GameObject.Find("control").GetComponent<control>().mode_1_direction == 2)
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
    
