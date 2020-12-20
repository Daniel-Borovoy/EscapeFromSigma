using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public float speed;
    bool gotoPlayer = false;
    public float aggrZone;
    private float distance = 1.2f;
    Transform player;
    float Dist;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        Dist = Vector2.Distance(transform.position, player.position);
        if (Dist <= aggrZone && Dist >= distance)
        {
            gotoPlayer = true;
        }
        else
        {
            gotoPlayer = false;
        }
        if (gotoPlayer == true)
        {
            GoToPlayer();
        }
    }
    private void GoToPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) <= aggrZone)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }      
    }
}
