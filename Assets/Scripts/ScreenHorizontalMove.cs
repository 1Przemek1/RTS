using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenHorizontalMove : MonoBehaviour {

    public const int SCREEN_BOUNDARY = 1;
    public const int SCROOLING_SPEED = 10;
    public float smoothness = 0.85f;

    public GameObject horizontalRotation;

    private int screenHeight;
    private int screenWidth;

    Vector3 targetPosition;

	void Start () {
        targetPosition = transform.position;
        screenHeight = Screen.height - SCREEN_BOUNDARY;
        screenWidth = Screen.width - SCREEN_BOUNDARY;
	}

	void Update () {

        if (Input.mousePosition.x > screenWidth)
        {
            targetPosition += transform.right * Time.deltaTime * SCROOLING_SPEED;
        }
        else if (Input.mousePosition.x < SCREEN_BOUNDARY)
        {
            targetPosition -= transform.right * Time.deltaTime * SCROOLING_SPEED; 
        }

        else if (Input.mousePosition.y > screenHeight)
        {
            targetPosition += horizontalRotation.transform.forward * Time.deltaTime * SCROOLING_SPEED;
        }

        else if (Input.mousePosition.y < SCREEN_BOUNDARY)
        {
            targetPosition -= horizontalRotation.transform.forward * Time.deltaTime * SCROOLING_SPEED;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, (1.0f - smoothness));
	}
}
