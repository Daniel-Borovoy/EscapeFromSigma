using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Instantiate(enemy, new Vector3(gameObject.transform.position.x + 10, gameObject.transform.position.y, gameObject.transform.position.z), transform.rotation);
        }
    }
}
