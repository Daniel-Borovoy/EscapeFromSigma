using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    HealthBar Healthbar;
    private void Start()
    {
        Healthbar = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBar>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Healthbar.currentHP < Healthbar.MaxHP-15)
            {
                Healthbar.Heal(15f);
            }
            else
            {
                Healthbar.Heal(Healthbar.MaxHP-Healthbar.currentHP);
            }
            Destroy(gameObject);
        }
    }
}
