using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CAMERABUTTON : MonoBehaviour
{
    [SerializeField]
    public GameObject CONTROL; //��Ʈ�� ���ӿ�����Ʈ
    control _control; //CONTROL���� �̾Ƴ��� control ��ũ��Ʈ
    CreateFloor _cf;  //CONTROL���� �̾Ƴ��� CreateFloor ��ũ��Ʈ
    CreateWall _cw;   //CONTROL���� �̾Ƴ��� CreateWall ��ũ��Ʈ
    CreateDoor _cd;   //CONTROL���� �̾Ƴ��� CreateDoor ��ũ��Ʈ

    [SerializeField]
    public GameObject FURNISLOTS; //��������� �κ��丮

    GameObject[] _buttons; //���� ���� 1��Ī ��ư��
    RectTransform[] _buttonstrans; //���� ���� 1��Ī ��ư�� ��ġ
    Image[] _buttonsimages; //���� ���� 1��Ī ��ư�� �̹���

    [SerializeField] // ����
    GameObject UIPLAN;  //�����弳��
    [SerializeField]
    GameObject UITHIRD; //������弳��
    [SerializeField]
    GameObject UIFIRST; //1��Ī��弳��
    //����ȭ��Ű�� ������Ʈ��

    GameObject UIINPLAN; //�������� ��ư���� ��Ƴ��� ���ӿ�����Ʈ(�ٴ� �� �� ��ư)
    RectTransform UIINPLANTRAN; //��ư������ ��ġ�� �ٲٱ� ���� ����
    GameObject[] _subbuttons; //�ٴ� �� �� ��ư��
    RectTransform[] _subbuttonstrans; //��ư���� UI��ġ
    Image[] _subbuttonsimages; //��ư���� UI�̹���
    bool _opensub = false; //��ư������ Ȱ��ȭ����

    GameObject UIDIR; //�� ������ ��ġ ������ �ٲٴ� ��ư���� ��Ƴ��� ���ӿ�����Ʈ(�����¿�)
    RectTransform UIDIRTRAN; //��ư������ ��ġ�� �ٲٱ� ���� ����
    GameObject[] _dirbuttons; //�����¿��ư��
    RectTransform[] _dirbuttonstrans; //��ư���� UI��ġ
    Image[] _dirbuttonsimages;  //��ư���� UI�̹���
    bool _opendir = false; //��ư������ Ȱ��ȭ����

    [SerializeField]
    Sprite[] _buttonssprites; //��ư ��������Ʈ��

    GameObject UIFLOOR; //�ٴ�
    GameObject[] _floorbuttons; //�ٴ��ؽ��Ĺ�ư����
    RectTransform[] _floorbuttonstrans; //�ٴ��ؽ��Ĺ�ư��ġ
    Image[] _floorbuttonsimages; //�ٴ��ؽ��Ĺ�ư�̹���
    bool _openfloor; //��ư���� Ȱ��ȭ����

    GameObject UIWALL; //��
    GameObject[] _wallbuttons;//��������ư����
    RectTransform[] _wallbuttonstrans; //��������ư��ġ����
    Image[] _wallbuttonsimages; //��������ư�̹���
    bool _openwall; //��ư���� Ȱ��ȭ����

    GameObject UIDOOR; //��
    GameObject[] _doorbuttons; //��������ư����
    RectTransform[] _doorbuttonstrans; //��������ư��ġ
    Image[] _doorbuttonsimages;//��������ư�̹���
    bool _opendoor; //��ư���� Ȱ��ȭ����

    void Awake()
    {
        Screen.SetResolution(1920, 1080, false); //�ػ� ����

        _buttons = new GameObject[3]; //����, ����, 1��Ī ��ư ������Ʈ�� (������ ���� ��ư)
        _buttonstrans = new RectTransform[3]; //��ƮƮ������ ����
        _buttonsimages = new Image[3]; //�̹��� ����
        for (int i=0; i<3; i++)//����, ����, 1��Ī ���� �� 3��
        { 
            _buttons[i] = new GameObject(); //��ư �迭 �ϳ��� ���ӿ�����Ʈ �Ҵ�
            if (_buttons[i].GetComponent<RectTransform>() == null)            //��ƮƮ������ ������Ʈ�� ���ٸ�
            {
                _buttons[i].AddComponent<RectTransform>();                    //��ƮƮ������ ������Ʈ�� ���� ������
                _buttonstrans[i] = _buttons[i].GetComponent<RectTransform>(); //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            }
            else                                                              //��ƮƮ������ ������Ʈ�� �ִٸ�
                _buttonstrans[i] = _buttons[i].GetComponent<RectTransform>(); //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            _buttons[i].transform.SetParent(this.transform); //�� �� �� ���ӿ�����Ʈ�� �θ� UICAMERAMODE��

            if (_buttons[i].GetComponent<Image>() == null) //�̹��� ������Ʈ�� ���ٸ�
            {
                _buttons[i].AddComponent<Image>();                          //�̹��� ������Ʈ�� ���� ������
                _buttonsimages[i] = _buttons[i].GetComponent<Image>();      //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            }
            else                                                            //�̹��� ������Ʈ�� �ִٸ�
                _buttonsimages[i] = _buttons[i].GetComponent<Image>();      //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            _buttonsimages[i].sprite = _buttonssprites[i]; //��ư�� ��������Ʈ�� _buttonssprites�� ����� �̹������� ������ ����

            _buttonstrans[i].sizeDelta = new Vector2(150, 100);             //��ư ������ ����
            _buttonstrans[i].localPosition = new Vector2(500 + i*160, 450); //��ư ��ġ ����
        }
        _control = CONTROL.GetComponent<control>(); //��Ʈ�� ������Ʈ �������� ����

        UIINPLAN = new GameObject();//���� ������ �ٴ� �� �� ��ư�� �θ� 
        if (UIINPLAN.GetComponent<RectTransform>() == null)               //��ƮƮ������ ������Ʈ�� ���ٸ�
        {
            UIINPLAN.AddComponent<RectTransform>();                       //��ƮƮ������ ������Ʈ�� ���� ������
            UIINPLANTRAN = UIINPLAN.GetComponent<RectTransform>();        //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
        }
        else                                                              //��ƮƮ������ ������Ʈ�� �ִٸ�
            UIINPLANTRAN = UIINPLAN.GetComponent<RectTransform>();        //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
        UIINPLAN.transform.SetParent(this.transform);                     //�� �� �� ���ӿ�����Ʈ�� �θ� UICAMERAMODE��
        UIINPLANTRAN.localPosition = new Vector2(0, 0);                   //��ġ ����

        _subbuttons = new GameObject[3];        //���� ��� �� �ٴ�, ��, �� ��ư ������Ʈ��(���� ���� ��ư, ������ÿ��� ��Ÿ��)
        _subbuttonstrans = new RectTransform[3]; //��ƮƮ������ ����
        _subbuttonsimages = new Image[3]; //�̹��� ����
        for (int i = 0; i < 3; i++) //�ٴ�, ��, ����ư ���� �� 3��
        {
            _subbuttons[i] = new GameObject();                                      //��ư �迭 �ϳ��� ���ӿ�����Ʈ �Ҵ�
            if (_subbuttons[i].GetComponent<RectTransform>() == null)               //��ƮƮ������ ������Ʈ�� ���ٸ�
            {
                _subbuttons[i].AddComponent<RectTransform>();                       //��ƮƮ������ ������Ʈ�� ���� ������
                _subbuttonstrans[i] = _subbuttons[i].GetComponent<RectTransform>(); //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            }
            else                                                                    //��ƮƮ������ ������Ʈ�� �ִٸ�
                _subbuttonstrans[i] = _subbuttons[i].GetComponent<RectTransform>(); //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            if (_subbuttons[i].GetComponent<Image>() == null)                       //�̹��� ������Ʈ�� ���ٸ�
            {
                _subbuttons[i].AddComponent<Image>();                               //�̹��� ������Ʈ�� ���� ������
                _subbuttonsimages[i] = _subbuttons[i].GetComponent<Image>();        //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            }
            else                                                                    //�̹��� ������Ʈ�� �ִٸ�
                _subbuttonsimages[i] = _subbuttons[i].GetComponent<Image>();        //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            _subbuttonsimages[i].sprite = _buttonssprites[3+i]; //��ư�� ��������Ʈ�� _buttonssprites�� ����� �̹������� ������ ����

            _subbuttonstrans[i].sizeDelta = new Vector2(150, 100);                  //��ư ������ ����
            _subbuttonstrans[i].localPosition = new Vector2(140 + i * 160, 980);    //��ư ��ġ ����
            _subbuttons[i].transform.SetParent(UIINPLAN.transform); //�� �� �� ���ӿ�����Ʈ�� �θ� UIINPLAN����(UICAMERAMODE - UIINPLAN - _subbuttons[i]��)
        }
        UIINPLAN.SetActive(false); //�ϴ� ������ ��Ȱ��ȭ

        UIDIR = new GameObject();        //��, �� ��� �� �����¿� ��ư���� �θ�
        if (UIDIR.GetComponent<RectTransform>() == null)               //��ƮƮ������ ������Ʈ�� ���ٸ�
        {
            UIDIR.AddComponent<RectTransform>();                       //��ƮƮ������ ������Ʈ�� ���� ������
            UIDIRTRAN = UIDIR.GetComponent<RectTransform>();           //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
        }
        else                                                           //��ƮƮ������ ������Ʈ�� �ִٸ�
            UIDIRTRAN = UIDIR.GetComponent<RectTransform>();           //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
        UIDIR.transform.SetParent(this.transform);                     //�� �� �� ���ӿ�����Ʈ�� �θ� UICAMERAMODE��
        UIDIRTRAN.localPosition = new Vector2(0, 0);                   //��ư ��ġ ����

        _dirbuttons = new GameObject[4];                                //�����ư(�����¿�) [0]�� [1]�� [2]�� [3]��
        _dirbuttonstrans = new RectTransform[4];                        //�����ư(�����¿�)�� ��ġ
        _dirbuttonsimages = new Image[4];                               //�����ư(�����¿�)�� �̹���
        _dirbuttons[0] = new GameObject();//�����ư [0]�� ���ӿ�����Ʈ �Ҵ�
        if (_dirbuttons[0].GetComponent<RectTransform>() == null)               //��ƮƮ������ ������Ʈ�� ���ٸ�
        {
            _dirbuttons[0].AddComponent<RectTransform>();                       //��ƮƮ������ ������Ʈ�� ���� ������
            _dirbuttonstrans[0] = _dirbuttons[0].GetComponent<RectTransform>(); //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
        }
        else                                                                    //��ƮƮ������ ������Ʈ�� �ִٸ�
            _dirbuttonstrans[0] = _dirbuttons[0].GetComponent<RectTransform>(); //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
        if (_dirbuttons[0].GetComponent<Image>() == null)                       //�̹��� ������Ʈ�� ���ٸ�
        {
            _dirbuttons[0].AddComponent<Image>();                               //�̹��� ������Ʈ�� ���� ������
            _dirbuttonsimages[0] = _dirbuttons[0].GetComponent<Image>();        //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
        }
        else                                                                    //�̹��� ������Ʈ�� �ִٸ�
            _dirbuttonsimages[0] = _dirbuttons[0].GetComponent<Image>();        //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
        _dirbuttonsimages[0].sprite = _buttonssprites[6]; //��ư�� ��������Ʈ�� _buttonssprites�� ����� �̹������� ������ ����

        _dirbuttonstrans[0].sizeDelta = new Vector2(100, 100);                  //��ư ������ ����
        _dirbuttonstrans[0].localPosition = new Vector2(220, 750);              //��ư ��ġ ����
        _dirbuttons[0].transform.SetParent(UIDIR.transform);//�� �� �� ���ӿ�����Ʈ�� �θ� UIDIR����(UICAMERAMODE - UIDIR - _dirbuttons[i]��)
        for (int i = 1; i < 4; i++)//�����ư [1]�� [2]�� [3]�� 
        {
            _dirbuttons[i] = new GameObject();//�����ư [i]�� ���ӿ�����Ʈ �Ҵ�
            if (_dirbuttons[i].GetComponent<RectTransform>() == null)// ��ƮƮ������ ������Ʈ�� ���ٸ�
            {
                _dirbuttons[i].AddComponent<RectTransform>();                       //��ƮƮ������ ������Ʈ�� ���� ������
                _dirbuttonstrans[i] = _dirbuttons[i].GetComponent<RectTransform>(); //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            }
            else                                                                    //��ƮƮ������ ������Ʈ�� �ִٸ�
                _dirbuttonstrans[i] = _dirbuttons[i].GetComponent<RectTransform>(); //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            if (_dirbuttons[i].GetComponent<Image>() == null)                       //�̹��� ������Ʈ�� ���ٸ�
            {
                _dirbuttons[i].AddComponent<Image>();                               //�̹��� ������Ʈ�� ���� ������
                _dirbuttonsimages[i] = _dirbuttons[i].GetComponent<Image>();        //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            }
            else                                                                    //�̹��� ������Ʈ�� �ִٸ�
                _dirbuttonsimages[i] = _dirbuttons[i].GetComponent<Image>();        //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            _dirbuttonsimages[i].sprite = _buttonssprites[6+i];//��ư�� ��������Ʈ�� _buttonssprites�� ����� �̹������� ������ ����

            _dirbuttonstrans[i].sizeDelta = new Vector2(100, 100);                  //��ư ������ ����
            _dirbuttonstrans[i].localPosition = new Vector2(20 + i * 100, 650);     //��ư ��ġ ����
            _dirbuttons[i].transform.SetParent(UIDIR.transform);//�� �� �� ���ӿ�����Ʈ�� �θ� UIDIR����(UICAMERAMODE - UIDIR - _dirbuttons[i]��)
        }
        UIDIR.SetActive(false);//�ϴ� ������ ��Ȱ��ȭ

        UIFLOOR = new GameObject();             //�ٴ��ؽ��Ĺ�ư���� ������ ���ӿ�����Ʈ
        UIFLOOR.transform.SetParent(UIINPLAN.transform);//�� �� �� ���ӿ�����Ʈ�� �θ� UIINPLAN����(UICAMERAMODE - UIINPLAN - UIFLOOR��)
        _floorbuttons = new GameObject[4];          //�ٴ��ؽ��Ĺ�ư��
        _floorbuttonstrans = new RectTransform[4];  //�ٴ��ؽ��Ĺ�ư�� ��ġ
        _floorbuttonsimages = new Image[4];         //�ٴ��ؽ��Ĺ�ư�� �̹���
        for (int i = 0; i < 4; i++) //�ٴ� 4����
        {
            _floorbuttons[i] = new GameObject();    //�ٴ��ؽ��Ĺ�ư�鿡 ���ӿ�����Ʈ �Ҵ�
            if (_floorbuttons[i].GetComponent<RectTransform>() == null)// ��ƮƮ������ ������Ʈ�� ���ٸ�
            {
                _floorbuttons[i].AddComponent<RectTransform>();//��ƮƮ������ ������Ʈ�� ���� ������
                _floorbuttonstrans[i] = _floorbuttons[i].GetComponent<RectTransform>();//������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            }
            else                                                                    //��ƮƮ������ ������Ʈ�� �ִٸ�
                _floorbuttonstrans[i] = _floorbuttons[i].GetComponent<RectTransform>(); //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            if (_floorbuttons[i].GetComponent<Image>() == null)//�̹��� ������Ʈ�� ���ٸ�
            {
                _floorbuttons[i].AddComponent<Image>();        //�̹��� ������Ʈ�� ���� ������
                _floorbuttonsimages[i] = _floorbuttons[i].GetComponent<Image>();//������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            }
            else//�̹��� ������Ʈ�� �ִٸ�
                _floorbuttonsimages[i] = _floorbuttons[i].GetComponent<Image>();//������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            _floorbuttonsimages[i].sprite = _buttonssprites[10 + i];        //��ư�� ��������Ʈ�� _buttonssprites�� ����� �̹������� ������ ����

            _floorbuttonstrans[i].sizeDelta = new Vector2(100, 100);                  //��ư ������ ����
            _floorbuttonstrans[i].localPosition = new Vector2(120 + i * 100, 870);     //��ư ��ġ ����
            _floorbuttonstrans[i].transform.SetParent(UIFLOOR.transform);//�� �� �� ���ӿ�����Ʈ�� �θ� UIFLOOR����
                                                                         //(UICAMERAMODE - UIINPLAN - UIFLOOR - _floorbuttonstrans[i]��)
        }
        UIFLOOR.SetActive(false); //�ϴ� ��Ȱ��ȭ

        UIDOOR = new GameObject();//���ؽ��Ĺ�ư���� ������ ���ӿ�����Ʈ
        UIDOOR.transform.SetParent(UIINPLAN.transform);//�� �� �� ���ӿ�����Ʈ�� �θ� UIINPLAN����(UICAMERAMODE - UIINPLAN - UIDOOR��)
        _doorbuttons = new GameObject[4];//���ؽ��Ĺ�ư��
        _doorbuttonstrans = new RectTransform[4];//���ؽ��Ĺ�ư�� ��ġ
        _doorbuttonsimages = new Image[4];//���ؽ��Ĺ�ư�� �̹���
        for (int i = 0; i < 2; i++) //�� 2����
        {
            _doorbuttons[i] = new GameObject();    //���ؽ��Ĺ�ư�鿡 ���ӿ�����Ʈ �Ҵ�
            if (_doorbuttons[i].GetComponent<RectTransform>() == null)// ��ƮƮ������ ������Ʈ�� ���ٸ�
            {
                _doorbuttons[i].AddComponent<RectTransform>();//��ƮƮ������ ������Ʈ�� ���� ������
                _doorbuttonstrans[i] = _doorbuttons[i].GetComponent<RectTransform>();//������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            }
            else                                                                   //��ƮƮ������ ������Ʈ�� �ִٸ�
                _doorbuttonstrans[i] = _doorbuttons[i].GetComponent<RectTransform>(); //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            if (_doorbuttons[i].GetComponent<Image>() == null)//�̹��� ������Ʈ�� ���ٸ�
            {
                _doorbuttons[i].AddComponent<Image>();       //�̹��� ������Ʈ�� ���� ������
                _doorbuttonsimages[i] = _doorbuttons[i].GetComponent<Image>();//������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            }
            else                                                                //�̹��� ������Ʈ�� ���ٸ�
                _doorbuttonsimages[i] = _doorbuttons[i].GetComponent<Image>();//������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            _doorbuttonsimages[i].sprite = _buttonssprites[14 + i];        //��ư�� ��������Ʈ�� _buttonssprites�� ����� �̹������� ������ ����

            _doorbuttonstrans[i].sizeDelta = new Vector2(100, 100);                  //��ư ������ ����
            _doorbuttonstrans[i].localPosition = new Vector2(120 + i * 100, 870);//��ư ��ġ ����
            _doorbuttonstrans[i].transform.SetParent(UIDOOR.transform);//�� �� �� ���ӿ�����Ʈ�� �θ� UIFLOOR����
                                                                       //(UICAMERAMODE - UIINPLAN - UIDOOR - _doorbuttonstrans[i]��)
        }
        UIDOOR.SetActive(false); //�ϴ� ��Ȱ��ȭ

        UIWALL = new GameObject();//���ؽ��Ĺ�ư���� ������ ���ӿ�����Ʈ
        UIWALL.transform.SetParent(UIINPLAN.transform);//�� �� �� ���ӿ�����Ʈ�� �θ� UIINPLAN����(UICAMERAMODE - UIINPLAN - UIDOOR��)
        _wallbuttons = new GameObject[4];//���ؽ��Ĺ�ư��
        _wallbuttonstrans = new RectTransform[4];//���ؽ��Ĺ�ư�� ��ġ
        _wallbuttonsimages = new Image[4];//���ؽ��Ĺ�ư�� �̹���
        for (int i = 0; i < 4; i++)//�� 4����
        {
            _wallbuttons[i] = new GameObject();//���ؽ��Ĺ�ư�鿡 ���ӿ�����Ʈ �Ҵ�
            if (_wallbuttons[i].GetComponent<RectTransform>() == null)// ��ƮƮ������ ������Ʈ�� ���ٸ�
            {
                _wallbuttons[i].AddComponent<RectTransform>();//��ƮƮ������ ������Ʈ�� ���� ������
                _wallbuttonstrans[i] = _wallbuttons[i].GetComponent<RectTransform>();//������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            }
            else                                                                  //��ƮƮ������ ������Ʈ�� �ִٸ�
                _wallbuttonstrans[i] = _wallbuttons[i].GetComponent<RectTransform>(); //������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            if (_wallbuttons[i].GetComponent<Image>() == null)//�̹��� ������Ʈ�� ���ٸ�
            {
                _wallbuttons[i].AddComponent<Image>();       //�̹��� ������Ʈ�� ���� ������
                _wallbuttonsimages[i] = _wallbuttons[i].GetComponent<Image>();//������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            }
            else                                                               //�̹��� ������Ʈ�� ���ٸ�
                _wallbuttonsimages[i] = _wallbuttons[i].GetComponent<Image>();//������Ʈ�� ���������� ��ġ�迭�� �����Ѵ�.
            _wallbuttonsimages[i].sprite = _buttonssprites[18 + i];        //��ư�� ��������Ʈ�� _buttonssprites�� ����� �̹������� ������ ����

            _wallbuttonstrans[i].sizeDelta = new Vector2(100, 100);                   //��ư ������ ����
            _wallbuttonstrans[i].localPosition = new Vector2(120 + i * 100, 870);//��ư ��ġ ����
            _wallbuttonstrans[i].transform.SetParent(UIWALL.transform);//�� �� �� ���ӿ�����Ʈ�� �θ� UIFLOOR����
                                                                       //(UICAMERAMODE - UIINPLAN - UIWALL - _wallbuttonstrans[i]��)
        }
        UIWALL.SetActive(false);//�ϴ� ��Ȱ��ȭ

        _cf = CONTROL.GetComponent<CreateFloor>(); //CONTROL�� CreateFloor ������Ʈ ��������
        _cw = CONTROL.GetComponent<CreateWall>(); //CONTROL�� CreateWall ������Ʈ ��������
        _cd = CONTROL.GetComponent<CreateDoor>(); //CONTROL�� CreateDoor ������Ʈ ��������
    }

    private void Start()
    {
        _control.SwitchingTo1();
        UIINPLAN.SetActive(true);
        FURNISLOTS.SetActive(false);
        UIDIR.SetActive(false);
        UITHIRD.SetActive(false);
        UIFIRST.SetActive(false);
        UIPLAN.SetActive(true);

        _opensub = true;
        _opendir = false;

        _openfloor = true;
        _openwall = false;
        _opendoor = false;
        UIFLOOR.SetActive(true);
    }
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) &&
            _buttonstrans[0].position.x - 75 < Input.mousePosition.x && Input.mousePosition.x < _buttonstrans[0].position.x + 75 &&
            _buttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _buttonstrans[0].position.y + 50)
            || Input.GetKeyDown(KeyCode.Alpha1)) //������ ��ư Ŭ���� Ȥ�� Ű����1
        {
            Debug.Log("asdadf");
            _control.SwitchingTo1();
            UIINPLAN.SetActive(true);
            FURNISLOTS.SetActive(false);
            UIDIR.SetActive(false);
            UITHIRD.SetActive(false);
            UIFIRST.SetActive(false);
            UIPLAN.SetActive(true);

            _opensub = true;
            _opendir = false;

            _openwall = false;
            _opendoor = false;
            _openfloor = true;
            UIWALL.SetActive(false);
            UIDOOR.SetActive(false);
            UIFLOOR.SetActive(true);
        }
        if ((Input.GetMouseButtonDown(0) &&
        _buttonstrans[1].position.x - 75 < Input.mousePosition.x && Input.mousePosition.x < _buttonstrans[1].position.x + 75 &&
         _buttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _buttonstrans[0].position.y + 50)
         || Input.GetKeyDown(KeyCode.Alpha2)) //������� ��ư Ŭ���� Ȥ�� Ű����2
        {
            Debug.Log("sasgasf");
            _control.SwitchingTo2();
            UIINPLAN.SetActive(false);
            FURNISLOTS.SetActive(true);
            UIDIR.SetActive(false);
            UITHIRD.SetActive(true);
            UIFIRST.SetActive(false);
            UIPLAN.SetActive(false);
            _control.SwitchingToFloor();
            _opensub = false;
            _opendir = false;
            UIWALL.SetActive(false);
            UIDOOR.SetActive(false);
            UIFLOOR.SetActive(false);
            _openfloor = false;
            _openwall = false;
            _opendoor = false;
        }
        if ((Input.GetMouseButtonDown(0) &&
        _buttonstrans[2].position.x - 75 < Input.mousePosition.x && Input.mousePosition.x < _buttonstrans[2].position.x + 75 &&
        _buttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _buttonstrans[0].position.y + 50)
        || Input.GetKeyDown(KeyCode.Alpha3)) //1��Ī��� ��ư Ŭ���� Ȥ�� Ű����3
        {
            Debug.Log("aasgvasf");
            _control.SwitchingTo3();
            UIINPLAN.SetActive(false);
            FURNISLOTS.SetActive(false);
            UIDIR.SetActive(false);
            UITHIRD.SetActive(false);
            UIFIRST.SetActive(true);
            UIPLAN.SetActive(false);
            _opensub = false;
            _opendir = false;
            UIWALL.SetActive(false);
            UIDOOR.SetActive(false);
            UIFLOOR.SetActive(false);
            _openfloor = false;
            _openwall = false;
            _opendoor = false;
        }
        if (_opensub == true) //������ �����
        {
            if (Input.GetMouseButtonDown(0) && //�ٴ� ��ư ������
                _subbuttonstrans[0].position.x - 75 < Input.mousePosition.x && Input.mousePosition.x < _subbuttonstrans[0].position.x + 75 &&
                _subbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _subbuttonstrans[0].position.y + 50)
            {
                Debug.Log("Floor");
                FURNISLOTS.SetActive(false);
                _control.SwitchingToFloor();
                UIDIR.SetActive(false);
                _opendir = false;
                _openwall = false;
                _opendoor = false;
                _openfloor = true;
                UIWALL.SetActive(false);
                UIDOOR.SetActive(false);
                UIFLOOR.SetActive(true);
            }
            if (Input.GetMouseButtonDown(0) &&  //�� ��ư ������
                _subbuttonstrans[1].position.x - 75 < Input.mousePosition.x && Input.mousePosition.x < _subbuttonstrans[1].position.x + 75 &&
                _subbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _subbuttonstrans[0].position.y + 50)
            {
                Debug.Log("Wall");
                FURNISLOTS.SetActive(false);
                _control.SwitchingToWall();
                UIDIR.SetActive(true);
                _opendir = true;
                _opendoor = false;
                _openfloor = false;
                _openwall = true;
                UIDOOR.SetActive(false);
                UIFLOOR.SetActive(false);
                UIWALL.SetActive(true);
            }
            if (Input.GetMouseButtonDown(0) &&  //�� ��ư ������
                _subbuttonstrans[2].position.x - 75 < Input.mousePosition.x && Input.mousePosition.x < _subbuttonstrans[2].position.x + 75 &&
                _subbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _subbuttonstrans[0].position.y + 50)
            {
                Debug.Log("Door");
                FURNISLOTS.SetActive(false);
                _control.SwitchingToDoor();
                UIDIR.SetActive(true);
                _opendir = true;
                _openfloor = false;
                _openwall = false;
                _opendoor = true;
                UIWALL.SetActive(false);
                UIFLOOR.SetActive(false);
                UIDOOR.SetActive(true);
            }
            
            if (_opendir == true) //������ ���� �� ���̳� ����� �����
            {
                if (Input.GetMouseButtonDown(0) && //UP�����ư ���� ��
                    _dirbuttonstrans[0].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[0].position.x + 50 &&
                    _dirbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("UP");
                    _control.SwitchingToUp();
                }
                if (Input.GetMouseButtonDown(0) && //Left�����ư ���� ��
                    _dirbuttonstrans[1].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[1].position.x + 50 &&
                    _dirbuttonstrans[1].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[1].position.y + 50)
                {
                    Debug.Log("Left");
                    _control.SwitchingToLeft();
                }
                if (Input.GetMouseButtonDown(0) && //Down�����ư ���� ��
                    _dirbuttonstrans[2].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[2].position.x + 50 &&
                    _dirbuttonstrans[1].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[1].position.y + 50)
                {
                    Debug.Log("Down");
                    _control.SwitchingToDown(); //Right�����ư ���� ��
                }
                if (Input.GetMouseButtonDown(0) &&
                    _dirbuttonstrans[3].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[3].position.x + 50 &&
                    _dirbuttonstrans[1].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[1].position.y + 50)
                {
                    Debug.Log("Right");
                    _control.SwitchingToRight();
                }
            }

            if(_openfloor == true) //������ ���� �� �ٴڸ�� �����
            {
                if (Input.GetMouseButtonDown(0) &&
                    _floorbuttonstrans[0].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _floorbuttonstrans[0].position.x + 50 &&
                    _floorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _floorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("�ٴ�1");
                    _cf.setFloorPrefab1();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _floorbuttonstrans[1].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _floorbuttonstrans[1].position.x + 50 &&
                    _floorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _floorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("�ٴ�2");
                    _cf.setFloorPrefab2();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _floorbuttonstrans[2].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _floorbuttonstrans[2].position.x + 50 &&
                    _floorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _floorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("�ٴ�3");
                    _cf.setFloorPrefab3();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _floorbuttonstrans[3].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[3].position.x + 50 &&
                    _floorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("�ٴ�4");
                    _cf.setFloorPrefab4();
                }
            }
            if (_openwall == true) //������ ���� �� ����� �����
            {
                if (Input.GetMouseButtonDown(0) &&
                    _wallbuttonstrans[0].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _wallbuttonstrans[0].position.x + 50 &&
                    _wallbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _wallbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("��1");
                    _cw.setWallPrefab1();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _wallbuttonstrans[1].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _wallbuttonstrans[1].position.x + 50 &&
                    _wallbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _wallbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("��2");
                    _cw.setWallPrefab2();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _wallbuttonstrans[2].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _wallbuttonstrans[2].position.x + 50 &&
                    _floorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _floorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("��3");
                    _cw.setWallPrefab3();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _wallbuttonstrans[3].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _wallbuttonstrans[3].position.x + 50 &&
                    _floorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("��4");
                    _cw.setWallPrefab4();
                }
            }
            if (_opendoor == true) //������ ���� �� ����� �����
            {
                if (Input.GetMouseButtonDown(0) &&
                    _doorbuttonstrans[0].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _doorbuttonstrans[0].position.x + 50 &&
                    _doorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _doorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("��1");
                    _cd.setDoorPrefab1();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _doorbuttonstrans[1].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _doorbuttonstrans[1].position.x + 50 &&
                    _doorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _doorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("��2");
                    _cd.setDoorPrefab2();
                }
            }

        }
    }
}
