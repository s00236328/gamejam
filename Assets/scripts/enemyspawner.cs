using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : objecthealth
{
    public GameObject EnemyPrefab;
    public GameObject SpawnerExplosion;
    public float SpawnTime = 5;
    public float SpawnArea = 2;
    public int amount;
    public int MaxEnemyToSpawn = 10;
    int numberOfEnemySpawned;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 2, 5);
    }
    void SpawnZombie()
    {
        Vector3 randomPosition = Random.insideUnitCircle * SpawnArea;

        Instantiate(EnemyPrefab, transform.position + randomPosition, Quaternion.identity);
        numberOfEnemySpawned++;

        if (numberOfEnemySpawned >= MaxEnemyToSpawn)
        {
            CancelInvoke("SpawnEnemy");
        }
    }
    public override void HandleCollision(GameObject otherObject)
    {
        if (otherObject.CompareTag("Bullet"))
        {
            Bullet bullet = otherObject.GetComponent<Bullet>();
            amount = bullet.Damage;
            SubtractHealth(bullet.Damage);
        }
        base.HandleCollision(otherObject);
    }
    public override void OnDeath()
    {
        Instantiate(SpawnerExplosion);
        Destroy(gameObject);
        base.OnDeath();
    }
}
