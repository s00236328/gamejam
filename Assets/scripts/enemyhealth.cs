using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : objecthealth
{
    public GameObject EnemyRemains;
    public GameObject EnemyExplosion;

    public override void HandleCollision(GameObject otherObject)
    {
        if (otherObject.gameObject.CompareTag("Bullet"))
        {
            Bullet bulletdamage= otherObject.GetComponent<Bullet>();
            int amount = bulletdamage.Damage;
            SubtractHealth(amount);
        }
            base.HandleCollision(otherObject);
    }
    public override void OnDeath()
    {
        Instantiate(EnemyRemains, transform.position, Quaternion.identity);
        Instantiate(EnemyExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        base.OnDeath();
    }
}

