using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;
    
    private float TimeBtwShots;
    public float StartTimeBtwShots;

    [Header("Rotation")]
    [SerializeField] private float RotationSpeed;
    private Vector2 currentDirection = new Vector3(0.0f, 1.0f, 0.0f);
    private Transform transformObject;

    private void Start()
    {
        transformObject = this.transform;
    }


    void Update()
    {
        if (TimeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, shotPoint.position, transform.rotation);
                TimeBtwShots = StartTimeBtwShots;
            }
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }


        //Rotation
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 objectPos = transformObject.position;
        Vector2 direction = mousePos - objectPos;
        direction.Normalize();
        currentDirection = Vector2.Lerp(currentDirection, direction, Time.deltaTime * RotationSpeed);
        transformObject.up = currentDirection;
    }
}
