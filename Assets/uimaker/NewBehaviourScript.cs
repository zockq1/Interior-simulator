using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class furniture
{
    string _name;
    int _funicode;

    public furniture(string p_name, int p_funicode)
    {
        _name = p_name; _funicode = p_funicode;
    }
}
