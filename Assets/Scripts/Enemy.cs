//using System.Collections;
//using System.Collections.Generic;
using UnityEngine.UI;

using System;
using UnityEditor.Experimental.UIElements;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    
    
    public float health;
    public float startHealth = 100;

    public int worth = 50;

    public float minimumDistanceCollision = 0.4f;

    public GameObject deathEffect;

    [Header("Unity stuff")] public Image healthBar;

    private void Start()
    {
        health = startHealth;
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health/startHealth;
        
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject, 5f);

        Destroy(gameObject);
    }

    public void Slow(float slowAmount)
    {
        speed = startSpeed * (1f - slowAmount);
    }
}
