using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private float startY;

    void Start()
    {
        startY = transform.position.y; 
    }

    void LateUpdate()
    {
        transform.position = new Vector3
        (
            player.position.x,        
            startY,                   
            transform.position.z
        );
    }
}
