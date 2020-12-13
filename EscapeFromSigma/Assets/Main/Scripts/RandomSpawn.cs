using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RandomSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    float RandX;
    Vector2 whereToSpawn;
    [SerializeField]
    private int i;
    System.Random random = new System.Random();
    void Start()
    {
        int value = random.Next(1, 5); // Диапазон кол-ва врагов в комнате 
        for (i = 0; i < value; i++)
        {
            RandX = Random.Range(-13.91f, 12.55f);
            whereToSpawn = new Vector2(RandX, transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
    }
}
