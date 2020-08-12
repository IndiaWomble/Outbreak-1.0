using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float camDistance = 24f;
    public float speed= 3.5f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(player.position.x, transform.position.y, player.position.z + camDistance),
            Time.deltaTime * speed);
    }
}