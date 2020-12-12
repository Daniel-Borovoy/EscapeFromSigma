using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    float RandX;
    Vector2 whereToSpawn;
    [SerializeField]
    private float spawnRate = 1f;
    float nextSpawn = 0.0f;
    void Start()
    {
        
    }
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            RandX = Random.Range(-13.91f, 12.55f);
            whereToSpawn = new Vector2(RandX, transform.position.y);
            Instantiate(obj, whereToSpawn, Quaternion.identity);
        }

    }
}
