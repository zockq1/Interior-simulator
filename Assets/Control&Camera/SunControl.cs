using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*SunControl
*1인칭 모드일 때 기본 조명 OFF
*B711205탁재민
*/
public class SunControl : MonoBehaviour
{
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
