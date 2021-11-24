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

    GameObject UIFURNI;
    RectTransform UIFURNITRAN;
    Image UIFURNIIMAGE;
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

    void Awake()
    {
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


        UIFURNI = new GameObject();
        if (UIFURNI.GetComponent<RectTransform>() == null)
        {
            UIFURNI.AddComponent<RectTransform>();
            UIFURNITRAN = UIFURNI.GetComponent<RectTransform>();
        }
        else
            UIFURNITRAN = UIFURNI.GetComponent<RectTransform>();
        UIFURNI.transform.SetParent(this.transform);
        UIFURNITRAN.localPosition = new Vector2(0, 0);

        _subbuttons = new GameObject[4];
        _subbuttonstrans = new RectTransform[4];
        _subbuttonsimages = new Image[4];
        for (int i = 0; i < 4; i++)
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
            _subbuttonstrans[i].localPosition = new Vector2(120 + i * 160, 980);
            _subbuttons[i].transform.SetParent(UIFURNI.transform);
        }
        UIFURNI.SetActive(false);

        _subbuttons = new GameObject[4];
        _subbuttonstrans = new RectTransform[4];
        _subbuttonsimages = new Image[4];
        for (int i = 0; i < 4; i++)
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
            _subbuttonstrans[i].localPosition = new Vector2(120 + i * 160, 980);
            _subbuttons[i].transform.SetParent(UIFURNI.transform);
        }


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
        _dirbuttonstrans[0].localPosition = new Vector2(200, 860);
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
                _dirbuttonstrans[i].localPosition = new Vector2(i * 100, 760);
                _dirbuttons[i].transform.SetParent(UIDIR.transform);
        }
        UIDIR.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) &&
            _buttonstrans[0].position.x - 75 < Input.mousePosition.x && Input.mousePosition.x < _buttonstrans[0].position.x + 75 &&
            _buttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _buttonstrans[0].position.y + 50)
        {
            Debug.Log("asdadf");
            _opensub = false;
            _opendir = false;
            _control.SwitchingTo1();
            UIFURNI.SetActive(false);
            FURNISLOTS.SetActive(false);
            UIDIR.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0) &&
        _buttonstrans[1].position.x - 75 < Input.mousePosition.x && Input.mousePosition.x < _buttonstrans[1].position.x + 75 &&
         _buttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _buttonstrans[0].position.y + 50)
        {
            Debug.Log("sasgasf");
            _opensub = true;
            _opendir = false;
            _control.SwitchingTo2();
            UIFURNI.SetActive(true);
            FURNISLOTS.SetActive(false);
            UIDIR.SetActive(false);
            _control.SwitchingToFloor();
        }
        if (Input.GetMouseButtonDown(0) &&
        _buttonstrans[2].position.x - 75 < Input.mousePosition.x && Input.mousePosition.x < _buttonstrans[2].position.x + 75 &&
        _buttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _buttonstrans[0].position.y + 50)
        {
            Debug.Log("aasgvasf");
            _opensub = false;
            _opendir = false;
            _control.SwitchingTo3();
            UIFURNI.SetActive(false);
            FURNISLOTS.SetActive(false);
            UIDIR.SetActive(false);
        }
        if (_opensub == true)
        {
            if (Input.GetMouseButtonDown(0) &&
                _subbuttonstrans[0].position.x - 75 < Input.mousePosition.x && Input.mousePosition.x < _subbuttonstrans[0].position.x + 75 &&
                _subbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _subbuttonstrans[0].position.y + 50)
            {
                Debug.Log("sasgasf");
                FURNISLOTS.SetActive(false);
                _control.SwitchingToFloor();
                UIDIR.SetActive(false);
                _opendir = false;
            }
            if (Input.GetMouseButtonDown(0) &&
                _subbuttonstrans[1].position.x - 75 < Input.mousePosition.x && Input.mousePosition.x < _subbuttonstrans[1].position.x + 75 &&
                _subbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _subbuttonstrans[0].position.y + 50)
            {
                Debug.Log("sasgasf");
                FURNISLOTS.SetActive(false);
                _control.SwitchingToWall();
                UIDIR.SetActive(true);
                _opendir = true;
            }
            if (Input.GetMouseButtonDown(0) &&
                _subbuttonstrans[2].position.x - 75 < Input.mousePosition.x && Input.mousePosition.x < _subbuttonstrans[2].position.x + 75 &&
                _subbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _subbuttonstrans[0].position.y + 50)
            {
                Debug.Log("sasgasf");
                FURNISLOTS.SetActive(false);
                _control.SwitchingToDoor();
                UIDIR.SetActive(true);
                _opendir = true;
            }
            if (Input.GetMouseButtonDown(0) &&
                _subbuttonstrans[3].position.x - 75 < Input.mousePosition.x && Input.mousePosition.x < _subbuttonstrans[3].position.x + 75 &&
                _subbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _subbuttonstrans[0].position.y + 50)
            {
                Debug.Log("sasgasf");
                FURNISLOTS.SetActive(true);
                UIDIR.SetActive(false);
                _opendir = false;
            }
            
            if (_opendir == true)
            {
                if (Input.GetMouseButtonDown(0) &&
                    _dirbuttonstrans[0].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[0].position.x + 50 &&
                    _dirbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[0].position.y + 50)
                {
                    _control.SwitchingToUp();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _dirbuttonstrans[1].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[1].position.x + 50 &&
                    _dirbuttonstrans[1].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[1].position.y + 50)
                {
                    _control.SwitchingToLeft();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _dirbuttonstrans[2].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[2].position.x + 50 &&
                    _dirbuttonstrans[1].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[1].position.y + 50)
                {
                    _control.SwitchingToDown();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _dirbuttonstrans[3].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[3].position.x + 50 &&
                    _dirbuttonstrans[1].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[1].position.y + 50)
                {
                    _control.SwitchingToRight();
                }
            }
        }
    }
}
