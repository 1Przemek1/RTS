using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, ICreateUnit {

    public string name;
    public string description;
    public string actionButton;
    public Sprite image;
    public GameObject objectToCreate;

	public BuildingInfo getBuildingInfo() 
    {
        return new BuildingInfo(name, description, actionButton, image);
    }

    public void playSound()
    {
        GetComponent<AudioSource>().Play();
    }

    public void Create()
    {
        Transform createSpot = transform.GetChild(0).transform;
        Instantiate(objectToCreate, createSpot.position, createSpot.rotation);
    }
}
