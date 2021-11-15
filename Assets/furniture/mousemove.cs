using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousemove : MonoBehaviour
{
    public Renderer cubeColor;
    Color temp;    
    public bool iscollision;
    public bool isdeployment;
    void Start()
    {
        isdeployment = false;
        iscollision = false;
        cubeColor = gameObject.GetComponent<Renderer>();
        temp = cubeColor.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !iscollision)
        {
            isdeployment = true;
        }
        if(!isdeployment){
            Ray ray;
            RaycastHit hit;
            int _layerMask = 1<<LayerMask.NameToLayer("floor");
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast (ray, out hit, 30.0f, _layerMask)){
                this.transform.position = new Vector3((float)hit.point.x, (float)(hit.point.y), (float)hit.point.z);
                Debug.Log(hit.normal);
            
            }
        }
        if(isdeployment){
            GetComponent<Collider>().isTrigger = true;
        }
    }
    
    void OnTriggerEnter(Collider other){
        if(!isdeployment){
            iscollision = true;
            Debug.Log("Enter: 배치불가");
            cubeColor.material.color = Color.red;
        }
    }

    void OnTriggerStay(Collider other){
        if(!isdeployment){
            iscollision = true;
            Debug.Log("stay: 배치불가");
            cubeColor.material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other){
        if(!isdeployment){
            iscollision = false;
            Debug.Log("Eixt: 배치가능");
            cubeColor.material.color = temp;
        }
    }
    
}
