using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*LightControl
*1인칭 모드일 때 형광등 ON
*B711205탁재민
*/
public class LightControl : MonoBehaviour
{
        void Update()
    {
        if(GameObject.Find("control").GetComponent<control>().mode == 3){
            GetComponent<Light>().enabled = true;
        }
        else{
            GetComponent<Light>().enabled = false;
        }
    }
}
