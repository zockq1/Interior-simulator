using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject t1, t2, t3, t4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(GameObject.Find("control").GetComponent<control>().mode == 2){
            if(Input.GetKeyDown(KeyCode.Keypad1))
            {
                Instantiate(t1);
            }

            if(Input.GetKeyDown(KeyCode.Keypad2))
            {
                Instantiate(t2);
            }

            if(Input.GetKeyDown(KeyCode.Keypad3))
            {
                Instantiate(t1);
            }

            if(Input.GetKeyDown(KeyCode.Keypad4))
            {
                Instantiate(t2);
            }
        }
    }
}
