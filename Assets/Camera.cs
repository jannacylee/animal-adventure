using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;          
    public float followSpeed = 5f;  
    private Vector3 offset;            
    public float leftBoundary;  
    public float rightBoundary;

    void Start() {
        offset = transform.position - player.position;
    }

    void Update() {
        
        float xPos = player.position.x + offset.x;
        xPos = Mathf.Clamp(xPos, leftBoundary, rightBoundary);

        Vector3 targetPosition = new Vector3(xPos, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime); // move camera to targest pos @ followSpeed
    }
}
