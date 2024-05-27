using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WapenRichten : MonoBehaviour
{
    public Camera mainCamera;
    public Transform rotatingObject;

    public void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        if (rotatingObject == null)
        {
            Debug.LogError("Rotating object is not assigned.");
        }
    }

    public void Update()
    {
        AimToCursor();
    }

    public void AimToCursor()
    {
        if (rotatingObject != null)
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            Vector3 direction = mousePosition - rotatingObject.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            rotatingObject.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
