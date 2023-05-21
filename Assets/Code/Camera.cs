using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float speed = 5f;

    private Vector2 targetPoint;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (player != null)
        {
            targetPoint = Vector2.Lerp(player.transform.position, new Vector2(0f, 5f), 0.7f);

            Vector3 newPos = Vector3.Lerp(transform.position, targetPoint, Time.deltaTime * speed); //SMOOTH FOLLOW
            newPos.z = -10;
            transform.position = newPos; 
        }
    }
}
