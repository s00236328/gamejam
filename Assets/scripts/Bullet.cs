using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float movementSpeed = 10;
    public int Damage = 25;
    

    // Start is called before the first frame update
    private void Start()
    {
        //calls clean up after 2 secs 
        Invoke("CleanUp", 2);
        
    }
    public void SetDirection(Vector3 direction)
    {

               transform.up = direction.normalized;
        GetComponent<Rigidbody2D>().velocity = transform.up * movementSpeed;

    }

    // Update is called once per frame
    void CleanUp()
    {
     Destroy(gameObject);   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Roof"))
            Destroy(gameObject);
    }
}
