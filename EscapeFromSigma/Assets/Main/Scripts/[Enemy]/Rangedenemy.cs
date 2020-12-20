using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rangedenemy : MonoBehaviour
{
    public float speed = 5f;
    bool attack = false;
    public float stoppingDistance;
    Transform player;
    public float shootingDistance;
    public float intimDistance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            attack = true;
        }
        if (Vector2.Distance(transform.position, player.position) < shootingDistance)
        {
            Stay();
        }
        else if (attack == true)
        {
            Attack();
        }

    }
    private void Attack()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
    private void Stay()
    {
        if (Vector2.Distance(transform.position, player.position) < intimDistance)
        {
            GoAway();
        }
    }
    private void GoAway()
    {

    }
}
