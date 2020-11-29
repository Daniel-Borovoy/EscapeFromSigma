using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{   
    // изменил направление гравитации с помощью скрипта
    void FixedUpdate()
    {
        Physics2D.gravity = new Vector3(0, 0, -9.8f);
    }
}
