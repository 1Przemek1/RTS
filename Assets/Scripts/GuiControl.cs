using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiControl : MonoBehaviour {

    public GameObject uiControl;

    private UiHandler uiHandler;
    private Unit selectedUnit;

    private const int LEFT_MOUSE_BUTTON = 0;
    private const int RIGHT_MOUSE_BUTTON = 1;

	void Start () {
        if (!uiHandler)
        {
            uiHandler = uiControl.GetComponent<UiHandler>();
        }
	}
	
	void Update () {

        if (Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON))
        {
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                
                if (hit.transform.gameObject.tag == ObjectsEnums.BUILDING.ToString())
                {
                    handleBuildingClick(hit);
                }
                else if (hit.transform.gameObject.tag == ObjectsEnums.UNIT.ToString())
                {
                    handleUnitClick(hit);
                }
                else if (hit.transform.gameObject.tag == ObjectsEnums.GROUND.ToString())
                {
                    handleGoundClick(hit);
                }

            }
        }

        else if (Input.GetMouseButtonDown(RIGHT_MOUSE_BUTTON))
        {
            uiHandler.unselectObject();
        }
	}

    private void handleBuildingClick(RaycastHit hit)
    {
        Building building = hit.transform.gameObject.GetComponent<Building>();
        building.playSound();
        uiHandler.displaySelectedBuilding(building.getBuildingInfo());
        uiHandler.setObjectToCreate(building);
    }

    private void handleUnitClick(RaycastHit hit)
    {
        Unit unit = hit.transform.gameObject.GetComponent<Unit>();
        selectedUnit = unit;
        unit.playSound();
        uiHandler.displaySelectedUnit(unit.getUnitInfo());
    }

    private void handleGoundClick(RaycastHit hit)
    {
        if (selectedUnit)
        {
            selectedUnit.setDestination(hit.point);
        }
    }
}
