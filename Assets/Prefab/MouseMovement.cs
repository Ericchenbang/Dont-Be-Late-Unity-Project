using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] float sensitivity;
    [SerializeField] GameObject student;

    float xRotation=0f;
    float yRotation=0f;

    private void Update()
    {
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;
        yRotation += Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);             // to stop the player from looking above/below 90
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        if (yRotation > 0f || yRotation < 0f)
        {
            transform.SetParent(null);
            student.transform.localEulerAngles = new Vector3(0, yRotation*3, 0);
            //viking.transform.Rotate(new Vector3(0, yRotation/50, 0));
        }
        transform.SetParent(student.transform);
        //viking.transform.localEulerAngles = new Vector3(0, yRotation, 0);
        transform.localEulerAngles = new Vector3(xRotation, yRotation, 0);

    }
}
