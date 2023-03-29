using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : character
{
    float hor, ver;
    
    Vector3 mousePosition;
    Vector3 direction;
    //changed from type bullet to game object bulletprefab
    public Bullet BulletPrefab;
    public Transform BulletSpawn;

    public int Ammo = 20;
    public int MaxAmmo = 20;
    public float RegenrateAmmoTime = 2;
    public int AmmoRegenAmount=1;

    protected override void Start()
    {


        
        InvokeRepeating("RegenerateAmmo", RegenrateAmmoTime, RegenrateAmmoTime);
        base.Start();
           
        
    }
    private void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");
        direction.x = hor * movementSpeed;
        direction.y = ver * movementSpeed;
        body.velocity = direction;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        transform.up = (mousePosition - transform.position);

        if (Input.GetButton("Fire2"))
        {
            SetState(CharacterState.Attack);
            if (Input.GetButtonDown("Fire1"))
            {
                if (Ammo > 0)
                {
                    Fire();
                }
            }
        }
        else
        {
            SetState(CharacterState.idle);
        }
    }
    private void FixedUpdate()
    {
            body.MovePosition(transform.position + new Vector3(hor, ver, 0)* movementSpeed*Time.deltaTime);
    }
    void Fire()
    {
        Bullet inst = Instantiate(BulletPrefab, BulletSpawn.transform.position, Quaternion.identity);
        inst.SetDirection(transform.up);
        Ammo--;
        
    }
     void RegenerateAmmo()
    {
        if (Ammo < MaxAmmo)
        {
            Ammo += AmmoRegenAmount;
        }
        if (Ammo > MaxAmmo) 
        { 
            Ammo = MaxAmmo; 
        }
    }


}
