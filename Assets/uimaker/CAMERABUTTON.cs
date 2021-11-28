using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CAMERABUTTON : MonoBehaviour
{
    [SerializeField]
    public GameObject CONTROL; //컨트롤 게임오브젝트
    control _control; //CONTROL에서 뽑아내는 control 스크립트
    CreateFloor _cf;  //CONTROL에서 뽑아내는 CreateFloor 스크립트
    CreateWall _cw;   //CONTROL에서 뽑아내는 CreateWall 스크립트
    CreateDoor _cd;   //CONTROL에서 뽑아내는 CreateDoor 스크립트

    [SerializeField]
    public GameObject FURNISLOTS; //가구모드의 인벤토리

    GameObject[] _buttons; //도면 가구 1인칭 버튼들
    RectTransform[] _buttonstrans; //도면 가구 1인칭 버튼들 위치
    Image[] _buttonsimages; //도면 가구 1인칭 버튼들 이미지

    [SerializeField] // 설명서
    GameObject UIPLAN;  //도면모드설명서
    [SerializeField]
    GameObject UITHIRD; //가구모드설명서
    [SerializeField]
    GameObject UIFIRST; //1인칭모드설명서
    //직렬화시키는 오브젝트들

    GameObject UIINPLAN; //도면모드의 버튼들을 모아놓는 게임오브젝트(바닥 벽 문 버튼)
    RectTransform UIINPLANTRAN; //버튼모음의 위치를 바꾸기 위한 변수
    GameObject[] _subbuttons; //바닥 벽 문 버튼들
    RectTransform[] _subbuttonstrans; //버튼들의 UI위치
    Image[] _subbuttonsimages; //버튼들의 UI이미지
    bool _opensub = false; //버튼집합의 활성화여부

    GameObject UIDIR; //벽 문모드시 설치 방향을 바꾸는 버튼들을 모아놓는 게임오브젝트(상하좌우)
    RectTransform UIDIRTRAN; //버튼모음의 위치를 바꾸기 위한 변수
    GameObject[] _dirbuttons; //상하좌우버튼들
    RectTransform[] _dirbuttonstrans; //버튼들의 UI위치
    Image[] _dirbuttonsimages;  //버튼들의 UI이미지
    bool _opendir = false; //버튼집합의 활성화여부

    [SerializeField]
    Sprite[] _buttonssprites; //버튼 스프라이트들

    GameObject UIFLOOR; //바닥
    GameObject[] _floorbuttons; //바닥텍스쳐버튼집합
    RectTransform[] _floorbuttonstrans; //바닥텍스쳐버튼위치
    Image[] _floorbuttonsimages; //바닥텍스쳐버튼이미지
    bool _openfloor; //버튼집합 활성화여부

    GameObject UIWALL; //벽
    GameObject[] _wallbuttons;//벽종류버튼집합
    RectTransform[] _wallbuttonstrans; //벽종류버튼위치집합
    Image[] _wallbuttonsimages; //벽종류버튼이미지
    bool _openwall; //버튼집합 활성화여부

    GameObject UIDOOR; //문
    GameObject[] _doorbuttons; //문종류버튼집합
    RectTransform[] _doorbuttonstrans; //문종류버튼위치
    Image[] _doorbuttonsimages;//문종류버튼이미지
    bool _opendoor; //버튼집합 활성화여부

    void Awake()
    {
        Screen.SetResolution(1920, 1080, false); //해상도 설정

        _buttons = new GameObject[3]; //도면, 가구, 1인칭 버튼 오브젝트들 (오른쪽 위의 버튼)
        _buttonstrans = new RectTransform[3]; //렉트트랜스폼 설정
        _buttonsimages = new Image[3]; //이미지 설정
        for (int i=0; i<3; i++)//도면, 가구, 1인칭 합쳐 총 3개
        { 
            _buttons[i] = new GameObject(); //버튼 배열 하나당 게임오브젝트 할당
            if (_buttons[i].GetComponent<RectTransform>() == null)            //렉트트랜스폼 컴포넌트가 없다면
            {
                _buttons[i].AddComponent<RectTransform>();                    //렉트트랜스폼 컴포넌트를 새로 생성후
                _buttonstrans[i] = _buttons[i].GetComponent<RectTransform>(); //컴포넌트의 참조정보를 위치배열에 저장한다.
            }
            else                                                              //렉트트랜스폼 컴포넌트가 있다면
                _buttonstrans[i] = _buttons[i].GetComponent<RectTransform>(); //컴포넌트의 참조정보를 위치배열에 저장한다.
            _buttons[i].transform.SetParent(this.transform); //그 후 이 게임오브젝트의 부모를 UICAMERAMODE로

            if (_buttons[i].GetComponent<Image>() == null) //이미지 컴포넌트가 없다면
            {
                _buttons[i].AddComponent<Image>();                          //이미지 컴포넌트를 새로 생성후
                _buttonsimages[i] = _buttons[i].GetComponent<Image>();      //컴포넌트의 참조정보를 위치배열에 저장한다.
            }
            else                                                            //이미지 컴포넌트가 있다면
                _buttonsimages[i] = _buttons[i].GetComponent<Image>();      //컴포넌트의 참조정보를 위치배열에 저장한다.
            _buttonsimages[i].sprite = _buttonssprites[i]; //버튼의 스프라이트를 _buttonssprites에 저장된 이미지에서 가져와 적용

            _buttonstrans[i].sizeDelta = new Vector2(150, 100);             //버튼 사이즈 설정
            _buttonstrans[i].localPosition = new Vector2(500 + i*160, 450); //버튼 위치 설정
        }
        _control = CONTROL.GetComponent<control>(); //컨트롤 컴포넌트 참조정보 저장

        UIINPLAN = new GameObject();//도면 모드시의 바닥 벽 문 버튼의 부모 
        if (UIINPLAN.GetComponent<RectTransform>() == null)               //렉트트랜스폼 컴포넌트가 없다면
        {
            UIINPLAN.AddComponent<RectTransform>();                       //렉트트랜스폼 컴포넌트를 새로 생성후
            UIINPLANTRAN = UIINPLAN.GetComponent<RectTransform>();        //컴포넌트의 참조정보를 위치배열에 저장한다.
        }
        else                                                              //렉트트랜스폼 컴포넌트가 있다면
            UIINPLANTRAN = UIINPLAN.GetComponent<RectTransform>();        //컴포넌트의 참조정보를 위치배열에 저장한다.
        UIINPLAN.transform.SetParent(this.transform);                     //그 후 이 게임오브젝트의 부모를 UICAMERAMODE로
        UIINPLANTRAN.localPosition = new Vector2(0, 0);                   //위치 조정

        _subbuttons = new GameObject[3];        //도면 모드 시 바닥, 벽, 문 버튼 오브젝트들(왼쪽 위의 버튼, 도면모드시에만 나타남)
        _subbuttonstrans = new RectTransform[3]; //렉트트랜스폼 설정
        _subbuttonsimages = new Image[3]; //이미지 설정
        for (int i = 0; i < 3; i++) //바닥, 벽, 문버튼 합쳐 총 3개
        {
            _subbuttons[i] = new GameObject();                                      //버튼 배열 하나당 게임오브젝트 할당
            if (_subbuttons[i].GetComponent<RectTransform>() == null)               //렉트트랜스폼 컴포넌트가 없다면
            {
                _subbuttons[i].AddComponent<RectTransform>();                       //렉트트랜스폼 컴포넌트를 새로 생성후
                _subbuttonstrans[i] = _subbuttons[i].GetComponent<RectTransform>(); //컴포넌트의 참조정보를 위치배열에 저장한다.
            }
            else                                                                    //렉트트랜스폼 컴포넌트가 있다면
                _subbuttonstrans[i] = _subbuttons[i].GetComponent<RectTransform>(); //컴포넌트의 참조정보를 위치배열에 저장한다.
            if (_subbuttons[i].GetComponent<Image>() == null)                       //이미지 컴포넌트가 없다면
            {
                _subbuttons[i].AddComponent<Image>();                               //이미지 컴포넌트를 새로 생성후
                _subbuttonsimages[i] = _subbuttons[i].GetComponent<Image>();        //컴포넌트의 참조정보를 위치배열에 저장한다.
            }
            else                                                                    //이미지 컴포넌트가 있다면
                _subbuttonsimages[i] = _subbuttons[i].GetComponent<Image>();        //컴포넌트의 참조정보를 위치배열에 저장한다.
            _subbuttonsimages[i].sprite = _buttonssprites[3+i]; //버튼의 스프라이트를 _buttonssprites에 저장된 이미지에서 가져와 적용

            _subbuttonstrans[i].sizeDelta = new Vector2(150, 100);                  //버튼 사이즈 설정
            _subbuttonstrans[i].localPosition = new Vector2(140 + i * 160, 980);    //버튼 위치 설정
            _subbuttons[i].transform.SetParent(UIINPLAN.transform); //그 후 이 게임오브젝트의 부모를 UIINPLAN으로(UICAMERAMODE - UIINPLAN - _subbuttons[i]순)
        }
        UIINPLAN.SetActive(false); //일단 도면모드 비활성화

        UIDIR = new GameObject();        //벽, 문 모드 시 상하좌우 버튼들의 부모
        if (UIDIR.GetComponent<RectTransform>() == null)               //렉트트랜스폼 컴포넌트가 없다면
        {
            UIDIR.AddComponent<RectTransform>();                       //렉트트랜스폼 컴포넌트를 새로 생성후
            UIDIRTRAN = UIDIR.GetComponent<RectTransform>();           //컴포넌트의 참조정보를 위치배열에 저장한다.
        }
        else                                                           //렉트트랜스폼 컴포넌트가 있다면
            UIDIRTRAN = UIDIR.GetComponent<RectTransform>();           //컴포넌트의 참조정보를 위치배열에 저장한다.
        UIDIR.transform.SetParent(this.transform);                     //그 후 이 게임오브젝트의 부모를 UICAMERAMODE로
        UIDIRTRAN.localPosition = new Vector2(0, 0);                   //버튼 위치 설정

        _dirbuttons = new GameObject[4];                                //방향버튼(상하좌우) [0]상 [1]좌 [2]하 [3]우
        _dirbuttonstrans = new RectTransform[4];                        //방향버튼(상하좌우)의 위치
        _dirbuttonsimages = new Image[4];                               //방향버튼(상하좌우)의 이미지
        _dirbuttons[0] = new GameObject();//방향버튼 [0]상에 게임오브젝트 할당
        if (_dirbuttons[0].GetComponent<RectTransform>() == null)               //렉트트랜스폼 컴포넌트가 없다면
        {
            _dirbuttons[0].AddComponent<RectTransform>();                       //렉트트랜스폼 컴포넌트를 새로 생성후
            _dirbuttonstrans[0] = _dirbuttons[0].GetComponent<RectTransform>(); //컴포넌트의 참조정보를 위치배열에 저장한다.
        }
        else                                                                    //렉트트랜스폼 컴포넌트가 있다면
            _dirbuttonstrans[0] = _dirbuttons[0].GetComponent<RectTransform>(); //컴포넌트의 참조정보를 위치배열에 저장한다.
        if (_dirbuttons[0].GetComponent<Image>() == null)                       //이미지 컴포넌트가 없다면
        {
            _dirbuttons[0].AddComponent<Image>();                               //이미지 컴포넌트를 새로 생성후
            _dirbuttonsimages[0] = _dirbuttons[0].GetComponent<Image>();        //컴포넌트의 참조정보를 위치배열에 저장한다.
        }
        else                                                                    //이미지 컴포넌트가 있다면
            _dirbuttonsimages[0] = _dirbuttons[0].GetComponent<Image>();        //컴포넌트의 참조정보를 위치배열에 저장한다.
        _dirbuttonsimages[0].sprite = _buttonssprites[6]; //버튼의 스프라이트를 _buttonssprites에 저장된 이미지에서 가져와 적용

        _dirbuttonstrans[0].sizeDelta = new Vector2(100, 100);                  //버튼 사이즈 설정
        _dirbuttonstrans[0].localPosition = new Vector2(220, 750);              //버튼 위치 설정
        _dirbuttons[0].transform.SetParent(UIDIR.transform);//그 후 이 게임오브젝트의 부모를 UIDIR으로(UICAMERAMODE - UIDIR - _dirbuttons[i]순)
        for (int i = 1; i < 4; i++)//방향버튼 [1]좌 [2]하 [3]우 
        {
            _dirbuttons[i] = new GameObject();//방향버튼 [i]상에 게임오브젝트 할당
            if (_dirbuttons[i].GetComponent<RectTransform>() == null)// 렉트트랜스폼 컴포넌트가 없다면
            {
                _dirbuttons[i].AddComponent<RectTransform>();                       //렉트트랜스폼 컴포넌트를 새로 생성후
                _dirbuttonstrans[i] = _dirbuttons[i].GetComponent<RectTransform>(); //컴포넌트의 참조정보를 위치배열에 저장한다.
            }
            else                                                                    //렉트트랜스폼 컴포넌트가 있다면
                _dirbuttonstrans[i] = _dirbuttons[i].GetComponent<RectTransform>(); //컴포넌트의 참조정보를 위치배열에 저장한다.
            if (_dirbuttons[i].GetComponent<Image>() == null)                       //이미지 컴포넌트가 없다면
            {
                _dirbuttons[i].AddComponent<Image>();                               //이미지 컴포넌트를 새로 생성후
                _dirbuttonsimages[i] = _dirbuttons[i].GetComponent<Image>();        //컴포넌트의 참조정보를 위치배열에 저장한다.
            }
            else                                                                    //이미지 컴포넌트가 있다면
                _dirbuttonsimages[i] = _dirbuttons[i].GetComponent<Image>();        //컴포넌트의 참조정보를 위치배열에 저장한다.
            _dirbuttonsimages[i].sprite = _buttonssprites[6+i];//버튼의 스프라이트를 _buttonssprites에 저장된 이미지에서 가져와 적용

            _dirbuttonstrans[i].sizeDelta = new Vector2(100, 100);                  //버튼 사이즈 설정
            _dirbuttonstrans[i].localPosition = new Vector2(20 + i * 100, 650);     //버튼 위치 설정
            _dirbuttons[i].transform.SetParent(UIDIR.transform);//그 후 이 게임오브젝트의 부모를 UIDIR으로(UICAMERAMODE - UIDIR - _dirbuttons[i]순)
        }
        UIDIR.SetActive(false);//일단 방향모드 비활성화

        UIFLOOR = new GameObject();             //바닥텍스쳐버튼들을 모으는 게임오브젝트
        UIFLOOR.transform.SetParent(UIINPLAN.transform);//그 후 이 게임오브젝트의 부모를 UIINPLAN으로(UICAMERAMODE - UIINPLAN - UIFLOOR순)
        _floorbuttons = new GameObject[4];          //바닥텍스쳐버튼들
        _floorbuttonstrans = new RectTransform[4];  //바닥텍스쳐버튼들 위치
        _floorbuttonsimages = new Image[4];         //바닥텍스쳐버튼들 이미지
        for (int i = 0; i < 4; i++) //바닥 4종류
        {
            _floorbuttons[i] = new GameObject();    //바닥텍스쳐버튼들에 게임오브젝트 할당
            if (_floorbuttons[i].GetComponent<RectTransform>() == null)// 렉트트랜스폼 컴포넌트가 없다면
            {
                _floorbuttons[i].AddComponent<RectTransform>();//렉트트랜스폼 컴포넌트를 새로 생성후
                _floorbuttonstrans[i] = _floorbuttons[i].GetComponent<RectTransform>();//컴포넌트의 참조정보를 위치배열에 저장한다.
            }
            else                                                                    //렉트트랜스폼 컴포넌트가 있다면
                _floorbuttonstrans[i] = _floorbuttons[i].GetComponent<RectTransform>(); //컴포넌트의 참조정보를 위치배열에 저장한다.
            if (_floorbuttons[i].GetComponent<Image>() == null)//이미지 컴포넌트가 없다면
            {
                _floorbuttons[i].AddComponent<Image>();        //이미지 컴포넌트를 새로 생성후
                _floorbuttonsimages[i] = _floorbuttons[i].GetComponent<Image>();//컴포넌트의 참조정보를 위치배열에 저장한다.
            }
            else//이미지 컴포넌트가 있다면
                _floorbuttonsimages[i] = _floorbuttons[i].GetComponent<Image>();//컴포넌트의 참조정보를 위치배열에 저장한다.
            _floorbuttonsimages[i].sprite = _buttonssprites[10 + i];        //버튼의 스프라이트를 _buttonssprites에 저장된 이미지에서 가져와 적용

            _floorbuttonstrans[i].sizeDelta = new Vector2(100, 100);                  //버튼 사이즈 설정
            _floorbuttonstrans[i].localPosition = new Vector2(120 + i * 100, 870);     //버튼 위치 설정
            _floorbuttonstrans[i].transform.SetParent(UIFLOOR.transform);//그 후 이 게임오브젝트의 부모를 UIFLOOR으로
                                                                         //(UICAMERAMODE - UIINPLAN - UIFLOOR - _floorbuttonstrans[i]순)
        }
        UIFLOOR.SetActive(false); //일단 비활성화

        UIDOOR = new GameObject();//문텍스쳐버튼들을 모으는 게임오브젝트
        UIDOOR.transform.SetParent(UIINPLAN.transform);//그 후 이 게임오브젝트의 부모를 UIINPLAN으로(UICAMERAMODE - UIINPLAN - UIDOOR순)
        _doorbuttons = new GameObject[4];//문텍스쳐버튼들
        _doorbuttonstrans = new RectTransform[4];//문텍스쳐버튼들 위치
        _doorbuttonsimages = new Image[4];//문텍스쳐버튼들 이미지
        for (int i = 0; i < 2; i++) //문 2종류
        {
            _doorbuttons[i] = new GameObject();    //문텍스쳐버튼들에 게임오브젝트 할당
            if (_doorbuttons[i].GetComponent<RectTransform>() == null)// 렉트트랜스폼 컴포넌트가 없다면
            {
                _doorbuttons[i].AddComponent<RectTransform>();//렉트트랜스폼 컴포넌트를 새로 생성후
                _doorbuttonstrans[i] = _doorbuttons[i].GetComponent<RectTransform>();//컴포넌트의 참조정보를 위치배열에 저장한다.
            }
            else                                                                   //렉트트랜스폼 컴포넌트가 있다면
                _doorbuttonstrans[i] = _doorbuttons[i].GetComponent<RectTransform>(); //컴포넌트의 참조정보를 위치배열에 저장한다.
            if (_doorbuttons[i].GetComponent<Image>() == null)//이미지 컴포넌트가 없다면
            {
                _doorbuttons[i].AddComponent<Image>();       //이미지 컴포넌트를 새로 생성후
                _doorbuttonsimages[i] = _doorbuttons[i].GetComponent<Image>();//컴포넌트의 참조정보를 위치배열에 저장한다.
            }
            else                                                                //이미지 컴포넌트가 없다면
                _doorbuttonsimages[i] = _doorbuttons[i].GetComponent<Image>();//컴포넌트의 참조정보를 위치배열에 저장한다.
            _doorbuttonsimages[i].sprite = _buttonssprites[14 + i];        //버튼의 스프라이트를 _buttonssprites에 저장된 이미지에서 가져와 적용

            _doorbuttonstrans[i].sizeDelta = new Vector2(100, 100);                  //버튼 사이즈 설정
            _doorbuttonstrans[i].localPosition = new Vector2(120 + i * 100, 870);//버튼 위치 설정
            _doorbuttonstrans[i].transform.SetParent(UIDOOR.transform);//그 후 이 게임오브젝트의 부모를 UIFLOOR으로
                                                                       //(UICAMERAMODE - UIINPLAN - UIDOOR - _doorbuttonstrans[i]순)
        }
        UIDOOR.SetActive(false); //일단 비활성화

        UIWALL = new GameObject();//벽텍스쳐버튼들을 모으는 게임오브젝트
        UIWALL.transform.SetParent(UIINPLAN.transform);//그 후 이 게임오브젝트의 부모를 UIINPLAN으로(UICAMERAMODE - UIINPLAN - UIDOOR순)
        _wallbuttons = new GameObject[4];//벽텍스쳐버튼들
        _wallbuttonstrans = new RectTransform[4];//벽텍스쳐버튼들 위치
        _wallbuttonsimages = new Image[4];//벽텍스쳐버튼들 이미지
        for (int i = 0; i < 4; i++)//벽 4종류
        {
            _wallbuttons[i] = new GameObject();//벽텍스쳐버튼들에 게임오브젝트 할당
            if (_wallbuttons[i].GetComponent<RectTransform>() == null)// 렉트트랜스폼 컴포넌트가 없다면
            {
                _wallbuttons[i].AddComponent<RectTransform>();//렉트트랜스폼 컴포넌트를 새로 생성후
                _wallbuttonstrans[i] = _wallbuttons[i].GetComponent<RectTransform>();//컴포넌트의 참조정보를 위치배열에 저장한다.
            }
            else                                                                  //렉트트랜스폼 컴포넌트가 있다면
                _wallbuttonstrans[i] = _wallbuttons[i].GetComponent<RectTransform>(); //컴포넌트의 참조정보를 위치배열에 저장한다.
            if (_wallbuttons[i].GetComponent<Image>() == null)//이미지 컴포넌트가 없다면
            {
                _wallbuttons[i].AddComponent<Image>();       //이미지 컴포넌트를 새로 생성후
                _wallbuttonsimages[i] = _wallbuttons[i].GetComponent<Image>();//컴포넌트의 참조정보를 위치배열에 저장한다.
            }
            else                                                               //이미지 컴포넌트가 없다면
                _wallbuttonsimages[i] = _wallbuttons[i].GetComponent<Image>();//컴포넌트의 참조정보를 위치배열에 저장한다.
            _wallbuttonsimages[i].sprite = _buttonssprites[18 + i];        //버튼의 스프라이트를 _buttonssprites에 저장된 이미지에서 가져와 적용

            _wallbuttonstrans[i].sizeDelta = new Vector2(100, 100);                   //버튼 사이즈 설정
            _wallbuttonstrans[i].localPosition = new Vector2(120 + i * 100, 870);//버튼 위치 설정
            _wallbuttonstrans[i].transform.SetParent(UIWALL.transform);//그 후 이 게임오브젝트의 부모를 UIFLOOR으로
                                                                       //(UICAMERAMODE - UIINPLAN - UIWALL - _wallbuttonstrans[i]순)
        }
        UIWALL.SetActive(false);//일단 비활성화

        _cf = CONTROL.GetComponent<CreateFloor>(); //CONTROL의 CreateFloor 컴포넌트 가져오기
        _cw = CONTROL.GetComponent<CreateWall>(); //CONTROL의 CreateWall 컴포넌트 가져오기
        _cd = CONTROL.GetComponent<CreateDoor>(); //CONTROL의 CreateDoor 컴포넌트 가져오기
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
            || Input.GetKeyDown(KeyCode.Alpha1)) //도면모드 버튼 클릭시 혹은 키보드1
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
         || Input.GetKeyDown(KeyCode.Alpha2)) //가구모드 버튼 클릭시 혹은 키보드2
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
        || Input.GetKeyDown(KeyCode.Alpha3)) //1인칭모드 버튼 클릭시 혹은 키보드3
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
        if (_opensub == true) //도면모드 실행시
        {
            if (Input.GetMouseButtonDown(0) && //바닥 버튼 누를시
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
            if (Input.GetMouseButtonDown(0) &&  //벽 버튼 누를시
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
            if (Input.GetMouseButtonDown(0) &&  //문 버튼 누를시
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
            
            if (_opendir == true) //도면모드 실행 후 벽이나 문모드 실행시
            {
                if (Input.GetMouseButtonDown(0) && //UP방향버튼 누를 시
                    _dirbuttonstrans[0].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[0].position.x + 50 &&
                    _dirbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("UP");
                    _control.SwitchingToUp();
                }
                if (Input.GetMouseButtonDown(0) && //Left방향버튼 누를 시
                    _dirbuttonstrans[1].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[1].position.x + 50 &&
                    _dirbuttonstrans[1].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[1].position.y + 50)
                {
                    Debug.Log("Left");
                    _control.SwitchingToLeft();
                }
                if (Input.GetMouseButtonDown(0) && //Down방향버튼 누를 시
                    _dirbuttonstrans[2].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[2].position.x + 50 &&
                    _dirbuttonstrans[1].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[1].position.y + 50)
                {
                    Debug.Log("Down");
                    _control.SwitchingToDown(); //Right방향버튼 누를 시
                }
                if (Input.GetMouseButtonDown(0) &&
                    _dirbuttonstrans[3].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[3].position.x + 50 &&
                    _dirbuttonstrans[1].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[1].position.y + 50)
                {
                    Debug.Log("Right");
                    _control.SwitchingToRight();
                }
            }

            if(_openfloor == true) //도면모드 실행 후 바닥모드 실행시
            {
                if (Input.GetMouseButtonDown(0) &&
                    _floorbuttonstrans[0].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _floorbuttonstrans[0].position.x + 50 &&
                    _floorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _floorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("바닥1");
                    _cf.setFloorPrefab1();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _floorbuttonstrans[1].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _floorbuttonstrans[1].position.x + 50 &&
                    _floorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _floorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("바닥2");
                    _cf.setFloorPrefab2();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _floorbuttonstrans[2].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _floorbuttonstrans[2].position.x + 50 &&
                    _floorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _floorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("바닥3");
                    _cf.setFloorPrefab3();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _floorbuttonstrans[3].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _dirbuttonstrans[3].position.x + 50 &&
                    _floorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("바닥4");
                    _cf.setFloorPrefab4();
                }
            }
            if (_openwall == true) //도면모드 실행 후 벽모드 실행시
            {
                if (Input.GetMouseButtonDown(0) &&
                    _wallbuttonstrans[0].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _wallbuttonstrans[0].position.x + 50 &&
                    _wallbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _wallbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("벽1");
                    _cw.setWallPrefab1();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _wallbuttonstrans[1].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _wallbuttonstrans[1].position.x + 50 &&
                    _wallbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _wallbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("벽2");
                    _cw.setWallPrefab2();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _wallbuttonstrans[2].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _wallbuttonstrans[2].position.x + 50 &&
                    _floorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _floorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("벽3");
                    _cw.setWallPrefab3();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _wallbuttonstrans[3].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _wallbuttonstrans[3].position.x + 50 &&
                    _floorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _dirbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("벽4");
                    _cw.setWallPrefab4();
                }
            }
            if (_opendoor == true) //도면모드 실행 후 문모드 실행시
            {
                if (Input.GetMouseButtonDown(0) &&
                    _doorbuttonstrans[0].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _doorbuttonstrans[0].position.x + 50 &&
                    _doorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _doorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("문1");
                    _cd.setDoorPrefab1();
                }
                if (Input.GetMouseButtonDown(0) &&
                    _doorbuttonstrans[1].position.x - 50 < Input.mousePosition.x && Input.mousePosition.x < _doorbuttonstrans[1].position.x + 50 &&
                    _doorbuttonstrans[0].position.y - 50 < Input.mousePosition.y && Input.mousePosition.y < _doorbuttonstrans[0].position.y + 50)
                {
                    Debug.Log("문2");
                    _cd.setDoorPrefab2();
                }
            }

        }
    }
}
