using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth :objecthealth
{
    
    private void OnCollisionStay2D(Collision2D collision)
    { 
        HandleCollision(collision.gameObject);

    }
    public override void HandleCollision(GameObject otherObject)
    {
        if (otherObject.CompareTag("Enemy"))
        {
            enemy dps= otherObject.gameObject.GetComponent<enemy>();
            int amount = dps.Damage;

            SubtractHealth(amount);
        }
        
            

            base.HandleCollision(otherObject);
    }
    public override void OnDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        base.OnDeath(); 
    }
}
