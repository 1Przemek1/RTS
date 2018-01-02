using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    public string name;
    public string description;
    public Sprite image;

    public UnitInfo getUnitInfo()
    {
        return new UnitInfo(name, description, image);
    }

    public void playSound()
    {
        GetComponent<AudioSource>().Play();
    }

    public void setDestination(Vector3 destination)
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = destination;
    }
}
