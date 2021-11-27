using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("control").GetComponent<control>().mode == 3){
            GetComponent<Light>().enabled = false;
        }
        else{
            GetComponent<Light>().enabled = true;
        }
    }
}
