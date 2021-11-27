using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofMove : MonoBehaviour
{
    /*
     * B911035 김세환
     * 넓은 면적의 plane을 뒤집어서 천장 생성
     * plane을 x축을 기준으로 180도 회전하면 
     * plane이 물체 위에 있다고 하더라도 plane 밑의 물체들이 보이는 것을 이용함.
     * 시작하자마자 planePrefab이 생성되고, 해당하는 위치로 가도록 함.
     */

    Vector3 roofPos;
    public GameObject roof;

    // 시작되면 천장 바로 생성.
    void Start()
    {
        GameObject go = Instantiate(roof) as GameObject;
        roofPos.x = 10.0f;
        roofPos.y = 2.6f;
        roofPos.z = 10.0f;
        go.transform.position = roofPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
