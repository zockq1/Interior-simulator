using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCreate : MonoBehaviour
{
    public GameObject FloorPrefab1;//나무바닥
    public GameObject FloorPrefab2;//타일바닥
    public GameObject FloorPrefab3;//대리석바닥
    public GameObject FloorPrefab4;//시멘트바닥
    private GameObject temp_floor;

    bool createPossibleFloor = true; //바닥생성모드

    bool buttonDown = false;//마우스 클릭 후에 뗀 것인지 감지.

    private Vector3 mouse_Pos;
    private Vector3 mouse_PosCur;   // 실시간(현재 프레임) 마우스 좌표
    private Vector3 mouse_startPos; // 드래그 시작 지점 마우스 좌표
    private Vector3 mouse_finishPos;   // Rect의 최소 지점 좌표
    //private Vector3 floorPosition;
    private Vector3 temp; //위치 임시 저장용.

    List<GameObject> floorCloneList = new List<GameObject>(); //clone리스트 저장.
    private int cloneNum = 0;


    // Start is called before the first frame update
    void Start()
    {
        mouse_Pos = transform.position;
    }
    // Update is called once per frame
    
    private void Update()
    {

        //UI 클릭으로 타일의 종류를 바꿔줌.
        temp_floor = FloorPrefab1;


        if(GameObject.Find("control").GetComponent<control>().mode == 1 && GameObject.Find("control").GetComponent<control>().mode_1 == 1){
            createPossibleFloor = true;
        }
        else{
             createPossibleFloor = false;
        }

        //마우스를 끌어서 타일 까는 작업.
        if (Input.GetMouseButtonDown(0))
        {
            if (createPossibleFloor == true)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 10000f))
                {
                    mouse_Pos = hit.point;
                    mouse_Pos.y = transform.position.y;
                }
                mouse_startPos.x = (int)mouse_Pos.x + 0.5f;
                mouse_startPos.y = 0.0f;
                mouse_startPos.z = (int)mouse_Pos.z + 0.5f;
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
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 10000f))
                {
                    mouse_Pos = hit.point;
                    mouse_Pos.y = transform.position.y;
                }
                mouse_finishPos.x = (int)mouse_Pos.x + 0.5f;
                mouse_finishPos.y = 0.0f;
                mouse_finishPos.z = (int)mouse_Pos.z + 0.5f;

                temp = mouse_startPos;
                while (mouse_finishPos.x >= mouse_startPos.x)
                {

                    mouse_startPos.z = temp.z;
                    while (mouse_finishPos.z >= mouse_startPos.z)
                    {

                        GameObject go = Instantiate(temp_floor) as GameObject;
                        go.transform.position = mouse_startPos;
                        //floorCloneList.Add(go);
                        //cloneNum += 1;
                        mouse_startPos.z += 1.0f;
                    }
                    mouse_startPos.x += 1.0f;
                }
                buttonDown = false;
                //createPossibleFloor = false;
            }

        }

        //타일 Delete 로 삭제
        /*
        if (Input.GetKey(KeyCode.Delete) == true && createPossibleFloor==true)
        {
            Debug.Log("타일 삭제 ON");
            if (cloneNum-1 >= 0)
            {
                Destroy(floorCloneList[cloneNum-1]);
                floorCloneList.RemoveAt(cloneNum-1);
                cloneNum -= 1;
            }

        }
        */

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
