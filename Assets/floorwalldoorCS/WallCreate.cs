using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreate : MonoBehaviour
{
    public GameObject WallPrefab1;//��� ���� ��
    public GameObject WallPrefab2;//�ٸ� ���� ��
    public GameObject WallPrefab3;//�ٸ� ���� ��
    public GameObject WallPrefab4;//�ٸ� ���� ��

    private GameObject temp_wall;
    //private GameObject cloneTemp;
    List<GameObject> cloneList = new List<GameObject>();

    Vector3 mouse_Pos;
    Vector3 temp;
    int[] WallPos = new int[5];
    bool createPossibleWall = false;
    bool firstMouseClickCheck = false; //���콺 Ŭ�� ���� �ؼ� ��ġ �����ϴ��� üũ.
    void Start()
    {
        
        mouse_Pos = transform.position;
       
    }
    void Update()
    {
        //� ������ ������ ������.
        temp_wall = WallPrefab1;//(�ӽ�)

        //����ġ ��� On / Off
        if (Input.GetKey(KeyCode.Alpha2) == true) 
        {
            if (createPossibleWall == true) { createPossibleWall = false; Debug.Log("�� ��ġ ��� OFF"); }
            else { createPossibleWall = true; Debug.Log("�� ��ġ ��� ON"); }
        }

        //���콺�� ���� �׸��� Ŭ����, Ű���� �����¿�� �� ��ġ.
        if (Input.GetMouseButtonDown(0) && createPossibleWall==true)
        {
            for (int i = 0; i < 5; i++) //�� �׸��忡 �� ���� ���� �ʱ�ȭ.
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
        
        //���� �� ������ ���콺 Ŭ������ ����
        if (Input.GetMouseButton(1) && createPossibleWall == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //ī�޶󿡼� ���̸� ���.
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
