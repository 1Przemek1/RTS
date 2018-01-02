using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInfo : MonoBehaviour {

    public string name;
    public string descritption;
    public Sprite sprite;


    public UnitInfo(string _name, string _desc, Sprite _image)
    {
        name = _name;
        descritption = _desc;
        sprite = _image;
    }
}
