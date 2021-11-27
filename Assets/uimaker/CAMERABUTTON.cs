using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CAMERABUTTON : MonoBehaviour
{
    [SerializeField]
    public GameObject CONTROL;
    control _control;

    [SerializeField]
    public GameObject FURNISLOTS;
    UIFurnituresComp _UIFurnituresComp;

    GameObject[] _buttons; //도면 가구 1
    RectTransform[] _buttonstrans;
    Image[] _buttonsimages;

    [SerializeField]
    GameObject UITHIRD;
    GameObject UIINPLAN;
    RectTransform UIINPLANTRAN;
    Image UIINPLANIMAGE;
    GameObject[] _subbuttons; //바닥 벽 문
    RectTransform[] _subbuttonstrans;
    Image[] _subbuttonsimages;
    bool _opensub = false;

    GameObject UIDIR;
    RectTransform UIDIRTRAN;
    Image UIDIRIMAGE;
    GameObject[] _dirbuttons; //상하좌우
    RectTransform[] _dirbuttonstrans;
    Image[] _dirbuttonsimages;
    bool _opendir = false;

    [SerializeField]
    Sprite _buttonssprite;

    GameObject UIFLOOR; //바닥
    GameObject[] _floorbuttons;
    RectTransform[] _floorbuttonstrans;
    Image[] _floorbuttonsimages;

    GameObject UIDOOR; //문
    GameObject[] _doorbuttons;
    RectTransform[] _doorbuttonstrans;
    Image[] _doorbuttonsimages;

    GameObject UIWALL; //벽
    GameObject[] _wallbuttons;
    RectTransform[] _wallbuttonstrans;
    Image[] _wallbuttonsimages;

    bool _openfloor;
    bool _openwall;
    bool _opendoor;

    void Awake()
    {
        Screen.SetResolution(1920, 1080, false); 
        _buttons = new GameObject[3];
        _buttonstrans = new RectTransform[3];
        _buttonsimages = new Image[3];
        for (int i=0; i<3; i++){
            _buttons[i] = new GameObject();
            if (_buttons[i].GetComponent<RectTransform>() == null)
            {
                _buttons[i].AddComponent<RectTransform>();
                _buttonstrans[i] = _buttons[i].GetComponent<RectTransform>();
            }
            else
                _buttonstrans[i] = _buttons[i].GetComponent<RectTransform>();
            _buttons[i].transform.SetParent(this.transform);
            if (_buttons[i].GetComponent<Image>() == null)
            {
                _buttons[i].AddComponent<Image>();
                _buttonsimages[i] = _buttons[i].GetComponent<Image>();
            }
            else
                _buttonsimages[i] = _buttons[i].GetComponent<Image>();
            _buttonsimages[i].sprite = _buttonssprite;

            _buttonstrans[i].sizeDelta = new Vector2(150, 100);
            _buttonstrans[i].localPosition = new Vector2(500 + i*160, 450);
        }
        _control = CONTROL.GetComponent<control>();
        _UIFurnituresComp = CONTROL.GetComponent<UIFurnituresComp>();

        UIINPLAN = new GameObject();
        if (UIINPLAN.GetComponent<RectTransform>() == null)
        {
            UIINPLAN.AddComponent<RectTransform>();
            UIINPLANTRAN = UIINPLAN.GetComponent<RectTransform>();
        }
        else
            UIINPLANTRAN = UIINPLAN.GetComponent<RectTransform>();
        UIINPLAN.transform.SetParent(this.transform);
        UIINPLANTRAN.localPosition = new Vector2(0, 0);

        _subbuttons = new GameObject[3];
        _subbuttonstrans = new RectTransform[3];
        _subbuttonsimages = new Image[3];
        for (int i = 0; i < 3; i++)
        {
            _subbuttons[i] = new GameObject();
            if (_subbuttons[i].GetComponent<RectTransform>() == null)
            {
                _subbuttons[i].AddComponent<RectTransform>();
                _subbuttonstrans[i] = _subbuttons[i].GetComponent<RectTransform>();
            }
            else
                _subbuttonstrans[i] = _subbuttons[i].GetComponent<RectTransform>();
            if (_subbuttons[i].GetComponent<Image>() == null)
            {
                _subbuttons[i].AddComponent<Image>();
                _subbuttonsimages[i] = _subbuttons[i].GetComponent<Image>();
            }
            else
                _subbuttonsimages[i] = _subbuttons[i].GetComponent<Image>();
            _subbuttonsimages[i].sprite = _buttonssprite;

            _subbuttonstrans[i].sizeDelta = new Vector2(150, 100);
            _subbuttonstrans[i].localPosition = new Vector2(140 + i * 160, 980);
            _subbuttons[i].transform.SetParent(UIINPLAN.transform);
        }
        UIINPLAN.SetActive(false);

        UIDIR = new GameObject();
        if (UIDIR.GetComponent<RectTransform>() == null)
        {
            UIDIR.AddComponent<RectTransform>();
            UIDIRTRAN = UIDIR.GetComponent<RectTransform>();
        }
        else
            UIDIRTRAN = UIDIR.GetComponent<RectTransform>();
        UIDIR.transform.SetParent(this.transform);
        UIDIRTRAN.localPosition = new Vector2(0, 0);

        _dirbuttons = new GameObject[4];
        _dirbuttonstrans = new RectTransform[4];
        _dirbuttonsimages = new Image[4];
        _dirbuttons[0] = new GameObject();
        if (_dirbuttons[0].GetComponent<RectTransform>() == null)
        {
            _dirbuttons[0].AddComponent<RectTransform>();
            _dirbuttonstrans[0] = _dirbuttons[0].GetComponent<RectTransform>();
        }
        else
            _dirbuttonstrans[0] = _dirbuttons[0].GetComponent<RectTransform>();
        if (_dirbuttons[0].GetComponent<Image>() == null)
        {
            _dirbuttons[0].AddComponent<Image>();
            _dirbuttonsimages[0] = _dirbuttons[0].GetComponent<Image>();
        }
        else
            _dirbuttonsimages[0] = _dirbuttons[0].GetComponent<Image>();
        _dirbuttonsimages[0].sprite = _buttonssprite;

        _dirbuttonstrans[0].sizeDelta = new Vector2(100, 100);
        _dirbuttonstrans[0].localPosition = new Vector2(220, 750);
        _dirbuttons[0].transform.SetParent(UIDIR.transform);
        for (int i = 1; i < 4; i++)
        {
            _dirbuttons[i] = new GameObject();
            if (_dirbuttons[i].GetComponent<RectTransform>() == null)
            {
                _dirbuttons[i].AddComponent<RectTransform>();
                _dirbuttonstrans[i] = _dirbuttons[i].GetComponent<RectTransform>();
            }
            else
                _dirbuttonstrans[i] = _dirbuttons[i].GetComponent<RectTransform>();
            if (_dirbuttons[i].GetComponent<Image>() == null)
            {
                _dirbuttons[i].AddComponent<Image>();
                _dirbuttonsimages[i] = _dirbuttons[i].GetComponent<Image>();
            }
            else
                _dirbuttonsimages[i] = _dirbuttons[i].GetComponent<Image>();
                _dirbuttonsimages[i].sprite = _buttonssprite;

                _dirbuttonstrans[i].sizeDelta = new Vector2(100, 100);
                _dirbuttonstrans[i].localPosition = new Vector2(20 + i * 100, 650);
                _dirbuttons[i].transform.SetParent(UIDIR.transform);
        }
        UIDIR.SetActive(false);

        UIFLOOR = new GameObject();
        UIFLOOR.transform.SetParent(UIINPLAN.transform);
        _floorbuttons = new GameObject[4];
        _floorbuttonstrans = new RectTransform[4];
        _floorbuttonsimages = new Image[4];
        for (int i = 0; i < 4; i++)
        {
            _floorbuttons[i] = new GameObject();
            if (_floorbuttons[i].GetComponent<RectTransform>() == null)
            {
                _floorbuttons[i].AddComponent<RectTransform>();
                _floorbuttonstrans[i] = _floorbuttons[i].GetComponent<RectTransform>();
            }
            else
                _floorbuttonstrans[i] = _floorbuttons[i].GetComponent<RectTransform>();
            if (_floorbuttons[i].GetComponent<Image>() == null)
            {
                _floorbuttons[i].AddComponent<Image>();
                _floorbuttonsimages[i] = _floorbuttons[i].GetComponent<Image>();
            }
            else
                _floorbuttonsimages[i] = _floorbuttons[i].GetComponent<Image>();
            _floorbuttonsimages[i].sprite = _buttonssprite;

            _floorbuttonstrans[i].transform.SetParent(UIFLOOR.transform);
            _floorbuttonstrans[i].sizeDelta = new Vector2(100, 100);
            _floorbuttonstrans[i].localPosition = new Vector2(120 + i * 100, 870);
            _floorbuttonstrans[i].transform.SetParent(UIFLOOR.transform);
        }
        UIFLOOR.SetActive(false);

        UIDOOR = new GameObject();
        UIDOOR.transform.SetParent(UIINPLAN.transform);
        _doorbuttons = new GameObject[4];
        _doorbuttonstrans = new RectTransform[4];
        _doorbuttonsimages = new Image[4];
        for (int i = 0; i < 4; i++)
        {
            _doorbuttons[i] = new GameObject();
            if (_doorbuttons[i].GetComponent<RectTransform>() == null)
            {
                _doorbuttons[i].AddComponent<RectTransform>();
                _doorbuttonstrans[i] = _doorbuttons[i].GetComponent<RectTransform>();
            }
            else
                _doorbuttonstrans[i] = _doorbuttons[i].GetComponent<RectTransform>();
            if (_doorbuttons[i].GetComponent<Image>() == null)
            {
                _doorbuttons[i].AddComponent<Image>();
                _doorbuttonsimages[i] = _doorbuttons[i].GetComponent<Image>();
            }
            else
                _doorbuttonsimages[i] = _doorbuttons[i].GetComponent<Image>();
            _doorbuttonsimages[i].sprite = _buttonssprite;

            _doorbuttonstrans[i].transform.SetParent(UIDOOR.transform);
            _doorbuttonstrans[i].sizeDelta = new Vector2(100, 100);
            _doorbuttonstrans[i].localPosition = new Vector2(120 + i * 100, 870);
            _doorbuttonstrans[i].transform.SetParent(UIDOOR.transform);
        }
        UIDOOR.SetActive(false);

        UIWALL = new GameObject();
        UIWALL.transform.SetParent(UIINPLAN.transform);
        _wallbuttons = new GameObject[4];
        _wallbuttonstrans = new RectTransform[4];
        _wallbuttonsimages = new Image[4];
        for (int i = 0; i < 4; i++)
        {
            _wallbuttons[i] = new GameObject();
            if (_wallbuttons[i].GetComponent<RectTransform>() == null)
            {
                _wallbuttons[i].AddComponent<RectTransform>();
                _wallbuttonstrans[i] = _wallbuttons[i].GetComponent<RectTransform>();
            }
            else
                _wallbuttonstrans[i] = _wallbuttons[i].GetComponent<RectTransform>();
            if (_wallbuttons[i].GetComponent<Image>() == null)
            {
                _wallbuttons[i].AddComponent<Image>();
                _wallbuttonsimages[i] = _wallbuttons[i].GetComponent<Image>();
            }
            else
                _wallbuttonsimages[i] = _wallbuttons[i].GetComponent<Image>();
            _wallbuttonsimages[i].sprite = _buttonssprite;

            _wallbuttonstrans[i].transform.SetParent(UIWALL.transform);
            _wallbuttonstrans[i].sizeDelta = new Vector2(100, 100);
            _wallbuttonstrans[i].localPosition = new Vector2(120 + i * 100, 870);
            _wallbuttonstrans[i].transform.SetParent(UIWALL.transform);
        }
        UIWALL.SetActive(false);
    }

    private void Start()
    {
        _control.SwitchingTo1();
        UIINPLAN.SetActive(true);
        FURNISLOTS.SetActive(false);
        UIDIR.SetActive(false);
        UITHIRD.SetActive(false);
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
            || Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("asdadf");
            _control.SwitchingTo1();
            UIINPLAN.SetActive(true);
            FURNISLOTS.SetActive(false);
            UIDIR.SetActive(false);
            UITHIRD.SetActive(false);
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
         || Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("sasgasf");
            _control.SwitchingTo2();
            UIINPLAN.SetActive(false);
            FURNISLOTS.SetActive(true);
            UIDIR.SetActive(false);
            UITHIRD.SetActive(true);
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
        || Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("aasgvasf");
            _control.SwitchingTo3();
            UIINPLAN.SetActive(false);
            FURNISLOTS.SetActive(false);
            UIDIR.SetActive(false);
            UITHIRD.SetActive(false);
            _opensub = false;
            _opendir = false;
            UIWALL.SetActive(false);
            UIDOOR.SetActive(false);
            UIFLOOR.SetActive(false);
            _openfloor = false;
            _openwall = false;
            _opendoor = false;
        }
        if (_opensub == true)
        {
            if (Input.GetMouseButtonDown(0) &&
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
            if (Input.GetMouseButtonDown(0) &&
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
            if (Input.GetMouseButtonDown(0) &&
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
            
            if (_opendir == true)
            {
                if (Input.GetMouseButtonDown(0) &&
                    _dirbuttonstrans[0].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[0].position.x + 50 &&
                    _dirbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("UP");
                    _control.SwitchingToUp();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _dirbuttonstrans[1].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[1].position.x + 50 &&
                    _dirbuttonstrans[1].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[1].position.y + 50)
                {
                    Debug.Log("Left");
                    _control.SwitchingToLeft();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _dirbuttonstrans[2].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[2].position.x + 50 &&
                    _dirbuttonstrans[1].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[1].position.y + 50)
                {
                    Debug.Log("Down");
                    _control.SwitchingToDown();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _dirbuttonstrans[3].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[3].position.x + 50 &&
                    _dirbuttonstrans[1].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[1].position.y + 50)
                {
                    Debug.Log("Right");
                    _control.SwitchingToRight();
                }
            }

            if(_openfloor == true)
            {
                if (Input.GetMouseButtonDown(0) &&
                    _floorbuttonstrans[0].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _floorbuttonstrans[0].position.x + 50 &&
                    _floorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _floorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("바닥1");
                    //함수
                }
                if (Input.GetMouseButtonDown(0) &&
                    _floorbuttonstrans[1].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _floorbuttonstrans[1].position.x + 50 &&
                    _floorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _floorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("바닥2");
                    //함수
                }
                if (Input.GetMouseButtonDown(0) &&
                    _floorbuttonstrans[2].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _floorbuttonstrans[2].position.x + 50 &&
                    _floorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _floorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("바닥3");
                    //함수
                }
                if (Input.GetMouseButtonDown(0) &&
                    _floorbuttonstrans[3].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[3].position.x + 50 &&
                    _floorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("바닥4");
                    //함수
                }
            }
            if (_openwall == true)
            {
                if (Input.GetMouseButtonDown(0) &&
                    _wallbuttonstrans[0].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _wallbuttonstrans[0].position.x + 50 &&
                    _wallbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _wallbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("벽1");
                    //함수
                }
                if (Input.GetMouseButtonDown(0) &&
                    _wallbuttonstrans[1].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _wallbuttonstrans[1].position.x + 50 &&
                    _wallbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _wallbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("벽2");
                    //함수
                }
                if (Input.GetMouseButtonDown(0) &&
                    _wallbuttonstrans[2].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _wallbuttonstrans[2].position.x + 50 &&
                    _floorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _floorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("벽3");
                    //함수
                }
                if (Input.GetMouseButtonDown(0) &&
                    _wallbuttonstrans[3].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _wallbuttonstrans[3].position.x + 50 &&
                    _floorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("벽4");
                    //함수
                }
            }
            if (_opendoor == true)
            {
                if (Input.GetMouseButtonDown(0) &&
                    _doorbuttonstrans[0].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _doorbuttonstrans[0].position.x + 50 &&
                    _doorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _doorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("문1");
                    //함수
                }
                if (Input.GetMouseButtonDown(0) &&
                    _doorbuttonstrans[1].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _doorbuttonstrans[1].position.x + 50 &&
                    _doorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _doorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("문2");
                    //함수
                }
                if (Input.GetMouseButtonDown(0) &&
                    _doorbuttonstrans[2].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _doorbuttonstrans[2].position.x + 50 &&
                    _doorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _doorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("문3");
                    //함수
                }
                if (Input.GetMouseButtonDown(0) &&
                    _doorbuttonstrans[3].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _doorbuttonstrans[3].position.x + 50 &&
                    _doorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _doorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("문4");
                    //함수
                }
            }

        }
    }
}
