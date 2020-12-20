using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meleeenemy : MonoBehaviour
{
    public float speed;
    bool attack = false;
    public float stoppingDistance;
    Transform player;

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
        else
        {
            Debug.Log("");
        }
        if (attack==true)
        {
            Attack();
        }
    }
    private void Attack()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
