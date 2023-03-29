using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class objecthealth : MonoBehaviour
{
   
    public int Health = 100;
    public int MaxHealth = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollision(collision.gameObject);
    }
    public void AddHealth(int amount)
    {
        
        Health = Health + amount;
        if (Health < MaxHealth)
        {
            Health = MaxHealth;
        }
    }
    public void SubtractHealth(int amount)
    {
        
        Health= Health - amount;
        if (Health <= 0) 
        {
            OnDeath();
        }
    }
    public virtual void OnDeath () 
    {
       
    }
    public virtual void HandleCollision(GameObject otherObject) { }
}
