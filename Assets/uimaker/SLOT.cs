using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SLOT : MonoBehaviour
{
    [SerializeField]
    GameObject GO; //����������
    Deployment DP; //������ Deployment ������Ʈ ���� ����

    Button BT; //�� ������ ��ư ������Ʈ ������ ����

    private void Start()
    {
        BT = this.GetComponent<Button>();
        DP = GO.GetComponent<Deployment>();
        BT.onClick.AddListener(doit); //��ư Ŭ���� doit�Լ��� ����
    }

    void doit()
    {     
            Debug.Log("sf"); 
            Instantiate(GO); //������ �����.
    }
}
