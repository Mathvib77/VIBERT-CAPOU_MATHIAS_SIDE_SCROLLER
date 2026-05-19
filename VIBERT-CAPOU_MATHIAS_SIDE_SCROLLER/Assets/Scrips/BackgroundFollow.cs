using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    private Transform cam;
    private float fixedY; 
    private float fixedZ;

    void Start()
    {
        cam = Camera.main.transform;
        fixedY = transform.position.y;
        fixedZ = transform.position.z;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(
            cam.position.x,  
            fixedY,         
            fixedZ
        );
    }
}