using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryingSplit : MonoBehaviour
{
    private Transform transformObject;
    private Vector2 mousePos;
    private Vector2 objectPos;
    Vector2 direction;
    private float Angle;
    private float sign;
    private void Start()
    {
        transformObject = this.transform;
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        objectPos = transformObject.position;
        direction = mousePos - objectPos;

        sign = (direction.y >= objectPos.y) ? 1 : -1;
        Angle = Vector2.Angle(Vector2.right, direction) * sign;
    }
    
}
