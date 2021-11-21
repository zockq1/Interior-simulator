using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreate : MonoBehaviour
{
    public GameObject WallPrefab1;//흰색 벽지 벽
    public GameObject WallPrefab2;//다른 벽지 벽
    public GameObject WallPrefab3;//다른 벽지 벽
    public GameObject WallPrefab4;//다른 벽지 벽

    private GameObject temp_wall;
    //private GameObject cloneTemp;
    List<GameObject> cloneList = new List<GameObject>();

    Vector3 mouse_Pos;
    Vector3 temp;
    int[] WallPos = new int[5];
    bool createPossibleWall = false;
    bool firstMouseClickCheck = false; //마우스 클릭 먼저 해서 위치 지정하는지 체크.
    void Start()
    {
        
        mouse_Pos = transform.position;
       
    }
    void Update()
    {
        //어떤 벽지를 선택할 것인지.
        temp_wall = WallPrefab1;//(임시)

        //벽설치 모드 On / Off
        if (Input.GetKey(KeyCode.Alpha2) == true) 
        {
            if (createPossibleWall == true) { createPossibleWall = false; Debug.Log("벽 설치 모드 OFF"); }
            else { createPossibleWall = true; Debug.Log("벽 설치 모드 ON"); }
        }

        //마우스를 통해 그리드 클릭후, 키보드 상하좌우로 벽 설치.
        if (Input.GetMouseButtonDown(0) && createPossibleWall==true)
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
        if (Input.GetKey(KeyCode.LeftArrow) == true && firstMouseClickCheck==true && createPossibleWall == true)
        {
            if (WallPos[0] == 0)
            {
                    mouse_Pos.x = (int)mouse_Pos.x + 0.5f;
                    mouse_Pos.y = 0.0f;
                    mouse_Pos.z = (int)mouse_Pos.z + 0.1f;
                    GameObject go = Instantiate(temp_wall) as GameObject;
                    go.transform.position = mouse_Pos;
                    WallPos[0] = 1;
                    mouse_Pos = temp;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) == true && firstMouseClickCheck == true && createPossibleWall == true)
        {
            
            if (WallPos[1] == 0)
            {
             
                    mouse_Pos.x = (int)mouse_Pos.x + 0.5f;
                    mouse_Pos.y = 0.0f;
                    mouse_Pos.z = (int)mouse_Pos.z + 0.9f;
                    GameObject go = Instantiate(temp_wall) as GameObject;
                    go.transform.position = mouse_Pos;
                    WallPos[1] = 1;
                    mouse_Pos = temp;
            }
            
        }
        else if (Input.GetKey(KeyCode.UpArrow) == true && firstMouseClickCheck == true && createPossibleWall == true)
        {
            
            if (WallPos[2] == 0)
            {
                    mouse_Pos.x = (int)mouse_Pos.x + 0.1f;
                    mouse_Pos.y = 0.0f;
                    mouse_Pos.z = (int)mouse_Pos.z + 0.5f;
                    GameObject go = Instantiate(temp_wall) as GameObject;
                    go.transform.position = mouse_Pos;
                    go.transform.rotation = Quaternion.Euler(0, 90, 0);
                    WallPos[2] = 1;
                    mouse_Pos = temp;

            }
            
            

        }
        else if (Input.GetKey(KeyCode.DownArrow) == true && firstMouseClickCheck == true && createPossibleWall == true)
        {
            if (WallPos[3] == 0)
            {
                    mouse_Pos.x = (int)mouse_Pos.x + 0.9f;
                    mouse_Pos.y = 0.0f;
                    mouse_Pos.z = (int)mouse_Pos.z + 0.5f;
                    GameObject go = Instantiate(temp_wall) as GameObject;
                    go.transform.position = mouse_Pos;
                    go.transform.rotation = Quaternion.Euler(0, 90, 0);
                    WallPos[3] = 1;
                    mouse_Pos = temp;


            }
            
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
