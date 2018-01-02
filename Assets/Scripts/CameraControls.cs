using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour
{
    public float movementSpeed = 0.1f;
    public float rotationSpeed = 4f;
    public float smoothness = 0.85f;

    public GameObject horizontalRotation;
    
    Quaternion targetRotation;
    Quaternion horizontalTargetRotation;

    float targetRotationY;
    float targetRotationX;

    void Start()
    {
        //targetPosition = transform.position;
        targetRotation = transform.rotation;
        targetRotationY = transform.localRotation.eulerAngles.y;
        targetRotationX = transform.localRotation.eulerAngles.x;
    }

    void Update()
    {
        /*if( Input.GetKey( KeyCode.W ) )
            targetPosition += transform.forward * movementSpeed;
        if( Input.GetKey( KeyCode.A ) )
            targetPosition -= transform.right * movementSpeed;
        if( Input.GetKey( KeyCode.S ) )
            targetPosition -= transform.forward * movementSpeed;
        if( Input.GetKey( KeyCode.D ) )
            targetPosition += transform.right * movementSpeed;
        if( Input.GetKey( KeyCode.Q ) )
            targetPosition -= transform.up * movementSpeed;
        if( Input.GetKey( KeyCode.E ) )
            targetPosition += transform.up * movementSpeed;*/

        if( Input.GetMouseButton( 2 ) )
        {
            Cursor.visible = false;
            targetRotationY += Input.GetAxis( "Mouse X" ) * rotationSpeed;
            targetRotationX -= Input.GetAxis( "Mouse Y" ) * rotationSpeed;

            fixRotationX();

            targetRotation = Quaternion.Euler( targetRotationX, targetRotationY, 0.0f );
            horizontalTargetRotation = Quaternion.Euler(0.0f, targetRotationY, 0.0f);
        }
        else
            Cursor.visible = true;


        //transform.position = Vector3.Lerp( transform.position, targetPosition, ( 1.0f - smoothness ) );
        transform.rotation = Quaternion.Lerp( transform.rotation, targetRotation, ( 1.0f - smoothness ) );

        horizontalRotation.transform.rotation = Quaternion.Lerp(horizontalRotation.transform.rotation, horizontalTargetRotation, (1.0f - smoothness));
    }

    private void fixRotationX()
    {
        if (targetRotationX >= 60) 
            targetRotationX = 60;
        else if(targetRotationX <= -5)
            targetRotationX = -5;
    }
}
