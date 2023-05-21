using System;
using System.Collections;
using Unity.Netcode;
using UnityEngine;

public class PlayerShooting : NetworkBehaviour
{
    private bool calcInput = true;
    
    //Facing
    [SerializeField] private SpriteRenderer playerSprite;
    private float movementDirection;

    private bool isFacingRight;
    
    //Shooting
    [SerializeField] private GameObject gunPos;
    [SerializeField] private GameObject bullet;

    private bool canShoot;
    [SerializeField] private float shootCooldown = 0.1f;

    private void Awake()
    {
        canShoot = true;
    }

    private void Start()
    {
        UnityEngine.Camera.main.GetComponent<Camera>().player = gameObject;
    }

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) calcInput = false;
    }

    private void Update()
    {
        if (calcInput)
        {
            //Flip Character
            movementDirection = Input.GetAxis("Horizontal");
        
            if (movementDirection > 0)
            {
                isFacingRight = true;
                Vector3 tempVec = transform.localScale;
                tempVec.x = 1;
                transform.localScale = tempVec;
            }
            else if (movementDirection < 0)
            {
                isFacingRight = false;
                Vector3 tempVec = transform.localScale;
                tempVec.x = -1;
                transform.localScale = tempVec;
            }
        
            //Shooting
            if (Input.GetKey(KeyCode.Space) && canShoot)
            {
                var tempBullet = Instantiate(bullet, gunPos.transform.position, Quaternion.identity);
                tempBullet.AddComponent<Bullet>().facingRight = isFacingRight;
                StartCoroutine(Cooldown());
            }
        }
    }

    IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
}
