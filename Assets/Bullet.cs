using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 75f;
    public bool facingRight;

    void Update()
    {
        if (facingRight) transform.position += Vector3.right * bulletSpeed * Time.deltaTime;
        if (!facingRight) transform.position += Vector3.left * bulletSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("COL: " + col.collider.gameObject.name);
        Destroy(gameObject);
    }
}
