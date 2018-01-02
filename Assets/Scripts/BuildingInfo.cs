using UnityEngine;

public class BuildingInfo  {

    public string name;
    public string descritption;
    public string actionButton;
    public Sprite sprite;

    public BuildingInfo(string _name, string _desc, string _actionButton, Sprite _image)
    {
        name = _name;
        descritption = _desc;
        actionButton = _actionButton;
        sprite = _image;
    }

}
