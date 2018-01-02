using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

    public float movementSpeed = 0.1f;
    public float smoothness = 0.85f;

    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private AnimationController animationController;

	// Use this for initialization
	void Start () {
        targetPosition = transform.position;
        targetRotation = transform.rotation;
        animationController = gameObject.GetComponent<AnimationController>();
	}
	
	// Update is called once per frame
	void Update () {

        if (animationController.CanMove()) 
        {
            if (Input.GetKey(KeyCode.W))
            {
                targetPosition += transform.forward * movementSpeed;
                StartCoroutine(Move());
            }
            else if (Input.GetKey(KeyCode.S))
            {
                targetPosition -= transform.forward * movementSpeed;
                StartCoroutine(Move());
            }

            if (Input.GetKey(KeyCode.D))
            {
                targetRotation *= Quaternion.AngleAxis(1, Vector3.up);
                StartCoroutine(Rotate());
            }
            else if (Input.GetKey(KeyCode.A))
            {
                targetRotation *= Quaternion.AngleAxis(-1, Vector3.up);
                StartCoroutine(Rotate());
            } 
        }
	}

    IEnumerator Move()
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);

            yield return null;
        }
        StopCoroutine(Move());
    }

    IEnumerator Rotate()
    {
        while (Quaternion.Angle(transform.rotation, targetRotation) >= 5)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * Time.deltaTime); 
            yield return null;
        }
        StopCoroutine(Rotate());
    }
}
