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

    // Start is called before the first frame update
    List<GameObject> cloneList = new List<GameObject>();
    Vector3 mouse_Pos;
    Vector3 temp;
    int[] WallPos = new int[5];
    bool createPossibleDoor = false;
    bool firstMouseClickCheck = false; //마우스 클릭 먼저 해서 위치 지정하는지 체크.
    void Start()
    {
        mouse_Pos = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        //UI 클릭시 해당 문으로 바꿔줌.
        temp_door1 = DoorPrefab1_1;
        temp_door2 = DoorPrefab1_2;

        if(GameObject.Find("control").GetComponent<control>().mode == 1 && GameObject.Find("control").GetComponent<control>().mode_1 == 3){
            createPossibleDoor = true;
        }
        else{
            createPossibleDoor = false;
        }

        //5튼키 문설치 모드 On / Off


        //마우스로 격자 설정후, 키보드 상하좌우로 문 설치.
        if (Input.GetMouseButtonDown(0) && createPossibleDoor == true)
        {
            for (int i = 0; i < 5; i++) //각 그리드에 벽 존재 여부 초기화.
            {
                WallPos[i] = 0;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000f))
            {
                mouse_Pos = hit.point;
                mouse_Pos.y = transform.position.y;
                temp = mouse_Pos;
            }
            Debug.Log(mouse_Pos);
            firstMouseClickCheck = true;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) == true && firstMouseClickCheck == true && createPossibleDoor == true)
        {
            if (WallPos[0] == 0)
            {
                mouse_Pos.x = (int)mouse_Pos.x + 0.95f;
                mouse_Pos.y = 0.0f;
                mouse_Pos.z = (int)mouse_Pos.z + 0.049f;
                GameObject go = Instantiate(temp_door1) as GameObject;
                go.transform.position = mouse_Pos;
                WallPos[0] = 1;
                mouse_Pos = temp;
            }

        }
        else if (Input.GetKey(KeyCode.RightArrow) == true && firstMouseClickCheck == true && createPossibleDoor == true)
        {
            if (WallPos[1] == 0)
            {
                mouse_Pos.x = (int)mouse_Pos.x + 0.95f;
                mouse_Pos.y = 0.0f;
                mouse_Pos.z = (int)mouse_Pos.z + 0.95f;
                GameObject go = Instantiate(temp_door1) as GameObject;
                go.transform.position = mouse_Pos;
                WallPos[1] = 1;
                mouse_Pos = temp;
            }

        }
        else if (Input.GetKey(KeyCode.UpArrow) == true && firstMouseClickCheck == true && createPossibleDoor == true)
        {
            if (WallPos[2] == 0)
            {
                mouse_Pos.x = (int)mouse_Pos.x +0.04f;
                mouse_Pos.y = 0.0f;
                mouse_Pos.z = (int)mouse_Pos.z + 0.95f;
                GameObject go = Instantiate(temp_door2) as GameObject;
                go.transform.position = mouse_Pos;
                WallPos[2] = 1;
                mouse_Pos = temp;
            }

        }

        else if (Input.GetKey(KeyCode.DownArrow) == true && firstMouseClickCheck == true && createPossibleDoor == true)
        {
            if (WallPos[3] == 0)
            {
                mouse_Pos.x = (int)mouse_Pos.x +0.951f;
                mouse_Pos.y = 0.0f;
                mouse_Pos.z = (int)mouse_Pos.z + 0.95f;
                GameObject go = Instantiate(temp_door2) as GameObject;
                go.transform.position = mouse_Pos;
                WallPos[3] = 1;
                mouse_Pos = temp;
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
    