using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofMove : MonoBehaviour
{
    Vector3 roofPos;
    public GameObject roof;

    // 시작되면 천장 바로 생성.
    void Start()
    {
        GameObject go = Instantiate(roof) as GameObject;
        roofPos.x = 10.0f;
        roofPos.y = 2.4f;
        roofPos.z = 10.0f;
        go.transform.position = roofPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
