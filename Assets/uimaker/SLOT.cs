using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SLOT : MonoBehaviour
{
    [SerializeField]
    GameObject GO; //가구프리팹
    Deployment DP; //가구의 Deployment 컴포넌트 정보 저장

    Button BT; //이 슬롯의 버튼 컴포넌트 정보를 저장

    private void Start()
    {
        BT = this.GetComponent<Button>();
        DP = GO.GetComponent<Deployment>();
        BT.onClick.AddListener(doit); //버튼 클릭시 doit함수를 실행
    }

    void doit()
    {     
            Debug.Log("sf"); 
            Instantiate(GO); //가구를 만든다.
    }
}
