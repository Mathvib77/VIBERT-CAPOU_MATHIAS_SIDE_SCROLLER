using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform target;
    public float smoothTime = 0.2f;
    public Vector3 offset = new Vector3(0f,0f,0f);

    Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null) return;

        Vector3 targetPosition = target.position + offset;
        
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,ref velocity, smoothTime);
    }
}
