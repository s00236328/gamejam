using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : character
{
    public int Damage = 10;
    public float MinMovementSpeed = 1;
    public float MaxMovementSpeed = 3;

    public float AttackRange = 3;
    GameObject player;


    protected override void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movementSpeed= Random.Range(MinMovementSpeed, MaxMovementSpeed);
        base.Start();
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < AttackRange)
        {
            SetState(CharacterState.Attack);

            transform.up = player.transform.position - transform.position;
        }
        else
        {
            SetState(CharacterState.idle);
        }
    }
    private void FixedUpdate()
    {
        if (State == CharacterState.Attack)
        {
            body.MovePosition(transform.position+transform.up.normalized*movementSpeed*Time.deltaTime);
        }
    }
}
