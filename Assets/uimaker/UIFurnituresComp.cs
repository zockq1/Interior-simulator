using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFurnituresComp : MonoBehaviour
{
    bool activeslots = false ;
    bool _uion = false;
    bool _uion2 = false;
    int dummyidx = 0;
    #region (+)camerabutton
    GameObject[] _buttons3;
    RectTransform[] _buttons3rect;
    Image[] _buttons3image;
    #endregion
    #region (+) slotsvar
    GameObject[] _slots;
    RectTransform[] _slotsrectarr;
    Image[] _slotsimagearr;
    [SerializeField]
    Sprite[] _slotsspritearr;
    Vector2 _slotboxsize;
    Vector2 _slotboxposition;

    int _slotsarraylen;
    int _slotscolumnlen;
    int _slotsfinalrowlen;
    int _slotsmaxrownum;

    int temprow; int tempcolumn; float temptime = 0; bool _doubleclickmode = false; bool _doubleclickmodetest = false; Vector2 _mouseclickpos;
    
    #endregion;
    #region (+) furnituresvar
    GameObject furni;
    RaycastHit hit;
    Ray ray;
    [SerializeField]
    GameObject[] _funituremodels;
    bool _mouseclick = false;

    furniture[] _furniarr;
    GameObject[] _furniturethumbs;
    RectTransform[] _furniturethumbsrects;
    Image[] _furniturethumbsimages;
    [SerializeField]
    Sprite[] _furniturethumbssprites;

    GameObject _clickedfurniture;
    RectTransform _clickedfurniturerect;
    Image _clickedfurnitureimage;

    #endregion
    #region (+) explanationvar
    GameObject _explanationbox;
    GameObject _explanationtext;

    #endregion
    #region (+) scroll
    GameObject M_INVEN_SCROLLVIEW; RectTransform M_INVEN_SCROLLVIEW_TRAN;
    GameObject M_INVEN_VIEWPORT; RectTransform M_INVEN_VIEWPORT_TRAN; Image M_INVEN_VIEWPORT_IMAGE; Mask M_INVEN_VIEWPORT_MASK;
    GameObject M_CONTENTS; RectTransform M_CONTENTS_TRAN;
    GameObject M_INVEN_SCROLL; RectTransform M_INVEN_SCROLL_TRAN; Image M_INVEN_SCROLL_IMAGE;
    GameObject M_INVEN_HANDLE; RectTransform M_INVEN_HANDLE_TRAN; Image M_INVEN_HANDLE_IMAGE;
    float M_DELTA_HANPOS; float M_SCROLL_MIN; float M_SCROLL_SIZE; float M_SCROLL_CONTENTS_SIZE;
    bool M_HANDLE_DRAG_ON = false; bool M_HANDLE_STEP1 = false;//스크롤

    bool M_CLICK_ON = false; int M_KEY;
    #endregion

    void Awake()
    {
        _slotsarraylen = 27;
        _slotscolumnlen = 2;
        _slotsmaxrownum = _slotsarraylen / _slotscolumnlen;
        if( ((float)_slotsarraylen / (float)_slotscolumnlen) > 0)
        {
            dummyidx = 1;
        }
        _slotsfinalrowlen = _slotsarraylen % _slotscolumnlen;
        _slotboxsize = new Vector2(150, 150);
        _slotboxposition = new Vector2(50, -50);

        #region CLICKED_FURNITURE
        _doubleclickmode = false;
        _clickedfurniture = new GameObject();
        _clickedfurniturerect = new RectTransform();
        if (_clickedfurniture.GetComponent<RectTransform>() == null)
        {
            _clickedfurniture.AddComponent<RectTransform>();
            _clickedfurniturerect = _clickedfurniture.GetComponent<RectTransform>();
            _clickedfurniture.transform.SetParent(this.transform);
        }
        else
            _clickedfurniturerect = _clickedfurniture.GetComponent<RectTransform>();
        if (_clickedfurniture.GetComponent<Image>() == null)
        {
            _clickedfurniture.AddComponent<Image>();
            _clickedfurnitureimage = _clickedfurniture.GetComponent<Image>();
        }
        else
            _clickedfurnitureimage = _clickedfurniture.GetComponent<Image>();
        _clickedfurniture.SetActive(false);

        #endregion

        #region SCROLLVIEW_INTERF      

        M_INVEN_SCROLLVIEW = new GameObject();
        if (M_INVEN_SCROLLVIEW.GetComponent<RectTransform>() == null)
        {
            M_INVEN_SCROLLVIEW.AddComponent<RectTransform>();
            M_INVEN_SCROLLVIEW_TRAN = M_INVEN_SCROLLVIEW.GetComponent<RectTransform>();
        }
        else
            M_INVEN_SCROLLVIEW_TRAN = M_INVEN_SCROLLVIEW.GetComponent<RectTransform>();
        M_INVEN_SCROLLVIEW.transform.SetParent(this.transform);
        M_INVEN_SCROLLVIEW_TRAN.sizeDelta = new Vector2(_slotboxsize.x * _slotscolumnlen + 20, _slotboxsize.y * 4 + 20);
        M_INVEN_SCROLLVIEW_TRAN.pivot = new Vector2(0, 1);
        M_INVEN_SCROLLVIEW_TRAN.localPosition = _slotboxposition;
        #endregion

        #region VIEWPORT_INTERF       

        M_INVEN_VIEWPORT = new GameObject();
        if (M_INVEN_VIEWPORT.GetComponent<RectTransform>() == null)
        {
            M_INVEN_VIEWPORT.AddComponent<RectTransform>();
            M_INVEN_VIEWPORT_TRAN = M_INVEN_VIEWPORT.GetComponent<RectTransform>();
        }
        else
            M_INVEN_VIEWPORT_TRAN = M_INVEN_VIEWPORT.GetComponent<RectTransform>();
        M_INVEN_VIEWPORT.transform.SetParent(M_INVEN_SCROLLVIEW.transform);
        M_INVEN_VIEWPORT_TRAN.sizeDelta = new Vector2(_slotboxsize.x * _slotscolumnlen, _slotboxsize.y * 4);
        M_INVEN_VIEWPORT_TRAN.pivot = new Vector2(0, 1);
        M_INVEN_VIEWPORT_TRAN.localPosition = new Vector2(0, 0);

        if (M_INVEN_VIEWPORT.GetComponent<Image>() == null)
        {
            M_INVEN_VIEWPORT.AddComponent<Image>();
            M_INVEN_VIEWPORT_IMAGE = M_INVEN_VIEWPORT.GetComponent<Image>();
        }
        else
            M_INVEN_VIEWPORT_IMAGE = M_INVEN_VIEWPORT.GetComponent<Image>();
        M_INVEN_VIEWPORT_IMAGE.sprite = _slotsspritearr[0];

        if (M_INVEN_VIEWPORT.GetComponent<Mask>() == null)
        {
            M_INVEN_VIEWPORT.AddComponent<Mask>();
            M_INVEN_VIEWPORT_MASK = M_INVEN_VIEWPORT.GetComponent<Mask>();
        }
        else
            M_INVEN_VIEWPORT_MASK = M_INVEN_VIEWPORT.GetComponent<Mask>();


        #endregion

        #region CONTENTS_INTERF
        M_CONTENTS = new GameObject();
        if (M_CONTENTS.GetComponent<RectTransform>() == null)
        {
            M_CONTENTS.AddComponent<RectTransform>();
            M_CONTENTS_TRAN = M_CONTENTS.GetComponent<RectTransform>();
        }
        else
            M_CONTENTS_TRAN = M_CONTENTS.GetComponent<RectTransform>();
        M_CONTENTS.transform.SetParent(M_INVEN_VIEWPORT_MASK.transform);
        M_CONTENTS_TRAN.sizeDelta = new Vector2(_slotboxsize.x * _slotscolumnlen, _slotboxsize.y * _slotsmaxrownum + dummyidx);
        M_CONTENTS_TRAN.pivot = new Vector2(0, 1);
        M_CONTENTS_TRAN.localPosition = new Vector2(0, 0);

        _slots = new GameObject[_slotsarraylen];
        _slotsrectarr = new RectTransform[_slotsarraylen];
        _slotsimagearr = new Image[_slotsarraylen];
        for (int i = 0; i < _slotsarraylen; i++)
        {
            _slots[i] = new GameObject();
            if (_slots[i].GetComponent<RectTransform>() == null)
            {
                _slots[i].AddComponent<RectTransform>();
                _slotsrectarr[i] = _slots[i].GetComponent<RectTransform>();
                _slots[i].transform.SetParent(M_CONTENTS.transform);
            }
            else
                _slotsrectarr[i] = _slots[i].GetComponent<RectTransform>();
            _slotsrectarr[i].SetParent(M_CONTENTS.transform);
            if (_slots[i].GetComponent<Image>() == null)
            {
                _slots[i].AddComponent<Image>();
                _slotsimagearr[i] = _slots[i].GetComponent<Image>();
            }
            else
                _slotsimagearr[i] = _slots[i].GetComponent<Image>();
        }

        _furniarr = new furniture[_slotsarraylen];
        _furniarr[0] = new furniture("가구0", 0);
        _furniarr[1] = new furniture("가구1", 1);
        _furniarr[2] = new furniture("가구2", 2);
        _furniarr[3] = new furniture("가구3", 3);
        _furniarr[4] = new furniture("가구4", 4);
        _furniarr[5] = new furniture("가구5", 5);
        _furniarr[6] = new furniture("가구6", 6);
        _furniarr[7] = new furniture("가구7", 7);
        _furniarr[8] = new furniture("가구8", 8);
        _furniarr[9] = new furniture("가구9", 9);
        _furniarr[10] = new furniture("가구10", 10);
        _furniarr[11] = new furniture("가구11", 11);
        _furniarr[12] = new furniture("가구12", 12);
        _furniarr[13] = new furniture("가구13", 13);
        _furniarr[14] = new furniture("가구14", 14);
        _furniarr[15] = new furniture("가구15", 15);
        _furniarr[16] = new furniture("가구16", 16);
        _furniarr[17] = new furniture("가구17", 17);
        _furniarr[18] = new furniture("가구18", 18);
        _furniarr[19] = new furniture("가구19", 19);
        _furniarr[20] = new furniture("가구20", 20);
        _furniarr[21] = new furniture("가구21", 21);
        _furniarr[22] = new furniture("가구22", 22);
        _furniarr[23] = new furniture("가구23", 23);
        _furniarr[24] = new furniture("가구24", 24);
        _furniarr[25] = new furniture("가구25", 25);
        _furniarr[26] = new furniture("가구26", 26);

        _furniturethumbs = new GameObject[_slotsarraylen];
        _furniturethumbsrects = new RectTransform[_slotsarraylen];
        _furniturethumbsimages = new Image[_slotsarraylen];

        for (int i = 0; i < _slotsarraylen; i++)
        {
            _furniturethumbs[i] = new GameObject();
            if (_furniturethumbs[i].GetComponent<RectTransform>() == null)
            {
                _furniturethumbs[i].AddComponent<RectTransform>();
                _furniturethumbsrects[i] = _furniturethumbs[i].GetComponent<RectTransform>();
                _furniturethumbs[i].transform.SetParent(M_CONTENTS.transform);
            }
            else
                _furniturethumbsrects[i] = _furniturethumbs[i].GetComponent<RectTransform>();
            if (_furniturethumbs[i].GetComponent<Image>() == null)
            {
                _furniturethumbs[i].AddComponent<Image>();
                _furniturethumbsimages[i] = _furniturethumbs[i].GetComponent<Image>();
            }
            else
                _furniturethumbsimages[i] = _furniturethumbs[i].GetComponent<Image>();
        }


        for (int i = 0; i < _slotsmaxrownum; i++)
        {
            for (int j = 0; j < _slotscolumnlen; j++)
            {
                _slotsrectarr[_slotscolumnlen * i + j].sizeDelta = _slotboxsize;
                _slotsrectarr[_slotscolumnlen * i + j].pivot = new Vector2(0, 1);
                _slotsrectarr[_slotscolumnlen * i + j].localPosition = new Vector2(j * _slotboxsize.x, -i * _slotboxsize.y);
                _slotsrectarr[_slotscolumnlen * i + j].anchorMin = new Vector2(0.5f, 0.5f);
                _slotsrectarr[_slotscolumnlen * i + j].anchorMax = new Vector2(0.5f, 0.5f);
                _slotsimagearr[_slotscolumnlen * i + j].sprite = _slotsspritearr[0];
                Debug.Log("(" + i + ", " + j + ")" + (_slotscolumnlen * i + j));

                _furniturethumbsrects[_slotscolumnlen * i + j].sizeDelta = _slotboxsize;
                _furniturethumbsrects[_slotscolumnlen * i + j].pivot = new Vector2(0, 1);
                _furniturethumbsrects[_slotscolumnlen * i + j].localPosition = new Vector2(j * _slotboxsize.x, -i * _slotboxsize.y);
                _furniturethumbsrects[_slotscolumnlen * i + j].anchorMin = new Vector2(0.5f, 0.5f);
                _furniturethumbsrects[_slotscolumnlen * i + j].anchorMax = new Vector2(0.5f, 0.5f);
                _furniturethumbsimages[_slotscolumnlen * i + j].sprite = _furniturethumbssprites[_slotscolumnlen * i + j];
            }
        }
        for (int k = 0; k < _slotsfinalrowlen; k++)
        {
            _slotsrectarr[_slotscolumnlen * _slotsmaxrownum + k].sizeDelta = _slotboxsize;
            _slotsrectarr[_slotscolumnlen * _slotsmaxrownum + k].pivot = new Vector2(0, 1);
            _slotsrectarr[_slotscolumnlen * _slotsmaxrownum + k].localPosition = new Vector2
                (k * _slotboxsize.x, -_slotsmaxrownum * _slotboxsize.y);
            _slotsrectarr[_slotscolumnlen * _slotsmaxrownum + k].anchorMin = new Vector2(0.5f, 0.5f);
            _slotsrectarr[_slotscolumnlen * _slotsmaxrownum + k].anchorMax = new Vector2(0.5f, 0.5f);
            _slotsimagearr[_slotscolumnlen * _slotsmaxrownum + k].sprite = _slotsspritearr[0];
            Debug.Log("(" + _slotsmaxrownum + ", " + k + ")" + (_slotscolumnlen * _slotsmaxrownum + k));

            _furniturethumbsrects[_slotscolumnlen * _slotsmaxrownum + k].sizeDelta = _slotboxsize;
            _furniturethumbsrects[_slotscolumnlen * _slotsmaxrownum + k].pivot = new Vector2(0, 1);
            _furniturethumbsrects[_slotscolumnlen * _slotsmaxrownum + k].localPosition = new Vector2(k * _slotboxsize.x, -(_slotsmaxrownum+dummyidx) * _slotboxsize.y);
            _furniturethumbsrects[_slotscolumnlen * _slotsmaxrownum + k].anchorMin = new Vector2(0.5f, 0.5f);
            _furniturethumbsrects[_slotscolumnlen * _slotsmaxrownum + k].anchorMax = new Vector2(0.5f, 0.5f);
            _furniturethumbsimages[_slotscolumnlen * _slotsmaxrownum + k].sprite = _furniturethumbssprites[_slotscolumnlen * _slotsmaxrownum + k];
        }


        #endregion

        #region SCROLL_INTERF
        M_INVEN_SCROLL = new GameObject();
        if (M_INVEN_SCROLL.GetComponent<RectTransform>() == null)
        {
            M_INVEN_SCROLL.AddComponent<RectTransform>();
            M_INVEN_SCROLL_TRAN = M_INVEN_SCROLL.GetComponent<RectTransform>();
        }
        else
            M_INVEN_SCROLL_TRAN = M_INVEN_SCROLL.GetComponent<RectTransform>();
        M_INVEN_SCROLL.transform.SetParent(M_INVEN_SCROLLVIEW.transform);
        M_INVEN_SCROLL_TRAN.sizeDelta = new Vector2(20, _slotboxsize.y * 4);
        M_INVEN_SCROLL_TRAN.pivot = new Vector2(0, 1);
        M_INVEN_SCROLL_TRAN.localPosition = new Vector2(_slotboxsize.x * _slotscolumnlen, 0);

        if (M_INVEN_SCROLL.GetComponent<Image>() == null)
        {
            M_INVEN_SCROLL.AddComponent<Image>();
            M_INVEN_SCROLL_IMAGE = M_INVEN_SCROLL.GetComponent<Image>();
        }
        else
            M_INVEN_SCROLL_IMAGE = M_INVEN_SCROLL.GetComponent<Image>();
        M_INVEN_SCROLL_IMAGE.sprite = _slotsspritearr[1];
        
        M_INVEN_HANDLE = new GameObject();
        if (M_INVEN_HANDLE.GetComponent<RectTransform>() == null)
        {
            M_INVEN_HANDLE.AddComponent<RectTransform>();
            M_INVEN_HANDLE_TRAN = M_INVEN_HANDLE.GetComponent<RectTransform>();
        }
        else
            M_INVEN_HANDLE_TRAN = M_INVEN_HANDLE.GetComponent<RectTransform>();
        M_INVEN_HANDLE.transform.SetParent(M_INVEN_SCROLL.transform);
        M_INVEN_HANDLE_TRAN.pivot = new Vector2(0, 1);
        M_INVEN_HANDLE_TRAN.localPosition = new Vector2(0, 0);
        M_INVEN_HANDLE_TRAN.sizeDelta = new Vector2(20, (_slotboxsize.y * 4) * (4.0f / (float)_slotsmaxrownum));
        Debug.Log("asfag");
        Debug.Log(_slotboxsize.y * 4);


        if (M_INVEN_HANDLE.GetComponent<Image>() == null)
        {
            M_INVEN_HANDLE.AddComponent<Image>();
            M_INVEN_HANDLE_IMAGE = M_INVEN_HANDLE.GetComponent<Image>();
        }
        else
            M_INVEN_HANDLE_IMAGE = M_INVEN_HANDLE.GetComponent<Image>();
        M_INVEN_HANDLE_IMAGE.sprite = _slotsspritearr[0];

        M_SCROLL_MIN = M_INVEN_SCROLL_TRAN.position.y - M_INVEN_SCROLL_TRAN.sizeDelta.y + M_INVEN_HANDLE_TRAN.sizeDelta.y;
        M_SCROLL_SIZE = M_INVEN_SCROLL_TRAN.sizeDelta.y - M_INVEN_HANDLE_TRAN.sizeDelta.y;
        M_SCROLL_CONTENTS_SIZE = M_CONTENTS_TRAN.sizeDelta.y - M_INVEN_VIEWPORT_TRAN.sizeDelta.y;
        #endregion

        
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            if ( ( ((Screen.height - (_slotboxsize.y * 4) + _slotboxposition.y) < Input.mousePosition.y && Input.mousePosition.y < (Screen.height + _slotboxposition.y)) &&
            (_slotboxposition.x < Input.mousePosition.x && Input.mousePosition.x < _slotboxposition.x + _slotboxsize.x * _slotscolumnlen &&
        _slotboxposition.y > (Input.mousePosition.y - Screen.height) && (Input.mousePosition.y - Screen.height) > _slotboxposition.y - _slotboxsize.y * (_slotsmaxrownum + 1)))
        &&
        !(_slotboxposition.x + _slotboxsize.x * _slotsfinalrowlen < Input.mousePosition.x && Input.mousePosition.x < _slotboxposition.x + _slotboxsize.x * (_slotsfinalrowlen + 1) &&
        _slotboxposition.y - _slotboxsize.y * _slotsmaxrownum > (Input.mousePosition.y - Screen.height) && (Input.mousePosition.y - Screen.height) > _slotboxposition.y - _slotboxsize.y * (_slotsmaxrownum + 1)))
        {
            _uion = true;
            Debug.Log(_uion);
            if (Input.GetMouseButtonDown(0))
            {
                if (!_doubleclickmodetest)
                {
                    _doubleclickmodetest = true;
                }
                else if (temptime < 0.5f)
                {
                    Debug.Log("더블클릭 성공");
                    temprow = (int)((Screen.height - Input.mousePosition.y + _slotboxposition.y) / _slotboxsize.y);
                    tempcolumn = (int)((Input.mousePosition.x - _slotboxposition.x) / _slotboxsize.x);
                    _doubleclickmode = true;
                }
                else if (temptime >= 0.5f)
                {
                    Debug.Log("느려");
                    temptime = 0;
                    _doubleclickmodetest = false;
                }
            }
        }
        else
        {
            _uion = false;

            Debug.Log((Screen.height - (_slotboxsize.y * 4) + _slotboxposition.y) +" 사이에 "+ Input.mousePosition.y + " 사이에 " + (Screen.height + _slotboxposition.y));
        }

        if (_doubleclickmode == true)
        {
            doubleclick();
            temptime = 0;
            _doubleclickmodetest = false;
        }
        if (_doubleclickmodetest == true)
        {
            temptime += Time.deltaTime;
        }

        if (_mouseclick)
        {
            if (Input.GetMouseButtonDown(0) && !(_slotboxposition.x < Input.mousePosition.x && Input.mousePosition.x < _slotboxposition.x + _slotboxsize.x * _slotscolumnlen &&
        _slotboxposition.y > (Input.mousePosition.y - Screen.height) && (Input.mousePosition.y - Screen.height) > _slotboxposition.y - _slotboxsize.y * (_slotsmaxrownum + 1) &&
        !(_slotboxposition.x + _slotboxsize.x * _slotsfinalrowlen < Input.mousePosition.x && Input.mousePosition.x < _slotboxposition.x + _slotboxsize.x * (_slotsfinalrowlen + 1) &&
        _slotboxposition.y - _slotboxsize.y * _slotsmaxrownum > (Input.mousePosition.y - Screen.height) && (Input.mousePosition.y - Screen.height) > _slotboxposition.y - _slotboxsize.y * (_slotsmaxrownum + 1))))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.CompareTag("Terrain"))
                {
                    Vector3 pos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    Debug.Log(pos);
                    furni = Instantiate(_funituremodels[_slotscolumnlen * temprow + tempcolumn], pos, Quaternion.identity);
                    Debug.Log("옮김");
                    _clickedfurniture.SetActive(false);
                    _doubleclickmode = false;
                    _mouseclick = false;
                }
            }
        }

        #region SCROLLING
        if(((Screen.height - (_slotboxsize.y * 4) + _slotboxposition.y) < Input.mousePosition.y && Input.mousePosition.y < (Screen.height + _slotboxposition.y)) &&
             M_INVEN_HANDLE_TRAN.position.x < Input.mousePosition.x && Input.mousePosition.x < M_INVEN_HANDLE_TRAN.position.x + M_INVEN_HANDLE_TRAN.sizeDelta.x)
        {
            _uion2 = true;
            Debug.Log(_uion2);
        }
        else
        {
            _uion2 = false;
            Debug.Log(_uion2);
        }

        if (
            (M_INVEN_HANDLE_TRAN.position.x < Input.mousePosition.x &&
           Input.mousePosition.x < M_INVEN_HANDLE_TRAN.position.x + M_INVEN_HANDLE_TRAN.sizeDelta.x &&
           M_INVEN_HANDLE_TRAN.position.y - M_INVEN_HANDLE_TRAN.sizeDelta.y < Input.mousePosition.y &&
           Input.mousePosition.y < M_INVEN_HANDLE_TRAN.position.y && M_HANDLE_DRAG_ON == false))
        {
            if (Input.GetMouseButtonDown(0))
            {
                M_DELTA_HANPOS = M_INVEN_HANDLE_TRAN.position.y - Input.mousePosition.y;
                M_HANDLE_DRAG_ON = true;
            }
        }

        if (Input.GetMouseButton(0) && M_HANDLE_DRAG_ON == true)
        {
            M_HANDLE_STEP1 = true;
        }
        if (Input.GetMouseButtonUp(0) && M_HANDLE_DRAG_ON == true)
        {
            M_HANDLE_STEP1 = false;
            M_HANDLE_DRAG_ON = false;
        }

        #endregion
        
    }

    private void FixedUpdate()
    {
        #region SCROLLING
        if (M_HANDLE_STEP1 == true)
        {
            M_INVEN_HANDLE_TRAN.position = new Vector2(M_INVEN_HANDLE_TRAN.position.x,
                Mathf.Clamp(Input.mousePosition.y + M_DELTA_HANPOS, M_INVEN_SCROLL_TRAN.position.y
                -(M_INVEN_SCROLL_TRAN.sizeDelta.y - M_INVEN_HANDLE_TRAN.sizeDelta.y), M_INVEN_SCROLL_TRAN.position.y));

            Debug.Log((Input.mousePosition.y + M_DELTA_HANPOS) + ", 최대는 " + (M_INVEN_SCROLL_TRAN.position.y - M_INVEN_HANDLE_TRAN.sizeDelta.y) + ", 최소는 " + M_INVEN_SCROLL_TRAN.position.y);

            M_CONTENTS_TRAN.position = new Vector2(M_CONTENTS_TRAN.position.x,
                M_INVEN_VIEWPORT_TRAN.position.y +

                (M_SCROLL_CONTENTS_SIZE *
                ((M_INVEN_SCROLL_TRAN.position.y - M_INVEN_HANDLE_TRAN.position.y) / M_SCROLL_SIZE))
                );
        }
        #endregion
    }

    void doubleclick()
    {
        _clickedfurniture.SetActive(true);
        _clickedfurniturerect.localPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y - Screen.height);
        _clickedfurnitureimage.sprite = _furniturethumbssprites[_slotscolumnlen * temprow + tempcolumn];

        _mouseclick = true;

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("취소");
            _clickedfurniture.SetActive(false);
            _doubleclickmode = false;
        }
    }

    public bool getuion()
    {
        return _uion;
    }
    public bool getuion2()
    {
        return _uion2;
    }
}