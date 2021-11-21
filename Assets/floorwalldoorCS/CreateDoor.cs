using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDoor : MonoBehaviour
{
    public GameObject DoorPrefab1_1;//��¦1-1
    public GameObject DoorPrefab1_2;//��¦1-2
    public GameObject DoorPrefab2_1;//��¦2-1
    public GameObject DoorPrefab2_2;//��¦2-2
    private GameObject temp_door1;
    private GameObject temp_door2;

    // Start is called before the first frame update
    List<GameObject> cloneList = new List<GameObject>();
    Vector3 mouse_Pos;
    Vector3 temp;
    int[] WallPos = new int[5];
    bool createPossibleDoor = false;
    bool firstMouseClickCheck = false; //���콺 Ŭ�� ���� �ؼ� ��ġ �����ϴ��� üũ.
    void Start()
    {
        mouse_Pos = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        //UI Ŭ���� �ش� ������ �ٲ���.
        temp_door1 = DoorPrefab1_1;
        temp_door2 = DoorPrefab1_2;

        if(GameObject.Find("control").GetComponent<control>().mode == 1 && GameObject.Find("control").GetComponent<control>().mode_1 == 3){
            createPossibleDoor = true;
        }
        else{
            createPossibleDoor = false;
        }

        //5ưŰ ����ġ ��� On / Off


        //���콺�� ���� ������, Ű���� �����¿�� �� ��ġ.
        if (Input.GetMouseButtonDown(0) && createPossibleDoor == true)
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


        //�� ������ ���콺 Ŭ������ ����
        if (Input.GetMouseButton(1) && createPossibleDoor == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //ī�޶󿡼� ���̸� ���.
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
    