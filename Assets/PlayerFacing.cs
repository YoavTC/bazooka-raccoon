using System;
using UnityEngine;

public class PlayerFacing : MonoBehaviour
{
    public static PlayerFacing Instance;
    public bool isFacingRight;

    [SerializeField] private SpriteRenderer playerSprite;
    private float movementDirection;

    private void Awake()
    {
        isFacingRight = true;
    }

    void Update()
    {
        movementDirection = Input.GetAxis("Horizontal");
        
        if (movementDirection > 0)
        {
            isFacingRight = true;
            playerSprite.flipX = false;
        }
        else if (movementDirection < 0)
        {
            isFacingRight = false;
            playerSprite.flipX = true;
        }
    }
}
