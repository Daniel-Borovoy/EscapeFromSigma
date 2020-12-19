using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;
    public float StartTimeBtwShots;
    private float TimeBtwShots;

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
            TimeBtwShots -= Time.deltaTime;
    }
}
