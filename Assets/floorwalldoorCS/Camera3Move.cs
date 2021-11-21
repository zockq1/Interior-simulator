using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3Move : MonoBehaviour
{
    private Vector3 targetPos;
    public bool planMode = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //도면 모드 ON/ OFF



        //도면모드일때, 카메라 이동.
        if (Input.GetKey(KeyCode.Keypad4) == true)
        {
            targetPos = transform.position;
            targetPos.z -= 0.5f;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * 10f);
        }
        if (Input.GetKey(KeyCode.Keypad6) == true)
        {
            targetPos = transform.position;
            targetPos.z += 0.5f;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * 10f);
        }
        if (Input.GetKey(KeyCode.Keypad8) == true)
        {
            targetPos = transform.position;
            targetPos.x -= 0.5f;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * 10f);
        }
        if (Input.GetKey(KeyCode.Keypad2) == true)
        {
            targetPos = transform.position;
            targetPos.x += 0.5f;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * 10f);
        }
        if (Input.GetKey(KeyCode.Keypad5) == true)
        {
            targetPos = transform.position;
            targetPos.y -= 0.5f;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * 10f);
        }
        if (Input.GetKey(KeyCode.Keypad7) == true)
        {
            targetPos = transform.position;
            targetPos.y += 0.5f;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * 10f);
        }
    }
}
