using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    private Camera camera;
    private void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 screenmousePosition = Input.mousePosition;
        Vector3 worldMousePosition = camera.ScreenToWorldPoint(screenmousePosition);
        transform.LookAt(worldMousePosition);
    }
}
