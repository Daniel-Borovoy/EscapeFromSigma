using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variables
    public int health;
    private AddRoom room;
    public float MovingSpeed;
    public bool isRangedEnemy;
    public float AggressiveZone;
    public float MeleeStoppingDistance; //Minimal distance between player and melee enemy
    public float RangedStoppingDistance; //Minimal distance between player and ranged enemy
    private float DBPaE; //Distance Between Player and Enemy
    Transform player;


    //Awake, Start
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        room = GetComponentInParent<AddRoom>();
    }
    
    
    //Updates
    private void Update()
    {
        //Something about enemy health
        if (health <= 0)
        {
            Destroy(gameObject);
            room.enemies.Remove(gameObject);
        }

        //Moving
        DBPaE = Vector2.Distance(transform.position, player.position);

        if (DBPaE <= AggressiveZone)
        {
            if (isRangedEnemy)
            {
                GoToPlayer(RangedStoppingDistance);
            }
            else
            {
                GoToPlayer(MeleeStoppingDistance);
            }
        }
    }

    //Other methods
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void GoToPlayer(float StoppingDistance)
    {
        if (DBPaE >= StoppingDistance) 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, MovingSpeed * Time.deltaTime);
        }
    }

    public void Attack()
    {

    }
}
