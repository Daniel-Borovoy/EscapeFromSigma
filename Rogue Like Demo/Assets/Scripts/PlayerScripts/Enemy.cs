using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float regenRate;
    public float regenDelay;
    private float timeToRegen = 5;


    IEnumerator ExecuteAfterTime(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        Debug.Log("regenerating...");
    }

    private void Start()
    {
        if (health == 2)
        {
            Debug.Log(health);
        }
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(ExecuteAfterTime(timeToRegen));
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
