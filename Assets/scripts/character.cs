using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public enum CharacterState
{
    idle,
    Attack
}

public class character : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterState State;
    public Sprite IdleSprite;
    public Sprite AttackSprite;
    public float movementSpeed = 5;
    protected Rigidbody2D body;
    
    SpriteRenderer spriteRenderer;
    protected virtual void Start()
    {
      body= GetComponent<Rigidbody2D>();
        spriteRenderer= GetComponent<SpriteRenderer>();
        SetState(State);
    }
    public void SetState(CharacterState newState)
    {
        State = newState;

        if (State == CharacterState.idle)
        {
            spriteRenderer.sprite = IdleSprite;
        }
        else
        {
            spriteRenderer.sprite = AttackSprite;
        }
    }

   
    
}
