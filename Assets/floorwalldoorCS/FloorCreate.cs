using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCreate : MonoBehaviour
{
    public GameObject FloorPrefab1;//�����ٴ�
    public GameObject FloorPrefab2;//Ÿ�Ϲٴ�
    public GameObject FloorPrefab3;//�븮���ٴ�
    public GameObject FloorPrefab4;//�ø�Ʈ�ٴ�
    private GameObject temp_floor;

    bool createPossibleFloor = true; //�ٴڻ������

    bool buttonDown = false;//���콺 Ŭ�� �Ŀ� �� ������ ����.

    private Vector3 mouse_Pos;
    private Vector3 mouse_PosCur;   // �ǽð�(���� ������) ���콺 ��ǥ
    private Vector3 mouse_startPos; // �巡�� ���� ���� ���콺 ��ǥ
    private Vector3 mouse_finishPos;   // Rect�� �ּ� ���� ��ǥ
    //private Vector3 floorPosition;
    private Vector3 temp; //��ġ �ӽ� �����.

    List<GameObject> floorCloneList = new List<GameObject>(); //clone����Ʈ ����.
    private int cloneNum = 0;


    // Start is called before the first frame update
    void Start()
    {
        mouse_Pos = transform.position;
    }
    // Update is called once per frame
    
    private void Update()
    {

        //UI Ŭ������ Ÿ���� ������ �ٲ���.
        temp_floor = FloorPrefab1;


        if(GameObject.Find("control").GetComponent<control>().mode == 1 && GameObject.Find("control").GetComponent<control>().mode_1 == 1){
            createPossibleFloor = true;
        }
        else{
             createPossibleFloor = false;
        }

        //���콺�� ��� Ÿ�� ��� �۾�.
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
            //���콺 �巡�� ��
        }

        if (Input.GetMouseButtonUp(0) && buttonDown == true) //���콺 ��
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

        //Ÿ�� Delete �� ����
        /*
        if (Input.GetKey(KeyCode.Delete) == true && createPossibleFloor==true)
        {
            Debug.Log("Ÿ�� ���� ON");
            if (cloneNum-1 >= 0)
            {
                Destroy(floorCloneList[cloneNum-1]);
                floorCloneList.RemoveAt(cloneNum-1);
                cloneNum -= 1;
            }

        }
        */

        //Ÿ�� ������ ���콺 Ŭ������ ����.
        if (Input.GetMouseButton(1) && createPossibleFloor == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //ī�޶󿡼� ���̸� ���.
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
