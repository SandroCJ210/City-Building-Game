using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 mouseOriginPoint;
    private Vector3 offset;
    private bool dragging;
    void Update()
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize -=
            Input.GetAxis("Mouse ScrollWheel") * Camera.main.orthographicSize, 2.5f, 30f);
        if (Input.GetMouseButton(2))
        {
            offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            if (!dragging)
            {
                dragging = true;
                mouseOriginPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            dragging = false;
        }
        if (dragging)
        {
            transform.position = mouseOriginPoint - offset;
        }
    }
}
