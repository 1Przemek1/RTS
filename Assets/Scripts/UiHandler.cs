using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UiHandler : MonoBehaviour {

    public GameObject actionButton;
    public GameObject description;
    public GameObject image;

    private Image img;
    private Sprite basicImg;
    private ICreateUnit creator;

    void Start()
    {
        if (!img)
        {
            img = image.GetComponent<Image>();
        }

        basicImg = new Sprite();
        basicImg = img.sprite;
    }

    public void displaySelectedBuilding(BuildingInfo info)
    {
        img.sprite = info.sprite;
        description.GetComponentInChildren<Text>().text = info.descritption;
        actionButton.GetComponentInChildren<Text>().text = info.actionButton;
    }

    public void displaySelectedUnit(UnitInfo info)
    {
        img.sprite = info.sprite;
        description.GetComponentInChildren<Text>().text = info.descritption;
    }

    public void unselectObject()
    {
        img.sprite = basicImg;
        description.GetComponentInChildren<Text>().text = "";
        actionButton.GetComponentInChildren<Text>().text = "";
        creator = null;
    }

    public void setObjectToCreate(ICreateUnit obj)
    {
        creator = obj;
    }

    public void create()
    {
        if (creator != null) 
        {
            creator.Create();
        }
        else 
        {
            Debug.Log("Nothink to create");
        }
    }
}
