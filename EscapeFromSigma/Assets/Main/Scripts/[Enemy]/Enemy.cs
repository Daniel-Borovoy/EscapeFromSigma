using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    private AddRoom room;

    private void Start()
    {
        room = GetComponentInParent<AddRoom>();
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            room.enemies.Remove(gameObject);
        }

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
