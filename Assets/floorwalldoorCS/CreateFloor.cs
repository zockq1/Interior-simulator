using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFloor: MonoBehaviour
{
    public GameObject FloorPrefab1;//나무바닥
    public GameObject FloorPrefab2;//타일바닥
    public GameObject FloorPrefab3;//대리석바닥
    public GameObject FloorPrefab4;//시멘트바닥
    private GameObject temp_floor;//설치한 바닥 프리팹 지정변수

    bool createPossibleFloor = true; //바닥생성모드

    bool buttonDown = false;//마우스 클릭 후에 뗀 것인지 감지.

    private Vector3 mouse_Pos;
    private Vector3 mouse_PosCur;   // 실시간(현재 프레임) 마우스 좌표
    private Vector3 mouse_startPos; // 드래그 시작 지점 마우스 좌표
    private Vector3 mouse_finishPos;   // Rect의 최소 지점 좌표

  
    private Vector3 temp; //위치 임시 저장용.
    private Vector3 tempPos; //이전 마우스 위치 임시 저장.
    private bool doubleCheck; //같은 위치 중복 생성 방지 변수.
    private GridPos gridpos; //GridPos로 부터 가져온 마우스 좌표.

    List<GameObject> floorCloneList = new List<GameObject>(); //clone리스트 저장.
    private int cloneNum = 0;


    // Start is called before the first frame update
    void Start()
    {
        doubleCheck = true;
        mouse_Pos = transform.position;
        temp_floor = FloorPrefab1;
    }
    // Update is called once per frame
    
    //바닥 프리팹 지정함수
    public void setFloorPrefab1()
    {
        temp_floor = FloorPrefab1;
    }
    public void setFloorPrefab2()
    {
        temp_floor = FloorPrefab2;
    }
    public void setFloorPrefab3()
    {
        temp_floor = FloorPrefab3;
    }
    public void setFloorPrefab4()
    {
        temp_floor = FloorPrefab4;
    }

    private void Update()
    {

        if (GameObject.Find("control").GetComponent<control>().mode == 1 && GameObject.Find("control").GetComponent<control>().mode_1 == 1)
        {
            createPossibleFloor = true;
        }
        else
        {
            createPossibleFloor = false;
        }


        if (tempPos != GameObject.Find("GridPos").GetComponent<GridPos>().mouse_Pos)
        {
            doubleCheck = true;
        }
        
        //벽 생성과 비슷한 방식으로 바닥 생성 추가
        /*
        if (Input.GetMouseButton(0) && createPossibleFloor == true && doubleCheck == true)
        {
            gridpos = GameObject.Find("GridPos").GetComponent<GridPos>();
            tempPos = gridpos.mouse_Pos;
            mouse_Pos = gridpos.mouse_Pos;
            mouse_Pos.y = 0.0f;
            GameObject go = Instantiate(temp_floor) as GameObject;
            go.transform.position = mouse_Pos;
            doubleCheck = false;

        }
        */
        
        if (Input.GetMouseButtonDown(0))
        {
            if (createPossibleFloor == true)
            {
                mouse_startPos = GameObject.Find("GridPos").GetComponent<GridPos>().mouse_Pos;
                mouse_startPos.y = 0.0f;
                buttonDown = true;
            }
        }

        if (Input.GetMouseButton(0))
        {
            //마우스 드래그 중
        }

        if (Input.GetMouseButtonUp(0) && buttonDown == true) //마우스 뗌
        {
            if (createPossibleFloor == true)
            {
                mouse_finishPos = GameObject.Find("GridPos").GetComponent<GridPos>().mouse_Pos;
                mouse_finishPos.y = 0.0f;
                temp = mouse_startPos;
                while (mouse_finishPos.x >= mouse_startPos.x)
                {

                    mouse_startPos.z = temp.z;
                    while (mouse_finishPos.z >= mouse_startPos.z)
                    {

                        GameObject go = Instantiate(temp_floor) as GameObject;
                        go.transform.position = mouse_startPos;

                        mouse_startPos.z += 1.0f;
                    }
                    mouse_startPos.x += 1.0f;
                }
                buttonDown = false;

            }

        }
        
        
        //타일 오른쪽 마우스 클릭으로 삭제.
        if (Input.GetMouseButton(1) && createPossibleFloor == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //카메라에서 레이를 쏜다.
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 30000))
            {
                Debug.Log(hit.transform.gameObject.tag);
                if (hit.transform.tag == "Floor")
                {
                    Destroy(hit.transform.gameObject);
                }

            }
       

        }



    }
    
}
